using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_ISW_G3.Control;

namespace TP_ISW_G3.Interfaces
{
    public partial class frmPago : Form
    {

        private gestorLoQueSea gestor;
        private string maskedText1Value = "";
        private string maskedText2Value = "";
        private string maskedText3Value = "";

        // Estilo cantidad efectivo
        private bool cantidadEfectivoValid = false;
        private bool cantidadEfectivoTouched = false;

        // Estilo nro tarjeta
        private bool nrtoTarjetaTouched = false;
        private bool nroTarjetaValid = false;

        // Estilo nombre titular
        private bool nombreTitularTouched = false;
        private bool nombreTitularValid = false;

        // Estilo codigo seguridad
        private bool cvcTouched = false;
        private bool cvcValid = false;

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

            label11.Visible = false;
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

            label11.Visible = false;
        }

        public void resetTxts()
        {
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";

            maskedText1Value = "";
            maskedText2Value = "";
            maskedText3Value = "";

            nroTarjetaValid = false;
            nrtoTarjetaTouched = false;

            nombreTitularValid = false;
            nombreTitularTouched = false;

            cvcValid = false;
            cvcTouched = false;

            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;

            maskedTextBox1.BackColor = gestor.clearErrorColor();
            maskedTextBox2.BackColor = gestor.clearErrorColor();
            maskedTextBox3.BackColor = gestor.clearErrorColor();

            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
        }

        private void cmbMediosPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            btnPagar.Enabled = true;

            resetTxts();

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

            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
        }


        public void validarEfectivo()
        {
            double efectivo;
            if (double.TryParse(maskedText1Value, out efectivo))
            {
                if (efectivo < Convert.ToDouble(lblTotal.Text))
                {
                    cantidadEfectivoValid = false;
                    return;
                }

                cantidadEfectivoValid = true;
                return;
            } else
            {
                cantidadEfectivoValid = false;
            }

        }

        public void estiloCantidadEfectivo()
        {
            if (!cantidadEfectivoValid && cantidadEfectivoTouched)
            {
                label11.Visible = true;
                label11.Text = "*Por favor ingrese un monto mayor o igual al total";
                label11.ForeColor = gestor.setErrorText();
                    
                maskedTextBox1.BackColor = gestor.setErrorColor();
            }
            else
            {
                label11.Visible = false;

                maskedTextBox1.BackColor = gestor.clearErrorColor();
            }
        }

        
        public void validarNumeroTarjeta() 
        {
            if (maskedText1Value.Trim().Length == 0)
            {
                return;
            }

            // Revisar ese 12 despues
            if (maskedText1Value[0].ToString() == "4" && maskedText1Value.Trim().Length >= 12 )
            {
                nroTarjetaValid = true;
                return;
            }

            nroTarjetaValid = false;
            return;
        }

        public void estiloNumeroTarjeta()
        {
            if (!nroTarjetaValid && nrtoTarjetaTouched)
            {
                label11.Visible = true;
                label11.Text = "*Numero de tarjeta invalido";
                label11.ForeColor = gestor.setErrorText();

                maskedTextBox1.BackColor = gestor.setErrorColor();
            }
            else
            {
                label11.Visible = false;

                maskedTextBox1.BackColor = gestor.clearErrorColor();
            }
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {

            if (cmbMediosPago.SelectedIndex == 0)
            {
                maskedText1Value = maskedTextBox1.Text;

                // Calcular el vuelto a devolver
                double total = Convert.ToDouble(lblTotal.Text);

                double vuelto = -1;

                if (maskedText1Value.Trim().Length > 0)
                {
                    double montoIngresado;

                    if (double.TryParse(maskedText1Value, out montoIngresado))
                    {
                        vuelto = montoIngresado - total;
                        maskedTextBox2.Text = (vuelto >= 0) ? vuelto.ToString() : "";

                        validarEfectivo();
                        estiloCantidadEfectivo();

                    }
                    else
                    {
                        cantidadEfectivoValid = false;
                    }
                }

            }
            else if (cmbMediosPago.SelectedIndex == 1)
            {
                maskedText1Value = maskedTextBox1.Text;

                validarNumeroTarjeta();
                estiloNumeroTarjeta();
            }
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            if (cmbMediosPago.SelectedIndex == 0)
            {
                cantidadEfectivoTouched = true;
                validarEfectivo();
                estiloCantidadEfectivo();

                nrtoTarjetaTouched = false;
            }
            else if (cmbMediosPago.SelectedIndex == 1)
            {
                cantidadEfectivoTouched = false;

                nrtoTarjetaTouched = true;
                validarNumeroTarjeta();
                estiloNumeroTarjeta();

            }
        }

        public void validarNombreTitular()
        {

            string patron = @"^[A-Za-záéíóúÁÉÍÓÚñÑ\s]+$";

            if (Regex.IsMatch(maskedText2Value, patron))
            {
                nombreTitularValid = true;
                return;
            }
            else
            {
                nombreTitularValid = false;
                return;
            }
        }

        public void estiloNombreTitular()
        {
            if (!nombreTitularValid && nombreTitularTouched)
            {
                label12.Visible = true;
                label12.Text = "*Por favor ingrese un nombre";
                label12.ForeColor = gestor.setErrorText();

                maskedTextBox2.BackColor = gestor.setErrorColor();
            }
            else
            {
                label12.Visible = false;
                label12.Text = "";

                maskedTextBox2.BackColor = gestor.clearErrorColor();
            }
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            maskedText2Value = maskedTextBox2.Text.Trim();

            if (cmbMediosPago.SelectedIndex == 1)
            {
                validarNombreTitular();
                estiloNombreTitular();
            }
        }

        private void maskedTextBox2_Leave(object sender, EventArgs e)
        {
            if (cmbMediosPago.SelectedIndex == 0)
            {
                nombreTitularTouched = false;
                validarNombreTitular();
                estiloNombreTitular();

            }
            else if (cmbMediosPago.SelectedIndex == 1)
            {
                nombreTitularTouched = true;
                validarNombreTitular();
                estiloNombreTitular();
            }
        }

        public void validarCvc()
        {
            if (maskedText3Value.Trim().Length < 3)
            {
                cvcValid = false;
                return;
            }

            cvcValid = true;
            return;
        }

        public void estiloCvc()
        {
            if (!cvcValid && cvcTouched)
            {
                label13.Visible = true;
                label13.Text = "*Por favor ingrese un codigo de seguridad valido";
                label13.ForeColor = gestor.setErrorText();

                maskedTextBox3.BackColor = gestor.setErrorColor();
            }
            else
            {
                label13.Visible = false;
                label13.Text = "";

                maskedTextBox3.BackColor = gestor.clearErrorColor();
            }
        }

        private void maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            maskedText3Value = maskedTextBox3.Text.Trim();
            validarCvc();
            estiloCvc();
        }

        private void maskedTextBox3_Leave(object sender, EventArgs e)
        {
            cvcTouched = true;
            validarCvc();
            estiloCvc();
        }
        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (cmbMediosPago.SelectedIndex == 0)
            {
                if (!cantidadEfectivoValid)
                {
                    MessageBox.Show("Por favor ingrese un monto valido");
                    cantidadEfectivoTouched = true;
                    estiloCantidadEfectivo();
                    maskedTextBox1.Focus();
                    return;
                }
            }
            else if (cmbMediosPago.SelectedIndex == 1)
            {
                if (!nroTarjetaValid)
                {
                    MessageBox.Show("Por favor ingrese un numero de tarjeta valido (Debe comenzar con 4 y tener al menos 12 digitos");
                    nrtoTarjetaTouched = true;
                    estiloNumeroTarjeta();
                    maskedTextBox1.Focus();
                    return;
                }

                if (!nombreTitularValid)
                {
                    MessageBox.Show("Por favor ingrese un nombre de titular valido");
                    nombreTitularTouched = true;
                    estiloNombreTitular();
                    maskedTextBox2.Focus();
                    return;
                }

                if (!cvcValid)
                {
                    MessageBox.Show("Por favor ingrese un codigo de seguridad valido");
                    cvcTouched = true;
                    estiloCvc();
                    maskedTextBox3.Focus();
                    return;
                }
            }

            resetTxts();
            MessageBox.Show("Pago procesado con exito!");
        }
    }
}