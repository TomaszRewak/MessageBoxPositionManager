using System;
using System.Runtime.InteropServices;
using System.Text;
using static MessageBoxPositionManager.MessageBoxInterop;

namespace MessageBoxPositionManager
{
	public static class MessageBoxCenteringService
	{
		[ThreadStatic] private static IntPtr _hook;
		[ThreadStatic] private static HookProc _hookProc;

		public static void Initialize()
		{
			if (_hook != IntPtr.Zero) return;

			_hookProc = HandleMessage;
			_hook = SetWindowsHookEx(HookType.WH_CALLWNDPROCRET, _hookProc, IntPtr.Zero, GetCurrentThreadId());
		}

		private static IntPtr HandleMessage(int code, IntPtr wParam, IntPtr lParam)
		{
			if (code >= 0)
				ProcessMessage(lParam);

			return CallNextHookEx(_hook, code, wParam, lParam);
		}

		private static void ProcessMessage(IntPtr param)
		{
			var message = Marshal.PtrToStructure<Msg>(param);
			if (message.Message != 0x0018) return;

			var box = message.Hwnd;
			var parent = GetParent(box);
			if (parent == IntPtr.Zero) return;

			var className = new StringBuilder(7);
			GetClassName(box, className, className.Capacity);
			if (!className.Equals("#32770")) return;

			if (!GetWindowRect(box, out var boxRect)) return;
			if (!GetWindowRect(parent, out var parentRect)) return;

			var width = boxRect.Right - boxRect.Left;
			var height = boxRect.Bottom - boxRect.Top;
			var left = (parentRect.Left + parentRect.Right) / 2 - width / 2;
			var top = (parentRect.Top + parentRect.Bottom) / 2 - height / 2;

			var screen = MonitorFromWindow(parent, MonitorDefaultTo.Nearest);
			var monitorInfo = MonitorInfo.Empty;
			if (GetMonitorInfo(screen, ref monitorInfo))
			{
				left = Math.Max(monitorInfo.WorkArea.Left, Math.Min(monitorInfo.WorkArea.Right - width, left));
				top = Math.Max(monitorInfo.WorkArea.Top, Math.Min(monitorInfo.WorkArea.Bottom - height, top));
			}

			const SetWindowPosFlags commonFlags =
				SetWindowPosFlags.SynchronousWindowPosition |
				SetWindowPosFlags.IgnoreResize |
				SetWindowPosFlags.DoNotActivate |
				SetWindowPosFlags.DoNotChangeOwnerZOrder |
				SetWindowPosFlags.IgnoreZOrder;

			SetWindowPos(box, IntPtr.Zero, left, top, width, height, commonFlags);
		}
	}
}
