# Challenge Gestión de Tareas 🚀

Una API sencilla con un CRUD para la gestión de tareas, diseñada para facilitar la administración y el seguimiento de tareas.

---

## Tabla de Contenidos 📖
1. [Descripción](#descripción)
2. [Tecnología](#tecnología)
3. [Instalación](#instalación)
4. [API Endpoints](#api-endpoints)

---

## Descripción 📝

Esta API permite la creación, lectura, actualización y eliminación de tareas en una base de datos. Es ideal para gestionar tareas con diferentes estados (Pendiente, En progreso, Completada) de forma sencilla.

---

## Tecnología 💻

- **.NET 8**
- **MySQL** versión **8.0.25**

> **Nota**: Para probar con otra versión de MySQL, cambia la versión en `Program.cs`, línea 10:
> ```csharp
> builder.Services.AddDbContext<TodotasksContext>(options =>
>     options.UseMySql(
>         builder.Configuration["ConnectionStrings:DefaultConnection"]?.ToString(), 
>         new MySqlServerVersion(new Version(8, 0, 35))));
> ```

---

## Instalación ⚙️

Sigue estos pasos para configurar y ejecutar el proyecto localmente:

1. Clona este repositorio:
   ```bash
   git clone https://github.com/catrobio27/gestion_tareas.git
   ```
2. Restaura la base de datos:
  - Utiliza el archivo dump-todotasks-202411101758_Local.sql.
  - La base de datos contiene dos tablas (Tasks y StatusTask).
  - Nota: Solo existen tres estados para idStatusTask:
    1 = Pendiente
    2 = En progreso
    3 = Completad
4. Compila el proyecto:
 ```bash
  dotnet build
```
5. Ejecuta el proyecto:
 ```bash
  dotnet run
```
7. Abre el navegador en https://localhost:57828/swagger/index.html para ver la documentación Swagger de los endpoints.
8. API Endpoints 🔍
  - Obtener todas las tareas
    GET /api/Tasks/All
    Retorna: List<TasksDTO>
```bash
  [
    {
        "idTasks": "integer(int32)",
        "idStatusTasks": "integer(int32)",
        "title": "string",
        "description": "string",
        "descriptionStatus": "string"
    }
]
```
 - GET /api/Tasks/{idTask}
    Retorna: TasksDTO
    Parámetro: int idTask > 0
```bash
 {
    "idTasks": "integer(int32)",
    "idStatusTasks": "integer(int32)",
    "title": "string",
    "description": "string",
    "descriptionStatus": "string"
}
```
 - Eliminar tarea
    DELETE /api/Tasks/{idTask}
    Retorna: bool (true si fue borrado)
    Parámetro: int idTask > 0
   
- Crear nueva tarea
    POST /api/Tasks/
    Retorna: TasksDTO
    Parámetro: TasksDTO
```bash
{
    "idStatusTasks": "integer(int32)",
    "title": "string (No puede ser nulo)",
    "description": "string"
}
```
-Actualizar tarea
  PUT /api/Tasks/
  Retorna: TasksDTO
  Parámetro: TasksDTO
```bash
{
    "idTasks": "integer(int32)",
    "idStatusTasks": "integer(int32)",
    "title": "string",
    "description": "string"
}
```


