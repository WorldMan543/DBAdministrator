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
using DBAdministrator.DialogBoxes;

namespace DBAdministrator.Pages
{
	/// <summary>
	/// Interaction logic for TablesListPage.xaml
	/// </summary>
	public partial class TablesListPage : Page
	{
		private IList<TableViewModel> _originalModels;
		private readonly ITableAccessService _tableAccessService;
		private readonly string _database;
		public ObservableCollection<TableViewModel> Models { get; set; }

		public TablesListPage(ITableAccessService tableAccessService, string database)
		{
			_database = database;
			_tableAccessService = tableAccessService;
			_originalModels = tableAccessService.GetTableInfoList(database);
			Models = new ObservableCollection<TableViewModel>(_originalModels);
			InitializeComponent();
		}

		private void Search_Click(object sender, RoutedEventArgs e)
		{
			var results = _originalModels.Where(p => p.TableName.Contains(SearchValue.Text)).ToList();
			Models.Clear();
			results.ForEach(Models.Add);
		}

		private void EditTable_OnClick(object sender, RoutedEventArgs e)
		{
			if (TablesList.SelectedItems.Count == 0) return;
			var item = (TableViewModel)TablesList.SelectedItems[0];
			NavigationService.Navigate(new EditTablePage(_tableAccessService, _database, item.TableName));
		}

		private void Create_Click(object sender, RoutedEventArgs e)
		{
			var dialog = new CreateTableDialogBox(_tableAccessService, _database);
			dialog.ShowDialog();
			if (dialog.DialogResult != null && dialog.DialogResult.Value)
			{
				NavigationService.Navigate(new EditTablePage(_tableAccessService, _database, dialog.TableName));
			}
		}

		private void Rename_Click(object sender, RoutedEventArgs e)
		{
			if (TablesList.SelectedItems.Count == 0) return;
			var item = (TableViewModel)TablesList.SelectedItems[0];
			var dialog = new CreateTableDialogBox(_tableAccessService, _database, item.TableName);
			dialog.ShowDialog();
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			if (TablesList.SelectedItems.Count == 0) return;
			var item = (TableViewModel)TablesList.SelectedItems[0];
			string messageBoxText = "Do you want to delete table?";
			string caption = "Delete";
			MessageBoxButton button = MessageBoxButton.YesNo;
			MessageBoxImage icon = MessageBoxImage.Warning;
			var result = MessageBox.Show(messageBoxText, caption, button, icon);
			if (result == MessageBoxResult.Yes)
			{
				_tableAccessService.DeleteTable(_database, item.TableName);
			}
		}
	}
}
