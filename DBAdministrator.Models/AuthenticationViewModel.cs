using System.Collections.Generic;
using System.Security;

namespace DBAdministrator.Models
{
	public class AuthenticationViewModel : NotifyPropertyChangedBase
	{
		private string _serverName;
		private string _userName;
		private SecureString _password;

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