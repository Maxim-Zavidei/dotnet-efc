using System;
using System.Collections.Generic;
using Basics.Console;
using Basics.Console.Models;
using Microsoft.EntityFrameworkCore;

namespace Basics.Console.DataAccess;

public partial class BasicsContext : DbContext
{
    public BasicsContext()
    {
    }

    public BasicsContext(DbContextOptions<BasicsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Entity> Entities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("DataSource=Data/basics.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entity>(entity =>
        {
            entity.ToTable("Entity");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("INT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
