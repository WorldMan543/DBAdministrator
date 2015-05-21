using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DBAdministrator.Models;
using System.Net.Security;
using System.Security;
using DBAdministrator.Models.TreeView;
using System.Collections.Specialized;

namespace Business.Interfaces
{
	public interface IDatabaseAccessService : IAccessService
	{
		void DeleteDatabase(string databaseName);

		IList<DatabaseViewModel> GetDatabaseInfoList();

		void CreateDatabase(string database);

		IList<string> GetDatabaseList();

	}
}