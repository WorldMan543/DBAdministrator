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
	/// Interaction logic for ServerRolesListPage.xaml
	/// </summary>
	public partial class ServerRolesListPage : Page
	{
		private IList<RoleViewModel> _originalModels;
		private IServerRoleAccessService _serverRoleAccessService;
		public ObservableCollection<RoleViewModel> Models { get; set; }
		public ServerRolesListPage(IServerRoleAccessService serverRoleAccessService)
		{
			_serverRoleAccessService = serverRoleAccessService;
			_originalModels = serverRoleAccessService.GetRoleInfoList();
			Models = new ObservableCollection<RoleViewModel>(_originalModels);
			InitializeComponent();
		}

		private void Search_Click(object sender, RoutedEventArgs e)
		{
			var results = _originalModels.Where(p => p.Name.Contains(SearchValue.Text)).ToList();
			Models.Clear();
			results.ForEach(Models.Add);
		}

		private void Edit_Click(object sender, RoutedEventArgs e)
		{
			if (RolesList.SelectedItems.Count == 0) return;
			var item = (RoleViewModel)RolesList.SelectedItems[0];
			NavigationService.Navigate(new EditServerRole(_serverRoleAccessService, item.Name));
		}
	}
}
