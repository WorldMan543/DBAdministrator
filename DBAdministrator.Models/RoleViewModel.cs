using System;

namespace DBAdministrator.Models
{
	public class RoleViewModel
	{
		public string Name { get; set; }

		public string Owner { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime DateLastModified { get; set; }
	}
}