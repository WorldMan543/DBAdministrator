using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAdministrator.Models
{
	public class ServerRoleViewModel
	{
		public string Name { get; set; }

		public string Owner { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime DateLastModified { get; set; }
	}
}
