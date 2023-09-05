using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_ISW_G3.Control
{
    public class Direccion
    {
        private string calle;
        private int numero;
        private string ciudad;
        private string referencia;
        private string nombreCalle;
        private string numero1;

        public Direccion(string nombreCalle, string numero1, string ciudad, string referencia)
        {
            this.nombreCalle = nombreCalle;
            this.numero1 = numero1;
            this.ciudad = ciudad;
            this.referencia = referencia;
        }
    }
}
