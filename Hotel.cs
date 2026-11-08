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
    //Esse método serve para procurar um quarto pelo número e devolver o objeto Quarto encontrado.
    //public → permite que o método seja chamado de outra classe, como o Program.
    //Quarto → é o tipo que o método retorna.
    //BuscarQuartoReserva → nome do método.
    //int numeroQuarto → recebe o número que queremos procurar.
    public Quarto BuscarQuartoReserva(int numeroQuarto)
    {

        //O for percorre a lista de quartos, começando na posição 0.
        for (int i = 0; i < listaQuartos.Count; i++)
        {

            //Aqui pegamos o quarto da posição atual da lista e colocamos na variável quarto.
            Quarto quarto = listaQuartos[i];


            //“O número desse quarto que estou olhando é igual ao número que estou procurando?
            if (quarto.Numero == numeroQuarto)
            {
                //Ele devolve o objeto Quarto encontrado.
                return quarto;
            }
        }
        //null significa que nenhum quarto foi encontrado.
        return null;

    }

//“Esse método procura o quarto pelo número e, quando encontra, chama o método VerificarDisponibilidade do próprio quarto.”
    public void VerificarDisponibilidadeQuarto(int numeroQuarto){
        for (int i = 0; i < listaQuartos.Count; i++){
            Quarto quarto = listaQuartos[i];
        
            if(quarto.Numero == numeroQuarto){
                quarto.VerificarDisponibilidade();
            }
        }
        //BuscarQuartoReserva() → retorna o objeto Quarto.

        //VerificarDisponibilidadeQuarto() → apenas verifica/mostra a disponibilidade.
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

        //cria o objeto hospede
    Hospede hospede = new Hospede(id, nome, cpf, telefone);

    listaHospedes.Add(hospede);
    //“O método recebe os dados digitados pelo usuário, cria um objeto Hospede usando o construtor e adiciona esse objeto na lista de hóspedes.”

    Console.WriteLine(" ");
    Console.WriteLine("Hóspede cadastrado com sucesso!");
}
//“Eu percorro a lista de hóspedes e, para cada objeto encontrado, chamo o método ExibirDados.”
public void ListarHospedes()
{
    for (int i = 0; i < listaHospedes.Count; i++)
    {
        Hospede hospede = listaHospedes[i];

        hospede.ExibirDados();

        Console.WriteLine(" ");
    }
}

// busco o hospede pleo mid digitado se n encontra retorna null 
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
    { //quando a reserva é add a lista eu chamo o metodo ocupar, assim um quarto n vai ser reservado amsi de uma vez quanod estiver em uso
        listaReservas.Add(reserva);
        reserva.Quarto.Ocupar();

        Console.WriteLine(" ");
        Console.WriteLine("Reserva realizada com sucesso!");
    }

    //percorre todas as reservas armazenadas e chama o metodo exibir para mostra cada uma
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
            Reserva reserva = listaReservas[i]; //Porque i representa a posição daquela reserva na lista.
            //pega o id percorre a lsita procurando ele, acho ele libera o quarto relacionado e remove a reserva da lista. Depois usa return porque não precisa continuar procurando.”
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
