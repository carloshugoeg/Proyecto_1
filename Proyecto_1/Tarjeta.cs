﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    internal class Tarjeta
    {
        //tarjeta puede ser obviado, solamente se usa para verificar un formato correcto. Sin embargo 
        private string NumeroTarjeta { get; set; }
        private string NombreTitular { get; set; }
        private int MMVencimiento { get; set; }
        private int YYVencimiento { get; set; }
        private int CVV {  get; set; }
        public Tarjeta(string numeroTarjeta, string nombreTitular, int mMVencimiento, int yYVencimiento, int cVV)
        {
            NumeroTarjeta = numeroTarjeta;
            NombreTitular = nombreTitular;
            MMVencimiento = mMVencimiento;
            YYVencimiento = yYVencimiento;
            CVV = cVV;
        }
    }
}
