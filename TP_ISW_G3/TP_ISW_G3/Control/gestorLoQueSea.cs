using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_ISW_G3.Interfaces;

namespace TP_ISW_G3.Control
{
    internal class gestorLoQueSea
    {
        private frmInicio frmInicio;
        private frmLoQueSea frmLoQueSea;

        public gestorLoQueSea(frmInicio frmInicio)
        {
            this.frmInicio = frmInicio;
        }

        public void crearFormLoQueSea()
        {
            frmInicio.Hide();
            frmLoQueSea = new frmLoQueSea();
            frmLoQueSea.Show();
        }
    }
}
