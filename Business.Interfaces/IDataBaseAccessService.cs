using System.Collections;
using System.Collections.Generic;
using DBAdministrator.Models;
using System.Net.Security;
using System.Security;
using DBAdministrator.Models.TreeView;

namespace Business.Interfaces
{
	public interface IDataBaseAccessService
	{
		void Connect(AuthenticationViewModel authenticationModel);

		AuthenticationViewModel GetAuthenticationViewModel();

		

		ServerStructViewModel GetDatabaseTree();

		#region GetInfo

		IList<DatabaseViewModel> GetDatabaseInfoList();

		#endregion

		#region Delete

		void DeleteStoredProcedure(string databaseName, string procedureName);

		void DeleteTable(string databaseName, string tableName);

		void DeleteDatabaseRole(string databaseName, string roleName);

		void DeleteDatabaseUser(string databaseName, string userName);

		void DeleteDatabase(string databaseName);

		#endregion 



	}
}