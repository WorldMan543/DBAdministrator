using System.Collections.Generic;

namespace DBAdministrator.Models
{
	public class DataGridViewModel
	{
		public DataGridViewModel()
		{
			Columns = new List<string>();
			Rows = new List<object>();
		}

		public IList<string> Columns { get; set; }

		public IList<object> Rows { get; set; } 
	}
}