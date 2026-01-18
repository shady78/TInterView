using System;
using System.Collections.Generic;
using System.Text;
using TInterView.Domain.enums;

namespace TInterView.Domain.Entities;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime DuDate { get; set; }
    public TaskPriority? Priority { get; set; }
    public AppTaskStatus? Status { get; set; }
    public bool IsDeleted { get; set; }
}
