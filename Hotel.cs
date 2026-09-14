class Hotel{
    
    List<Hospede> listaHospedes = new List<Hospede>();
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

    //  busca o quarto para usar na reserva
    public Quarto BuscarQuartoReserva(int numeroQuarto)
    {
        for (int i = 0; i < listaQuartos.Count; i++)
        {
            Quarto quarto = listaQuartos[i];

            if (quarto.Numero == numeroQuarto)
            {
                return quarto;
            }
        }

        return null;
    }

    public void VerificarDisponibilidadeQuarto(int numeroQuarto){
        for (int i = 0; i < listaQuartos.Count; i++){
            Quarto quarto = listaQuartos[i];
        
            if(quarto.Numero == numeroQuarto){
                quarto.VerificarDisponibilidade();
            }
        }
    }

    // hospede

public void CadastrarHospede()
{
    Console.WriteLine(" ");
    Console.Write("ID do hóspede: ");
    int id = int.Parse(Console.ReadLine());

    Console.Write("Nome: ");
    string nome = Console.ReadLine();

    Console.Write("CPF: ");
    string cpf = Console.ReadLine();

    Console.Write("Telefone: ");
    string telefone = Console.ReadLine();

    Hospede hospede = new Hospede(id, nome, cpf, telefone);

    listaHospedes.Add(hospede);

    Console.WriteLine(" ");
    Console.WriteLine("Hóspede cadastrado com sucesso!");
}

public void ListarHospedes()
{
    for (int i = 0; i < listaHospedes.Count; i++)
    {
        Hospede hospede = listaHospedes[i];

        hospede.ExibirDados();

        Console.WriteLine(" ");
    }
}

public Hospede BuscarHospede(int id)
{
    for (int i = 0; i < listaHospedes.Count; i++)
    {
        Hospede hospede = listaHospedes[i];

        if (hospede.Id == id)
        {
            return hospede;
        }
    }

    return null;
}

    // reserva

    public void FazerReserva(Reserva reserva)
    {
        listaReservas.Add(reserva);
        reserva.Quarto.Ocupar();

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
                reserva.Quarto.Liberar();
                listaReservas.RemoveAt(i);

                Console.WriteLine(" ");
                Console.WriteLine("Reserva cancelada com sucesso!");

                return;
            }
        }

        Console.WriteLine("Reserva não encontrada!");
    }
}
