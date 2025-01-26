using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grizhla.UtilitiesCore.EF.Basic;
using Grizhla.UtilitiesCore.EF.StructuralUtilities;
using Grizhla.UtilitiesCore.Helpers.JsonUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Grizhla.UtilitiesCore.EF;

public class GrizhlaDBContext : DbContext
{
	private readonly bool historyEnabled;

	public GrizhlaDBContext(DbContextOptions options, bool historyEnabled = true) : base(options)
	{
		this.historyEnabled = historyEnabled;
	}

	public DbSet<GrizhlaHistory> __GrizhlaHistory { get; set; }

	public override int SaveChanges()
	{
		this.ChangeTracker.DetectChanges();
		EntityEntry[] added = this.ChangeTracker.Entries()
								.Where(t => t.State == EntityState.Added)
								.ToArray();

		foreach (EntityEntry entry in added)
		{
			if (entry.Entity is GrizhlaRecord)
			{
				GrizhlaRecord? track = entry.Entity as GrizhlaRecord;
				track!.CreatedAt = DateTime.Now;
				if (historyEnabled)
				{
					this.__GrizhlaHistory.Add(new()
					{
						ModelName = entry.GetType().Name,
						PrimaryKey = track.GetPrimaryKey(),
						DBMethod = DBMethod.Add,
						NewState = JsonSerializerUtility.Serialize(track),
						OldState = null
					});
				}
			}
		}

		EntityEntry[] modified = this.ChangeTracker.Entries()
								.Where(t => t.State == EntityState.Modified)
								.ToArray();


		foreach (EntityEntry entry in modified)
		{
			if (entry.Entity is GrizhlaRecord)
			{
				GrizhlaRecord? track = entry.Entity as GrizhlaRecord;
				track!.LastModified = DateTime.Now;
				if (historyEnabled)
				{
					GrizhlaRecord? orginalValues = entry.OriginalValues.ToObject() as GrizhlaRecord;
					this.__GrizhlaHistory.Add(new()
					{
						ModelName = entry.GetType().Name,
						PrimaryKey = track.GetPrimaryKey()!,
						DBMethod = DBMethod.Update,
						NewState = JsonSerializerUtility.Serialize(track),
						OldState = JsonSerializerUtility.Serialize(orginalValues!)
					});
				}
			}
		}

		if (historyEnabled)
		{
			EntityEntry[] deleted = this.ChangeTracker.Entries()
								.Where(t => t.State == EntityState.Deleted)
								.ToArray();
			foreach (EntityEntry entry in deleted)
			{
				GrizhlaRecord? track = entry.Entity as GrizhlaRecord;
				this.__GrizhlaHistory.Add(new()
				{
					ModelName = entry.GetType().Name,
					PrimaryKey = track!.GetPrimaryKey()!,
					DBMethod = DBMethod.Delete,
					NewState = null,
					OldState = JsonSerializerUtility.Serialize(track!)
				});
			}
		}

		//
		return base.SaveChanges();
	}

	public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		return await Task.Run(() => this.SaveChanges());
	}
}
