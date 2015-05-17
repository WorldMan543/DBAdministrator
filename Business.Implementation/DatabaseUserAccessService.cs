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
	public class DatabaseUserAccessService : BaseAccessService, IDatabaseUserAccessService
	{
		protected ICollection<UserViewModel> users;
		public DatabaseUserAccessService(IServerConnect serverConnect)
			: base(serverConnect)
		{
		}

		public void DeleteDatabaseUser(string databaseName, string userName)
		{
			_serverConnect.DeleteDatabaseUser(databaseName, userName);
		}

		public IList<UserViewModel> GetUserInfoList(string database)
		{
			var users = _serverConnect.GetDatabaseUsersList(database);
			return users.Select(u => new UserViewModel()
			{
				Name = u.Name,
				Permit = u.HasDBAccess
			}).ToList();
		}

		public void CreateUser()
		{
			throw new System.NotImplementedException();
		}

		public void EditUser()
		{
			throw new System.NotImplementedException();
		}
	}
}
