using Microsoft.EntityFrameworkCore;
using ToDoTask.Interfaces;
using ToDoTask.Models;
using ToDoTask.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddDbContext<TodotasksContext>(options =>
    options.UseMySql(
        builder.Configuration["ConnectionStrings:DefaultConnection"]?.ToString(), new MySqlServerVersion(new Version(8, 0, 35))));

builder.Services.AddScoped<ITasksService, TasksService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
