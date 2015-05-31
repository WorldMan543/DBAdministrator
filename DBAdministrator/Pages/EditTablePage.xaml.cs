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
	/// Interaction logic for EditTablePage.xaml
	/// </summary>
	public partial class EditTablePage : Page
	{
		private readonly ITableAccessService _tableAccessService;
		private string _tableName;
		private string _databaseName;
		private string _schema;

		public ObservableCollection<TableInfoViewModel> ViewModel { get; set; }

		public EditTablePage(ITableAccessService tableAccessService, string databaseName, string tableName, string schema)
		{
			_schema = schema;
			_tableAccessService = tableAccessService;
			_databaseName = databaseName;
			_tableName = tableName;
			ViewModel = new ObservableCollection<TableInfoViewModel>(_tableAccessService.GetTableSchema(databaseName, tableName, schema));
			InitializeComponent();
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			_tableAccessService.EditTable(ViewModel, _tableName, _databaseName, _schema);
		}

		private void OnChecked(object sender, RoutedEventArgs e)
		{

		}
	}
}
