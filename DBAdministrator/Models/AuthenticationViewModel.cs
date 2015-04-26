using System.Collections.Generic;
using System.Linq;
using System.Security;
using DBAdministrator.Enums;
using DBAdministrator.Helpers;

namespace DBAdministrator.Models
{
	public class AuthenticationViewModel : NotifyPropertyChangedBase
	{
		private string _serverName;
		private string _userName;
		private SecureString _password;

		public AuthenticationViewModel()
		{
			AuthenticationTypes = ReflectionHelpers.GetAllValuesAndDescriptions<AuthenticationType>();
			SelectedAuthenticationType = AuthenticationTypes.Any() 
				? AuthenticationTypes.First().Key : 0;
		}

		public IList<KeyValuePair<int, string>> AuthenticationTypes { get; set; }

		public IList<string> ServersName { get; set; } 

		public int SelectedAuthenticationType { get; set; }

		public string ServerName
		{
			get { return _serverName; }
			set { _serverName = value; NotifyPropertyChanged("ServerName"); }
		}

		public string UserName
		{
			get { return _userName; }
			set { _userName = value; NotifyPropertyChanged("UserName"); }
		}

		public SecureString Password
		{
			get { return _password; }
			set { _password = value; NotifyPropertyChanged("Password"); }
		}

	}
}