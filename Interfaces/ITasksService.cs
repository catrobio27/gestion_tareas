
using ToDoTask.DTOs;

namespace ToDoTask.Interfaces;

public interface ITasksService
{
    Task<List<TasksDTO>> GetTaskList();
    Task<TasksDTO> GetTaskById(int idTasks);
    Task<TasksDTO> CreateTask(TasksDTO Task);
    Task<TasksDTO> UpdateTask(TasksDTO Task);
    Task<TasksDTO> DeleteTask(int idTasks);
}
