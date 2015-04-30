using System.Collections.ObjectModel;

namespace DBAdministrator.Models.TreeView
{
	public class DatabaseStructViewModel : NotifyPropertyChangedBase
	{
		public DatabaseStructViewModel()
		{
			Tables = new ObservableCollection<TableStructViewModel>();
			Procedures = new ObservableCollection<StoredProcedureStructViewModel>();
			Users = new ObservableCollection<UserStructViewModel>();
			Roles = new ObservableCollection<RoleStructViewModel>();
		}

		public string DatabaseName { get; set; }

		public ObservableCollection<TableStructViewModel> Tables { get; set; }

		public ObservableCollection<StoredProcedureStructViewModel> Procedures { get; set; }

		public ObservableCollection<UserStructViewModel> Users { get; set; }

		public ObservableCollection<RoleStructViewModel> Roles { get; set; } 
	
	}
}