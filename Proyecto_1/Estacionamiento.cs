using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    internal class Estacionamiento
    {
        private List<Vehiculo> vehiculosEstacionados = new List<Vehiculo>();
        private Caja Caja = new Caja();
        private int EspaciosCarro = 3;
        private int EspaciosMoto = 5;
        private int EspaciosBus = 0;

        public void IngresarVehiculo ()
        {
            string tipoVehiculo;
            do
            {
                Console.Clear();
                Console.WriteLine("------INGRESO DE VEHICULO------");
                Console.WriteLine("\n      1. Ingresar Carro");
                Console.WriteLine("      2. Ingresar Motocicleta");
                Console.WriteLine("      3. Ingresar Bus");
                Console.WriteLine("      4. Regresar");
                Console.Write("\nPorfavor seleccione una opcion: ");
                tipoVehiculo = Console.ReadLine();
                string Placa, Marca, Modelo, Color;
                int indiceEncontrado;
                if(tipoVehiculo != "1" &&  tipoVehiculo != "2" && tipoVehiculo != "3" || !Disponiblidad(tipoVehiculo))
                {
                    return;
                }
                do
                {
                    Console.Write("Ingrese Numero de Placa: ");
                    Placa = Console.ReadLine();
                    indiceEncontrado = BuscarVehiculo(Placa);
                } while (indiceEncontrado != -1);
                Console.Write("Ingrese marca: ");
                Marca = Console.ReadLine();
                Console.Write("Ingrese Modelo: ");
                Modelo = Console.ReadLine();
                Console.Write("Ingrese Color: ");
                Color = Console.ReadLine();
                if(tipoVehiculo == "1")
                {
                    vehiculosEstacionados.Add(new Carro(Placa,Marca,Modelo,Color, DateTime.Now, 20));
                    EspaciosCarro--;
                }
                else if (tipoVehiculo == "2")
                {
                    vehiculosEstacionados.Add(new Motocicleta(Placa, Marca, Modelo, Color, DateTime.Now, 10));
                    EspaciosMoto--;
                }
                else if (tipoVehiculo == "3")
                {
                    vehiculosEstacionados.Add(new Bus(Placa, Marca, Modelo, Color, DateTime.Now, 40));
                    EspaciosBus--;
                }
            } while (true);
        }
        public void NoDisponibilidad()
        {
            var sec = 4;
            bool isTimeIsUp = false;
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("No hay disponiblidad para su vehiculo, porfavor regrese mas tarde");
            Console.Write("Sera regresado al menu en  ");
            int i = 4;
            int left = Console.GetCursorPosition().Left;
            int top = Console.GetCursorPosition().Top;
            do
            {
                if(stopwatch.Elapsed.TotalSeconds == 1 || stopwatch.Elapsed.TotalSeconds == 2 || stopwatch.Elapsed.TotalSeconds == 3 || stopwatch.Elapsed.TotalSeconds == 4)
                {
                    Console.SetCursorPosition(left,top);
                    Console.Write(i - stopwatch.Elapsed.Seconds);
                }
                if (stopwatch.Elapsed.Seconds > sec)
                {
                    Console.ResetColor();
                    return;
                }
            }while (true);
        }
        public bool Disponiblidad(string tipoVehiculo)
        {
            if (tipoVehiculo == "1" && EspaciosCarro <= 0)
            {
                NoDisponibilidad();
                return false;
            }
            else if (tipoVehiculo == "2" && EspaciosMoto <= 0)
            {
                NoDisponibilidad();
                return false;
            }
            else if (tipoVehiculo == "3" && EspaciosBus <= 0)
            {
                NoDisponibilidad();
                return false;
            }
            return true;
        }
        public int BuscarVehiculo(string placa)
        {
            int indice = -1;
            foreach(var vehiculo in vehiculosEstacionados)
            {
                if(vehiculo.GetPlaca() == placa.ToLower().Trim())
                {
                    indice = vehiculosEstacionados.IndexOf(vehiculo);
                }
            }
            return indice;
        }
    }
}
