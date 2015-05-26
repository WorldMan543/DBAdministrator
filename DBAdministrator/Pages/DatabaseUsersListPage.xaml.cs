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
using System.Collections.ObjectModel;

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
		private IList<UserViewModel> _originalModels;
		public ObservableCollection<UserViewModel> Models { get; set; }
		public DatabaseUsersListPage(IDatabaseUserAccessService databaseUserAccessService, IServerUserAccessService serverUserAccessService, string database)
		{
			_databaseUserAccessService = databaseUserAccessService;
			_serverUserAccessService = serverUserAccessService;
			_database = database;
			_originalModels = databaseUserAccessService.GetUserInfoList(database);
			Models = new ObservableCollection<UserViewModel>(_originalModels);
			InitializeComponent();
		}

		private void Search_Click(object sender, RoutedEventArgs e)
		{
			var results = _originalModels.Where(p => p.Name.Contains(SearchValue.Text)).ToList();
			Models.Clear();
			results.ForEach(Models.Add);
		}

		private void Create_Click(object sender, RoutedEventArgs e)
		{
			var dlg = new CreateDatabaseUser(_databaseUserAccessService, _serverUserAccessService, _database);
			dlg.ShowDialog();
			if (dlg.DialogResult.HasValue && dlg.DialogResult.Value)
			{
			}
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			if (UsersList.SelectedItems.Count == 0) return;
			var item = (UserViewModel)UsersList.SelectedItems[0];
			string messageBoxText = "Do you want to delete database user?";
			string caption = "Delete";
			MessageBoxButton button = MessageBoxButton.YesNo;
			MessageBoxImage icon = MessageBoxImage.Warning;
			var result = MessageBox.Show(messageBoxText, caption, button, icon);
			if (result == MessageBoxResult.Yes)
			{
				_databaseUserAccessService.DeleteDatabaseUser(_database, item.Name);
			}
		}
	}
}
