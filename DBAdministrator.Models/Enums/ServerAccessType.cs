using System.ComponentModel;

namespace DBAdministrator.Models.Enums
{
	public enum ServerAccessType
	{
		[Description("Undefined")]
		Undefined = 0,
		[Description("Grant")]
		Grant = 1,
		[Description("Deny")]
		Deny = 2,
		[Description("Windows Authentication")]
		NonNTLogin = 99
	}
}