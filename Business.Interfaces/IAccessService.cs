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
	public interface IAccessService
	{
		void Connect(AuthenticationViewModel authenticationModel);

		AuthenticationViewModel GetAuthenticationViewModel();

		ServerStructViewModel GetDatabaseTree();

		IList<DataGridViewModel> ExecuteQuery(string query, string databaseName);

		StringCollection ExportData(string databaseName, bool includeTables,
			bool includeTablesData, bool includeStoredProcedures,
			bool includeDescriptiveComments);

	}
}