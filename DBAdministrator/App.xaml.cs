using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Business.Implementation;
using Business.Interfaces;
using Microsoft.Practices.Unity;
using SMO.Implementation;
using SMO.Interfaces;
using System.Globalization;
using System.Threading;

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
			container.RegisterType<IDatabaseAccessService, DatabaseAccessService>();
			container.RegisterType<IDatabaseRoleAccessService, DatabaseRoleAccessService>();
			container.RegisterType<IDatabaseUserAccessService, DatabaseUserAccessService>();
			container.RegisterType<IServerRoleAccessService, ServerRoleAccessService>();
			container.RegisterType<IServerUserAccessService, ServerUserAccessService>();
			container.RegisterType<ITableAccessService, TableAccessService>();
			container.RegisterType<IStoredProcedureAccessService, StoredProcedureAccessService>();
			container.RegisterType<IServerConnect, ServerConnect>();


			var mainWindow = container.Resolve<MainWindow>();
			mainWindow.Show();
		}

		void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			var exception = e.Exception;
			while (exception.InnerException != null) exception = exception.InnerException;
			MessageBox.Show(exception.Message, "Error");
			e.Handled = true;
		}
	}
}
