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

namespace DBAdministrator.Pages
{
	/// <summary>
	/// Interaction logic for StoredProceduresListPage.xaml
	/// </summary>
	public partial class StoredProceduresListPage : Page
	{
		public IList<StoredProcedureViewModel> Models { get; set; }
		public StoredProceduresListPage(IDataBaseAccessService dataBaseAccessService, string database)
		{
			Models = dataBaseAccessService.GetStoredProcedureInfoList(database);
			InitializeComponent();
		}
	}
}
