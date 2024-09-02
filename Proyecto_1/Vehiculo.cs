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

        protected string  Marca { get; set; }
        protected string Modelo { get; set; }
        protected string Color { get; set; }
        public DateTime Ingreso { get; set; }
        public DateTime Salida { get; set; }

        public virtual void MostrarInformacion() //base de la funcion mostrarInfo
        {
            Console.WriteLine("--------VEHICULOS ESTACIONADOS--------");
            Console.WriteLine("\nPlaca:" + Placa);
            Console.WriteLine("\nMarca:" + Marca);
            Console.WriteLine("\nModelo:" + Modelo);
            Console.WriteLine("\nColor:" + Color);
            Console.WriteLine("\nHora Ingreso:" + Ingreso);
            Console.WriteLine("\nPrecio Hora: Q." + PrecioHora);
        }
        public int CalcularSegundos() //se calculan los segundos entre la entrada y salida
        {
            double totalSec;
            Salida = DateTime.Now;
            totalSec = (Salida - Ingreso).TotalSeconds; //total seconds nos da el total de los segundos (los cuales tomaremos como horas)
            int segundos = Convert.ToInt16(Math.Round(totalSec));
            return segundos;
        }

        //aqui se puede observar el encapsulamiento
        protected decimal PrecioHora { get; set; } //atributo protected
        public decimal GetPrecio() //visualizado con metodo publico
        {
            return PrecioHora; 
        }
        protected string Placa { get; set; } //atributo protected
        public string GetPlaca() //metodo publico
        {
            return Placa.ToLower().Trim(); 
        }
    }
}
