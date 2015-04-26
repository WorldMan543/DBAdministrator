using System.Collections;
using System.Collections.Generic;
using DBAdministrator.Models;
using System.Net.Security;
using System.Security;

namespace Business.Interfaces
{
	public interface IDataBaseAccessService
	{
		void Connect(AuthenticationViewModel authenticationModel);

		AuthenticationViewModel GetAuthenticationViewModel();
	}
}