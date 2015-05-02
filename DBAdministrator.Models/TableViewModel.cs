using System;
using DBAdministrator.Models.Enums;

namespace DBAdministrator.Models
{
	public class TableViewModel : NotifyPropertyChangedBase
	{
		public string TableName { get; set; }

		public string Owner { get; set; }

		public string Type { get; set; }

		public DateTime CreateDate { get; set; }

		public long RowsCount { get; set; }

	}
}