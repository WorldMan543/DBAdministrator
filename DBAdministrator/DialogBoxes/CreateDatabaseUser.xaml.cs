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
using Business.Interfaces;


namespace DBAdministrator.DialogBoxes
{
	/// <summary>
	/// Interaction logic for CreateDatabaseUser.xaml
	/// </summary>
	public partial class CreateDatabaseUser : Window
	{
		private readonly IDatabaseUserAccessService _databaseUserAccessService;
		private readonly string _database;

		public IList<string> Logins { get; set; }

		public string Login { get; set; }

		public string UserName { get; set; }

		public CreateDatabaseUser(IDatabaseUserAccessService databaseUserAccessService, IServerUserAccessService serverUserAccessService, string database)
		{
			_databaseUserAccessService = databaseUserAccessService;
			_database = database;
			Logins = serverUserAccessService.GetLoginsName();
			Login = Logins.FirstOrDefault();
			InitializeComponent();
		}

		private void CreateLogin_OnClick(object sender, RoutedEventArgs e)
		{
			if (!this.IsValid()) return;
			_databaseUserAccessService.CreateDatabaseUser(_database, UserName, Login);
			DialogResult = true;
		}

	}
}
