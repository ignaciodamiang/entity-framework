using entitiyframework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Para que deje de crear la DB en memoria y no haya conflicto con la creación y conexión a la DB en SQL Server
// No se debería realizar mas de una config por contexto.
// builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

// String de conexión para usar EF con Sql Server y se conecte a BD
// TrustServerCertificate=true; es para que confie en cualquier certificado de servidor (no recomendado en producción)
// https://stackoverflow.com/questions/17615260/the-certificate-chain-was-issued-by-an-authority-that-is-not-trusted-when-conn
// 
builder.Services.AddSqlServer<TareasContext>("Data Source=W10DH;Initial Catalog=TareasDB;user id=sa;password=.; TrustServerCertificate=True;");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Se reutiliza el endpoint y deberíamos poder conectarnos a Sql Server y generarse la base de datos si no está generada.
app.MapGet("/dbconnection", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.Run();