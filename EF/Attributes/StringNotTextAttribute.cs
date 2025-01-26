using System.ComponentModel.DataAnnotations.Schema;

namespace Grizhla.UtilitiesCore.EF.Attributes;

public class StringNotTextAttribute : ColumnAttribute
{
	public StringNotTextAttribute(int i = 127) : base()
	{
		this.TypeName = $"varchar({i})";
	}
}