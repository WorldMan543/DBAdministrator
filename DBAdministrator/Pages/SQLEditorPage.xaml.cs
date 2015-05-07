using System;
using System.Collections.Generic;
using System.Dynamic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Business.Interfaces;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Win32;

namespace DBAdministrator.Pages
{
	/// <summary>
	/// Interaction logic for SQLEditorPage.xaml
	/// </summary>
	public partial class SQLEditorPage : Page
	{
		private readonly IDataBaseAccessService _dataBaseAccessService;

		public SQLEditorPage(IDataBaseAccessService dataBaseAccessService)
		{
			_dataBaseAccessService = dataBaseAccessService;
			InitializeComponent();
		}

		private void EnableSqlHighlighting()
		{
			using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DBAdministrator.Resources.SQL.xshd"))
			{
				if (stream == null) return;
				using (var reader = new XmlTextReader(stream))
				{
					Editor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
				}
			}
		}

		private void SQLEditorPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			EnableSqlHighlighting();
		}

		private void LoadQuery_OnClick(object sender, RoutedEventArgs e)
		{
			var dialog = new OpenFileDialog
			{
				DefaultExt = ".sql",
				Filter = "SQL Documents (.sql)|*.sql"
			};
			var result = dialog.ShowDialog();
			if (result == true)
			{
				var text = File.ReadAllText(dialog.FileName);
				Editor.Text = text;
			}
		}

		private void SaveQuery_OnClick(object sender, RoutedEventArgs e)
		{
			var dialog = new SaveFileDialog
			{
				DefaultExt = ".sql",
				Filter = "SQL Documents (.sql)|*.sql"
			};
			var result = dialog.ShowDialog();
			if (result == true)
			{
				File.WriteAllText(dialog.FileName, Editor.Text);
			}
		}

		private void ExecuteQuery_OnClick(object sender, RoutedEventArgs e)
		{
			var viewModels = _dataBaseAccessService.ExecuteQuery(Editor.Text, "AdventureWorks2014");
			foreach (var viewModel in viewModels)
			{
				var item = new TabItem {Header = "Request 1"};
				TabControl1.Items.Add(item);
				var datagrid = new DataGrid {IsReadOnly = true};
				foreach (var columnName in viewModel.Columns)
				{
					var column = new DataGridTextColumn
					{
						Header = columnName,
						Binding = new Binding(columnName)
					};
					datagrid.Columns.Add(column);
				}
				viewModel.Rows.ForEach(r => datagrid.Items.Add(r));
				item.Content = datagrid;
			}
		}
	}
}
