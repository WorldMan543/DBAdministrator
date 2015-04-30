using System.Collections.Generic;
using System.Collections.ObjectModel;
using DBAdministrator.Models.TreeView;

namespace DBAdministrator.Models
{
	public class MainWindowViewModel : NotifyPropertyChangedBase
	{
		public MainWindowViewModel()
		{
			ServerStruct = new ObservableCollection<ServerStructViewModel>();
		}

		public StatusBarViewModel StatusBar { get; set; }

		public ObservableCollection<ServerStructViewModel> ServerStruct { get; set; }
	}
}