using Microsoft.SqlServer.Management.Smo;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace DBAdministrator.Models
{
	public class TableInfoViewModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public bool Identity { get; set; }
		public bool Nullable { get; set; }
		public bool InPrimaryKey { get; set; }
		public SqlDataType DataType { get; set; }
		public int MaxLength { get; set; }
		public string Default { get; set; }
	}
}