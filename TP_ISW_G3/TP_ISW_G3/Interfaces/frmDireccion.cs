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
        private gestorLoQueSea gestor;

        private string streetValue;

        private bool streetValid;
        private bool streetTouched;

        private string numberValue;

        private bool numberValid;
        private bool numberTouched;

        private bool cmbValid;
        private bool cmbTouched;
        

        public frmDireccion(Control.gestorLoQueSea gestorLoQueSea, string titulo)
        {
            InitializeComponent();
            gestor = gestorLoQueSea;

            // Cambia el titulo y el texto del boton según de donde se llame al constructor
            // (cambia el valor de titulo y con ese se hace la validación)
            lblTitulo.Text = titulo;

            if (titulo == "Dirección Comercio")
            {
                btnNext.Text = "Ir a dirección de entrega";
                this.BackgroundImage = 
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

        // Limpiar variables y cajas de texto
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
            cmbValid = false;
            cmbTouched = false;

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

        // Cargar dirección ingresada
        // Se hacen las validaciones para ver si se puede cargar la dirección
        public Direccion validarCampos()
        {
            string nombreCalle = txtCalle.Text.Trim();

            if (!streetValid)
            {
                MessageBox.Show("Por favor ingresar un nombre de calle valido");
                streetTouched = true;
                validarCalle();
                estiloCalle();
                txtCalle.Focus();
                return null;
            }

            string numero = txtNro.Text.Trim();

            if (!numberValid)
            {
                MessageBox.Show("Por favor ingresar un número de calle valido");
                numberTouched = true;
                validarNumero();
                estiloNumero();
                txtNro.Focus();
                return null;
            }


            if (!cmbValid)
            {
                MessageBox.Show("Por favor seleccionar una ciudad");
                cmbTouched = true;
                validarCombo();
                estiloCombo();
                cmbCiudades.Focus();
                return null;
            }


            // Si llego hasta aca paso todas las validaciones y se retorna un objeto dirección
            string referencia = txtReferencia.Text.Trim();
            string ciudad = cmbCiudades.SelectedItem.ToString();

            return new Direccion(nombreCalle, numero, ciudad, referencia);
        }

        // Evento click en el boton
        private void btnNext_Click(object sender, EventArgs e)
        {
            Direccion direccion = validarCampos();

            // Si la dirección es null es porque no paso alguna validación
            if (direccion != null)
            {
                // Según la dirección que estaba cargando ver cual es el siguiente form

                // Si era la dirección de comercio paso despues al form de la dirección de entrega
                if (lblTitulo.Text == "Dirección Comercio")
                {
                    gestor.cargarDireccionComercio(direccion);
                    gestor.crearFormDireccionEntrega("Direccion Entrega");
                }

                // Si era la dirección de entrega paso despues al pago
                else
                {
                    gestor.cargarDireccionEntrega(direccion);
                    gestor.crearFormPago();
                }
            }
            
        }

        public void validarCalle()
        {
            // Validar que la calle no sea una cadena vacia
            if (streetValue.Trim() == "")
            {
                streetValid = false;
                label5.Text = "*Por favor ingrese la calle";
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
                label5.ForeColor = gestor.setErrorText();

                txtCalle.BackColor = gestor.setErrorColor();
            } else
            {
                label5.Visible = false;

                txtCalle.BackColor = gestor.clearErrorColor();
            }
        }

        // Evento que se ejecuta cuando cambia un valor en el textbox correspondiente a la calle
        private void txtCalle_TextChanged(object sender, EventArgs e)
        {
            // Captura valor de la caja de texto y realizar validaciones y cambios en la interfaz
            streetValue = txtCalle.Text;
            validarCalle();
            estiloCalle();
        }

        // Evento que se ejecuta cuando la caja de texto de la calle pierde el foco
        private void txtCalle_Leave(object sender, EventArgs e)
        {
            streetTouched = true;
            validarCalle();
            estiloCalle();
        }

        public void validarNumero()
        {
            // Validar que se ingrese un número de calle
            if (numberValue.Trim().Length == 0)
            {
                numberValid = false;
                label6.Text = "*Por favor ingrese un número de calle";
                return;
            }

            // Validar que se ingrese con el formato correcto
            double precio;
            if (double.TryParse(numberValue, out precio))
            {
                numberValid = true;
                return;
            }
            else
            {
                numberValid = false;
                label6.Text = "*Por favor ingrese un número de calle con formato valido";
                return;
            }
        }

        public void estiloNumero()
        {
            if (!numberValid && numberTouched)
            {
                label6.Visible = true;
                label6.ForeColor = gestor.setErrorText();

                txtNro.BackColor = gestor.setErrorColor();

            } else
            {
                label6.Visible = false;

                txtNro.BackColor = gestor.clearErrorColor();
            }
        }

        // Evento que se ejecuta cuando cambia el valor de la caja de texto del número
        private void txtNro_TextChanged(object sender, EventArgs e)
        {
            numberValue = txtNro.Text;
            validarNumero();
            estiloNumero();
        }


        // Evento que se ejecuta cuando la caja de texto del número pierde el foco
        private void txtNro_Leave(object sender, EventArgs e)
        {
            numberTouched = true;
            validarNumero();
            estiloNumero();
        }

        private void validarCombo()
        {
            // Validar que se seleccione alguna ciudad
            if (cmbCiudades.SelectedIndex == -1) 
            {
                cmbValid = false;
                label7.Text = "*Por favor seleccione una ciudad";
                return;
            }

            cmbValid = true;
            return;
        }

        private void estiloCombo()
        {
            if (!cmbValid && cmbTouched)
            {
                label7.Visible = true;
                label7.ForeColor = gestor.setErrorText();

                cmbCiudades.BackColor = gestor.setErrorColor();
            }

            else
            {
                label7.Visible = false;

                cmbCiudades.BackColor = gestor.clearErrorColor();
            }
        }

        // Evento que ocurre cuando cambia el valor seleccionado en el combo de las ciudades
        private void cmbCiudades_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCombo();
            estiloCombo();
        }

        // Evento que ocurre cuando el combo de las ciudades pierde el foco
        private void cmbCiudades_Leave(object sender, EventArgs e)
        {
            cmbTouched = true;
            validarCombo();
            estiloCombo();
        }
    }
}
