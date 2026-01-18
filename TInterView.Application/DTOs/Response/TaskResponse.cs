using System;
using System.Collections.Generic;
using System.Text;

namespace TInterView.Application.DTOs.Response;

public record TaskResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime DuDate { get; set; }
    public string Priority { get; set; } = null!;
    public string Status { get; set; } = null!;
}
