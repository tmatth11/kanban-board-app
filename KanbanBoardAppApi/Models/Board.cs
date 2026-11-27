using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanBoardAppApi.Models;

public class Board : IAuditable
{
    public Guid Id { get; init; } = Guid.CreateVersion7();

    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [StringLength(75, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;

    [StringLength(250)]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    [ForeignKey(nameof(UserId))]
    public IdentityUser User { get; set; } = null!;

    public ICollection<Column> Columns { get; set; } = [];
}
