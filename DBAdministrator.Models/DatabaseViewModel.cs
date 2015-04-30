using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAdministrator.Models 
{
	public class DatabaseViewModel : NotifyPropertyChangedBase
	{
		public string DatabaseName { get; set; }
		public double Size { get; set; }
	}
}
