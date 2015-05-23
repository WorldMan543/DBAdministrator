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
	public interface IServerUserAccessService : IAccessService
	{

		IList<LoginViewModel> GetLoginInfoList();

		void EditServerUser();

		void CreateServerUser(int loginType, string loginName, string password);

		IList<string> GetLoginsName();

	}
}