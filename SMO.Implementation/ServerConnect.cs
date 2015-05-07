using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer;
using System.Diagnostics;
using System.Security;
using SMO.Interfaces;

namespace SMO.Implementation
{
	public class ServerConnect : IServerConnect
	{
		private ServerConnection _serverConnection;
		private Server _server;

		#region Connect

		public void Connect(string serverName, string userName, SecureString password)
		{
			_serverConnection = new ServerConnection(serverName, userName, password)
			{
				SqlExecutionModes = SqlExecutionModes.
					ExecuteAndCaptureSql,
				LoginSecure = true
			};
			Connect();
		}

		public void Connect(string serverName)
		{
			_serverConnection = new ServerConnection(serverName)
			{
				SqlExecutionModes = SqlExecutionModes.
					ExecuteAndCaptureSql,
				LoginSecure = true
			};
			Connect();
		}

		private void Connect()
		{
			_serverConnection.Connect();
			_server = new Server(_serverConnection);
		}

		#endregion

		#region GetLists

		public IList<string> GetServersList()
		{
			var dataTable = SmoApplication.EnumAvailableSqlServers(false);
			var result = dataTable.Rows.Count > 0
				? dataTable.Rows.Cast<DataRow>().Select(dr => dr["Name"]).Cast<string>()
				: Enumerable.Empty<string>();
			return result.ToList();
		}

		public IList<Database> GetDatabaseList()
		{
			var databases = _server.Databases;
			return databases.Cast<Database>().ToList();
		}

		public IList<Table> GetTablesList(string database)
		{
			var tables = _server.Databases[database].Tables;
			return tables.Cast<Table>().ToList();
		}

		public IList<StoredProcedure> GetStoredProceduresList(string database)
		{
			var storedProcedures = _server.Databases[database].StoredProcedures;
			return storedProcedures.Cast<StoredProcedure>().ToList();
		}

		public IList<ServerRole> GetServerRolesList()
		{
			var roles = _server.Roles;
			return roles.Cast<ServerRole>().ToList();
		}

		public IList<DatabaseRole> GetDatabaseRolesList(string database)
		{
			var roles = _server.Databases[database].Roles;
			return roles.Cast<DatabaseRole>().ToList();
		}

		public IList<User> GetDatabaseUsersList(string database)
		{
			var users = _server.Databases[database].Users;
			return users.Cast<User>().ToList();
		}


		public IList<Login> GetLoginsList()
		{
			var logins = _server.Logins;
			return logins.Cast<Login>().ToList();
		}

		#endregion

		#region Delete

		public void DeleteStoredProcedure(string databaseName, string procedureName)
		{
			var database = _server.Databases[databaseName];
			var procedure = database.StoredProcedures[procedureName];
			procedure.Drop();
		}

		public void DeleteTable(string databaseName, string tableName)
		{
			var database = _server.Databases[databaseName];
			var table = database.Tables[tableName];
			table.Drop();
		}

		public void DeleteDatabaseRole(string databaseName, string roleName)
		{
			var database = _server.Databases[databaseName];
			var role = database.Roles[roleName];
			role.Drop();
		}

		public void DeleteDatabaseUser(string databaseName, string userName)
		{
			var database = _server.Databases[databaseName];
			var user = database.Users[userName];
			user.Drop();
		}

		public void DeleteDatabase(string databaseName)
		{
			var database = _server.Databases[databaseName];
			database.Drop();
		}

		#endregion

		#region Create

		public void CreateDatabase(string database)
		{
			var newDatabase = new Database(_server, database);
			newDatabase.Create();
		}

		public void CreateTable(string databaseName, string tableName)
		{
			var database = _server.Databases[databaseName];
			var table = new Table(database, tableName);
			var column = new Column(table, "ID", DataType.Int);
			table.Columns.Add(column);
			table.Create();
		}

		#endregion

		public DataTableCollection ExecuteQuery(string query, string databaseName = "AdventureWorks2014")
		{
			var database = _server.Databases[databaseName];
			var result = database.ExecuteWithResults(query);
			return result.Tables;
		}


		public void RenameTable(string databaseName, string oldName, string newName)
		{
			var database = _server.Databases[databaseName];
			var table = database.Tables[oldName];
			table.Rename(newName);
		}


		public Table GetTable(string databaseName, string tableName)
		{
			var database = _server.Databases[databaseName];
			return database.Tables[tableName];
		}
	}
}
