using Business.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace DBAdministrator.DialogBoxes
{
	/// <summary>
	/// Interaction logic for ExportDatabaseDialogBox.xaml
	/// </summary>
	public partial class ExportDatabaseDialogBox : Window
	{
		private readonly IDatabaseAccessService _dataBaseAccessService;

		public string DatabaseName { get; set; }
		public ObservableCollection<string> DatabasesName { get; set; } 
		public bool IncludeTables { get; set; }
		public bool IncludeTablesData { get; set; }
		public bool IncludeStoredProcedures { get; set; }
		public bool IncludeDescriptiveComments { get; set; }

		public ExportDatabaseDialogBox(IDatabaseAccessService dataBaseAccessService,
			IList<string> databasesName)
		{
			_dataBaseAccessService = dataBaseAccessService;
			DatabasesName = new ObservableCollection<string>(databasesName);
			DatabaseName = databasesName.FirstOrDefault();
			InitializeComponent();
		}

		private void ExportBottom_Click(object sender, RoutedEventArgs e)
		{
			var dialog = new SaveFileDialog
			{
				DefaultExt = ".sql",
				Filter = "SQL Documents (.sql)|*.sql"
			};
			var result = dialog.ShowDialog();
			if (result == true)
			{
				var results = _dataBaseAccessService.ExportData(DatabaseName, IncludeTables, IncludeTablesData, IncludeStoredProcedures, IncludeDescriptiveComments);
				File.WriteAllLines(dialog.FileName, results.Cast<string>());
				DialogResult = true;
			}
		}
	}
}
