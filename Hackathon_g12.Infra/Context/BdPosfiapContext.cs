using Hackathon_g12.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_g12.Infra.Context;

public partial class BdPosfiapContext : DbContext
{
    public BdPosfiapContext(DbContextOptions<BdPosfiapContext> options)
        : base(options)
    {
		ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		ChangeTracker.AutoDetectChangesEnabled = false;
	}

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("VIDEOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DESCRICAO");
            entity.Property(e => e.Dtcad)
                .HasColumnType("datetime")
                .HasColumnName("DTCAD");
            entity.Property(e => e.Dtproc)
                .HasColumnType("datetime")
                .HasColumnName("DTPROC");
            entity.Property(e => e.Situacao)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SITUACAO");
        });

		base.OnModelCreating(modelBuilder);
	}

    

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
	{
		foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
		{
			if (entry.State == EntityState.Added)
			{
				entry.Property("DTCAD").CurrentValue = DateTime.UtcNow;
			}
		}

		return base.SaveChangesAsync(cancellationToken);
	}
}
