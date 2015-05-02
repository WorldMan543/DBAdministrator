using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMO.Interfaces;
using DBAdministrator.Models;
using DBAdministrator.Models.Enums;
using DBAdministrator.Models.Helpers;
using DBAdministrator.Models.TreeView;
using Microsoft.SqlServer.Management.Smo;
using AuthenticationType = DBAdministrator.Models.Enums.AuthenticationType;

namespace Business.Implementation
{
	public class DataBaseAccessService : IDataBaseAccessService
	{
		private readonly IServerConnect _serverConnect;

		public DataBaseAccessService(IServerConnect serverConnect)
		{
			_serverConnect = serverConnect;
		}

		#region Connect

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
			_serverConnect.Connect(authenticationModel.ServerName);
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

		private IList<Table> GetTablesList(string database)
		{
			return _serverConnect.GetTablesList(database);
		}

		private IList<StoredProcedure> GetStoredProceduresList(string database)
		{
			return _serverConnect.GetStoredProceduresList(database);
		}

		private IList<DatabaseRole> GetDatabaseRolesList(string database)
		{
			return _serverConnect.GetDatabaseRolesList(database);
		}

		private IList<User> GetDatabasUsersList(string database)
		{
			return _serverConnect.GetDatabaseUsersList(database);
		}

		#endregion

		#region Delete

		public void DeleteStoredProcedure(string databaseName, string procedureName)
		{
			_serverConnect.DeleteStoredProcedure(databaseName, procedureName);
		}


		public void DeleteTable(string databaseName, string tableName)
		{
			_serverConnect.DeleteTable(databaseName, tableName);
		}

		public void DeleteDatabaseRole(string databaseName, string roleName)
		{
			_serverConnect.DeleteDatabaseRole(databaseName, roleName);
		}

		public void DeleteDatabaseUser(string databaseName, string userName)
		{
			_serverConnect.DeleteDatabaseUser(databaseName, userName);
		}

		public void DeleteDatabase(string databaseName)
		{
			_serverConnect.DeleteDatabase(databaseName);
		}

		#endregion

		#region GetInfo

		public IList<DatabaseViewModel> GetDatabaseInfoList()
		{
			var databases = _serverConnect.GetDatabaseList();
			return databases.Select(d => new DatabaseViewModel()
			{
				DatabaseName = d.Name,
				Size = d.Size
			}).ToList();
		}

		public IList<TableViewModel> GetTableInfoList(string database)
		{
			var tables = _serverConnect.GetTablesList(database);
			return tables.Select(t => new TableViewModel()
			{
				TableName = t.Name,
				CreateDate = t.CreateDate,
				RowsCount = t.RowCount,
				Owner = t.Owner,
				Type = ReflectionHelpers.GetCustomDescription(t.IsSystemObject 
					? TableType.System : TableType.User)
			}).ToList();
		}


		public IList<StoredProcedureViewModel> GetStoredProcedureInfoList(string database)
		{
			var procedures = _serverConnect.GetStoredProceduresList(database);
			return procedures.Select(p => new StoredProcedureViewModel()
			{
				ProcedureName = p.Name,
				CreateDate = p.CreateDate,
				Owner = p.Owner,
				Type = ReflectionHelpers.GetCustomDescription(p.IsSystemObject
					? ProcedureType.System : ProcedureType.User)
			}).ToList();
		}

		#endregion

		public IList<UserViewModel> GetUserInfoList(string database)
		{
			var users = _serverConnect.GetDatabaseUsersList(database);
			return users.Select(u => new UserViewModel()
			{
				Name = u.Name,
				Permit = u.HasDBAccess
			}).ToList();
		}

		public IList<RoleViewModel> GetRoleInfoList(string database)
		{
			var roles = _serverConnect.GetDatabaseRolesList(database);
			return roles.Select(r => new RoleViewModel()
			{
				Name = r.Name,
				CreateDate = r.CreateDate,
 				DateLastModified = r.DateLastModified,
				Owner = r.Owner
			}).ToList();
		}

		public IList<RoleViewModel> GetRoleInfoList()
		{
			var roles = _serverConnect.GetServerRolesList();
			return roles.Select(r => new RoleViewModel()
			{
				Name = r.Name,
				CreateDate = r.DateCreated,
				DateLastModified = r.DateModified,
				Owner = r.Owner,

			}).ToList();
		}


		public IList<LoginViewModel> GetLoginInfoList()
		{
			var users = _serverConnect.GetLoginsList();
			return users.Select(u => new LoginViewModel()
			{
				Name = u.Name,
				DefaultDatabase = u.DefaultDatabase,
				Language = u.Language,
				LoginType = ReflectionHelpers.GetCustomDescription((DBAdministrator.Models.Enums.LoginType)((int)u.LoginType)),
				ServerAccess = ReflectionHelpers.GetCustomDescription((ServerAccessType)((int)u.WindowsLoginAccessType))
			}).ToList();
		}
	}
}
