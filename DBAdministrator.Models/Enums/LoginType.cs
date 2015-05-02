using System.ComponentModel;

namespace DBAdministrator.Models.Enums
{
	public enum LoginType
	{
		[Description("Windows User")]
		WindowsUser = 0,
		[Description("Windows Group")]
		WindowsGroup = 1,
		[Description("SQL Server Login")]
		SqlLogin = 2,
		[Description("Certificate")]
		Certificate = 3,
		[Description("Asymmetric Key")]
		AsymmetricKey = 4,
	}
}