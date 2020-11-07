using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MessageBoxPositionManager.Example.WindowsPresentationFoundation
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void NewMessageBoxButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(this, "Some content", "Title", MessageBoxButton.OK);
		}

		private void NewWindowButton_Click(object sender, RoutedEventArgs e)
		{
			var newWindow = new MainWindow();
			newWindow.Show();
		}
	}
}
