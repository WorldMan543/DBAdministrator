using Microsoft.SqlServer.Management.Smo;
using System.Collections.Generic;
using System.Security;

namespace SMO.Interfaces
{
	public interface IServerConnect
	{
		void Connect(string serverName);
		void Connect(string serverName, string userName, SecureString password);
		IList<string> GetServersList();
		IList<Database> GetDatabaseList();
		IList<Table> GetTablesList(string database);
		IList<StoredProcedure> GetStoredProceduresList(string database);
		IList<ServerRole> GetServerRolesList();
		IList<DatabaseRole> GetDatabaseRolesList(string database);
		IList<User> GetDatabasUsersList(string database);

		void DeleteStoredProcedure(string databaseName, string procedureName);

		void DeleteTable(string databaseName, string tableName);

		void DeleteDatabaseRole(string databaseName, string roleName);

		void DeleteDatabaseUser(string databaseName, string userName);

		void DeleteDatabase(string databaseName);

	}
}