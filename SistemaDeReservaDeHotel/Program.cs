using SistemaDeReservaDeHotel.Modelos;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;


List<Quarto> quartosDisponiveis = new List<Quarto>();
List<Quarto> quartosExistentes = new List<Quarto>();
List<Reserva> reservas = new List<Reserva>();
Hotel hotel = new Hotel();

quartosDisponiveis.Add(new Quarto(1, "Solteiro / básico", 120.00));
quartosDisponiveis.Add(new Quarto(2, "Casal / básico", 240.00));
quartosDisponiveis.Add(new Quarto(3, "Casal / premium", 400.00));
quartosDisponiveis.Add(new Quarto(4, "Solteiro / premium", 200.00));
quartosDisponiveis.Add(new Quarto(5, "4 pessoas / básico", 450.00));
quartosDisponiveis.Add(new Quarto(6, "4 pessoas / premium", 750.00));
quartosDisponiveis.Add(new Quarto(7, "4 pessoas / luxo", 1200.00));
quartosDisponiveis.Add(new Quarto(8, "Casal / luxo", 650.00));
quartosDisponiveis.Add(new Quarto(9, "3 pessoas / basico", 390));
quartosDisponiveis.Add(new Quarto(10, "4 pessoas / cobertura 1", 2500.00));
quartosDisponiveis.Add(new Quarto(11, "4 pessoas / cobertura 2", 3300.00));

quartosExistentes.Add(new Quarto(1, "Solteiro / básico", 120.00));
quartosExistentes.Add(new Quarto(2, "Casal / básico", 240.00));
quartosExistentes.Add(new Quarto(3, "Casal / premium", 400.00));
quartosExistentes.Add(new Quarto(4, "Solteiro / premium", 200.00));
quartosExistentes.Add(new Quarto(5, "4 pessoas / básico", 450.00));
quartosExistentes.Add(new Quarto(6, "4 pessoas / premium", 750.00));
quartosExistentes.Add(new Quarto(7, "4 pessoas / luxo", 1200.00));
quartosExistentes.Add(new Quarto(8, "Casal / luxo", 650.00));
quartosExistentes.Add(new Quarto(9, "3 pessoas / basico", 390));
quartosExistentes.Add(new Quarto(10, "4 pessoas / cobertura 1", 2500.00));
quartosExistentes.Add(new Quarto(11, "4 pessoas / cobertura 2", 3300.00));






MenuInicialSistema(reservas, quartosDisponiveis, quartosExistentes);





void MenuInicialSistema(List<Reserva> reservas, List<Quarto> quartosDisponiveis, List<Quarto> quartosExistentes)
{
    while (true)
    {
        Console.Clear();
        hotel.LogoSistema();
        Thread.Sleep(1500);
        Console.WriteLine("\nBem vindo ao sistema gerenciador do nosso hotel\n\n");
        Console.WriteLine("Selecione a opção desejada abaixo:");
        Console.WriteLine("1 - Fazer uma reserva.");
        Console.WriteLine("2 - Dar baixa em reservas.");
        Console.WriteLine("3 - Mostrar os quartos disponíveis");
        Console.WriteLine("4 - Consultar reservas.");
        Console.WriteLine("5 - Para fechar o sistema.\n");
        string escolha = Console.ReadLine();

        switch (escolha)
        {
            case "1":
                hotel.CriarReserva(reservas, quartosDisponiveis, quartosExistentes);
                break;


            case "2":
                hotel.DarBaixaEmReservas(quartosDisponiveis, quartosExistentes, reservas);
                break;

            case "3":
                hotel.ListaQuartosDisponiveis(quartosDisponiveis);
                Console.WriteLine("\n\nDigite qualquer tecla para voltar ao menu principal.");
                Console.ReadKey();
                break;

            case "4":
                hotel.ListaReservasDisponiveis(reservas);
                Console.WriteLine("\n\nDigite qualquer tecla para voltar ao menu principal.");
                Console.ReadKey();
                break;

            case "5":
                Console.WriteLine("Encerrando o sistema...\n");
                Thread.Sleep(1500);
                Console.WriteLine("Tchau tchau...");
                Thread.Sleep(2000);
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("Opção inválida");
                Thread.Sleep(3000);
                break;

        }
    }
}













