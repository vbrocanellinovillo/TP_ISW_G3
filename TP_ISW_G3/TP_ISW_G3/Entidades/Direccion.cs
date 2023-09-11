using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_ISW_G3.Control
{
    public class direccion
    {
        private string nombreCalle;
        private string numero;
        private string ciudad;
        private string referencia;

        public direccion(string nombreCalle, string numero1, string ciudad, string referencia)
        {
            this.nombreCalle = nombreCalle;
            this.numero = numero1;
            this.ciudad = ciudad;
            this.referencia = referencia;
        }
    }
}
