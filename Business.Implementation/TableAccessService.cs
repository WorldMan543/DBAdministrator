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

		public void DeleteTable(string databaseName, string tableName, string schema)
		{
			_serverConnect.DeleteTable(databaseName, tableName, schema);
		}

		public IList<TableViewModel> GetTableInfoList(string database)
		{
			var tables = _serverConnect.GetTablesList(database);
			return tables.Select(t => new TableViewModel()
			{
				TableName = t.Name,
				FullName = string.Format("{0}.{1}", t.Schema, t.Name),
				Owner = t.Schema,
				Type = ReflectionHelpers.GetCustomDescription(t.Schema.Equals("sys")
					? TableType.System : TableType.User)
			}).ToList();
		}

		public void CreateTable(string databaseName, string tableName)
		{
			_serverConnect.CreateTable(databaseName, tableName);
		}

		public void RenameTable(string database, string oldName, string newName, string schema)
		{
			_serverConnect.RenameTable(database, oldName, newName, schema);
		}

		public IList<TableInfoViewModel> GetTableSchema(string database, string tableName, string schema)
		{
			var table = _serverConnect.GetTable(database, tableName, schema);
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

		public void EditTable(IEnumerable<TableInfoViewModel> tableSchema, string tableName, string databaseName, string defaultSchema)
		{
			var table = _serverConnect.GetTable(databaseName, tableName, defaultSchema);
			var oldColumns = table.Columns.Cast<Column>();
			var updatedColumns = oldColumns.Where(c => tableSchema.Select(s => s.ID).Contains(c.ID)).ToList();
			var newColumns = tableSchema.Where(s => s.ID == 0);
			var deletedColumns = oldColumns.Except(updatedColumns).ToList();
			deletedColumns.ForEach(d => d.Drop());
			for(int i = 0; i < updatedColumns.Count(); i++)
			{
				var schema = tableSchema.First(s => s.ID.Equals(updatedColumns[i].ID));
				updatedColumns[i].Nullable = schema.Nullable;
				updatedColumns[i].Rename(schema.Name);
				updatedColumns[i].DataType = new DataType(schema.DataType);
				updatedColumns[i].Alter();
			}
			foreach (var newColumn in newColumns)
			{
				var column = new Column(table, newColumn.Name, new DataType(newColumn.DataType))
				{
					Nullable = newColumn.Nullable
				};
				column.Create();
			}
			table.Alter();
			table.Indexes.Cast<Index>().Where(index => index.IndexKeyType == IndexKeyType.DriPrimaryKey).ToList().ForEach(index => index.MarkForDrop(true));
			foreach (var i in tableSchema.Where(x => x.InPrimaryKey))
			{
				Index index = new Index(table, Guid.NewGuid().ToString());
				index.IndexKeyType = IndexKeyType.DriPrimaryKey;

				//You will have to store the names of columns before deleting the key.
				index.IndexedColumns.Add(new IndexedColumn(index, i.Name));

				table.Indexes.Add(index);
			}
			table.Alter();

		}

	}
}
