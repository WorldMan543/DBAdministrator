using System.Collections.Generic;
using System.Security;

namespace SMO.Interfaces
{
	public interface IServerConnect
	{
		void Connect(string serverName);
		void Connect(string serverName, string userName, SecureString password);
		IList<string> GetServersList();
	}
}