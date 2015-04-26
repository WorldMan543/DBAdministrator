using System.ComponentModel;

namespace DBAdministrator.Models.Enums
{
	
	public enum AuthenticationType
	{
		[Description("Windows Authentication")]
		Windows = 0,
		[Description("SQL Server Authentication")]
		Server = 1
	}
}