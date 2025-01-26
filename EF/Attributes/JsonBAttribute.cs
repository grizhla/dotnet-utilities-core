using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grizhla.UtilitiesCore.EF.Attributes;
public class JsonBAttribute : ColumnAttribute
{
	public JsonBAttribute() : base()
	{
		this.TypeName = "jsonb";
	}
}
