using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Business.Implementation;
using Business.Interfaces;
using Microsoft.Practices.Unity;
using SMO.Implementation;
using SMO.Interfaces;

namespace DBAdministrator
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			IUnityContainer container = new UnityContainer();
			container.RegisterType<IDataBaseAccessService, DataBaseAccessService>();
			container.RegisterType<IServerConnect, ServerConnect>();

			var mainWindow = container.Resolve<MainWindow>();
			mainWindow.Show();
		}
	}
}
