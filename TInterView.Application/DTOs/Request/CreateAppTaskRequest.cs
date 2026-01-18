using TInterView.Domain.enums;

namespace TInterView.Application.DTOs.Request;

public record CreateAppTaskRequest
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime DuDate { get; set; }
    public TaskPriority Priority { get; set; }
    //public AppTaskStatus Status { get; set; }
}
