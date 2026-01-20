using Microsoft.EntityFrameworkCore;
using TInterView.Domain.Entities;
using TInterView.Domain.enums;
using TInterView.Domain.Repositories;
using TInterView.Infrastructure.Data;

namespace TInterView.Infrastructure.Repositories;

public class AppTaskRepository : IAppTaskRepository
{
    private readonly ApplicationDbContext _context;

    public AppTaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TaskItem> CreateAsync(TaskItem task)
    {
        _context.AppTasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task DeleteAsync(int id)
    {
        // Implementation for deleting a task by id  (Soft delete)
        //var task = GetByIdAsync(id);
        var task = await _context.AppTasks.FindAsync(id);
        if (task is null)
        {
            return;
        }
        task.IsDeleted = true;
       await _context.SaveChangesAsync();
    }

    public async Task<(List<TaskItem> tasks, int totalCount)> GetAllAsync(int pageNumber, int pageSize, AppTaskStatus? status, string? searchTerm)
    {
        var query = _context
            .AppTasks.
             Where(t => !t.IsDeleted)
            .AsQueryable();

        if (status.HasValue)
        {
            query = query.Where(t => t.Status == status.Value);
        }
        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(s => s.Title.Contains(searchTerm));
        }

        var totalCount = await query.CountAsync();
        var task = await query
           .Skip((pageNumber - 1) * pageSize)
           .Take(pageSize)
           .ToListAsync();
        return(task , totalCount);
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        var task = await _context.AppTasks.FindAsync(id);
        return task;
    }

    public async Task UpdateAsync(TaskItem task)
    {
        _context.AppTasks.Update(task);
        await  _context.SaveChangesAsync();
    }
}
