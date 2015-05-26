using Business.Interfaces;
using DBAdministrator.Models;
using DBAdministrator.Models.Enums;
using DBAdministrator.Models.Helpers;
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
using DBAdministrator.Helpers;
using System.Security;

namespace DBAdministrator.DialogBoxes
{
	/// <summary>
	/// Interaction logic for CreateServerUser.xaml
	/// </summary>
	public partial class CreateServerUser : Window
	{
		private readonly IServerUserAccessService _serverUserAccessService;
		public AuthenticationViewModel ViewModel { get; private set; }
		public CreateServerUser(IServerUserAccessService serverUserAccessService)
		{
			_serverUserAccessService = serverUserAccessService;
			var authenticationTypes = ReflectionHelpers.GetAllValuesAndDescriptions<AuthenticationType>();
			ViewModel = new AuthenticationViewModel()
			{
				AuthenticationTypes = authenticationTypes,
				SelectedAuthenticationType = authenticationTypes.First().Key
			};
			InitializeComponent();
		}

		private void CreateLogin_OnClick(object sender, RoutedEventArgs e)
		{
			if (!this.IsValid()) return;
			var secure = new SecureString();
			_serverUserAccessService.CreateServerUser(ViewModel.SelectedAuthenticationType, ViewModel.UserName, ViewModel.Password);
			DialogResult = true;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			User.GetBindingExpression(TextBox.TextProperty).UpdateSource();
			//Password.GetBindingExpression(TextBox.TextProperty).UpdateSource();
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
					//Validation.ClearInvalid(UserName.GetBindingExpression(TextBox.TextProperty));
					Validation.ClearInvalid(Password.GetBindingExpression(TextBox.TextProperty));
					//assword.GetBindingExpression(TextBox.TextProperty).UpdateSource();
				}
				else
				{
					Password.GetBindingExpression(TextBox.TextProperty).UpdateSource();
					//Password.GetBindingExpression(TextBox.TextProperty).UpdateSource();
				}
				User.GetBindingExpression(TextBox.TextProperty).UpdateSource();
				Password.IsEnabled = isEnabled;
			}
		}
	}
}
