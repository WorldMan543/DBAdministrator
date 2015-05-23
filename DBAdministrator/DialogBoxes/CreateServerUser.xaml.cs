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
	}
}
