using entitiyframework;
using entitiyframework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapGet("/dbconnection", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) => 
{
    // Se quita el include de Categoria y la restriccion Where
    // return Results.Ok(dbContext.Tareas.Include(p=>p.Categoria).Where(p=> p.PrioridadTarea == entitiyframework.Models.Prioridad.Baja));
    return Results.Ok(dbContext.Tareas);
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) => 
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) => 
{
    var tareaDb = dbContext.Tareas.Find(id);
    if(tareaDb != null)
    {
        tareaDb.Titulo = tarea.Titulo;
        tareaDb.Descripcion = tarea.Descripcion;
        tareaDb.PrioridadTarea = tarea.PrioridadTarea;
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});

// Eliminar tarea endpoint
app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) => 
{
    var tareaDb = dbContext.Tareas.Find(id);
    if(tareaDb != null)
    {
        dbContext.Remove(tareaDb);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});

app.Run();