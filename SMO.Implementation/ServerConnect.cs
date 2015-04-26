using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer;
using System.Diagnostics;
using System.Security;
using SMO.Interfaces;

namespace SMO.Implementation
{
	public class ServerConnect : IServerConnect
	{
		private ServerConnection _serverConnection;
		private Server _server;

		public void Connect(string serverName, string userName, SecureString password)
		{
			_serverConnection = new ServerConnection(serverName, userName, password)
			{
				SqlExecutionModes = SqlExecutionModes.
					ExecuteAndCaptureSql,
				LoginSecure = true
			};
			Connect();
		}

		public void Connect(string serverName)
		{
			_serverConnection = new ServerConnection(serverName)
			{
				SqlExecutionModes = SqlExecutionModes.
					ExecuteAndCaptureSql,
				LoginSecure = true
			};
			Connect();
		}

		private void Connect()
		{
			_serverConnection.Connect();
			_server = new Server(_serverConnection);
		}

		public IList<string> GetServersList()
		{
			var dataTable = SmoApplication.EnumAvailableSqlServers(false);
			var result = dataTable.Rows.Count > 0 
				? dataTable.Rows.Cast<DataRow>().Select(dr => dr["Name"]).Cast<string>()
				: Enumerable.Empty<string>();
			return result.ToList();
		}

		public void GetDatabases()
		{
			var dd = _server.Databases;
		}

		

		

	}
}
