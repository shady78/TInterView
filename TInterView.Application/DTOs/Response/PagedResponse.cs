using System;
using System.Collections.Generic;
using System.Text;

namespace TInterView.Application.DTOs.Response;

public record PagedResponse<T>
{
    public List<T>? data { get; set; }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
}
