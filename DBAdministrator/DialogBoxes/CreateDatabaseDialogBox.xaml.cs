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
	/// Interaction logic for CreateDatabaseDialogBox.xaml
	/// </summary>
	public partial class CreateDatabaseDialogBox : Window
	{

		private readonly IDatabaseAccessService _dataBaseAccessService;
		public string DatabaseName { get; set; }

		public CreateDatabaseDialogBox(IDatabaseAccessService dataBaseAccessService)
		{
			_dataBaseAccessService = dataBaseAccessService;
			InitializeComponent();
		}

		private void CreateDatabase_OnClick(object sender, RoutedEventArgs e)
		{
			if (!this.IsValid()) return;
			_dataBaseAccessService.CreateDatabase(DatabaseName);
			DialogResult = true;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Database.GetBindingExpression(TextBox.TextProperty).UpdateSource();
		}
	}
}
