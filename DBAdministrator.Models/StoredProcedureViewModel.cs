using System;
using DBAdministrator.Models.Enums;

namespace DBAdministrator.Models
{
	public class StoredProcedureViewModel : NotifyPropertyChangedBase
	{
		public string ProcedureName { get; set; }

		public string Owner { get; set; }

		public string Type { get; set; }

		public string FullName { get; set; }
	}
}