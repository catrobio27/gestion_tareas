using System;
using System.Collections.Generic;

namespace ToDoTask.Models;

public partial class Tasks
{
    public int IdTasks { get; set; }

    public int IdStatusTasks { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Statustask IdStatusTasksNavigation { get; set; } = null!;
}
