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
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;

namespace DBAdministrator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			
			InitializeComponent();
			using (Stream s = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DBAdministrator.Resources.SQL.xshd"))
			{
				using (XmlTextReader reader = new XmlTextReader(s))
				{
					MyAvalonEdit.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
				}
			}
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			var server = new ServerConnect();
			server.Connect("WORLDMAN-PC");
			//server.GetServerList();
			server.GetDatabases();
		}
	}
}
