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
using DBAdministrator.Models.TreeView;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;

namespace DBAdministrator.Pages
{
	/// <summary>
	/// Interaction logic for StoredProceduresListPage.xaml
	/// </summary>
	public partial class StoredProceduresListPage : Page
	{
		private readonly IDatabaseAccessService _dataBaseAccessService;
		private readonly IStoredProcedureAccessService _storedProcedureAccessService;
		private readonly string _database;

		private IList<StoredProcedureViewModel> _originalModels;
		public ObservableCollection<StoredProcedureViewModel> Models { get; set; }
		public StoredProceduresListPage(IStoredProcedureAccessService storedProcedureAccessService, IDatabaseAccessService dataBaseAccessService, string database)
		{
			_storedProcedureAccessService = storedProcedureAccessService;
			_dataBaseAccessService = dataBaseAccessService;
			_database = database;
			_originalModels = storedProcedureAccessService.GetStoredProcedureInfoList(database);
			Models = new ObservableCollection<StoredProcedureViewModel>(_originalModels);
			InitializeComponent();
		}

		private void Search_Click(object sender, RoutedEventArgs e)
		{
			var results = _originalModels.Where(p => p.ProcedureName.Contains(SearchValue.Text)).ToList();
			Models.Clear();
			results.ForEach(Models.Add);
		}

		private void Create_Click(object sender, RoutedEventArgs e)
		{
			string query = string.Empty;
			using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DBAdministrator.Resources.CreateProcedure.sql"))
			{
				if (stream == null) return;
				using (var reader = new StreamReader(stream))
				{
					query = reader.ReadToEnd();
				}
			}
			MainWindow.Refresh();
			NavigationService.Navigate(new SQLEditorPage(_dataBaseAccessService, query, _database));
		}

		private void Edit_Click(object sender, RoutedEventArgs e)
		{
			if (ProcedureList.SelectedItems.Count == 0) return;
			var item = (StoredProcedureViewModel)ProcedureList.SelectedItems[0];
			var query = _storedProcedureAccessService.GetAlterStoredProcedure(_database, item.ProcedureName,
				item.Owner);
			NavigationService.Navigate(new SQLEditorPage(_dataBaseAccessService, query, _database));
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			if (ProcedureList.SelectedItems.Count == 0) return;
			var item = (StoredProcedureViewModel)ProcedureList.SelectedItems[0];
			string messageBoxText = "Do you want to delete procedure?";
			string caption = "Delete";
			MessageBoxButton button = MessageBoxButton.YesNo;
			MessageBoxImage icon = MessageBoxImage.Warning;
			var result = MessageBox.Show(messageBoxText, caption, button, icon);
			if (result == MessageBoxResult.Yes)
			{
				_storedProcedureAccessService.DeleteStoredProcedure(_database, item.ProcedureName, item.Owner);
				GetValue();
				MainWindow.Refresh();
			}
		}

		private void GetValue()
		{
			_originalModels = _storedProcedureAccessService.GetStoredProcedureInfoList(_database);
			Models.Clear();
			_originalModels.ToList().ForEach(Models.Add);
			SearchValue.Text = string.Empty;
		}
	}
}
