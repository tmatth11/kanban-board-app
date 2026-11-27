using System.ComponentModel.DataAnnotations;

namespace KanbanBoardAppApi.DTOs;

public record CreateBoardTaskRequest
(
    [Required(ErrorMessage = "Board task title is required.")]
    [StringLength(75, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    string Title,

    [StringLength(5000, ErrorMessage = "Board task description must not exceed 5000 characters.")]
    string? Description,

    IReadOnlyList<string>? Subtasks
);

public record UpdateBoardTaskRequest
(
    [Required(ErrorMessage = "Board task title is required.")]
    [StringLength(75, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    string Title,

    [StringLength(5000, ErrorMessage = "Board task description must not exceed 5000 characters.")]
    string? Description,

    [Required(ErrorMessage = "Column ID is required.")]
    Guid? ColumnId
);

public record MoveBoardTaskRequest
(
    [Required(ErrorMessage = "Target column ID is required.")]
    Guid TargetColumnId,

    double NewPosition
);

public record BoardTaskResponse
(
    Guid Id,
    Guid ColumnId,
    string Title,
    string? Description,
    double Position,
    DateTime CreatedAt,
    IReadOnlyList<SubtaskResponse> Subtasks
);