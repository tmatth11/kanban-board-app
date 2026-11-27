using KanbanBoardAppApi.Models;
using System.ComponentModel.DataAnnotations;

namespace KanbanBoardAppApi.DTOs;

public record CreateColumnRequest
(
    [Required(ErrorMessage = "Column name is required.")]
    [StringLength(75, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    string Name,

    ColumnColor Color = ColumnColor.Gray
);

public record UpdateColumnRequest
(
    [Required(ErrorMessage = "Column name is required.")]
    [StringLength(75, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    string Name,

    ColumnColor Color = ColumnColor.Gray
);

public record MoveColumnRequest
 (
    [Required(ErrorMessage = "New position is required.")]
    double? NewPosition
 );

public record ColumnResponse
(
    Guid Id,
    string Name,
    ColumnColor Color,
    double Position,
    IReadOnlyList<BoardTaskResponse> BoardTasks
);