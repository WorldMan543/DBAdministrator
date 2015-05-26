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
using SMO.Implementation;
using System.IO;
using System.Xml;
using Business.Interfaces;
using DBAdministrator.DialogBoxes;
using DBAdministrator.Models;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using Microsoft.Practices.Unity;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using DBAdministrator.Models.TreeView;
using DBAdministrator.Pages;
using Microsoft.Win32;
using Microsoft.SqlServer.Management.Common;
using System.Globalization;
using System.Threading;

namespace DBAdministrator
{

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly IDatabaseAccessService _databaseAccessService;
		private readonly IDatabaseRoleAccessService _databaseRoleAccessService;
		private readonly IDatabaseUserAccessService _databaseUserAccessService;
		private readonly IServerRoleAccessService _serverRoleAccessService;
		private readonly IServerUserAccessService _serverUserAccessService;
		private readonly ITableAccessService _tableAccessService;
		private readonly IStoredProcedureAccessService _storedProcedureAccessService;
		private bool isConnected = false;

		public MainWindowViewModel ViewModel { get; set; }

		public MainWindow([Dependency] IDatabaseAccessService dataBaseAccessService,
			[Dependency] IDatabaseRoleAccessService databaseRoleAccessService,
			[Dependency] IDatabaseUserAccessService databaseUserAccessService,
			[Dependency] IServerRoleAccessService serverRoleAccessService,
			[Dependency] IServerUserAccessService serverUserAccessService,
			[Dependency] ITableAccessService tableAccessService,
			[Dependency] IStoredProcedureAccessService storedProcedureAccessService)
		{
			_databaseAccessService = dataBaseAccessService;
			_databaseRoleAccessService = databaseRoleAccessService;
			_databaseUserAccessService = databaseUserAccessService;
			_serverRoleAccessService = serverRoleAccessService;
			_serverUserAccessService = serverUserAccessService;
			_tableAccessService = tableAccessService;
			_storedProcedureAccessService = storedProcedureAccessService;
			InitializeViewModel();
			InitializeComponent();
		}

		private void InitializeViewModel()
		{
			ViewModel = new MainWindowViewModel()
			{
				StatusBar = new StatusBarViewModel()
			};
		}

		private void ConnectMenuItem_OnClick(object sender, RoutedEventArgs e)
		{
			var dlg = new ConnectDialogBox(_databaseAccessService)
			{
				Owner = this
			};
			dlg.ShowDialog();
			if (dlg.DialogResult.HasValue && dlg.DialogResult.Value)
			{
				ViewModel.StatusBar.ServerName = dlg.ViewModel.ServerName;
				ViewModel.ServerStruct.Clear();
				ViewModel.ServerStruct.Add(new ServerStructViewModel()
				{
					ServerName = dlg.ViewModel.ServerName
				});
				var tree = _databaseAccessService.GetDatabaseTree();
				tree.ServerName = ViewModel.ServerStruct[0].ServerName;
				ViewModel.ServerStruct.Clear();
				ViewModel.ServerStruct.Add(tree);
				Frame = new Frame();
				Grid.Children.Clear();
				Grid.Children.Add(Frame);
				isConnected = true;
			}
		}

		private void MenuItem_OnClick(object sender, RoutedEventArgs e)
		{
			var tree = _databaseAccessService.GetDatabaseTree();
			tree.ServerName = ViewModel.ServerStruct[0].ServerName;
			ViewModel.ServerStruct.Clear();
			ViewModel.ServerStruct.Add(tree);
		}

		private void OpenEditor_OnClick(object sender, RoutedEventArgs e)
		{
			if (!isConnected) return;
			Frame.Navigate(new SQLEditorPage(_databaseAccessService));
		}

		private void DeleteStoredProcedure_OnClick(object sender, RoutedEventArgs e)
		{
			var model = (StoredProcedureStructViewModel)((MenuItem)sender).DataContext;
			string messageBoxText = "Do you want to delete procedure?";
			string caption = "Delete";
			MessageBoxButton button = MessageBoxButton.YesNo;
			MessageBoxImage icon = MessageBoxImage.Warning;
			var result = MessageBox.Show(messageBoxText, caption, button, icon);
			if (result == MessageBoxResult.Yes)
			{
				_storedProcedureAccessService.DeleteStoredProcedure(model.Database, model.ProcedureName);
			}
		}

		private void DeleteTable_OnClick(object sender, RoutedEventArgs e)
		{
			var model = (TableStructViewModel)((MenuItem)sender).DataContext;
			string messageBoxText = "Do you want to save changes?";
			string caption = "Delete";
			MessageBoxButton button = MessageBoxButton.YesNo;
			MessageBoxImage icon = MessageBoxImage.Warning;
			var result = MessageBox.Show(messageBoxText, caption, button, icon);
			if (result == MessageBoxResult.Yes)
			{
				_tableAccessService.DeleteTable(model.Database, model.TableName);
			}
		}

		private void DeleteDatabaseRole_OnClick(object sender, RoutedEventArgs e)
		{
			var model = (RoleStructViewModel)((MenuItem)sender).DataContext;
			string messageBoxText = "Do you want to delete database role?";
			string caption = "Delete";
			MessageBoxButton button = MessageBoxButton.YesNo;
			MessageBoxImage icon = MessageBoxImage.Warning;
			var result = MessageBox.Show(messageBoxText, caption, button, icon);
			if (result == MessageBoxResult.Yes)
			{
				_databaseRoleAccessService.DeleteDatabaseRole(model.Database, model.RoleName);
			}
			
		}

		private void DeleteDatabaseUser_OnClick(object sender, RoutedEventArgs e)
		{
			var model = (UserStructViewModel)((MenuItem)sender).DataContext;
			string messageBoxText = "Do you want to delete database user?";
			string caption = "Delete";
			MessageBoxButton button = MessageBoxButton.YesNo;
			MessageBoxImage icon = MessageBoxImage.Warning;
			var result = MessageBox.Show(messageBoxText, caption, button, icon);
			if (result == MessageBoxResult.Yes)
			{
				_databaseUserAccessService.DeleteDatabaseUser(model.Database, model.UserName);
			}
			
		}

		private void DeleteDatabase_OnClick(object sender, RoutedEventArgs e)
		{
			var model = (DatabaseStructViewModel)((MenuItem)sender).DataContext;
			string messageBoxText = "Do you want to delete database?";
			string caption = "Delete";
			MessageBoxButton button = MessageBoxButton.YesNo;
			MessageBoxImage icon = MessageBoxImage.Warning;
			var result = MessageBox.Show(messageBoxText, caption, button, icon);
			if (result == MessageBoxResult.Yes)
			{
				_databaseAccessService.DeleteDatabase(model.DatabaseName);
			}
		}

		private void OpenDatabaseList_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount != 2) return;
			Frame.Navigate(new DatabasesListPage(_databaseAccessService, _tableAccessService));
		}

		private void OpenRolesList_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount != 2) return;
			var model = ((RoleStructViewModel[])((TextBlock)sender).DataContext).First();
			var page = !string.IsNullOrEmpty(model.Database) 
				? (object)new DatabaseRolesListPage(_databaseRoleAccessService, model.Database)
				: new ServerRolesListPage(_serverRoleAccessService);
			Frame.Navigate(page);
		}

		private void OpenTablesList_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount != 2) return;
			var model = ((TableStructViewModel[])((TextBlock)sender).DataContext).First();
			Frame.Navigate(new TablesListPage(_tableAccessService, model.Database));
		}

		private void OpenProceduresList_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount != 2) return;
			var model = ((StoredProcedureStructViewModel[])((TextBlock)sender).DataContext).First();
			Frame.Navigate(new StoredProceduresListPage(_storedProcedureAccessService, _databaseAccessService, model.Database));
		}

		private void OpenUsersList_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount != 2) return;
			var model = ((UserStructViewModel[])((TextBlock)sender).DataContext).First();
			var page = !string.IsNullOrEmpty(model.Database)
				? (object)new DatabaseUsersListPage(_databaseUserAccessService, _serverUserAccessService, model.Database)
				: new LoginsListPage(_serverUserAccessService);
			Frame.Navigate(page);
		}

		private void CreateDatabase_OnClick(object sender, RoutedEventArgs e)
		{
			var dialog = new CreateDatabaseDialogBox(_databaseAccessService);
			dialog.ShowDialog();
			if (dialog.DialogResult != null && dialog.DialogResult.Value)
			{
				Frame.Navigate(new TablesListPage(_tableAccessService, dialog.DatabaseName));
			}
		}

		private void CreateTable_OnClick(object sender, RoutedEventArgs e)
		{
			var model = ((TableStructViewModel[])((MenuItem)sender).DataContext).First();
			var dialog = new CreateTableDialogBox(_tableAccessService, model.Database);
			dialog.ShowDialog();
			if (dialog.DialogResult != null && dialog.DialogResult.Value)
			{
				Frame.Navigate(new EditTablePage(_tableAccessService, model.Database, dialog.TableName));
			}
		}

		private void RenameTable_OnClick(object sender, RoutedEventArgs e)
		{
			var model = (TableStructViewModel)((MenuItem)sender).DataContext;
			var dialog = new CreateTableDialogBox(_tableAccessService, model.Database, model.TableName);
			dialog.ShowDialog();
		}

		private void ExportDatabase_OnClick(object sender, RoutedEventArgs e)
		{
			if (!isConnected) return;
			var names = ViewModel.ServerStruct.First().Databases.Select(d => d.DatabaseName).ToList();
			var dlg = new ExportDatabaseDialogBox(_databaseAccessService, names)
			{
				Owner = this
			};
			dlg.ShowDialog();
		}

		private void LogoutMenuItem_Click(object sender, RoutedEventArgs e)
		{
			if (!isConnected) return;
			_databaseAccessService.Disconnect();
			isConnected = false;
			Frame = new Frame();
			Grid.Children.Clear();
			Grid.Children.Add(Frame);
			ViewModel.StatusBar.ServerName = string.Empty;
			ViewModel.ServerStruct.Clear();
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			ConnectMenuItem_OnClick(sender, null);
		}

	}
}
