using Microsoft.SqlServer.Management.Smo;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Security;

namespace SMO.Interfaces
{
	public interface IServerConnect
	{
		void Connect(string serverName);
		void Connect(string serverName, string userName, SecureString password);

		#region List

		IList<string> GetServersList();
		IList<Database> GetDatabaseList();
		IList<Table> GetTablesList(string database);
		IList<StoredProcedure> GetStoredProceduresList(string database);
		IList<ServerRole> GetServerRolesList();
		IList<DatabaseRole> GetDatabaseRolesList(string database);
		IList<User> GetDatabaseUsersList(string database);
		IList<Login> GetLoginsList();

		#endregion

		#region Delete
		void DeleteStoredProcedure(string databaseName, string procedureName);

		void DeleteTable(string databaseName, string tableName);

		void DeleteDatabaseRole(string databaseName, string roleName);

		void DeleteDatabaseUser(string databaseName, string userName);

		void DeleteDatabase(string databaseName);
		#endregion

		#region Create

		void CreateDatabase(string database);

		void CreateTable(string database, string tableName);

		#endregion

		Table GetTable(string database, string tableName);

		void RenameTable(string database, string oldName, string newName);

		DataTableCollection ExecuteQuery(string query, string databaseName = "AdventureWorks2014");

		StringCollection ExportData(string databaseName, bool includeTables,
			bool includeTablesData, bool includeStoredProcedures,
			bool includeDescriptiveComments);


	}
}