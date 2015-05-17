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
	public interface IStoredProcedureAccessService : IAccessService
	{

		void DeleteStoredProcedure(string databaseName, string procedureName);

		IList<StoredProcedureViewModel> GetStoredProcedureInfoList(string database);

		//To do
		void CreateStoredProcedure();

		//To do
		void EditStoredProcedure();

	}
}