using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SMO.Interfaces;
using DBAdministrator.Models;
using DBAdministrator.Models.Enums;
using DBAdministrator.Models.Helpers;
using DBAdministrator.Models.TreeView;
using Microsoft.SqlServer.Management.Smo;
using AuthenticationType = DBAdministrator.Models.Enums.AuthenticationType;
using System.Collections.Specialized;

namespace Business.Implementation
{
	public class DatabaseAccessService : BaseAccessService, IDatabaseAccessService
	{
		protected ICollection<DatabaseViewModel> databases;

		public DatabaseAccessService(IServerConnect serverConnect)
			: base(serverConnect)
		{
		}

		public void DeleteDatabase(string databaseName)
		{
			_serverConnect.DeleteDatabase(databaseName);
		}

		public IList<string> GetDatabaseList()
		{
			var databases = _serverConnect.GetDatabaseList();
			return databases.Select(d => d.Name).ToList();
		}

		public IList<DatabaseViewModel> GetDatabaseInfoList()
		{
			var databases = _serverConnect.GetDatabaseList();
			return databases.Select(d => new DatabaseViewModel()
			{
				DatabaseName = d.Name,
				Size = d.Size
			}).ToList();
		}

		public void CreateDatabase(string database)
		{
			_serverConnect.CreateDatabase(database);
		}

	}
}
