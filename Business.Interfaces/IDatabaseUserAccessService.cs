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
	public interface IDatabaseUserAccessService : IAccessService
	{

		void DeleteDatabaseUser(string databaseName, string userName);

		IList<UserViewModel> GetUserInfoList(string database);

		void CreateDatabaseUser(string databaseName, string userName, string loginName);

	}
}