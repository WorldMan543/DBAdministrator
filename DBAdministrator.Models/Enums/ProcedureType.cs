using System.ComponentModel;

namespace DBAdministrator.Models.Enums
{
	public enum ProcedureType
	{
		[Description("User")]
		User = 0,
		[Description("System")]
		System = 1
	}
}