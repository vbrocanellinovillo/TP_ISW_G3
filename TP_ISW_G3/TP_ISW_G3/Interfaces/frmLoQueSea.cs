using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_ISW_G3.Control;
using System.Globalization;

namespace TP_ISW_G3.Interfaces
{
    public partial class frmLoQueSea : Form
    {
        private gestorLoQueSea gestor;

        private string descriptionValue;
        
        // Falta ver como hacer con el formato del precio
        private string priceValue;

        private bool descriptionValid;
        private bool descriptionTouched;

        private bool priceValid;
        private bool priceTouched;

        private bool allowDot = true;

        public frmLoQueSea(gestorLoQueSea gestorLoQueSea)
        {
            InitializeComponent();
            gestor = gestorLoQueSea;


            this.Controls.Add(textBox1);

            textBox1.KeyPress += TextBox1_KeyPress;
            textBox1.TextChanged += TextBox1_TextChanged;
        }


        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;

            if (!string.IsNullOrEmpty(inputText))
            {
                decimal value;

                if (decimal.TryParse(inputText, out value))
                {
                    // Formatear el valor con punto como separador de miles y coma como separador decimal
                    textBox1.Text = value.ToString("N2");
                    textBox1.SelectionStart = textBox1.Text.Length; // Colocar el cursor al final del TextBox
                }
            }
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                if ((e.KeyChar == '-' && textBox1.Text.Length == 0) || (e.KeyChar == decimalSeparator && allowDot))
                {
                    // Aceptar un guión para números negativos o un punto para decimales
                    allowDot = !allowDot;
                }
                else
                {
                    e.Handled = true; // Ignorar otros caracteres
                }
            }
        }


        // Evento para cargar la imagen
        private void button1_Click(object sender, EventArgs e)
        {
           
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos JPG (*.jpg)|*.jpg";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    FileInfo fileInfo = new FileInfo(filePath);

                    // Verificar el tamaño del archivo (en bytes)
                    long maxSizeBytes = 5 * 1024 * 1024; // 5 MB en bytes
                    if (fileInfo.Length <= maxSizeBytes)
                    {
                        pictureBox1.Image = Image.FromFile(filePath);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        // Aquí puedes procesar el archivo seleccionado
                        // filePath contiene la ruta al archivo JPG válido
                        // Puedes cargarlo o realizar cualquier otra operación necesaria.
                    }
                    else
                    {
                        MessageBox.Show("El tamaño del archivo supera los 5 MB permitidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Evento cuando se quiere pasar a ingresar la dirección de comercio
        private void btnDireccion_Click(object sender, EventArgs e)
        {
            // Validar que se ingrese descripción
            if(!descriptionValid)
            {
                MessageBox.Show("Por favor ingresar una descripcion valida");
                descriptionTouched = true;
                validarDescripcion();
                estiloDescripcion();
                txtDescripcion.Focus();
                return;
            }

            // Validar que se ingrese un precio valido
            if (!priceValid)
            {
                MessageBox.Show("Por favor ingresar un precio valido");
                priceTouched = true;
                validarPrecio();
                estiloPrecio();
                txtPrecio.Focus();
                return;
            }

            // Validación extra para el manejo de excepciones con el preico
            double precio;

            if (double.TryParse(txtPrecio.Text, out precio))
            {
                gestor.cargarTotal(precio);
            }
            else
            {
                MessageBox.Show("Por favor ingresar un precio valido");
                priceTouched = true;
                validarPrecio();
                estiloPrecio();
                txtPrecio.Focus();
                return;
            }

            resetTxts();
            gestor.crearFormDireccionComercio("Dirección Comercio");
        }

        public void validarDescripcion()
        {
            // Validar que se ingrese descripción (que no sea cadena vacia)
            if (descriptionValue.Trim() == "" )
            {
                descriptionValid = false;
                label2.Text = "*Por favor ingrese una descripción";
                return;
            }

            descriptionValid = true;
            return;
        }

        // Cambiar color del textbox y mostrar mensajes de error
        public void estiloDescripcion()
        {
            // Si no es valido y si la caja de texto ya fue enfocada (para que no muestre error apenas carga)
            if (!descriptionValid && descriptionTouched)
            {
                label2.Visible = true;
                label2.ForeColor = gestor.setErrorText();

                txtDescripcion.BackColor = gestor.setErrorColor();
            } else
            {
                label2.Visible = false;

                txtDescripcion.BackColor = gestor.clearErrorColor();
            }
        }

        public void validarPrecio()
        {
            // Validar que se ingrese un precio
            if (priceValue.Trim().Length == 0)
            {
                priceValid = false;
                label3.Text = "*Por favor ingrese un precio";
                return;
            }

            // Validar formato del precio
            double precio;
            if (double.TryParse(priceValue, out precio))
            {
                priceValid = true;
                label3.Text = "*Por favor ingrese un precio valido";
                return;
            } else
            {
                priceValid = false;
            }



        }

        public void estiloPrecio()
        {
            if (!priceValid && priceTouched)
            {
                label3.Visible = true;
                label3.ForeColor = gestor.setErrorText();

                txtPrecio.BackColor = gestor.setErrorColor();
            } else
            {
                label3.Visible = false;

                txtPrecio.BackColor = gestor.clearErrorColor();
            }
        }

        // Evento que ocurre cuando cambia el valor ingresado en la caja de texto de descripción
        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            // Capturar valor de la caja de texto y hacer validaciones y cambios en la interfaz según corresponda
            descriptionValue = txtDescripcion.Text;
            validarDescripcion();
            estiloDescripcion();
        }

        // Evento que ocurre cuando cambia el valor ingresado en la caja de texto del precio
        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            priceValue = txtPrecio.Text;
            validarPrecio();
            estiloPrecio();
        }

        // Evento que se ejecuta cuando la caja de texto de la descripción pierde el foco
        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            descriptionTouched = true;
            validarDescripcion();
            estiloDescripcion();
        }

        // Evento que se ejecuta cuando la caja de texto del precio pierde el foco
        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            priceTouched = true;
            validarPrecio();
            estiloPrecio();
        }

        // Limpiar variables y cajas de texto
        public void resetTxts()
        {
            txtDescripcion.Text = "";
            txtPrecio.Text = "";

            descriptionValue = "";
            priceValue = "";

            txtDescripcion.BackColor = gestor.clearErrorColor();
            txtPrecio.BackColor = gestor.clearErrorColor();

            descriptionValid = false;
            descriptionTouched = false;

            priceValid = false;
            priceTouched = false;

            label2.Visible = false;
            label3.Visible = false;
        }

        private void frmLoQueSea_Load(object sender, EventArgs e)
        {
            resetTxts();
                // Configurar la cultura personalizada para el TextBox
                CultureInfo customCulture = new CultureInfo("en-US"); // Punto como separador de miles, coma como separador decimal
                //textBox1.Culture = customCulture;
            
        }
    }
}
    
    
    
    

