using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanBoardAppApi.Models;
public enum Color
{ 
    Gray,
    Red,
    Orange,
    Yellow,
    Green,
    Blue,
    Purple
}

public class Column : IAuditable
{
    public Guid Id { get; init; } = Guid.CreateVersion7();

    [Required]
    public Guid BoardId { get; set; }

    [Required]
    [StringLength(75, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;

    public Color Color { get; set; } = Color.Gray;

    public double Position { get; set; }

    public DateTime CreatedAt { get; set; }

    [ForeignKey(nameof(BoardId))]
    public Board Board { get; set; } = null!;

    public ICollection<BoardTask> BoardTasks { get; set; } = [];
}
