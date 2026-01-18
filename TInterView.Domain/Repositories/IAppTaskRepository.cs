using System;
using System.Collections.Generic;
using System.Text;
using TInterView.Domain.Entities;
using TInterView.Domain.enums;

namespace TInterView.Domain.Repositories;

public interface IAppTaskRepository
{
    Task<TaskItem?> GetByIdAsync(int id);
    Task<(List<TaskItem> tasks, int totalCount)>
        GetAllAsync(int pageNumber, int pageSize, AppTaskStatus? status, string? searchTerm);


    Task<TaskItem> CreateAsync(TaskItem task);
    Task UpdateAsync(TaskItem task);
    // delete as soft delete IsDeleted = true
    Task DeleteAsync(int id);
}
