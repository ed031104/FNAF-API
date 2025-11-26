using System;
using System.Collections.Generic;
using Api_FNAF.DBOjects;
using Microsoft.EntityFrameworkCore;

namespace Api_FNAF.Context;

public partial class FNAFContext : DbContext
{
    public FNAFContext()
    {
    }

    public FNAFContext(DbContextOptions<FNAFContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animatronic> Animatronics { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<TypeAnimatronic> TypeAnimatronics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animatronic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Animatro__3213E83FEEAB86C8");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdGamesNavigation).WithMany(p => p.Animatronics).HasConstraintName("FK__Animatron__id_ga__3D5E1FD2");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Animatronics).HasConstraintName("FK__Animatron__id_ty__3C69FB99");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__games__3213E83FFC1687D0");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<TypeAnimatronic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__typeAnim__3213E83FCF4CC3D0");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
