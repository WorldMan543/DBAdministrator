namespace DBAdministrator.Models.TreeView
{
	public class TableStructViewModel : NotifyPropertyChangedBase
	{
		public string TableName { get; set; }

		public string Database { get; set; }

		public string Owner { get; set; }
	}
}