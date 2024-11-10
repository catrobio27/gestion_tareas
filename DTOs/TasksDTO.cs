namespace ToDoTask.DTOs;

public class TasksDTO
{
    public int IdTasks { get; set; }
    public int IdStatusTasks { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? DescriptionStatus { get; set; }
}