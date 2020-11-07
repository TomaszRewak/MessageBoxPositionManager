using System;
using System.Runtime.InteropServices;
using System.Text;

namespace MessageBoxPositionManager
{
	internal class MessageBoxInterop
	{
		[DllImport("kernel32.dll")]
		public static extern uint GetCurrentThreadId();

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SetWindowsHookEx(HookType hookType, HookProc lpfn, IntPtr hMod, uint dwThreadId);

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SetWindowPosFlags uFlags);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool UnhookWindowsHookEx(IntPtr hhk);

		[DllImport("user32.dll")]
		public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
		public static extern IntPtr GetParent(IntPtr hWnd);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

		public delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);

		public enum HookType : int
		{
			WH_JOURNALRECORD = 0,
			WH_JOURNALPLAYBACK = 1,
			WH_KEYBOARD = 2,
			WH_GETMESSAGE = 3,
			WH_CALLWNDPROC = 4,
			WH_CBT = 5,
			WH_SYSMSGFILTER = 6,
			WH_MOUSE = 7,
			WH_HARDWARE = 8,
			WH_DEBUG = 9,
			WH_SHELL = 10,
			WH_FOREGROUNDIDLE = 11,
			WH_CALLWNDPROCRET = 12,
			WH_KEYBOARD_LL = 13,
			WH_MOUSE_LL = 14
		}

		public enum SetWindowPosFlags : uint
		{
			SynchronousWindowPosition = 0x4000,
			DeferErase = 0x2000,
			DrawFrame = 0x0020,
			FrameChanged = 0x0020,
			HideWindow = 0x0080,
			DoNotActivate = 0x0010,
			DoNotCopyBits = 0x0100,
			IgnoreMove = 0x0002,
			DoNotChangeOwnerZOrder = 0x0200,
			DoNotRedraw = 0x0008,
			DoNotReposition = 0x0200,
			DoNotSendChangingEvent = 0x0400,
			IgnoreResize = 0x0001,
			IgnoreZOrder = 0x0004,
			ShowWindow = 0x0040,
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		};

		[StructLayout(LayoutKind.Sequential)]
		public struct Msg
		{
			public readonly IntPtr LResult;
			public readonly IntPtr LParam;
			public readonly IntPtr WParam;
			public readonly uint Message;
			public readonly IntPtr Hwnd;
		}
	}
}
