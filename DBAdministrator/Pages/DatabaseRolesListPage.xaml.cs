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

namespace DBAdministrator.Pages
{
	/// <summary>
	/// Interaction logic for DatabaseRolesListPage.xaml
	/// </summary>
	public partial class DatabaseRolesListPage : Page
	{
		public IList<RoleViewModel> Models { get; set; }
		public DatabaseRolesListPage(IDatabaseRoleAccessService databaseRoleAccessService, string database)
		{
			Models = databaseRoleAccessService.GetRoleInfoList(database);
			InitializeComponent();
		}
	}
}
