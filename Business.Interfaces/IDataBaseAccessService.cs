﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DBAdministrator.Models;
using System.Net.Security;
using System.Security;
using DBAdministrator.Models.TreeView;

namespace Business.Interfaces
{
	public interface IDataBaseAccessService
	{
		void Connect(AuthenticationViewModel authenticationModel);

		AuthenticationViewModel GetAuthenticationViewModel();

		

		ServerStructViewModel GetDatabaseTree();

		#region Delete

		void DeleteStoredProcedure(string databaseName, string procedureName);

		void DeleteTable(string databaseName, string tableName);

		void DeleteDatabaseRole(string databaseName, string roleName);

		void DeleteDatabaseUser(string databaseName, string userName);

		void DeleteDatabase(string databaseName);

		#endregion 

		
		#region GetInfo
		IList<DatabaseViewModel> GetDatabaseInfoList();

		IList<TableViewModel> GetTableInfoList(string database);

		IList<StoredProcedureViewModel> GetStoredProcedureInfoList(string database);

		IList<UserViewModel> GetUserInfoList(string database);

		IList<LoginViewModel> GetLoginInfoList();

		IList<RoleViewModel> GetRoleInfoList(string database);

		IList<RoleViewModel> GetRoleInfoList();

		#endregion



	}
}