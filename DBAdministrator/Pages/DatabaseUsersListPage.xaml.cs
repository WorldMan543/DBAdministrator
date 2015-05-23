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
using Business.Interfaces;
using DBAdministrator.Models;
using DBAdministrator.DialogBoxes;

namespace DBAdministrator.Pages
{
	/// <summary>
	/// Interaction logic for DatabaseUsersListPage.xaml
	/// </summary>
	public partial class DatabaseUsersListPage : Page
	{
		private IDatabaseUserAccessService _databaseUserAccessService;
		private IServerUserAccessService _serverUserAccessService;
		private string _database;
		public IList<UserViewModel> Models { get; set; }
		public DatabaseUsersListPage(IDatabaseUserAccessService databaseUserAccessService, IServerUserAccessService serverUserAccessService, string database)
		{
			_databaseUserAccessService = databaseUserAccessService;
			_serverUserAccessService = serverUserAccessService;
			_database = database;
			Models = databaseUserAccessService.GetUserInfoList(database);
			InitializeComponent();
		}

		private void Create_Click(object sender, RoutedEventArgs e)
		{
			var dlg = new CreateDatabaseUser(_databaseUserAccessService, _serverUserAccessService, _database);
			dlg.ShowDialog();
			if (dlg.DialogResult.HasValue && dlg.DialogResult.Value)
			{
			}
		}
	}
}
