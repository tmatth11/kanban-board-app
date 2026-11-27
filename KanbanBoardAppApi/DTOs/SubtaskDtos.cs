using System.ComponentModel.DataAnnotations;

namespace KanbanBoardAppApi.DTOs;

public record CreateSubtaskRequest
(
    [Required(ErrorMessage = "Subtask name is required.")]
    [StringLength(75, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    string Name
);

public record UpdateSubtaskRequest
(
    [Required(ErrorMessage = "Subtask name is required.")]
    [StringLength(75, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    string Name,

    bool IsCompleted,

    double Position
);

public record SubtaskResponse
(
    Guid Id,
    Guid BoardTaskId,
    string Name,
    bool IsCompleted,
    double Position
);