using System;
using System.Collections.Generic;
using System.Text;
using TInterView.Application.DTOs.Request;
using TInterView.Application.DTOs.Response;

namespace TInterView.Application.Interfaces;

public interface ITaskService
{
    Task<TaskResponse> CreateTaskAsync(CreateAppTaskRequest request);
    Task<PagedResponse<TaskResponse>> GetTasksAsync(AppTaskFilterRequest filter);
    Task<TaskResponse> GetTaskByIdAsync(int id);
    Task<TaskResponse> UpdateTaskAsync(int id, UpdateAppTaskRequest request);
    Task<bool> DeleteTaskAsync(int id);
}
