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
        public (decimal, int) CalcularTotal()
        { 
            int segundos = Vehiculo.CalcularSegundos();
            int fraccionesCobradas = 1;
            for (int i = 30; i <= segundos; i += 30)
            {
                fraccionesCobradas += 1;
            }
            decimal total = fraccionesCobradas * (Vehiculo.GetPrecio() /2);
            return (total, fraccionesCobradas);
        }
        public decimal AplicarRecargo(decimal total)
        {
            decimal Recargo = total * Convert.ToDecimal(0.10); 
            return total + Recargo;
        }
        public int[] DarVuelto(decimal dineroPagado, decimal total)
        {
            int[] Billetes = {200,100,50,20,10,5,1};
            int[] cantidadCadaBillete = new int[8];
            int dinero = Convert.ToInt32(dineroPagado - total);
            cantidadCadaBillete[7] =  Convert.ToInt32((dineroPagado - dinero) * 100);
            int i = 0;
            foreach (int billete in Billetes)
            {
                if (dinero > 0)
                {
                    int cantidadBillete;
                    cantidadBillete = dinero / billete;
                    dinero = dinero % billete;
                    cantidadCadaBillete[i] = cantidadBillete;
                    i++;
                }
                else break;
            }
            return cantidadCadaBillete;
            
        }
        public void SetVehiculo(Vehiculo Vehiculo) => this.Vehiculo = Vehiculo;
        public void CobroEfectivo(decimal total)
        {
            decimal dineroPagado;
            Console.WriteLine("------PAGO EFECTIVO------");
            do
            {
                dineroPagado = PedirPrecio();
                if(dineroPagado < total)
                {
                    Console.WriteLine("El monto es insuficiente... faltan Q." + (total - dineroPagado));
                    Console.WriteLine("Se le pedira un monto adicional");
                    dineroPagado += PedirPrecio();
                }
            } while (dineroPagado<total);
            if(dineroPagado == total)
            {
                Estacionamiento estacionamiento1 = new Estacionamiento();
                estacionamiento1.Confirmacion();
                return;
            }
            int[] BilletesVuelto = DarVuelto(dineroPagado, total);
            int[] Billetes = { 200, 100, 50, 20, 10, 5, 1 };
            int i = 0;
            Console.WriteLine("Se entregara el vuelto en las siguientes denominaciones: \n");
            foreach (int billete in BilletesVuelto)
            {
                if (billete != 0 && i != 7)
                {
                    Console.WriteLine($"{billete} de Q. {Billetes[i]}.00");
                }
                //else if (i == 7 && billete != 0)
                //{
                //    Console.WriteLine($"Y se devolveran Q. 0.{billete} que dio de extra");
                //}
                i++;
            }
            Console.WriteLine("Presione ENTER para entregar vuelto");
            Console.ReadLine();        
        }
        public decimal PedirPrecio()
        {
            do
            {
                try
                {

                    decimal precio;
                    do
                    {
                        Console.Write("\nIngrese el monto a entregar: Q.");
                        precio = decimal.Parse(Console.ReadLine());
                        if (precio == 0 || precio == null)
                        {
                            Console.WriteLine("Valor no puede ser 0");
                            Console.ReadLine();
                        }
                    } while (precio == 0);
                    return precio;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("INPUT INVALIDO");
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----PAGO EFECTIVO-----");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("EL numero es demasiado grande");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----PAGO EFECTIVO-----");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----PAGO EFECTIVO-----");
                }
            } while (true);
        }
    }
}
