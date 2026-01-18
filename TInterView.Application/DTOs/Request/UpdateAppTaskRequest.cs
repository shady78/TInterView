using System;
using System.Collections.Generic;
using System.Text;
using TInterView.Domain.enums;

namespace TInterView.Application.DTOs.Request;

public record UpdateAppTaskRequest
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime DuDate { get; set; }
    public TaskPriority? Priority { get; set; }
    public AppTaskStatus? Status { get; set; }
}
