using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanBoardAppApi.Models;

public class BoardTask : IAuditable
{
    public Guid Id { get; init; } = Guid.CreateVersion7();

    [Required]
    public Guid ColumnId { get; set; }

    [Required]
    [StringLength(75, MinimumLength = 1)]
    public string Title { get; set; } = string.Empty;

    [StringLength(5000)]
    public string? Description { get; set; }

    public double Position { get; set; }

    public DateTime CreatedAt { get; set; }

    [ForeignKey(nameof(ColumnId))]
    public Column Column { get; set; } = null!;

    public ICollection<Subtask> Subtasks { get; set; } = [];
}
