using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReservaDeHotel.Modelos
{
    public class Hospede
    {
        public string NomeCompleto { get; set; }

        public Hospede(string nome)
        {
            NomeCompleto = nome;
        }
    }
}
