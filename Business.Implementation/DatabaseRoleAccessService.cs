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
	public class DatabaseRoleAccessService : BaseAccessService, IDatabaseRoleAccessService
	{
		protected ICollection<RoleViewModel> roles;

		public DatabaseRoleAccessService(IServerConnect serverConnect)
			: base(serverConnect)
		{
		}

		public void DeleteDatabaseRole(string databaseName, string roleName)
		{
			_serverConnect.DeleteDatabaseRole(databaseName, roleName);
		}

		public IList<RoleViewModel> GetRoleInfoList(string database)
		{
			var roles = _serverConnect.GetDatabaseRolesList(database);
			return roles.Select(r => new RoleViewModel()
			{
				Name = r.Name,
				CreateDate = r.CreateDate,
				DateLastModified = r.DateLastModified,
				Owner = r.Owner
			}).ToList();
		}

		public IList<RoleViewModel> GetRoleInfoList()
		{
			var roles = _serverConnect.GetServerRolesList();
			return roles.Select(r => new RoleViewModel()
			{
				Name = r.Name,
				CreateDate = r.DateCreated,
				DateLastModified = r.DateModified,
				Owner = r.Owner,

			}).ToList();
		}



		public void CreateDatabaseRole()
		{
			throw new NotImplementedException();
		}

		public void EditDatabaseRole()
		{
			throw new NotImplementedException();
		}
	}
}
