using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaDeReservaDeHotel.Modelos
{
    public class Hotel
    {

        // Funcionalidades do menu.

        public void CriarReserva(List<Reserva> lista, List<Quarto> listaQuarto, List<Quarto> quartosExistentes)
        {

            while (true)
            {
                ListaQuartosDisponiveis(listaQuarto);
                Console.WriteLine("Escolha o quarto disponível acima para reservar e preencha as informações abaixo: \n");
                Console.WriteLine("Insira o seu nome completo: ");
                string nome = Console.ReadLine();
                Hospede nomeHospede = new Hospede(nome);

                Console.WriteLine("\nInsira o numero da suite que deseja reservar");
                string numeroDigitado = Console.ReadLine();
                int reservaNumero;
                bool confirmaNumero = int.TryParse(numeroDigitado, out reservaNumero);

                if (confirmaNumero == false)
                {
                    Console.WriteLine("\nVocê precisa digitar um número válido e que esteja na lista de quartos disponíveis.");
                    Thread.Sleep(3000);
                    Console.Clear();
                    continue;
                }

                confirmaNumero = VerificaNumeroQuartoNaLista(listaQuarto, reservaNumero);

                if (confirmaNumero == false)
                {
                    Console.WriteLine("\nSuite digitada não está na lista de disponíveis.");
                    Thread.Sleep(3000);
                    Console.Clear();
                    continue;
                }

                Console.WriteLine("\nInsira a data do checkin no formato dd/MM/yyyy: ");
                string checkinReserva = Console.ReadLine();
                DateTime checkin = RetornaDataFormatada(checkinReserva);

                if (checkin == DateTime.MinValue)
                {
                    Console.WriteLine("\nFormato de data inválido.");
                    Thread.Sleep(3000);
                    continue;
                }

                Console.WriteLine("\nInsira a data do checkout no formato DD/MM/AAAA: ");
                string chekoutReserva = Console.ReadLine();
                DateTime checkout = RetornaDataFormatada(chekoutReserva);

                if (checkout == DateTime.MinValue)
                {
                    Console.WriteLine("\nFormato de data inválido.");
                    Thread.Sleep(3000);
                    continue;
                }

                Thread.Sleep(1500);
                TimeSpan diarias = checkout - checkin;
                int numeroDeDiasReservados = diarias.Days + 1;
                double valorQuarto = EncontrarValorQuarto(listaQuarto, reservaNumero);
                double valorTotalDaReserva = numeroDeDiasReservados * valorQuarto;

                Console.Clear();
                LogoSistema();
                Console.WriteLine("\nConfirme as informaões digitadas: ");
                Thread.Sleep(2000);
                Console.WriteLine("\n-\n");
                Console.Write($"Nome: {nomeHospede.NomeCompleto}. \n");
                Console.Write($"Suite N: {reservaNumero}. \n");
                Console.Write($"Checkin: {checkin}. \n");
                Console.Write($"Checkout: {checkout}. \n");
                Console.Write($"Número de diarias: {numeroDeDiasReservados}. \n");
                Console.Write($"Valor total da reserva: {valorTotalDaReserva}R$. \n");
                Console.WriteLine("\n-\n");

                Console.WriteLine("Para confirmar as informações, digite 1.");
                Console.WriteLine("Para preencher novamente pressione qualquer outro número ou letra.");
                string escolha = Console.ReadLine();
                if (escolha == "1")
                {

                    Reserva reserva = new Reserva(checkin, checkout, reservaNumero, nomeHospede);
                    lista.Add(reserva);
                    RemoverQuartoReservado(listaQuarto, reservaNumero);
                    Console.WriteLine("\nReserva efetuada com sucesso !");
                    Thread.Sleep(4000);
                    break;
                }

                continue;

            }
        }


        //------------------------------------------------------------------------------------------------------------------------------------------------------------


        public void DarBaixaEmReservas(List<Quarto> listaQuartoDisponivel, List<Quarto> listaQuartoExistente, List<Reserva> listaReserva)
        {

            while (true)
            {
                ListaReservasDisponiveis(listaReserva);

                if (listaReserva.Count == 0)
                {
                    Console.WriteLine("\n\nNão há reservas ativas no sistema.");
                    Thread.Sleep(3000);
                    break;
                }

                Console.WriteLine("Digite abaixo o nome do cliente para dar a baixa na reserva.");
                string nomeCliente = Console.ReadLine();
                bool confirmaNomeNaLista = VerificarSeNomeEstaNaLista(listaReserva, nomeCliente);

                if (confirmaNomeNaLista == false)
                {
                    Console.WriteLine("\n\nFavor inserir um nome de cliente contido na reserva ativa que deseja dar baixa.");
                    Thread.Sleep(3000);
                    continue;
                }

                foreach (var reserva in listaReserva)
                {
                    if (nomeCliente == reserva.NomeHospede.NomeCompleto)
                    {
                        Console.WriteLine("\n-\n");
                        Console.WriteLine($"Nome do hospede: {reserva.NomeHospede.NomeCompleto}");
                        Console.WriteLine($"Numero do quarto: {reserva.NumeroQuartoReservado}");
                        Console.WriteLine($"Checkin: {reserva.Checkin}");
                        Console.WriteLine($"Checkout: {reserva.Checkout}");
                        Console.WriteLine("\n-\n");
                        Console.WriteLine("Confira as informações acima\n");
                        Thread.Sleep(5000);
                        listaReserva.Remove(reserva);
                        Console.WriteLine("\nBaixa efetuada com sucesso! \n");
                        Console.WriteLine("Voltando ao menu principal. ");
                        ReAdicionarQuartoReservado(listaQuartoDisponivel, listaQuartoExistente, reserva.NumeroQuartoReservado);
                        Thread.Sleep(4000);
                        break;
                    }
                }
                break;
            }
        }


        //------------------------------------------------------------------------------------------------------------------------------------------------------------


        public void ListaQuartosDisponiveis(List<Quarto> lista)
        {
            Console.Clear();
            LogoSistema();
            foreach (var item in lista)
            {
                Console.WriteLine("\n------------------------------------------------------------------");
                Console.WriteLine($"Numero do quarto: {item.NumeroQuarto}");
                Console.WriteLine($"Tipo do quarto: {item.TipoDeQuarto}");
                Console.WriteLine($"Valor do quarto: {item.ValorQuarto}");
                Console.WriteLine("------------------------------------------------------------------\n");
            }
        }


        //------------------------------------------------------------------------------------------------------------------------------------------------------------


        public void ListaReservasDisponiveis(List<Reserva> lista)
        {
            Console.Clear();
            LogoSistema();
            foreach (var item in lista)
            {
                Console.WriteLine("\n------------------------------------------------------------------");
                Console.WriteLine($"Nome do hospede: {item.NomeHospede.NomeCompleto}");
                Console.WriteLine($"Numero do quarto: {item.NumeroQuartoReservado}");
                Console.WriteLine($"Checkin: {item.Checkin}");
                Console.WriteLine($"Checkout: {item.Checkout}");
                Console.WriteLine("------------------------------------------------------------------\n");
            }
        }


        // Funções para adicionar e remover quartos da lista de disponiveis.
        

        public void RemoverQuartoReservado(List<Quarto> listaQuarto, int numeroQuartoReservado)
        {
            
            foreach (var item in listaQuarto)
            {
                    
                if (item.NumeroQuarto == numeroQuartoReservado)
                {
                    listaQuarto.Remove(item);
                    break;
                }

            }
        }


        //------------------------------------------------------------------------------------------------------------------------------------------------------------


        public void ReAdicionarQuartoReservado(List<Quarto> listaQuartoDisponivel, List<Quarto> listaQuartoExistente, int numeroQuartoReservado)
        {
            
            foreach (var item in listaQuartoExistente)
            {
                if(item.NumeroQuarto == numeroQuartoReservado)
                {
                    listaQuartoDisponivel.Add(item);
                }
            }
        }


        // Função para encontrar o valor total em reais do quarto escolhido.


        public double EncontrarValorQuarto(List<Quarto> lista, int numeroDoQuartoReservado)
        {
            double valorDoQuarto = 0;
            foreach (var item in lista)
            {
                if (item.NumeroQuarto == numeroDoQuartoReservado)
                {
                    valorDoQuarto = item.ValorQuarto;
                    return valorDoQuarto;
                }
            }
            return valorDoQuarto;
            
        }


        // Funções usadas para tratar erros de digitação ou para verificar se os dados informados
        // estão presentes nas listas.


        public bool VerificaNumeroQuartoNaLista(List<Quarto> lista, int numeroDeSuiteInformado)
        {
            foreach (var item in lista)
            {
                if (item.NumeroQuarto == numeroDeSuiteInformado)
                {
                    return true;
                }
            }

            return false;
        }


        //------------------------------------------------------------------------------------------------------------------------------------------------------------


        public DateTime RetornaDataFormatada(string data)
        {
            DateTime dataFormatada;
            string formatoCorreto = "dd/MM/yyyy";

            if (DateTime.TryParseExact(data, formatoCorreto, null, System.Globalization.DateTimeStyles.None, out dataFormatada))
            {
                return dataFormatada;
            } else
            {
                return DateTime.MinValue;
            }
        }


        //------------------------------------------------------------------------------------------------------------------------------------------------------------


        public bool VerificarSeNomeEstaNaLista(List<Reserva> listaReserva, string nome)
        {
            foreach (var item in listaReserva)
            {
                if (nome == item.NomeHospede.NomeCompleto)
                {
                    return true;
                }
            }
            return false;
        }


        // Função que mostra o logotipo do sistema.


        public void LogoSistema()
        {
            Console.WriteLine(@"
██╗░░██╗░█████╗░████████╗███████╗██╗░░░░░  ███╗░░░███╗░█████╗░███╗░░██╗░█████╗░░██████╗░███████╗██████╗░
██║░░██║██╔══██╗╚══██╔══╝██╔════╝██║░░░░░  ████╗░████║██╔══██╗████╗░██║██╔══██╗██╔════╝░██╔════╝██╔══██╗
███████║██║░░██║░░░██║░░░█████╗░░██║░░░░░  ██╔████╔██║███████║██╔██╗██║███████║██║░░██╗░█████╗░░██████╔╝
██╔══██║██║░░██║░░░██║░░░██╔══╝░░██║░░░░░  ██║╚██╔╝██║██╔══██║██║╚████║██╔══██║██║░░╚██╗██╔══╝░░██╔══██╗
██║░░██║╚█████╔╝░░░██║░░░███████╗███████╗  ██║░╚═╝░██║██║░░██║██║░╚███║██║░░██║╚██████╔╝███████╗██║░░██║
╚═╝░░╚═╝░╚════╝░░░░╚═╝░░░╚══════╝╚══════╝  ╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝░╚═════╝░╚══════╝╚═╝░░╚═╝");
        }   
    }
}
