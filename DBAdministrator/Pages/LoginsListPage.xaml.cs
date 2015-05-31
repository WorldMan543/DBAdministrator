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
	/// Interaction logic for LoginsListPage.xaml
	/// </summary>
	public partial class LoginsListPage : Page
	{
		private readonly IServerUserAccessService _serverUserAccessService;

		private IList<LoginViewModel> _originalModels;
		public ObservableCollection<LoginViewModel> Models { get; set; }
		public LoginsListPage(IServerUserAccessService serverUserAccessService)
		{
			_serverUserAccessService = serverUserAccessService;
			_originalModels = serverUserAccessService.GetLoginInfoList();
			Models = new ObservableCollection<LoginViewModel>(_originalModels);
			InitializeComponent();
		}

		private void Search_Click(object sender, RoutedEventArgs e)
		{
			var results = _originalModels.Where(p => p.Name.Contains(SearchValue.Text)).ToList();
			Models.Clear();
			results.ForEach(Models.Add);
		}

		private void Create_Click(object sender, RoutedEventArgs e)
		{
			var dlg = new CreateServerUser(_serverUserAccessService);
			dlg.ShowDialog();
			if (dlg.DialogResult.HasValue && dlg.DialogResult.Value)
			{
				GetValue();
				MainWindow.Refresh();
			}
		}

		private void GetValue()
		{
			_originalModels = _serverUserAccessService.GetLoginInfoList();
			Models.Clear();
			_originalModels.ToList().ForEach(Models.Add);
			SearchValue.Text = string.Empty;
		}
	}
}
