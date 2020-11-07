
namespace MessageBoxPositionManager.Example.WindowsForms
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._messageBoxButton = new System.Windows.Forms.Button();
			this._windowButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _messageBoxButton
			// 
			this._messageBoxButton.Location = new System.Drawing.Point(12, 149);
			this._messageBoxButton.Name = "_messageBoxButton";
			this._messageBoxButton.Size = new System.Drawing.Size(161, 29);
			this._messageBoxButton.TabIndex = 0;
			this._messageBoxButton.Text = "New message box";
			this._messageBoxButton.UseVisualStyleBackColor = true;
			this._messageBoxButton.Click += new System.EventHandler(this._messageBoxButton_Click);
			// 
			// _windowButton
			// 
			this._windowButton.Location = new System.Drawing.Point(627, 149);
			this._windowButton.Name = "_windowButton";
			this._windowButton.Size = new System.Drawing.Size(161, 29);
			this._windowButton.TabIndex = 1;
			this._windowButton.Text = "New window";
			this._windowButton.UseVisualStyleBackColor = true;
			this._windowButton.Click += new System.EventHandler(this._windowButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 328);
			this.Controls.Add(this._windowButton);
			this.Controls.Add(this._messageBoxButton);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button _messageBoxButton;
		private System.Windows.Forms.Button _windowButton;
	}
}

