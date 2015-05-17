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
using Business.Interfaces;
using DBAdministrator.Helpers;

namespace DBAdministrator.DialogBoxes
{
	/// <summary>
	/// Interaction logic for CreateTableDialogBox.xaml
	/// </summary>
	public partial class CreateTableDialogBox : Window
	{

		private readonly ITableAccessService _tableAccessService;
		private readonly string _database;
		private readonly string _oldName;

		public string TableName { get; set; }
		public CreateTableDialogBox(ITableAccessService tableAccessService, string database)
		{
			_database = database;
			_tableAccessService = tableAccessService;
			InitializeComponent();
		}

		public CreateTableDialogBox(ITableAccessService tableAccessService, string database, string oldName)
		{
			_database = database;
			TableName = _oldName = oldName;
			_tableAccessService = tableAccessService;
			InitializeComponent();
		}

		private void CreateTable_OnClick(object sender, RoutedEventArgs e)
		{
			if (!this.IsValid()) return;
			if (string.IsNullOrWhiteSpace(_oldName))
			{
				_tableAccessService.CreateTable(_database, TableName);
			}
			else
			{
				_tableAccessService.RenameTable(_database, _oldName, TableName);
			}
			DialogResult = true;
		}
	}
}
