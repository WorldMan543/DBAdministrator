namespace DBAdministrator.Models
{
	public class StatusBarViewModel : NotifyPropertyChangedBase
	{

		private string _serverName;
		public string ServerName
		{
			get
			{
				var result = !string.IsNullOrWhiteSpace(_serverName)
					? string.Format("Server Name: {0}", _serverName)
					: string.Empty;
				return result;
			}
			set
			{
				_serverName = value; 
				NotifyPropertyChanged("ServerName");
			}
		}
	}
}