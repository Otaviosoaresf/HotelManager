using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaDeReservaDeHotel.Modelos
{
    public class Reserva
    {
        public Reserva(DateTime checkin, DateTime checkout, int quarto, Hospede hospede)
        {
            Checkin = checkin;
            Checkout = checkout;
            NumeroQuartoReservado = quarto;
            NomeHospede = hospede;
        }

        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public int NumeroQuartoReservado { get; }
        public Hospede NomeHospede { get; }
    }
}
