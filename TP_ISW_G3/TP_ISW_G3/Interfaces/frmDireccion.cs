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
    public partial class frmDireccion : Form
    {
        gestorLoQueSea gestor;

        private string streetValue;

        private bool streetValid;
        private bool streetTouched;

        private string numberValue;

        private bool numberValid;
        private bool numberTouched;
        

        public frmDireccion(Control.gestorLoQueSea gestorLoQueSea, string titulo)
        {
            InitializeComponent();
            gestor = gestorLoQueSea;
            lblTitulo.Text = titulo;

            if (titulo == "Dirección Comercio")
            {
                btnNext.Text = "Ir a dirección de entrega";
            } else
            {
                btnNext.Text = "Ir a pago";
            }
        }

        public void cargarComboCiudades()
        {
            cmbCiudades.Items.Clear();
            cmbCiudades.Items.Add("Córdoba");
            cmbCiudades.Items.Add("Carlos Paz");
        }

        public void resetTxts()
        {
            txtCalle.Text = "";
            streetValue = "";
            streetValid = false;
            streetTouched = false;

            txtNro.Text = "";
            numberValue = "";
            numberTouched = false;
            numberValid = false;

            cmbCiudades.SelectedIndex = -1;
            txtReferencia.Text = "";

            txtCalle.BackColor = gestor.clearErrorColor();
            txtNro.BackColor = gestor.clearErrorColor();
            cmbCiudades.BackColor= gestor.clearErrorColor();

            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
        }

        private void frmDireccionComercio_Load(object sender, EventArgs e)
        {
            cargarComboCiudades();
            resetTxts();
        }

        public Direccion validarCampos()
        {
            string nombreCalle = txtCalle.Text.Trim();

            if (!streetValid)
            {
                MessageBox.Show("Por favor, completa el nombre de la calle.");
                streetTouched = true;
                estiloCalle();
                txtCalle.Focus();
                return null;
            }

            string numero = txtNro.Text.Trim();

            if (!numberValid)
            {
                MessageBox.Show("Por favor, completa el número de la calle.");
                numberTouched = true;
                estiloNumero();
                txtNro.Focus();
                return null;
            }


            if (cmbCiudades.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona una ciudad.");
                return null;
            }


            string referencia = txtReferencia.Text.Trim();
            string ciudad = cmbCiudades.SelectedItem.ToString();

            return new Direccion(nombreCalle, numero, ciudad, referencia);
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            Direccion direccion = validarCampos();

            if (direccion != null)
            {

                if (lblTitulo.Text == "Dirección Comercio")
                {
                    gestor.cargarDireccionComercio(direccion);
                    gestor.crearFormDireccionEntrega("Direccion Entrega");
                }
                else
                {
                    gestor.cargarDireccionEntrega(direccion);
                    gestor.crearFormPago();
                }
            }
            
        }

        public void validarCalle()
        {
            if (streetValue.Trim() == "")
            {
                streetValid = false;
                return;
            }

            streetValid = true;
            return;
        }

        public void estiloCalle()
        {
            if (!streetValid && streetTouched)
            {
                label5.Visible = true;
                label5.Text = "*Por favor ingrese la calle";
                label5.ForeColor = gestor.setErrorText();

                txtCalle.BackColor = gestor.setErrorColor();
            } else
            {
                label5.Visible = false;

                txtCalle.BackColor = gestor.clearErrorColor();
            }
        }

        private void txtCalle_TextChanged(object sender, EventArgs e)
        {
            streetValue = txtCalle.Text;
            validarCalle();
            estiloCalle();
        }

        private void txtCalle_Leave(object sender, EventArgs e)
        {
            streetTouched = true;
            validarCalle();
            estiloCalle();
        }

        public void validarNumero()
        {
            if (numberValue.Trim().Length == 0)
            {
                numberValid = false;
                return;
            }

            double precio;
            if (double.TryParse(numberValue, out precio))
            {
                numberValid = true;
                return;
            }
            else
            {
                numberValid = false;
            }
        }

        public void estiloNumero()
        {
            if (!numberValid && numberTouched)
            {
                label6.Visible = true;
                label6.Text = "*Por favor ingrese el número de calle";
                label6.ForeColor = gestor.setErrorText();

                txtNro.BackColor = gestor.setErrorColor();

            } else
            {
                label6.Visible = false;

                txtNro.BackColor = gestor.clearErrorColor();
            }
        }

        private void txtNro_TextChanged(object sender, EventArgs e)
        {
            numberValue = txtNro.Text;
            validarNumero();
            estiloNumero();
        }

        private void txtNro_Leave(object sender, EventArgs e)
        {
            numberTouched = true;
            validarNumero();
            estiloNumero();
        }
    }
}
