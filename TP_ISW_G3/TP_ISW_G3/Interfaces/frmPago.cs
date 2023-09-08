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
    public partial class frmPago : Form
    {

        private gestorLoQueSea gestor;
        private bool maskedText1Touched = false;
        private string primerNumero = "";

        public frmPago(Control.gestorLoQueSea _gestorLoQueSea)
        {
            InitializeComponent();
            gestor = _gestorLoQueSea;
        }

        public void cargarCombo()
        {
            cmbMediosPago.Items.Clear();
            cmbMediosPago.Items.Add("Efectivo");
            cmbMediosPago.Items.Add("Tarjeta Debito - Visa");
        }


        public void mostrarPagoEfectivo()
        {
            label3.Text = "Monto con el que se va a pagar";
            label4.Text = "Vuelto a recibir";
            maskedTextBox2.Enabled = false;

            label5.Visible = false;
            label6.Visible = false;
            dateTimePicker1.Visible = false;
            maskedTextBox3.Visible = false;

            label8.Visible = false;
        }

        public void mostrarPagoTarjeta()
        {
            label3.Text = "Número de tarjeta";
            label4.Text = "Nombre del titular";
            maskedTextBox2.Enabled = true;
            maskedTextBox2.Mask = "";

            label5.Visible = true;
            label5.Text = "Fecha vencimiento";
            dateTimePicker1.Visible = true;

            label6.Visible = true;
            label6.Text = "Codigo de seguridad";
            maskedTextBox3.Visible = true;

            label8.Visible = false;
        }

        private void cmbMediosPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            btnPagar.Enabled = true;

            if (cmbMediosPago.SelectedIndex == 0)
            {
                mostrarPagoEfectivo();
            }
            else if (cmbMediosPago.SelectedIndex == 1)
            {
                mostrarPagoTarjeta();
            }
        }

        private void frmPago_Load(object sender, EventArgs e)
        {
            cargarCombo();
            lblTotal.Text = gestor.devolverTotal();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pago completo");
        }

        
        public void validarNumeroTarjeta(string primerNumero)
        {
            if (primerNumero != "4" && maskedText1Touched)
            {
                label8.Visible = true;
                label8.ForeColor = gestor.setErrorColor();

                maskedTextBox1.BackColor = gestor.setErrorColor();
            }
            else
            {
                label8.Visible = false;

                maskedTextBox1.BackColor = gestor.clearErrorColor();
            }
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (cmbMediosPago.SelectedIndex == 0)
            {
                double total = Convert.ToDouble(lblTotal.Text);

                double vuelto = -1;

                if (maskedTextBox1.Text.Trim().Length > 0)
                {
                    double montoIngresado = Convert.ToDouble(maskedTextBox1.Text);
                    vuelto = montoIngresado - total;
                }

                maskedTextBox2.Text = (vuelto >= 0) ? vuelto.ToString() : ""; 

            } else if (cmbMediosPago.SelectedIndex == 1)
            {

                if (maskedTextBox1.Text.Trim().Length > 0)
                {
                    primerNumero = maskedTextBox1.Text[0].ToString();
                }

                validarNumeroTarjeta(primerNumero);
            }
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            maskedText1Touched = true;
            validarNumeroTarjeta(primerNumero);
        }
    }
}