using TInterView.Domain.enums;

namespace TInterView.Application.DTOs.Request;

public record AppTaskFilterRequest
{

    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; } = null;
    public AppTaskStatus? Status { get; set; } = null;
}
