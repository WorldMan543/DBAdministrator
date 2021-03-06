﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DBAdministrator.Models;
using System.Net.Security;
using System.Security;
using DBAdministrator.Models.TreeView;
using System.Collections.Specialized;

namespace Business.Interfaces
{
	public interface ITableAccessService : IAccessService
	{

		void DeleteTable(string databaseName, string tableName, string schema);

		IList<TableViewModel> GetTableInfoList(string database);

		void CreateTable(string databaseName, string tableName);

		void RenameTable(string database, string oldName, string newName, string schema);

		IList<TableInfoViewModel> GetTableSchema(string database, string tableName, string schema);

		void EditTable(IEnumerable<TableInfoViewModel> tableSchema, string talbeName, string databaseName, string schema);


	}
}