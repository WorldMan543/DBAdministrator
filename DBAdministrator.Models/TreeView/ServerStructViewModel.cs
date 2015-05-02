using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DBAdministrator.Models.TreeView
{
	public class ServerStructViewModel : NotifyPropertyChangedBase
	{

		private string _serverName;
		public string ServerName
		{
			get
			{
				return _serverName;
			}
			set
			{
				_serverName = value;
				NotifyPropertyChanged("ServerName");
			}
		}

		public ServerStructViewModel()
		{
			Databases = new ObservableCollection<DatabaseStructViewModel>();
			Logins = new ObservableCollection<UserStructViewModel>();
			Roles = new ObservableCollection<RoleStructViewModel>();
		}

		public ObservableCollection<DatabaseStructViewModel> Databases { get; set; }

		public ObservableCollection<UserStructViewModel> Logins { get; set; }

		public ObservableCollection<RoleStructViewModel> Roles { get; set; }
	}
}