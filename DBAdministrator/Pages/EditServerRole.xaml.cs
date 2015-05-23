using Business.Interfaces;
using System;
using System.Collections;
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

namespace DBAdministrator.Pages
{
	/// <summary>
	/// Interaction logic for EditServerRole.xaml
	/// </summary>
	public partial class EditServerRole : Page
	{
		ListBox dragSource = null;
		private IServerRoleAccessService _serverRoleAccessService;
		private string _roleName;
		private IDictionary<string, bool> defaultRoles;


		public ObservableCollection<string> UsersWithRole { get; set; }
		public ObservableCollection<string> UsersWithoutRole { get; set; }

		public EditServerRole(IServerRoleAccessService serverRoleAccessService, string roleName)
		{
			_serverRoleAccessService = serverRoleAccessService;
			_roleName = roleName;
			defaultRoles = serverRoleAccessService.GetLoginsRoleInfo(roleName);
			UsersWithRole = new ObservableCollection<string>(defaultRoles.Where(l => l.Value).Select(l => l.Key).ToList());
			UsersWithoutRole = new ObservableCollection<string>(defaultRoles.Where(l => !l.Value).Select(l => l.Key).ToList());
			InitializeComponent();
		}
		
		private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			ListBox parent = (ListBox)sender;
			dragSource = parent;
			object data = GetDataFromListBox(dragSource, e.GetPosition(parent));
			if (data != null)
			{
				DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
			}
		}

		private static object GetDataFromListBox(ListBox source, Point point)
		{
			UIElement element = source.InputHitTest(point) as UIElement;
			if (element != null)
			{
				object data = DependencyProperty.UnsetValue;
				while (data == DependencyProperty.UnsetValue)
				{
					data = source.ItemContainerGenerator.ItemFromContainer(element);
					if (data == DependencyProperty.UnsetValue)
					{
						element = VisualTreeHelper.GetParent(element) as UIElement;
					}
					if (element == source)
					{
						return null;
					}
				}
				if (data != DependencyProperty.UnsetValue)
				{
					return data;
				}
			}
			return null;
		}

		private void ListBox_Drop(object sender, DragEventArgs e)
		{
			ListBox parent = (ListBox)sender;
			string data = e.Data.GetData(typeof(string)) as string;
			(dragSource.ItemsSource as IList<string>).Remove(data);
			(parent.ItemsSource as IList<string>).Add(data);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var usersWithRole = UsersWithRole.Except(defaultRoles.Where(r => r.Value).Select(r => r.Key));
			var usersWithoutRole = UsersWithoutRole.Except(defaultRoles.Where(r => !r.Value).Select(r => r.Key));
			_serverRoleAccessService.UpdateRole(_roleName, usersWithRole, usersWithoutRole);
		}

	}
}
