using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReservaDeHotel.Modelos
{
    public class Quarto 
    {
        public Quarto(int numero, string tipo, double valor)
        {
            NumeroQuarto = numero;
            TipoDeQuarto = tipo;
            ValorQuarto = valor;
        }

        public int NumeroQuarto { get; set; }
        public string TipoDeQuarto { get; set; }
        public double ValorQuarto { get; set; }  
    }
}
