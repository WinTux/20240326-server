using _20240326_server.Contenido;
using _20240326_server.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlite(builder.Configuration.GetConnectionString("MiConexionLocalSQLite")));
// Add services to the container.

var app = builder.Build();
app.MapGet("api/plato", async (AppDbContext contexto) => {
    var elementos = await contexto.Platos.ToListAsync();
    return Results.Ok(elementos);
});
app.MapPost("api/plato", async (AppDbContext contexto, Plato plato) => {
    var elementos = await contexto.Platos.AddAsync(plato);
    await contexto.SaveChangesAsync();
    return Results.Created($"api/plato/{plato.Id}", plato);
});
app.MapPut("api/plato/{id}", async (AppDbContext contexto, int id, Plato plato) => {
    var elemento = await contexto.Platos.FirstOrDefaultAsync(p => p.Id == id);//SELECT * FROM Plato WHERE Id = {id} LIMIT 1;
    if (elemento == null)
        return Results.NotFound();
    elemento.Nombre = plato.Nombre;
    await contexto.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("api/plato/{id}", async (AppDbContext contexto, int id) => {
    var elemento = await contexto.Platos.FirstOrDefaultAsync(p => p.Id == id);//SELECT * FROM Plato WHERE Id = {id} LIMIT 1;
    if (elemento == null)
        return Results.NotFound();
    contexto.Platos.Remove(elemento);
    await contexto.SaveChangesAsync();
    return Results.NoContent();
});
app.Run();
