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

        private bool dateValid = false;
        private bool timeValid = false;

        public frmDatosFechaHora(Control.gestorLoQueSea gestorLoQueSea)
        {
            InitializeComponent();
            gestor = gestorLoQueSea;

            dateValue = DateTime.Now;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            DateTime fechaActual = DateTime.Now.Date;
            TimeSpan horaActual = DateTime.Now.TimeOfDay;

            if (dateValue.Date < fechaActual.Date)
            {
                dateValid = false;
                MessageBox.Show("La fecha tiene que mayor a la de hoy");
                return;
            }

            if (timeValue.Hours <= 7 && timeValue.Hours >= 0)
            {
                timeValid = false;
                MessageBox.Show("No se puede en ese horario");
                return;
            }

            if (dateValue.Date == fechaActual.Date)
            {
                if(timeValue < horaActual)
                {
                    dateValid = false;
                    MessageBox.Show("La hora tiene que ser mayor a la hora actual");
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

        //public void validarFecha()
        //{
        //    DateTime fechaActual = DateTime.Now;

        //    if (dateValue.Date == fechaActual.Date) 
        //    {
        //        dateValid = true;
        //        return;
        //    }

        //    if (dateValue < fechaActual)
        //    {
        //        dateValid = false;
        //        label1.Text = "*Por favor ingrese una fecha valida";
        //        return;
        //    }

        //    dateValid = true;
        //    return;
        //}

        public void estiloFecha()
        {
            if (!dateValid)
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
            //validarFecha();
            //estiloFecha();
        }

        public void validarHora()
        {
            DateTime fechaActual = DateTime.Now;
            TimeSpan horaActual = DateTime.Now.TimeOfDay;

            if (timeValue.Hours <= 7 && timeValue.Hours >= 0)
            {
                timeValid = false;
                label2.Text = "*Por favor ingrese una hora despues de las 7 AM y antes de las 12 PM";
                return;
            }

            if (dateValue.Date == fechaActual.Date)
            {
                if (timeValue.Hours < horaActual.Hours)
                {
                    timeValid = false;
                    label2.Text = "*Hora ingresada menor a la hora actual";
                    return;
                }
            }

            timeValid = true;
            return;
        }

        public void estiloHora()
        {
            if (!timeValid)
            {
                label2.Visible = true;
                label2.ForeColor = gestor.setErrorText();
            } else
            {
                label2.Visible = false;
            }
        }


        private void dtpHora_ValueChanged(object sender, EventArgs e)
        {
            timeValue = dtpHora.Value.TimeOfDay;
            //validarHora();
            //estiloHora();
        }
    }
}
