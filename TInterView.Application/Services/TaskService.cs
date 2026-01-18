using System;
using System.Collections.Generic;
using System.Text;
using TInterView.Application.DTOs.Request;
using TInterView.Application.DTOs.Response;
using TInterView.Application.Interfaces;
using TInterView.Application.Mapping;
using TInterView.Domain.Repositories;

namespace TInterView.Application.Services;

public class TaskService : ITaskService
{
    private readonly IAppTaskRepository _repository;

    public TaskService(IAppTaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<TaskResponse> CreateTaskAsync(CreateAppTaskRequest request)
    {
        var task = request.ToEntity();
        var created = await _repository.CreateAsync(task);
        return created.ToResponse();
    }

    public async Task<PagedResponse<TaskResponse>> GetTasksAsync(AppTaskFilterRequest filter)
    {
        var (tasks, totalCount) = await _repository.GetAllAsync(
            filter.PageNumber, filter.PageSize, filter.Status, filter.SearchTerm);

        return filter.ToPageRespose(tasks.Select(t => t.ToResponse()).ToList(), totalCount);
        //return new PagedResponse<TaskResponse>
        //{
        // Data = tasks.Select(t => t.ToResponse()).ToList(),
        //    PageNumber = filter.PageNumber,
        //    PageSize = filter.PageSize,
        //    TotalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize),
        //    TotalRecords = totalCount
        //};
    }

    public async Task<TaskResponse> UpdateTaskAsync(int id, UpdateAppTaskRequest request)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task is null) return null;

        request.UpdateEntity(task);

        await _repository.UpdateAsync(task);
        return task.ToResponse();
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task is null) return false;

        await _repository.DeleteAsync(id);
        return true;
    }

    public async Task<TaskResponse> GetTaskByIdAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);
        return task is null ? null : task.ToResponse();
    }
}