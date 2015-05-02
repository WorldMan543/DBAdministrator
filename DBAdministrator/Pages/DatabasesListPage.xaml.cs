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

namespace DBAdministrator.Pages
{
	/// <summary>
	/// Interaction logic for DatabasesListPage.xaml
	/// </summary>
	public partial class DatabasesListPage : Page
	{
		private readonly IDataBaseAccessService _dataBaseAccessService;
		public IList<DatabaseViewModel> Models { get; set; }

		public DatabasesListPage(IDataBaseAccessService dataBaseAccessService)
		{
			_dataBaseAccessService = dataBaseAccessService;
			Models = _dataBaseAccessService.GetDatabaseInfoList();
			InitializeComponent();
		}
	}
}
