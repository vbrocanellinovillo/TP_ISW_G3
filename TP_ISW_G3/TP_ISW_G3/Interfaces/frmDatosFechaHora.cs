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

        private bool dateValid;
        private bool dateTouched;

        public frmDatosFechaHora(Control.gestorLoQueSea gestorLoQueSea)
        {
            InitializeComponent();
            gestor = gestorLoQueSea;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas es fecha y hora?", "Confirmación", MessageBoxButtons.YesNo);



            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Pedido confirmado!!");
                this.Hide();
            }
        }

        public void validarFecha()
        {
            if (dateValue < DateTime.Now)
            {
                dateValid = false;
                label1.Text = "*Por favor ingrese una fecha mayor o igual a la actual";
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
                label2.Visible = false;
            }
        }

        private void dtpFechaHora_ValueChanged(object sender, EventArgs e)
        {
            dateValue = dtpFechaHora.Value;
            validarFecha();
            estiloFecha();
        }

        private void dtpFechaHora_Leave(object sender, EventArgs e)
        {
            dateTouched = true;
            validarFecha();
            estiloFecha();
        }
    }
}
