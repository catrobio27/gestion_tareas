using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using ToDoTask.DTOs;
using ToDoTask.Interfaces;
using ToDoTask.Models;

namespace ToDoTask.Services;

public class TasksService : ITasksService
{
    private readonly TodotasksContext _context;

    public TasksService(TodotasksContext context)
    {
        _context = context;
    }

    public async Task<TasksDTO> CreateTask(TasksDTO task)
    {
        var result = new TasksDTO();
        try
        {
            if (string.IsNullOrEmpty(task.Title))
            {
                throw new Exception("Task's title can't be null or empty");
            }
            else
            {
                var newTask = new Tasks
                {
                    IdStatusTasks = task.IdStatusTasks,
                    Description = task.Description,
                    Title = task.Title
                };
                var taskSave = await _context.AddAsync(newTask);
                await _context.SaveChangesAsync();

                result = await this.GetTaskById(taskSave.Entity.IdTasks);
            }
        }
        catch (DbException db)
        {
            throw new Exception(db.Message);
        }
        catch (System.Exception e)
        {
             if(e.InnerException != null)
                throw new Exception(e.InnerException.Message);
            else
                throw new Exception(e.Message);
        }
        return result;
    }

    public Task<TasksDTO> DeleteTask(int idTasks)
    {
        throw new NotImplementedException();
    }

    public async Task<TasksDTO> GetTaskById(int idTasks)
    {
        var result = new TasksDTO();
        try
        {
            var task = await _context.Tasks
                        .Include(t => t.IdStatusTasksNavigation)
                        .Where(t => t.IdTasks == idTasks)
                        .FirstOrDefaultAsync();
            if (task != null)
            {
                result.Description = task.Description;
                result.DescriptionStatus = task.IdStatusTasksNavigation.Description;
                result.IdStatusTasks = task.IdStatusTasks;
                result.IdTasks = task.IdTasks;
                result.Title = task.Title;
            }
            else
            {
                throw new Exception("Id task does not exist!");
            }
        }
        catch (DbException db)
        {
            throw new Exception(db.Message);
        }
        catch (System.Exception e)
        {
            throw new Exception(e.Message);
        }
        return result;
    }

    public async Task<List<TasksDTO>> GetTaskList()
    {
        var result = new List<TasksDTO>();
        try
        {
            var tasks = await _context.Tasks
                        .Include(t => t.IdStatusTasksNavigation)
                        .ToListAsync();

            if (tasks.Any())
            {
                foreach (var task in tasks)
                {
                    var taskDto = new TasksDTO
                    {
                        Description = task.Description,
                        DescriptionStatus = task.IdStatusTasksNavigation.Description,
                        IdStatusTasks = task.IdStatusTasks,
                        IdTasks = task.IdTasks,
                        Title = task.Title
                    };
                    result.Add(taskDto);
                }
            }
        }
        catch (DbException db)
        {
            throw new Exception(db.Message);
        }
        catch (System.Exception e)
        {
            throw new Exception(e.Message);
        }
        return result;
    }

    public Task<TasksDTO> UpdateTask(TasksDTO Task)
    {
        throw new NotImplementedException();
    }
}