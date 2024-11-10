using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ToDoTask.Models;

public partial class TodotasksContext : DbContext
{
    public TodotasksContext(DbContextOptions<TodotasksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Statustask> Statustask { get; set; }

    public virtual DbSet<Tasks> Tasks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Statustask>(entity =>
        {
            entity.HasKey(e => e.IdStatusTasks).HasName("PRIMARY");

            entity.ToTable("statustask");

            entity.Property(e => e.IdStatusTasks).HasColumnName("idStatusTasks");
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<Tasks>(entity =>
        {
            entity.HasKey(e => e.IdTasks).HasName("PRIMARY");

            entity.ToTable("tasks");

            entity.HasIndex(e => e.IdStatusTasks, "Tasks_FK");

            entity.Property(e => e.IdTasks).HasColumnName("idTasks");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.IdStatusTasks).HasColumnName("idStatusTasks");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.IdStatusTasksNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdStatusTasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tasks_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
