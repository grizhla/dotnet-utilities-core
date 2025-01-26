using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grizhla.UtilitiesCore.Helpers.DictionaryUtilities;

namespace Grizhla.UtilitiesCore.EF.StructuralUtilities;

public abstract class GrizhlaRecord
{
	public DateTime? LastModified { get; set; }

	public DateTime CreatedAt { get; set; }

	public abstract Guid GetPrimaryKey();
}
