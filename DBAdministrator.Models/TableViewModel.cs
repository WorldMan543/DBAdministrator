using System;
using DBAdministrator.Models.Enums;

namespace DBAdministrator.Models
{
	public class TableViewModel : NotifyPropertyChangedBase
	{
		public string TableName { get; set; }

		public string Owner { get; set; }

		public string Type { get; set; }

		public string FullName { get; set; }

		public string FileGroup { get; set; }

	}
}