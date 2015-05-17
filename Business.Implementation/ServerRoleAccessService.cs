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
	public class ServerRoleAccessService : BaseAccessService, IServerRoleAccessService
	{
		protected ICollection<ServerRoleViewModel> roles;

		public ServerRoleAccessService(IServerConnect serverConnect)
			: base(serverConnect)
		{
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

	}
}
