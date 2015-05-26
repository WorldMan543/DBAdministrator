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
using System.Collections.ObjectModel;

namespace DBAdministrator.Pages
{
	/// <summary>
	/// Interaction logic for DatabaseRolesListPage.xaml
	/// </summary>
	public partial class DatabaseRolesListPage : Page
	{
		private IList<RoleViewModel> _originalModels;
		private string _database;
		private IDatabaseRoleAccessService _databaseRoleAccessService;
		public ObservableCollection<RoleViewModel> Models { get; set; }
		public DatabaseRolesListPage(IDatabaseRoleAccessService databaseRoleAccessService, string database)
		{
			_database = database;
			_databaseRoleAccessService = databaseRoleAccessService;
			_originalModels = databaseRoleAccessService.GetRoleInfoList(database);
			Models = new ObservableCollection<RoleViewModel>(_originalModels);
			InitializeComponent();
		}

		private void Search_Click(object sender, RoutedEventArgs e)
		{
			var results = _originalModels.Where(p => p.Name.Contains(SearchValue.Text)).ToList();
			Models.Clear();
			results.ForEach(Models.Add);
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			if (RoleList.SelectedItems.Count == 0) return;
			var item = (RoleViewModel)RoleList.SelectedItems[0];
			string messageBoxText = "Do you want to delete database role?";
			string caption = "Delete";
			MessageBoxButton button = MessageBoxButton.YesNo;
			MessageBoxImage icon = MessageBoxImage.Warning;
			var result = MessageBox.Show(messageBoxText, caption, button, icon);
			if (result == MessageBoxResult.Yes)
			{
				_databaseRoleAccessService.DeleteDatabaseRole(_database, item.Name);
			}
		}
	}
}
