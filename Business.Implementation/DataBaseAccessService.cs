using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMO.Interfaces;

namespace Business.Implementation
{
	public class DataBaseAccessService : IDataBaseAccessService
	{

		public IServerConnect _serverConnect { get; set; }
		public DataBaseAccessService(IServerConnect serverConnect)
		{
			_serverConnect = serverConnect;
		}
	}
}
