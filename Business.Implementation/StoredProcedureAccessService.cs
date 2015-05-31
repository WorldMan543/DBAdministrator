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
	public class StoredProcedureAccessService : BaseAccessService, IStoredProcedureAccessService
	{
		protected ICollection<StoredProcedureViewModel> storedProcedures;

		public StoredProcedureAccessService(IServerConnect serverConnect)
			: base(serverConnect)
		{
		}

		public void DeleteStoredProcedure(string databaseName, string procedureName, string schema)
		{
			_serverConnect.DeleteStoredProcedure(databaseName, procedureName, schema);
		}


		public IList<StoredProcedureViewModel> GetStoredProcedureInfoList(string database)
		{
			var procedures = _serverConnect.GetStoredProceduresList(database);
			return procedures.AsQueryable().Select(p => new StoredProcedureViewModel()
			{
				ProcedureName = p.Name,
				FullName = string.Format("{0}.{1}", p.Schema, p.Name),
				Owner = p.Schema,
				Type = ReflectionHelpers.GetCustomDescription(p.Schema.Equals("sys")
					? ProcedureType.System : ProcedureType.User)
			}).ToList();
		}

		public string GetAlterStoredProcedure(string database, string procedureName, string schema)
		{
			return _serverConnect.GetAlterStoredProcedure(database, procedureName, schema);
		}

	}
}
