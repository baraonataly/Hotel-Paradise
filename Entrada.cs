using System;

class Entrada
{
    public static int LerNumero()
    {
        int numero;

        while (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.Write("Valor inválido! Digite novamente: ");
        }

        return numero;
    }

    public static decimal LerDecimal()
    {
        decimal valor;

        while (!decimal.TryParse(Console.ReadLine(), out valor))
        {
            Console.Write("Valor inválido! Digite novamente: ");
        }

        return valor;
    }

    public static DateTime LerData()
    {
        DateTime data;

        while (!DateTime.TryParse(Console.ReadLine(), out data))
        {
            Console.Write("Data inválida! Digite novamente: ");
        }

        return data;
    }

    public static string LerTexto()
    {
        return Console.ReadLine() ?? "";
    }
}