class Quarto{
    public int Numero;
    public string Tipo; // Solteiro, Casal, Suite
    public int Capacidade;
    public double ValorDiaria;
    public bool Disponibilidade = true;
    
    public Quarto(int numero, string tipo, int capacidade, double valorDiaria){
        Numero = numero;
        Tipo = tipo;
        Capacidade = capacidade;
        ValorDiaria = valorDiaria;
    }

    public void ExibirDadosQuarto(){
        Console.WriteLine(" ");
        Console.WriteLine("----------- Quarto -----------");
        Console.WriteLine(" ");

        Console.WriteLine($"Numero: {Numero}");
        Console.WriteLine($"Tipo: {Tipo}");
        Console.WriteLine($"Capacidade: {Capacidade}");
        Console.WriteLine($"Valor da Diaria: {ValorDiaria}");
        Console.WriteLine($"Está disponivel: {(Disponibilidade ? "Sim" : "Não")}");
        
        Console.WriteLine(" ");
        Console.WriteLine("------------------------------");
    }

    public void VerificarDisponibilidade(){
        Console.WriteLine($"Está disponivel: {(Disponibilidade ? "Sim" : "Não")}");
    }

    public void Ocupar(){
        Disponibilidade = false;
    }

    public void Liberar(){
        Disponibilidade = true;
    }
}