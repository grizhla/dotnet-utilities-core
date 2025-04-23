using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grizhla.UtilitiesCore.Helpers.DictionaryUtilities;
using Grizhla.UtilitiesCore.Helpers.Extensions;

namespace Grizhla.UtilitiesCore.EF.StructuralUtilities;

public abstract class GrizhlaRecord
{
    public DateTime CreatedAt { get; set; }

    public DateTime? LastModified { get; set; }

    public abstract Guid GetPrimaryKey();
}
