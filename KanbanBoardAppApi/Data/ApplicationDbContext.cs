using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using KanbanBoardAppApi.Models;

namespace KanbanBoardAppApi.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<Board> Boards { get; set; }
    public DbSet<Column> Columns { get; set; }
    public DbSet<BoardTask> BoardTasks { get; set; }
    public DbSet<Subtask> Subtasks { get; set; }

    public override int SaveChanges()
    {
        ApplyAuditTimestamps();

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        ApplyAuditTimestamps();

        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyAuditTimestamps()
    {
        var entries = ChangeTracker.Entries<IAuditable>()
            .Where(e => e.State == EntityState.Added);

        foreach (var entry in entries)
        {
            entry.Entity.CreatedAt = DateTime.UtcNow;
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Board>(entity =>
        {
            entity.HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(b => b.UserId);
        });

        builder.Entity<Column>(entity =>
        {
            entity.HasOne(c => c.Board)
                .WithMany(b => b.Columns)
                .HasForeignKey(c => c.BoardId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.Property(c => c.Color)
                .HasConversion<string>()
                .HasMaxLength(20);

            entity.HasIndex(c => new { c.BoardId, c.Position });
        });

        builder.Entity<BoardTask>(entity =>
        {
            entity.HasOne(t => t.Column)
                .WithMany(c => c.BoardTasks)
                .HasForeignKey(t => t.ColumnId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(t => new { t.ColumnId, t.Position });
        });

        builder.Entity<Subtask>(entity =>
        {
            entity.HasOne(s => s.BoardTask)
                .WithMany(t => t.Subtasks)
                .HasForeignKey(s => s.BoardTaskId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(s => new { s.BoardTaskId, s.Position });
        });
    }
}
