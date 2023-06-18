using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Streaming.logica
{
    public class VistaTarjeta
    {
        public string Codigo { get; set; }
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string NumeroTarjeta { get; set; }
        public string NombreTarjeta { get; set; }

        // Constructor de la clase
        public VistaTarjeta(string codigo, string primerNombre, string primerApellido, string numeroTarjeta, string nombreTarjeta)
        {
            Codigo = codigo;
            PrimerNombre = primerNombre;
            PrimerApellido = primerApellido;
            NumeroTarjeta = numeroTarjeta;
            NombreTarjeta = nombreTarjeta;
        }
        public VistaTarjeta()
        {
        }
        public override string ToString()
        {
            return $"Nombre: {PrimerNombre} {PrimerApellido}, Número Tarjeta: {NumeroTarjeta}, Nombre Tarjeta: {NombreTarjeta}";
        }
        public string devolverNumeroTarjeta(string input)
        {
            Regex regex = new Regex(@"Número Tarjeta: (\d+)");
            Match match = regex.Match(input);
            string numeroTarjeta = "";
            if (match.Success)
            {
                numeroTarjeta = match.Groups[1].Value;
            }
            return numeroTarjeta;
        }
    }

}
