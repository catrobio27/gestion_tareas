using System;
using System.Collections.Generic;

namespace ToDoTask.Models;

public partial class Statustask
{
    public int IdStatusTasks { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}
