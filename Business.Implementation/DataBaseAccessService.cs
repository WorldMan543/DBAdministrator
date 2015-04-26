using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMO.Interfaces;
using DBAdministrator.Models;
using DBAdministrator.Models.Enums;
using DBAdministrator.Models.Helpers;

namespace Business.Implementation
{
	public class DataBaseAccessService : IDataBaseAccessService
	{
		private readonly IServerConnect _serverConnect;

		public DataBaseAccessService(IServerConnect serverConnect)
		{
			_serverConnect = serverConnect;
		}

		public AuthenticationViewModel GetAuthenticationViewModel()
		{
			var authenticationTypes = ReflectionHelpers.GetAllValuesAndDescriptions<AuthenticationType>();
			var serversList = _serverConnect.GetServersList();
			return new AuthenticationViewModel()
			{
				AuthenticationTypes = authenticationTypes,
				SelectedAuthenticationType = authenticationTypes.Any()
					? authenticationTypes.First().Key : 0,
				ServersName = serversList,
				ServerName = serversList.FirstOrDefault()
			};
		}

		public void Connect(AuthenticationViewModel authenticationModel)
		{
			_serverConnect.Connect(authenticationModel.ServerName);
		}

	}
}
