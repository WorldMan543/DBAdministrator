using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microsoft.Practices.Unity;
using DBAdministrator.DialogBoxes;

namespace DBAdministrator.Pages
{
	/// <summary>
	/// Interaction logic for DatabasesListPage.xaml
	/// </summary>
	public partial class DatabasesListPage : Page
	{
		private readonly IDatabaseAccessService _dataBaseAccessService;
		private IList<DatabaseViewModel> _originalModels;
		private ITableAccessService _tableAccessService;
		public ObservableCollection<DatabaseViewModel> Models { get; set; }

		public DatabasesListPage(IDatabaseAccessService dataBaseAccessService, ITableAccessService tableAccessService)
		{
			_dataBaseAccessService = dataBaseAccessService;
			_tableAccessService = tableAccessService;
			_originalModels = _dataBaseAccessService.GetDatabaseInfoList();
			Models = new ObservableCollection<DatabaseViewModel>(_originalModels);
			InitializeComponent();
		}

		private void Search_Click(object sender, RoutedEventArgs e)
		{
			var results = _originalModels.Where(p => p.DatabaseName.Contains(SearchValue.Text)).ToList();
			Models.Clear();
			results.ForEach(Models.Add);
		}

		private void Create_Click(object sender, RoutedEventArgs e)
		{
			var dialog = new CreateDatabaseDialogBox(_dataBaseAccessService);
			dialog.ShowDialog();
			if (dialog.DialogResult != null && dialog.DialogResult.Value)
			{
				MainWindow.Refresh();
				NavigationService.Navigate(new TablesListPage(_tableAccessService, dialog.DatabaseName));
			}
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			if (DatabasesList.SelectedItems.Count == 0) return;
			var item = (DatabaseViewModel)DatabasesList.SelectedItems[0];
			string messageBoxText = "Do you want to delete database?";
			string caption = "Delete";
			MessageBoxButton button = MessageBoxButton.YesNo;
			MessageBoxImage icon = MessageBoxImage.Warning;
			var result = MessageBox.Show(messageBoxText, caption, button, icon);
			if (result == MessageBoxResult.Yes)
			{
				_dataBaseAccessService.DeleteDatabase(item.DatabaseName);
				GetValue();
				MainWindow.Refresh();
			}
		}

		private void GetValue()
		{
			_originalModels = _dataBaseAccessService.GetDatabaseInfoList();
			Models.Clear();
			_originalModels.ToList().ForEach(Models.Add);
			SearchValue.Text = string.Empty;
		}
	}
}
