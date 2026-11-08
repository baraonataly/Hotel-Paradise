using Microsoft.EntityFrameworkCore;
using HotelParadiseAPI;
using HotelParadiseAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// parte: banco de dados
builder.Services.AddDbContext<AppDbContext> (options =>
    {
        options.UseSqlite("Data Source=hotelparadise.db");
    });

var app = builder.Build();

// consulta hóspedes
app.MapGet("/hospedes", (AppDbContext context) =>
{
    return context.Hospedes.ToList();
});

// Cadastrar um hóspede
app.MapPost("/hospedes", (AppDbContext context, Hospede hospede) =>
{
    context.Hospedes.Add(hospede);
    context.SaveChanges();

    return Results.Created($"/hospedes/{hospede.Id}", hospede);
});

// busca hóspede por ID
app.MapGet("/hospedes/{id}", (AppDbContext context, int id) =>
{
    var hospede = context.Hospedes.Find(id);

    if (hospede == null)
        return Results.NotFound();

    return Results.Ok(hospede);
});

// atualiza o hóspede
app.MapPut("/hospedes/{id}", (AppDbContext context, int id, Hospede dados) =>
{
    var hospede = context.Hospedes.Find(id);

    if (hospede == null)
        return Results.NotFound();

    hospede.Nome = dados.Nome;
    hospede.CPF = dados.CPF;
    hospede.Telefone = dados.Telefone;

    context.SaveChanges();

    return Results.Ok(hospede);
});

// exclui o hóspede
app.MapDelete("/hospedes/{id}", (AppDbContext context, int id) =>
{
    var hospede = context.Hospedes.Find(id);

    if (hospede == null)
        return Results.NotFound();

    context.Hospedes.Remove(hospede);
    context.SaveChanges();

    return Results.Ok();
});

app.Run();