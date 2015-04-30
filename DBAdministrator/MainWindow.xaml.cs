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

namespace DBAdministrator
{

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		private readonly IDataBaseAccessService _dataBaseAccessService;

		public MainWindowViewModel ViewModel { get; set; }

		public MainWindow([Dependency] IDataBaseAccessService dataBaseAccessService)
		{
			_dataBaseAccessService = dataBaseAccessService;
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

		private void EnableSqlHighlighting()
		{
			using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DBAdministrator.Resources.SQL.xshd"))
			{
				if (stream == null) return;
				using (var reader = new XmlTextReader(stream))
				{
					//MyAvalonEdit.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
				}
			}
		}

		private void ConnectMenuItem_OnClick(object sender, RoutedEventArgs e)
		{
			var dlg = new ConnectDialogBox(_dataBaseAccessService)
			{
				Owner = this
			};
			dlg.ShowDialog();
			if (dlg.DialogResult != null && dlg.DialogResult.Value)
			{
				_dataBaseAccessService.Connect(dlg.ViewModel);
				ViewModel.StatusBar.ServerName = dlg.ViewModel.ServerName;
				ViewModel.ServerStruct.Clear();
				ViewModel.ServerStruct.Add(new ServerStructViewModel()
				{
					ServerName = dlg.ViewModel.ServerName
				});
			}
		}

		private void MainWindow_OnContentRendered(object sender, EventArgs e)
		{
			EnableSqlHighlighting();
		}

		private void MenuItem_OnClick(object sender, RoutedEventArgs e)
		{
			var tree = _dataBaseAccessService.GetDatabaseTree();
			tree.ServerName = ViewModel.ServerStruct[0].ServerName;
			ViewModel.ServerStruct.Clear();
			ViewModel.ServerStruct.Add(tree);
		}

		private void DeleteStoredProcedure_OnClick(object sender, RoutedEventArgs e)
		{
			var model = (StoredProcedureStructViewModel)((MenuItem)sender).DataContext;
			_dataBaseAccessService.DeleteStoredProcedure(model.Database, model.ProcedureName);
		}

		private void DeleteTable_OnClick(object sender, RoutedEventArgs e)
		{
			var model = (TableStructViewModel)((MenuItem)sender).DataContext;
			string messageBoxText = "Do you want to save changes?";
			string caption = "Word Processor";
			MessageBoxButton button = MessageBoxButton.OKCancel;
			MessageBoxImage icon = MessageBoxImage.Warning;
			var result = MessageBox.Show(messageBoxText, caption, button, icon);
			if (result.HasFlag(MessageBoxResult.OK))
			{
				_dataBaseAccessService.DeleteTable(model.Database, model.TableName);
			}
		}

		private void DeleteDatabaseRole_OnClick(object sender, RoutedEventArgs e)
		{
			var model = (RoleStructViewModel)((MenuItem)sender).DataContext;
			_dataBaseAccessService.DeleteDatabaseRole(model.Database, model.RoleName);
		}

		private void DeleteDatabaseUser_OnClick(object sender, RoutedEventArgs e)
		{
			var model = (UserStructViewModel)((MenuItem)sender).DataContext;
			_dataBaseAccessService.DeleteDatabaseUser(model.Database, model.UserName);
		}

		private void DeleteDatabase_OnClick(object sender, RoutedEventArgs e)
		{
			var model = (DatabaseStructViewModel)((MenuItem)sender).DataContext;
			_dataBaseAccessService.DeleteDatabase(model.DatabaseName);
		}

		
	}
}
