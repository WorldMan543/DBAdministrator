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
	public interface IDatabaseRoleAccessService : IAccessService
	{
		
		void DeleteDatabaseRole(string databaseName, string roleName);

		IList<RoleViewModel> GetRoleInfoList(string database);

		//To do
		void CreateDatabaseRole();

		//To do
		void EditDatabaseRole();

	}
}