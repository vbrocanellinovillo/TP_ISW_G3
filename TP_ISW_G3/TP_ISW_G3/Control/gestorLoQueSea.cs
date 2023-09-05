using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_ISW_G3.Interfaces;

namespace TP_ISW_G3.Control
{
    public class gestorLoQueSea
    {
        private frmInicio frmInicio;
        private frmLoQueSea frmLoQueSea;
        private frmDireccionComercio frmDireccion;

        private Direccion direccionComercio;
        private Direccion direccionEntrega;

        public gestorLoQueSea(frmInicio frmInicio)
        {
            this.frmInicio = frmInicio;
        }

        public void crearFormLoQueSea()
        {
            frmInicio.Hide();
            frmLoQueSea = new frmLoQueSea(this);
            frmLoQueSea.Show();
        }

        internal void crearFormDireccion()
        {
            frmLoQueSea.Hide();
            frmDireccion = new frmDireccionComercio(this);
            frmDireccion.Show();
        }

        public void cargarDireccionComercio(Direccion _direccionComercio)
        {
            direccionComercio = _direccionComercio;
        }

        public void cargarDireccionEntrega(Direccion _direccionEntrega)
        {
            direccionEntrega = _direccionEntrega;
        }

    }
}
