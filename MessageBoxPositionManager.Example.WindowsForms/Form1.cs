using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageBoxPositionManager.Example.WindowsForms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void _messageBoxButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show(this, "Some content", "Title", MessageBoxButtons.OK);
		}

		private void _windowButton_Click(object sender, EventArgs e)
		{
			var newForm = new Form1();
			newForm.Show();
		}
	}
}
