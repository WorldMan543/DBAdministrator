using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SMO.Interfaces;
using DBAdministrator.Models;
using DBAdministrator.Models.Enums;
using DBAdministrator.Models.Helpers;
using DBAdministrator.Models.TreeView;
using Microsoft.SqlServer.Management.Smo;
using AuthenticationType = DBAdministrator.Models.Enums.AuthenticationType;
using System.Collections.Specialized;

namespace Business.Implementation
{
	public class ServerUserAccessService : BaseAccessService, IServerUserAccessService
	{

		protected ICollection<LoginViewModel> users;

		public ServerUserAccessService(IServerConnect serverConnect)
			: base(serverConnect) 
		{
		}


		public IList<LoginViewModel> GetLoginInfoList()
		{
			var users = _serverConnect.GetLoginsList();
			return users.Select(u => new LoginViewModel()
			{
				Name = u.Name,
				DefaultDatabase = u.DefaultDatabase,
				Language = u.Language,
				LoginType = ReflectionHelpers.GetCustomDescription((DBAdministrator.Models.Enums.LoginType)((int)u.LoginType)),
				ServerAccess = ReflectionHelpers.GetCustomDescription((ServerAccessType)((int)u.WindowsLoginAccessType))
			}).ToList();
		}



		public void EditServerUser()
		{
			throw new NotImplementedException();
		}

		public void CreateServerUser()
		{
			throw new NotImplementedException();
		}
	}
}
