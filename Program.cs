// using System;

// class Program{

//     public static void GerenciarQuarto(Hotel hotel){
//         Console.WriteLine("");
//         int opQuarto = 1;
        
//         do{
//             Console.WriteLine("  ");
//             Console.WriteLine("---------------------------------");  
//             Console.WriteLine("          HOTEL PARADISE         ");  
//             Console.WriteLine("    Gerenciamento de Quartos     ");  
//             Console.WriteLine("---------------------------------");
//             Console.WriteLine("  ");
//             Console.WriteLine(" | [1] Cadastrar Quarto");
//             Console.WriteLine(" | [2] Listar Quartos");
//             Console.WriteLine(" | [3] Buscar Quarto");
//             Console.WriteLine(" | [4] Verificar Disponibilidade");
//             Console.WriteLine(" | [0] Voltar");
//             Console.WriteLine("  ");
//             Console.Write(">>> Escolha uma opção: ");
//             opQuarto = int.Parse(Console.ReadLine());

//             switch (opQuarto){
//                 case 1 :
//                     hotel.CadastrarQuarto();
//                 break;

//                 case 2:
//                     hotel.ListarQuartos();
//                 break;

//                 case 3:
//                     int num = 0;
            
//                     Console.WriteLine("Digite o número do Quarto: ");
//                     num = int.Parse(Console.ReadLine());
            
//                     hotel.BuscarQuarto(num);
//                 break;

//                 case 4:
//                     int numDisponi = 0;
            
//                     Console.WriteLine("Digite o número do Quarto: ");
//                     numDisponi = int.Parse(Console.ReadLine());
            
//                     hotel.VerificarDisponibilidadeQuarto(numDisponi);
//                 break;

//                 case 0:
//                 break;

//                 default:
//                     Console.WriteLine("Opção inválida, digite novamente");
//                 break;

                
//             }
//         }while(opQuarto != 0);
//     }

//     // gerencia as reservas
//     public static void GerenciarReserva(Hotel hotel)
// {
//     //Cria a variável que guarda a opção escolhida.
//     int opReserva = 1;
    
//     //Isso faz o menu repetir até o usuário escolher 0.
//     do
//     {
//         Console.WriteLine("  ");
//         Console.WriteLine("---------------------------------");
//         Console.WriteLine("          HOTEL PARADISE         ");
//         Console.WriteLine("    Gerenciamento de Reservas    ");
//         Console.WriteLine("---------------------------------");
//         Console.WriteLine("  ");
//         Console.WriteLine(" | [1] Fazer Reserva");
//         Console.WriteLine(" | [2] Listar Reservas");
//         Console.WriteLine(" | [3] Cancelar Reserva");
//         Console.WriteLine(" | [0] Voltar");
//         Console.WriteLine("  ");
//         Console.Write(">>> Escolha uma opção: ");

//         opReserva = int.Parse(Console.ReadLine());

//         switch (opReserva) //verifica a opção escolhida
//         {
//             case 1:
//                 Console.Write("ID da reserva: ");
//                 int idReserva = int.Parse(Console.ReadLine());

//                 Console.Write("ID do hóspede: ");
//                 int idHospede = int.Parse(Console.ReadLine());

//                 Hospede hospede = hotel.BuscarHospede(idHospede);

//                 if (hospede == null) //null significa que não existe objeto encontrado.
//                 {
//                     Console.WriteLine("Hóspede não encontrado!");
//                     break; //“Antes de criar a reserva eu verifico se o hóspede realmente existe.”
//                 }

//                 Console.Write("Número do quarto: ");
//                 int numeroQuarto = int.Parse(Console.ReadLine());

//                 Quarto quarto = hotel.BuscarQuartoReserva(numeroQuarto);//procura o n umero do quarto

//                 if (quarto == null) //a reserva é interrompida.
//                 {
//                     Console.WriteLine("Quarto não encontrado!");
//                     break;
//                 }

//                 if (quarto.Disponibilidade == false) // n cria uma reserva para um quarto ja ocupado
//                 {
//                     Console.WriteLine("Quarto não está disponível!");
//                     break;
//                 }

//                 Console.Write("Data de entrada: ");
//                 DateTime dataEntrada = DateTime.Parse(Console.ReadLine());

//                 Console.Write("Data de saída: ");
//                 DateTime dataSaida = DateTime.Parse(Console.ReadLine());//guarda as datas

//                 if (dataSaida <= dataEntrada) //impede uma reserva com data de saída anterior ou igual à data de entrada.”
//                 {
//                     Console.WriteLine("Data de saída inválida!");
//                     break;
//                 }

//                Reserva reserva = new Reserva(idReserva, hospede, quarto, dataEntrada, dataSaida); //criando obejto reserva
//                 //A reserva relaciona um hóspede a um quarto, por isso eu passo os objetos Hospede e Quarto para o construtor.
//                 reserva.CalcularValor(quarto.ValorDiaria);// // Depois de criar a reserva eu calculo o valor total usando a quantidade de dias e o valor da diária do quarto.
                  
//                 hotel.FazerReserva(reserva);//Aqui você envia o objeto para o Hotel.

//                 break;

//             case 2: ////Chama o método do Hotel que percorre a lista de reservas e mostra cada uma
//                 hotel.ListarReservas();

//             case 3: //Aqui recebe o ID da reserva que será cancelada.
//                 Console.Write("Digite o ID da reserva: ");
//                 int idCancelar = int.Parse(Console.ReadLine());

//                 ///O Hotel procura essa reserva e remove.
//                 hotel.CancelarReserva(idCancelar);
//                 break;

//             case 0:
//                 break;

//             default:
//                 Console.WriteLine("Opção inválida, digite novamente");
//                 break;
//         }

//     } while (opReserva != 0);
// }

//     public static void GerenciarHospede(Hotel hotel)
// {
//     int opHospede = 1;

//     do
//     {
//         Console.WriteLine("  ");
//         Console.WriteLine("---------------------------------");
//         Console.WriteLine("          HOTEL PARADISE         ");
//         Console.WriteLine("    Gerenciamento de Hóspedes    ");
//         Console.WriteLine("---------------------------------");
//         Console.WriteLine("  ");
//         Console.WriteLine(" | [1] Cadastrar Hóspede");
//         Console.WriteLine(" | [2] Listar Hóspedes");
//         Console.WriteLine(" | [3] Buscar Hóspede");
//         Console.WriteLine(" | [0] Voltar");
//         Console.WriteLine("  ");
//         Console.Write(">>> Escolha uma opção: ");

//         opHospede = int.Parse(Console.ReadLine());

//         switch (opHospede)
//         {
//             case 1:
//                 hotel.CadastrarHospede();//O Program controla a interação com o usuário, enquanto o Hotel executa as operações sobre os dados
//                 break;

//             case 2://percorre a lista e mostra os hospedes
//                 hotel.ListarHospedes();
//                 break;

//             case 3:
//                 Console.Write("Digite o ID do hóspede: ");
//                 int id = int.Parse(Console.ReadLine());//pede id e tenta acha

//                 Hospede hospede = hotel.BuscarHospede(id);

//                 if (hospede != null)// se n retorn nulo
//                 {
//                     hospede.ExibirDados();//se encontra mostra
//                 }
//                 else
//                 {
//                     Console.WriteLine("Hóspede não encontrado!");
//                 }

//                 break;

//             case 0:
//                 break;

//             default:
//                 Console.WriteLine("Opção inválida, digite novamente");
//                 break;
//         }

//     } while (opHospede != 0);
// }

//     static void Main(string[] args){
        
//         Hotel hotel = new Hotel();

//         int opcao = 1;
        
//         do{
//             Console.WriteLine("  ");
//             Console.WriteLine("---------------------------------");  
//             Console.WriteLine("          HOTEL PARADISE         ");  
//             Console.WriteLine("     Sistema de Gerenciamento    ");  
//             Console.WriteLine("---------------------------------");
//             Console.WriteLine("  ");
//             Console.WriteLine(" | [1] Gerenciar hóspedes");
//             Console.WriteLine(" | [2] Gerenciar quartos");
//             Console.WriteLine(" | [3] Gerenciar reservas");
//             Console.WriteLine(" | [0] Sair do Sistema ");
//             Console.WriteLine("  ");
//             Console.Write(">>> Escolha uma opção: ");
//             opcao = int.Parse(Console.ReadLine());
            

//             switch (opcao){
//                 case 1 :
//                  GerenciarHospede(hotel);// chame o metedogeren.. e passe o ob jeto hotel para ele
//                 break;

//                 case 2:
//                   GerenciarQuarto(hotel);
//                 break;

//                 case 3:
//                     GerenciarReserva(hotel);
//                 break;

//                 case 0:
//                 break;

//                 default:
//                     Console.WriteLine("Opção incorreta, digite novamente");
//                 break;

//             }

        
//         }while(opcao != 0);
//     }
// }