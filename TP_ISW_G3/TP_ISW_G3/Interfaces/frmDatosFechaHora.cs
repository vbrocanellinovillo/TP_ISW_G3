using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_ISW_G3.Control;

namespace TP_ISW_G3.Interfaces
{
    public partial class frmDatosFechaHora : Form
    {

        private gestorLoQueSea gestor;
        private DateTime dateValue;
        private TimeSpan timeValue;

        private bool dateValid;
        private bool dateTouched;

        public frmDatosFechaHora(Control.gestorLoQueSea gestorLoQueSea)
        {
            InitializeComponent();
            gestor = gestorLoQueSea;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            DateTime fechaActual = DateTime.Now.Date;
            TimeSpan horaActual = DateTime.Now.TimeOfDay;

            if (dateValue.Date < fechaActual.Date)
            {
                dateValid = false;
                MessageBox.Show("LA FECHA TIENE QUE SER MAYOR A HOY");
                return;
            }
            if(dateValue == fechaActual)
            {
                if(timeValue < horaActual)
                {
                    dateValid = false;
                    MessageBox.Show("LA HORA TIENE QUE SER MAYOR A AHORA");
                    return;
                }
            }
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas es fecha y hora?", "Confirmación", MessageBoxButtons.YesNo);



            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Pedido confirmado!!");
                this.Hide();
            }
        }

        public void validarFecha()
        {
            DateTime fechaActual = DateTime.Now;

            if (dateValue > fechaActual)
            {
                dateValid = false;
                MessageBox.Show("mal");
                return;
            }

            dateTouched = true;
            return;
        }

        public void estiloFecha()
        {
            if (!dateValid && dateTouched)
            {
                label1.Visible = true;
                label1.ForeColor = gestor.setErrorText();
            } else
            {
                label1.Visible = false;
            }
        }

        private void dtpFechaHora_ValueChanged(object sender, EventArgs e)
        {
            dateValue = dtpFechaHora.Value;
           // validarFecha();
            estiloFecha();
        }

        private void dtpFechaHora_Leave(object sender, EventArgs e)
        {
            dateTouched = true;
           // validarFecha();
            estiloFecha();
        }

        private void dtpHora_ValueChanged(object sender, EventArgs e)
        {
            timeValue = dtpHora.Value.TimeOfDay;
        }
    }
}
