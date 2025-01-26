using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grizhla.UtilitiesCore.EF.Basic;

[Table(nameof(GrizhlaHistory))]
public class GrizhlaHistory
{
	[Key]
	public Guid HistoryId { get; set; } = Guid.NewGuid();

	[Column(TypeName = "varchar(63)")]
	public required string ModelName { get; set; }

	[Column(TypeName = "varchar(63)")]
	public required Guid PrimaryKey { get; set; }

	public required DBMethod DBMethod { get; set; }

	[Column(TypeName = "jsonb")]
	public string? OldState { get; set; }

	[Column(TypeName = "jsonb")]
	public string? NewState { get; set; }

	public DateTime Time { get; set; } = DateTime.Now;
}

public enum DBMethod
{
	Add,
	Update,
	Delete
}
