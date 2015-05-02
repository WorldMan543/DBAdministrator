using System.ComponentModel;

namespace DBAdministrator.Models.Enums
{
	public enum TableType
	{
		[Description("User")]
		User = 0,
		[Description("System")]
		System = 1
	}
}