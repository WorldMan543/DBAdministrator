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
	/// Interaction logic for TablesListPage.xaml
	/// </summary>
	public partial class TablesListPage : Page
	{
		private readonly ITableAccessService _tableAccessService;
		private readonly string _database;
		public IList<TableViewModel> Models { get; set; }

		public TablesListPage(ITableAccessService tableAccessService, string database)
		{
			_database = database;
			_tableAccessService = tableAccessService;
			Models = tableAccessService.GetTableInfoList(database);
			InitializeComponent();
		}

		private void EditTable_OnClick(object sender, RoutedEventArgs e)
		{
			if (TablesList.SelectedItems.Count == 0) return;
			var item = (TableViewModel)TablesList.SelectedItems[0];
			NavigationService.Navigate(new EditTablePage(_tableAccessService, _database, item.TableName));
		}
	}
}
