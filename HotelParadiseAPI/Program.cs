using Microsoft.EntityFrameworkCore;
using HotelParadiseAPI;
using HotelParadiseAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<AppDbContext> (options =>
    {
        options.UseSqlite("Data Source=hotelparadise.db");
    });

var app = builder.Build();

// ==================== HÓSPEDES ====================

// Consultar hóspedes
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

// Buscar hóspede por ID
app.MapGet("/hospedes/{id}", (AppDbContext context, int id) =>
{
    var hospede = context.Hospedes.Find(id);

    if (hospede == null)
        return Results.NotFound();

    return Results.Ok(hospede);
});

// Atualizar o hóspede
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

// Excluir hóspede
app.MapDelete("/hospedes/{id}", (AppDbContext context, int id) =>
{
    var hospede = context.Hospedes.Find(id);

    if (hospede == null)
        return Results.NotFound();

    context.Hospedes.Remove(hospede);
    context.SaveChanges();

    return Results.Ok();
});

// ==================== QUARTOS ====================

// Consultar quartos
app.MapGet("/quartos", (AppDbContext context) =>
{
    return context.Quartos.ToList();
});

// Cadastrar um quarto
app.MapPost("/quartos", (AppDbContext context, Quarto quarto) =>
{
    context.Quartos.Add(quarto);
    context.SaveChanges();

    return Results.Created($"/quartos/{quarto.Numero}", quarto);
});

// Excluir um quarto
app.MapDelete("/quartos/{numero}", (AppDbContext context, int numero) =>
{
    var quarto = context.Quartos.Find(numero);

    if (quarto == null)
        return Results.NotFound("Quarto não encontrado.");

    // verifica se existem reservas vinculadas ao quarto
    var possuiReservas = context.Reservas.Any(r => r.QuartoNumero == numero);

    if (possuiReservas)
        return Results.BadRequest("Não é possível excluir um quarto que possui reservas vinculadas.");

    context.Quartos.Remove(quarto);
    context.SaveChanges();

    return Results.Ok("Quarto excluído com sucesso.");
});

// ==================== RESERVAS ====================

// Consultar reservas
app.MapGet("/reservas", (AppDbContext context) =>
{
    return context.Reservas
        .Include(r => r.Hospede)
        .Include(r => r.Quarto)
        .ToList();
});

// Cadastrar uma reserva
app.MapPost("/reservas", (AppDbContext context, Reserva reserva) =>
{
    // verifica as datas
    if (reserva.DataSaida <= reserva.DataEntrada)
        return Results.BadRequest("A data de saída deve ser posterior à data de entrada.");

    // busca hóspede e quarto
    var hospede = context.Hospedes.Find(reserva.HospedeId);
    var quarto = context.Quartos.Find(reserva.QuartoNumero);

    // Verifica se hóspede e quarto existem
    if (hospede == null || quarto == null)
        return Results.NotFound("Hóspede ou quarto não encontrado.");

    // verifica se o quarto já está reservado nesse período
    var conflito = context.Reservas.Any(r =>
        r.QuartoNumero == reserva.QuartoNumero &&
        r.DataEntrada < reserva.DataSaida &&
        r.DataSaida > reserva.DataEntrada
    );

    if (conflito)
        return Results.BadRequest("O quarto já está reservado nesse período.");


    // calcula o valor total da reserva
    var quantidadeDiarias = (reserva.DataSaida.Date - reserva.DataEntrada.Date).Days;

    reserva.ValorTotal = quantidadeDiarias * quarto.ValorDiaria;
    
    // Associa o hóspede e o quarto à reserva
    reserva.Hospede = hospede;
    reserva.Quarto = quarto;

    // salva a reserva
    context.Reservas.Add(reserva);
    context.SaveChanges();

    return Results.Created($"/reservas/{reserva.Id}", reserva);
});

// Excluir uma reserva
app.MapDelete("/reservas/{id}", (AppDbContext context, int id) =>
{
    var reserva = context.Reservas.Find(id);

    if (reserva == null)
        return Results.NotFound("Reserva não encontrada.");

    context.Reservas.Remove(reserva);
    context.SaveChanges();

    return Results.Ok("Reserva cancelada com sucesso.");
});


app.Run();