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
	public class TableAccessService : BaseAccessService, ITableAccessService
	{
		protected ICollection<TableViewModel> tables;

		public TableAccessService(IServerConnect serverConnect)
			: base(serverConnect)
		{
		}

		public void DeleteTable(string databaseName, string tableName)
		{
			_serverConnect.DeleteTable(databaseName, tableName);
		}

		public IList<TableViewModel> GetTableInfoList(string database)
		{
			var tables = _serverConnect.GetTablesList(database);
			return tables.Select(t => new TableViewModel()
			{
				TableName = t.Name,
				CreateDate = t.CreateDate,
				RowsCount = t.RowCount,
				Owner = t.Owner,
				Type = ReflectionHelpers.GetCustomDescription(t.IsSystemObject 
					? TableType.System : TableType.User)
			}).ToList();
		}

		public void CreateTable(string databaseName, string tableName)
		{
			_serverConnect.CreateTable(databaseName, tableName);
		}

		public void RenameTable(string database, string oldName, string newName)
		{
			_serverConnect.RenameTable(database, oldName, newName);
		}

		public IList<TableInfoViewModel> GetTableSchema(string database, string tableName)
		{
			var table = _serverConnect.GetTable(database, tableName);
			return table.Columns.Cast<Column>().Select(c => new TableInfoViewModel
			{
				ID = c.ID,
				Name = c.Name,
				Identity = c.Identity,
				Nullable = c.Nullable,
				InPrimaryKey = c.InPrimaryKey,
				DataType = c.DataType.SqlDataType,
				MaxLength = c.DataType.MaximumLength,
				Default = c.DefaultConstraint != null ? c.DefaultConstraint.Text : null
			}).ToList();
		}

		public void EditTable(IEnumerable<TableInfoViewModel> tableSchema, string tableName, string databaseName)
		{
			var table = _serverConnect.GetTable(databaseName, tableName);
			var oldColumns = table.Columns.Cast<Column>();
			var updatedColumns = oldColumns.Where(c => tableSchema.Select(s => s.ID).Contains(c.ID)).ToList();
			var newColumns = tableSchema.Where(s => s.ID == 0);
			var deletedColumns = oldColumns.Except(updatedColumns).ToList();
			deletedColumns.ForEach(d => d.Drop());
			//var transfer = new Transfer(new Database());
			for(int i = 0; i < updatedColumns.Count(); i++)
			{
				if (!updatedColumns[i].InPrimaryKey)
				{
					var schema = tableSchema.First(s => s.ID.Equals(updatedColumns[i].ID));
					//updatedColumn.Identity = schema.Identity;
					updatedColumns[i].Nullable = schema.Nullable;
					//updatedColumn.InPrimaryKey = schema.InPrimaryKey;
					updatedColumns[i].Rename(schema.Name);
					//updatedColumn.Set Name = schema.Name;
					updatedColumns[i].DataType = new DataType(schema.DataType);
					updatedColumns[i].Alter();
				}

			}
			foreach (var newColumn in newColumns)
			{
				var column = new Column(table, newColumn.Name, new DataType(newColumn.DataType))
				{
					//Identity = newColumn.Identity,
					Nullable = newColumn.Nullable,
					//InPrimaryKey = newColumn.InPrimaryKey
				};
				column.Create();
			}
		}

	}
}
