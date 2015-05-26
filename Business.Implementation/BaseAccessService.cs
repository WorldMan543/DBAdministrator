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
	public abstract class BaseAccessService : IAccessService
	{
		protected static IServerConnect _serverConnect;

		protected BaseAccessService(IServerConnect serverConnect)
		{
			_serverConnect = serverConnect;
		}

		public AuthenticationViewModel GetAuthenticationViewModel()
		{
			var authenticationTypes = ReflectionHelpers.GetAllValuesAndDescriptions<AuthenticationType>();
			var serversList = _serverConnect.GetServersList();
			serversList.Insert(0, Constants.DefaultServer);
			return new AuthenticationViewModel()
			{
				AuthenticationTypes = authenticationTypes,
				SelectedAuthenticationType = authenticationTypes.Any()
					? authenticationTypes.First().Key : 0,
				ServersName = serversList,
				ServerName = Constants.DefaultServer
			};
		}

		public void Connect(AuthenticationViewModel authenticationModel)
		{
			if (authenticationModel.SelectedAuthenticationType == 0)
			{
				_serverConnect.Connect(authenticationModel.ServerName);
			}
			else
			{
				_serverConnect.Connect(authenticationModel.ServerName, authenticationModel.UserName, authenticationModel.Password);
			}
			
		}

		public void Disconnect()
		{
			_serverConnect.Disconnect();
		}

		public ServerStructViewModel GetDatabaseTree()
		{
			var databases = _serverConnect.GetDatabaseList();
			var serverRoles = _serverConnect.GetServerRolesList();
			var serverLogins = _serverConnect.GetLoginsList();
			return new ServerStructViewModel()
			{
				Logins = new ObservableCollection<UserStructViewModel>(
					serverLogins.Select(u => new UserStructViewModel() { UserName = u.Name })),
				Roles = new ObservableCollection<RoleStructViewModel>(
					serverRoles.Select(r => new RoleStructViewModel() { RoleName = r.Name })),
				Databases = new ObservableCollection<DatabaseStructViewModel>(
					databases.Select(d => new DatabaseStructViewModel()
					{
						DatabaseName = d.Name,
						Roles = new ObservableCollection<RoleStructViewModel>(
							GetDatabaseRolesList(d.Name).Select(r => new RoleStructViewModel() { RoleName = r.Name, Database = r.Parent.Name })),
						Tables = new ObservableCollection<TableStructViewModel>(
							GetTablesList(d.Name).Select(t => new TableStructViewModel() { TableName = t.Name, Database = t.Parent.Name })),
						Procedures = new ObservableCollection<StoredProcedureStructViewModel>(
							GetStoredProceduresList(d.Name).Select(p => new StoredProcedureStructViewModel() { ProcedureName = p.Name, Database = p.Parent.Name })),
						Users = new ObservableCollection<UserStructViewModel>(
							GetDatabasUsersList(d.Name).Select(u => new UserStructViewModel() { UserName = u.Name, Database = u.Parent.Name })),
					})),
			};
		}

		public IList<DataGridViewModel> ExecuteQuery(string query, string databaseName)
		{
			var tables = _serverConnect.ExecuteQuery(query, databaseName);
			var result = new List<DataGridViewModel>(tables.Count);
			foreach (DataTable table in tables)
			{
				var rows = new List<object>(table.Rows.Count);
				var columns = table.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();
				foreach (var row in table.Rows.Cast<DataRow>())
				{
					var rowResult = new ExpandoObject() as IDictionary<string, object>;
					columns.ForEach(c => rowResult.Add(c, row[c].ToString()));
					rows.Add(rowResult);
				}
				result.Add(new DataGridViewModel()
				{
					Columns = columns.ToList(),
					Rows = rows
				});
			}
			return result;
		}

		public StringCollection ExportData(string databaseName, bool includeTables,
			bool includeTablesData, bool includeStoredProcedures,
			bool includeDescriptiveComments)
		{
			return _serverConnect.ExportData(databaseName, includeTables, includeTablesData,
				includeStoredProcedures, includeDescriptiveComments);
		}

		private IList<Table> GetTablesList(string database)
		{
			return _serverConnect.GetTablesList(database);
		}

		private IList<StoredProcedure> GetStoredProceduresList(string database)
		{
			return _serverConnect.GetStoredProceduresList(database).ToList();
		}

		private IList<DatabaseRole> GetDatabaseRolesList(string database)
		{
			return _serverConnect.GetDatabaseRolesList(database);
		}

		private IList<User> GetDatabasUsersList(string database)
		{
			return _serverConnect.GetDatabaseUsersList(database);
		}

		

	}
}
