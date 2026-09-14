class Hotel{
    
    List<Quarto> listaQuartos = new List<Quarto>();
    List<Reserva> listaReservas = new List<Reserva>();

    public void CadastrarQuarto(){
        Console.WriteLine(" ");
        Console.Write("Numero do quarto: ");
        int numeroQuarto = int.Parse(Console.ReadLine());

        while (numeroQuarto <= 0){
            Console.WriteLine("Número de quarto inválido! Digite novamente");
            Console.WriteLine(" ");
            Console.Write("Número do quarto: ");
            numeroQuarto = int.Parse(Console.ReadLine());
        }

        Console.Write("Tipo (Solteiro, Casal ou Suite): ");
        string tipo = Console.ReadLine();

        Console.Write("Capacidade: ");
        int capacidade = int.Parse(Console.ReadLine());
        
        Console.Write("Valor da diaria: ");
        decimal valorDiaria = decimal.Parse(Console.ReadLine());
    
        Quarto quarto = new Quarto(numeroQuarto, tipo, capacidade, valorDiaria);
        listaQuartos.Add(quarto);

        Console.WriteLine(" ");
        Console.WriteLine("Quarto adicionado com sucesso!");
    }

    public void ListarQuartos(){
        for (int i = 0; i < listaQuartos.Count; i++){
            Quarto quarto = listaQuartos[i];
            quarto.ExibirDadosQuarto();
        }
    }

    public void BuscarQuarto(int numeroQuarto){
        for (int i = 0; i < listaQuartos.Count; i++){
            Quarto quarto = listaQuartos[i];
            
            if(quarto.Numero == numeroQuarto){
                quarto.ExibirDadosQuarto();
            }
        }
        
    }

    public void VerificarDisponibilidadeQuarto(int numeroQuarto){
        for (int i = 0; i < listaQuartos.Count; i++){
            Quarto quarto = listaQuartos[i];
        
            if(quarto.Numero == numeroQuarto){
                quarto.VerificarDisponibilidade();
            }
        }
    }


    // reserva

    public void FazerReserva(Reserva reserva)
    {
        listaReservas.Add(reserva);

        Console.WriteLine(" ");
        Console.WriteLine("Reserva realizada com sucesso!");
    }

    public void ListarReservas()
    {
        for (int i = 0; i < listaReservas.Count; i++)
        {
            Reserva reserva = listaReservas[i];
            reserva.ExibirDados();
        }
    }

    public void CancelarReserva(int idReserva)
    {
        for (int i = 0; i < listaReservas.Count; i++)
        {
            Reserva reserva = listaReservas[i];

            if (reserva.Id == idReserva)
            {
                listaReservas.RemoveAt(i);

                Console.WriteLine(" ");
                Console.WriteLine("Reserva cancelada com sucesso!");

                return;
            }
        }

        Console.WriteLine("Reserva não encontrada!");
    }
}
