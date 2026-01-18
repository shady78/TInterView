using TInterView.Application.DTOs.Request;
using TInterView.Application.DTOs.Response;
using TInterView.Domain.Entities;
using TInterView.Domain.enums;

namespace TInterView.Application.Mapping;

public static class AppTaskMapping
{
    public static TaskItem ToEntity(this CreateAppTaskRequest request)
        => new TaskItem
        {
            Title = request.Title,
            Description = request.Description,
            DuDate = request.DuDate,
            Priority = request.Priority,
            Status = AppTaskStatus.New
        };

    public static void UpdateEntity(this UpdateAppTaskRequest request, TaskItem task)
    {
        task.Title = request.Title;
        task.Description = request.Description;
        task.DuDate = request.DuDate;
        task.Priority = request.Priority;
        task.Status = request.Status;
    }

    public static TaskResponse ToResponse(this TaskItem task)
        => new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DuDate = task.DuDate,
            Priority = task.Priority.ToString(),
            Status = task.Status.ToString()
        };

    public static PagedResponse<TaskResponse> ToPageRespose(this AppTaskFilterRequest request, List<TaskResponse> taskData, int totalCount)
    {
        return new PagedResponse<TaskResponse>
        {
            data = taskData,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize),
            TotalCount = totalCount
        };
    }


}
