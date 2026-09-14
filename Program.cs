using System;

class Program{

    public static void GerenciarQuarto(Hotel hotel){
        Console.WriteLine("");
        int opQuarto = 1;
        
        do{
            Console.WriteLine("  ");
            Console.WriteLine("---------------------------------");  
            Console.WriteLine("          HOTEL PARADISE         ");  
            Console.WriteLine("    Gerenciamento de Quartos     ");  
            Console.WriteLine("---------------------------------");
            Console.WriteLine("  ");
            Console.WriteLine(" | [1] Cadastrar Quarto");
            Console.WriteLine(" | [2] Listar Quartos");
            Console.WriteLine(" | [3] Buscar Quarto");
            Console.WriteLine(" | [4] Verificar Disponibilidade");
            Console.WriteLine(" | [0] Voltar");
            Console.WriteLine("  ");
            Console.Write(">>> Escolha uma opção: ");
            opQuarto = int.Parse(Console.ReadLine());

            switch (opQuarto){
                case 1 :
                    hotel.CadastrarQuarto();
                break;

                case 2:
                    hotel.ListarQuartos();
                break;

                case 3:
                    int num = 0;
            
                    Console.WriteLine("Digite o número do Quarto: ");
                    num = int.Parse(Console.ReadLine());
            
                    hotel.BuscarQuarto(num);
                break;

                case 4:
                    int numDisponi = 0;
            
                    Console.WriteLine("Digite o número do Quarto: ");
                    numDisponi = int.Parse(Console.ReadLine());
            
                    hotel.VerificarDisponibilidadeQuarto(numDisponi);
                break;

                default:
                    Console.WriteLine("Opção inválida, digite novamente");
                break;

                
            }
        }while(opQuarto != 0);
    }
    static void Main(string[] args){
        
        Hotel hotel = new Hotel();

        int opcao = 1;
        
        do{
            Console.WriteLine("  ");
            Console.WriteLine("---------------------------------");  
            Console.WriteLine("          HOTEL PARADISE         ");  
            Console.WriteLine("     Sistema de Gerenciamento    ");  
            Console.WriteLine("---------------------------------");
            Console.WriteLine("  ");
            Console.WriteLine(" | [1] Gerenciar hóspedes");
            Console.WriteLine(" | [2] Gerenciar quartos");
            Console.WriteLine(" | [3] Gerenciar reservas");
            Console.WriteLine(" | [0] Sair do Sistema ");
            Console.WriteLine("  ");
            Console.Write(">>> Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());
            

            switch (opcao){
                case 1 :
                    Console.WriteLine("");
                break;

                case 2:
                  GerenciarQuarto(hotel);
                break;

                case 3:
                    Console.WriteLine("");
                break;

                case 0:
                break;

                default:
                    Console.WriteLine("Opção incorreta, digite novamente");
                break;

            }

        
        }while(opcao != 0);
    }
}