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

namespace SMO.Implementation
{
	public class ServerConnect
	{
		private ServerConnection ServerConn;
		private Server SqlServerSelection;
		private Boolean ErrorFlag;
		
		public void Connect(string serverName)
		{
			try
			{
				ServerConn = new ServerConnection();
				ServerConn.ServerInstance = serverName;
				ServerConn.SqlExecutionModes = SqlExecutionModes.
						ExecuteAndCaptureSql;
				ServerConn.LoginSecure = true;
				ServerConn.Connect();
				SqlServerSelection = new Server(ServerConn);
				ErrorFlag = true;
			}
			catch (ConnectionFailureException ex)
			{
				Debug.WriteLine(ex.Message);
				ErrorFlag = true;
			}
			catch (SmoException ex)
			{
				Debug.WriteLine(ex.Message);
				ErrorFlag = true;
			}

		}

		public void GetServerList()
		{
			List<object> servers = new List<object>();
			DataTable dt = SmoApplication.EnumAvailableSqlServers(false);
			if (dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					servers.Add(dr["Name"]);
				}
				ErrorFlag = true;
			}
			else
			{
				ErrorFlag = true;
			}
		}

		public void GetDatabases()
		{
			var dd = SqlServerSelection.Databases;
			ErrorFlag = true;
		}

		

		

	}
}
