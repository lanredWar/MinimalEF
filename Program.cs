using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalEF.Models;

var builder = WebApplication.CreateBuilder(args);

//Conexion a base de datos en memoria para asegurar posteriormente la conexion con una base real
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

//Servicio que se va conectar a SQL
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//Se agrega Enpoint para verificar la creacion de la base de atos en memoria con el contexto 
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", async([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(p=> p.Categoria));
});

app.MapPost("/api/tareas", async([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    //Formas para agregar el registro
    await dbContext.AddAsync(tarea);
    //Forma #2 para agregar un registro await dbContext.Tareas.AddAsync(tarea);

    //forma para salvar/guardar el registro
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
