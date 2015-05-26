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
using System.ComponentModel;
using Business.Interfaces;
using DBAdministrator.Models;
using DBAdministrator.Validators;

namespace DBAdministrator.DialogBoxes
{
	/// <summary>
	/// Interaction logic for ConnectDialogBox.xaml
	/// </summary>
	public partial class ConnectDialogBox : Window
	{
		private IDatabaseAccessService _databaseAccessService;
		public AuthenticationViewModel ViewModel { get; private set; }

		public ConnectDialogBox(IDatabaseAccessService databaseAccessService)
		{
			_databaseAccessService = databaseAccessService;
			ViewModel = databaseAccessService.GetAuthenticationViewModel();
			InitializeComponent();
		}
		
		private void ConnectBottom_OnClick(object sender, RoutedEventArgs e)
		{
			if (!this.IsValid()) return;
			try
			{
				_databaseAccessService.Connect(ViewModel);
				DialogResult = true;
			}
			catch (Exception ex)
			{
				while (ex.InnerException != null) ex = ex.InnerException;
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.IsInitialized)
			{
				var comboBox = (ComboBox)e.Source;
				var item = (KeyValuePair<int, string>)comboBox.SelectionBoxItem;
				var isEnabled = item.Key == 0;
				if (!isEnabled)
				{
					Validation.ClearInvalid(UserName.GetBindingExpression(TextBox.TextProperty));
				}
				else
				{
					UserName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
					Password.GetBindingExpression(TextBox.TextProperty).UpdateSource();
				}
				UserName.IsEnabled = Password.IsEnabled = isEnabled;
			}
		}

	}
}
