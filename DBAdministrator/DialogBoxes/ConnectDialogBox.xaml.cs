using DBAdministrator.Helpers;
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
using System.Windows.Shapes;
using DBAdministrator.Enums;
using System.ComponentModel;
using DBAdministrator.Models;

namespace DBAdministrator.DialogBoxes
{
	/// <summary>
	/// Interaction logic for ConnectDialogBox.xaml
	/// </summary>
	public partial class ConnectDialogBox : Window
	{

		public AuthenticationViewModel ViewModel { get; private set; }

		public ConnectDialogBox()
		{
			ViewModel = new AuthenticationViewModel();
			InitializeComponent();
		}

		public ConnectDialogBox(IEnumerable<string> serversList)
		{
			var serversName = serversList as IList<string> ?? serversList.ToList();
			ViewModel = new AuthenticationViewModel()
			{
				ServersName = serversName,
				ServerName = serversName.FirstOrDefault()
			};
			InitializeComponent();
		}
		
		private void ConnectBottom_OnClick(object sender, RoutedEventArgs e)
		{
			if (!this.IsValid()) return;
			this.DialogResult = true;
		}

	}
}
