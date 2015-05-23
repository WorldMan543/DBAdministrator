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
	public interface IServerRoleAccessService : IAccessService
	{
		
		IList<RoleViewModel> GetRoleInfoList();

		IDictionary<string, bool> GetLoginsRoleInfo(string roleName);

		void UpdateRole(string roleName, IEnumerable<string> loginsWithRole, IEnumerable<string> loginsWithoutRole);


	}
}