using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanBoardAppApi.Models;

public class Subtask : IAuditable
{
    public Guid Id { get; init; } = Guid.CreateVersion7();

    [Required]
    public Guid BoardTaskId { get; set; }

    [Required]
    [StringLength(75, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;

    public bool IsCompleted { get; set; } = false;

    public double Position { get; set; }

    public DateTime CreatedAt { get; set; }

    [ForeignKey(nameof(BoardTaskId))]
    public BoardTask BoardTask { get; set; } = null!;
}
