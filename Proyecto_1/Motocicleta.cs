using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    internal class Motocicleta : Vehiculo
    {
        public Motocicleta(string placa, string marca, string modelo, string color, DateTime ingreso, decimal precioHora) : base(placa, marca, modelo, color, ingreso, precioHora)
        {
        }
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine("Tipo Vehiculo: Motocicleta");
        }
    }
}
