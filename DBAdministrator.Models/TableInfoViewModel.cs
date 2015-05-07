namespace DBAdministrator.Models
{
	public class TableInfoViewModel
	{
		public string Name { get; set; }
		public bool Identity { get; set; }
		public bool Nullable { get; set; }
		public bool InPrimaryKey { get; set; }
		public string DataType { get; set; }
		public int MaxLength { get; set; }
		public string Default { get; set; }
	}
}