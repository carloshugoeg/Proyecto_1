using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    internal class Caja
    {
        public Caja() { }
        protected Vehiculo Vehiculo { get; set; }
        public decimal CalcularTotal()
        { 
            int minutos = Vehiculo.CalcularMinutos();
            int fraccionesCobradas = 0;
            for (int i = 30; i >= minutos; i += 30)
            {
                fraccionesCobradas += 1;
            }
            decimal total = fraccionesCobradas * (Vehiculo.GetPrecio() /2);
            return total;
        }
        public decimal AplicarRecargo(decimal total)
        {
            decimal Recargo = total * Convert.ToDecimal(0.10); 
            return total + Recargo;
        }
        public void DarVuelto()
        {
            
        }
        public void SetVehiculo(Vehiculo Vehiculo) => this.Vehiculo = Vehiculo;
    }
}
