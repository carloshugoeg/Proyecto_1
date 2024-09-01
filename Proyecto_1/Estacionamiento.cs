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
        private int EspaciosBus = 1;


        public void VerEspacios()
        {
            Console.WriteLine("Espacios Vehiculo Convencional: " + EspaciosCarro);

            Console.WriteLine("Espacios para Motocicletas: " + EspaciosMoto);

            Console.WriteLine("Espacios para Bus: " + EspaciosBus);
        }

        public void IngresarEspacios()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("----BUENOS DIAS----");
            Console.WriteLine("Antes de aperturar porfavor ingrese cuantos espacios de cada vehiculo habran hoy");
            Console.WriteLine("Si los espacios seran aparados durante todo el dia ingrese '0'");
            Console.ResetColor();
            int espaciosCarro, espaciosMoto, espaciosBus;
            do
            {
                Console.Write("Espacios Carro: ");
                espaciosCarro = PedirInt();
                Console.Write("Espacios Moto: ");
                espaciosMoto = PedirInt();
                Console.Write("Espacios Bus: ");
                espaciosBus = PedirInt();
                if(espaciosCarro >= 0 && espaciosBus >= 0 && espaciosMoto >= 0)
                {
                    EspaciosCarro = espaciosCarro;
                    EspaciosMoto = espaciosMoto;
                    EspaciosBus = espaciosBus;
                    break;
                }
                Console.WriteLine("No pueden haber espacios negativos");
            }while(true);
        }
        public void VerVehiculos()
        {
            if (vehiculosEstacionados.Count > 0)
            {
                foreach (Vehiculo vehiculo in vehiculosEstacionados)
                {
                    vehiculo.MostrarInformacion();
                }
                Console.WriteLine("Presione ENTER para continuar"); Console.ReadLine();
            }
            else { NoVehiculos(); }
        }
        public void IngresarVehiculo ()
        {
            string tipoVehiculo;
            do
            {
                Console.Clear();
                Console.WriteLine("------INGRESO DE VEHICULO------");
                Console.WriteLine("\n      1. Ingresar Carro..........Q.20/h");
                Console.WriteLine("      2. Ingresar Motocicleta....Q.10/h");
                Console.WriteLine("      3. Ingresar Bus............Q.30/h");
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
                    Confirmacion();
                }
                else if (tipoVehiculo == "2")
                {
                    vehiculosEstacionados.Add(new Motocicleta(Placa, Marca, Modelo, Color, DateTime.Now, 10));
                    EspaciosMoto--;
                    Confirmacion();
                }
                else if (tipoVehiculo == "3")
                {
                    vehiculosEstacionados.Add(new Bus(Placa, Marca, Modelo, Color, DateTime.Now, 40));
                    EspaciosBus--;
                    Confirmacion();
                }
            } while (true);
        }

        public void RetirarVehiculo()
        {
            string placa;
            int indice = -1;
            Vehiculo VehiculoRetirar;
            Console.WriteLine("------RETIRAR VEHICULO------");
            if (vehiculosEstacionados.Count == 0)
            {
                NoVehiculos();
                return;
            }
            Console.WriteLine("\nPorfavor ingrese numero de placa");
            do
            {
                Console.Clear();
                Console.WriteLine("------RETIRAR VEHICULO------\n");
                Console.Write("\nPlaca: ");
                placa = Console.ReadLine();
                indice = BuscarVehiculo(placa);
            } while (indice == -1);
            VehiculoRetirar = vehiculosEstacionados[indice];
            Caja.SetVehiculo(VehiculoRetirar);
            (decimal total, int fraccionesCobradas) = Caja.CalcularTotal();
            Console.Write($"Se cobraran {fraccionesCobradas / 2} horas");
            if(fraccionesCobradas % 2 == 1) Console.Write(", se le aproximara a la siguiente fraccion");
            Console.WriteLine("\nSu total es de: Q." + total);
            do
            {
                Console.WriteLine("Seleccione metodo de pago");
                Console.WriteLine("\n     1. Efectivo");
                Console.WriteLine("     2. Tarjeta");
                string option = Console.ReadLine();
                if(option == "1")
                {
                    Caja.CobroEfectivo(total);
                    Confirmacion();
                    break;
                }
                else if(option == "2")
                {
                    if (Caja.CobroTarjeta(total))
                    {
                        break;
                    }
                }
            }while(true);
            if (VehiculoRetirar is Carro) EspaciosCarro += 1;
            else if (VehiculoRetirar is Motocicleta) EspaciosMoto += 1;
            else if (VehiculoRetirar is Bus) EspaciosBus += 1;
            vehiculosEstacionados.Remove(VehiculoRetirar);

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
        public void Confirmacion()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            var sec = 4;
            bool isTimeIsUp = false;
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine("Operacion realizada correctamente");
            Console.WriteLine("GRACIAS POR PREFERIRNOS");
            Console.Write("Sera regresado al menu en  ");
            int i = 4;
            int left = Console.GetCursorPosition().Left;
            int top = Console.GetCursorPosition().Top;
            do
            {
                if (stopwatch.Elapsed.TotalSeconds == 1 || stopwatch.Elapsed.TotalSeconds == 2 || stopwatch.Elapsed.TotalSeconds == 3 || stopwatch.Elapsed.TotalSeconds == 4)
                {
                    Console.SetCursorPosition(left, top);
                    Console.Write(i - stopwatch.Elapsed.Seconds);
                }
                if (stopwatch.Elapsed.Seconds > sec)
                {
                    Console.ResetColor();
                    return;
                }
            } while (true);
        }
        public void NoVehiculos()
        {
            var sec = 4;
            bool isTimeIsUp = false;
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("No hay vehiculos estacionados, porfavor ingrese vehiculo antes");
            Console.Write("Sera regresado al menu en  ");
            int i = 4;
            int left = Console.GetCursorPosition().Left;
            int top = Console.GetCursorPosition().Top;
            do
            {
                if (stopwatch.Elapsed.TotalSeconds == 1 || stopwatch.Elapsed.TotalSeconds == 2 || stopwatch.Elapsed.TotalSeconds == 3 || stopwatch.Elapsed.TotalSeconds == 4)
                {
                    Console.SetCursorPosition(left, top);
                    Console.Write(i - stopwatch.Elapsed.Seconds);
                }
                if (stopwatch.Elapsed.Seconds > sec)
                {
                    Console.ResetColor();
                    return;
                }
            } while (true);
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
        public int PedirInt()
        {
            do
            {
                try
                {
                    int monto;
                    monto = int.Parse(Console.ReadLine());
                    return monto;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("INPUT INVALIDO");
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----APERTURA ESTACIONAMIENTO-----\n");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("EL numero es demasiado grande");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----APERTURA ESTACIONAMIENTO-----\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----APERTURA ESTACIONAMIENTO-----\n");
                }
            } while (true);
        }
    }
}
