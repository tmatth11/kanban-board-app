using System.ComponentModel.DataAnnotations;

namespace KanbanBoardAppApi.DTOs;

public record CreateBoardRequest
(
    [Required(ErrorMessage = "Board name is required.")]
    [StringLength(75, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    string Name,

    [StringLength(250, ErrorMessage = "{0} must not exceed {1} characters.")]
    string? Description
);

public record UpdateBoardRequest
(
    [Required(ErrorMessage = "Board name is required.")]
    [StringLength(75, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    string Name,

    [StringLength(250, ErrorMessage = "{0} must not exceed {1} characters.")]
    string? Description
);

public record BoardSummaryResponse
(
    Guid Id,
    string Name,
    string? Description,
    DateTime CreatedAt
);

public record BoardDetailResponse
(
    Guid Id,
    string Name,
    string? Description,
    DateTime CreatedAt,
    IReadOnlyList<ColumnResponse> Columns
);