using System;
class Reserva{
    public int Id;
    public Hospede Hospede;
    public Quarto Quarto;
    public DateTime DataEntrada;
    public DateTime DataSaida;
    public decimal ValorTotal;

    public Reserva(int id, Hospede hospede, Quarto quarto, DateTime dataEntrada, DateTime dataSaida)
    {
        Id = id;
        Hospede = hospede;
        Quarto = quarto;
        DataEntrada = dataEntrada;
        DataSaida = dataSaida;
    }

    public void CalcularValor(decimal ValorDiariaQuarto)
{
    if (DataSaida <= DataEntrada)
    {
        Console.WriteLine("Data de saída inválida!");
        ValorTotal = 0;
        return;
    }

    int dias = (DataSaida - DataEntrada).Days;

    ValorTotal = dias * ValorDiariaQuarto;
}

    public void ExibirDados()
    {
        Console.WriteLine("ID da reserva: " + Id);
        Console.WriteLine("Hóspede: " + Hospede.Nome);
        Console.WriteLine("Quarto: " + Quarto.Numero);
        Console.WriteLine("Entrada: " + DataEntrada);
        Console.WriteLine("Saída: " + DataSaida);
        Console.WriteLine("Valor total: R$ " + ValorTotal);
    }
}