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

        CalcularValor();
    }

    public void CalcularValor()
    {
        int dias = (DataSaida - DataEntrada).Days;

        if (dias > 0)
        {
            ValorTotal = dias * Quarto.ValorDiaria;
        }
        else
        {
            ValorTotal = 0;
        }
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
