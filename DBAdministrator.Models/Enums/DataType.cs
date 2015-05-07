using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace DBAdministrator.Models.Enums
{
	public enum DataType
	{
		[Description("bigint")]
		BigInt = 1,
		[Description("binary")]
		Binary = 2,
		[Description("bit")]
		Bit = 3,
		[Description("char")]
		Char = 4,
		[Description("datetime")]
		DateTime = 6,
		[Description("decimal")]
		Decimal = 7,
		[Description("float")]
		Float = 8,
		[Description("image")]
		Image = 9,
		[Description("int")]
		Int = 10,
		[Description("money")]
		Money = 11,
		[Description("nchar")]
		NChar = 12,
		[Description("ntext")]
		NText = 13,
		[Description("nvarchar")]
		NVarChar = 14,
		[Description("nvarcharmax")]
		NVarCharMax = 15,
		[Description("real")]
		Real = 16,
		[Description("smalldatetime")]
		SmallDateTime = 17,
		[Description("smallint")]
		SmallInt = 18,
		[Description("smallmoney")]
		SmallMoney = 19,
		[Description("text")]
		Text = 20,
		[Description("timestamp")]
		Timestamp = 21,
		[Description("tinyint")]
		TinyInt = 22,
		[Description("uniqueidentifier")]
		UniqueIdentifier = 23,
		[Description("varbinary")]
		VarBinary = 28,
		[Description("varbinarymax")]
		VarBinaryMax = 29,
		[Description("varchar")]
		VarChar = 30,
		[Description("varcharmax")]
		VarCharMax = 31,
		[Description("variant")]
		Variant = 32,
		[Description("xml")]
		Xml = 33,
		[Description("sysname")]
		SysName = 34,
		[Description("numeric")]
		Numeric = 35,
		[Description("date")]
		Date = 36,
		[Description("time")]
		Time = 37,
		[Description("batetimeoffset")]
		DateTimeOffset = 38,
		[Description("datetime2")]
		DateTime2 = 39,
		[Description("hierarchyid")]
		HierarchyId = 41,
		[Description("geometry")]
		Geometry = 42,
		[Description("geography")]
		Geography = 43
	}
}