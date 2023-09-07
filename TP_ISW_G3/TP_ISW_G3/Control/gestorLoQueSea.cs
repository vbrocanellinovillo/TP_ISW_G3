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
        private frmDireccion frmDireccionComercio;
        private frmDireccion frmDireccionEntrega;
        private frmPago frmPago;

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

        public void crearFormDireccionComercio(string titulo)
        {
            frmLoQueSea.Hide();
            frmDireccionComercio = new frmDireccion(this, titulo);
            frmDireccionComercio.Show();
        }

        public void cargarDireccionComercio(Direccion _direccionComercio)
        {
            direccionComercio = _direccionComercio;
        }



        public void crearFormDireccionEntrega(string titulo)
        {
            frmDireccionComercio.Hide();
            frmDireccionEntrega = new frmDireccion(this, titulo);
            frmDireccionEntrega.Show();
        }

        public void cargarDireccionEntrega(Direccion _direccionEntrega)
        {
            direccionEntrega = _direccionEntrega;
        }

        public void crearFormPago()
        {
            frmDireccionEntrega.Hide();
            frmPago = new frmPago(this);
            frmPago.Show();
        }
    }
}
