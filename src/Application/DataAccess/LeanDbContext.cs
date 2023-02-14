using System;
using System.Collections.Generic;
using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.DataAccess;

public partial class LeanDbContext : DbContext
{
    public LeanDbContext()
    {
    }

    public LeanDbContext(DbContextOptions<LeanDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssemblyStep> AssemblySteps { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    public virtual DbSet<PartDefinition> PartDefinitions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Round> Rounds { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<StationsAssemblyStepss> StationsAssemblyStepsses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("DataSource=Data/lean-db.db;foreign keys=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Part>(entity =>
        {
            entity.HasIndex(e => e.PartDefinitionId, "IX_Parts_PartDefinitionId");

            entity.HasIndex(e => e.ProductId, "IX_Parts_ProductId");

            entity.HasOne(d => d.PartDefinition).WithMany(p => p.Parts)
                .HasForeignKey(d => d.PartDefinitionId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Product).WithMany(p => p.Parts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.RoundId, "IX_Products_RoundId");

            entity.Property(e => e.Start).HasDefaultValueSql("datetime('now')");

            entity.HasOne(d => d.Round).WithMany(p => p.Products)
                .HasForeignKey(d => d.RoundId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Round>(entity =>
        {
            entity.Property(e => e.Start).HasDefaultValueSql("datetime('now')");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasIndex(e => e.RoundId, "IX_Stations_RoundId");

            entity.HasOne(d => d.Round).WithMany(p => p.Stations)
                .HasForeignKey(d => d.RoundId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<StationsAssemblyStepss>(entity =>
        {
            entity.ToTable("StationsAssemblyStepss");

            entity.HasIndex(e => e.AssemblyStepId, "IX_StationsAssemblyStepss_AssemblyStepId");

            entity.HasIndex(e => e.StationId, "IX_StationsAssemblyStepss_StationId");

            entity.HasOne(d => d.AssemblyStep).WithMany(p => p.StationsAssemblyStepsses)
                .HasForeignKey(d => d.AssemblyStepId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Station).WithMany(p => p.StationsAssemblyStepsses)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
