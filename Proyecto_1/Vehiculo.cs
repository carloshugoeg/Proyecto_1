using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    internal class Vehiculo
    {
        public Vehiculo(string placa, string marca, string modelo, string color, DateTime ingreso, decimal precioHora)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Color = color;
            Ingreso = ingreso;
            PrecioHora = precioHora;
        }

        protected string Placa { get; set; }
        protected string  Marca { get; set; }
        protected string Modelo { get; set; }
        protected string Color { get; set; }
        public DateTime Ingreso { get; set; }
        public DateTime Salida { get; set; }
        protected decimal PrecioHora { get; set; }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine("--------VEHICULOS ESTACIONADOS--------");
            Console.WriteLine("\nPlaca:" + Placa);
            Console.WriteLine("\nMarca:" + Marca);
            Console.WriteLine("\nModelo:" + Modelo);
            Console.WriteLine("\nColor:" + Color);
            Console.WriteLine("\nHora Ingreso:" + Ingreso);
            Console.WriteLine("\nPrecio Hora: Q." + PrecioHora);
        }
        public int CalcularSegundos()
        {
            double totalSec;
            Salida = DateTime.Now;
            totalSec = (Salida - Ingreso).TotalSeconds;
            int segundos = Convert.ToInt16(Math.Round(totalSec));
            return segundos;
        }

        public decimal GetPrecio()
        {
            return PrecioHora; 
        }
        public string GetPlaca()
        {
            return Placa.ToLower().Trim(); 
        }
    }
}
