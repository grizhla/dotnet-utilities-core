using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grizhla.UtilitiesCore.EF.Basic;

[Table($"__{nameof(GrizhlaHistory)}")]
public class GrizhlaHistory
{
	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int HistoryId { get; set; }

	public required string ModelName { get; set; }

	public required string PrimaryKey { get; set; }

	public required DBMethod DBMethod { get; set; }

	[Column(TypeName = "jsonb")]
	public string? OldState { get; set; }

	[Column(TypeName = "jsonb")]
	public string? NewState { get; set; }

	public DateTime OnTime { get; set; } = DateTime.Now;
}

public enum DBMethod
{
	Add,
	Update,
	Delete
}
