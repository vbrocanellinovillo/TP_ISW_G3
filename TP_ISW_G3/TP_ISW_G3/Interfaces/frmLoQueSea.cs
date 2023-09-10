using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_ISW_G3.Control;

namespace TP_ISW_G3.Interfaces
{
    public partial class frmLoQueSea : Form
    {
        gestorLoQueSea gestor;

        private string descriptionValue;
        
        // Falta ver como hacer con el formato del precio
        private string priceValue;

        private bool descriptionValid;
        private bool descriptionTouched;

        private bool priceValid;
        private bool priceTouched;

        public frmLoQueSea(gestorLoQueSea gestorLoQueSea)
        {
            InitializeComponent();
            gestor = gestorLoQueSea;   
        }

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

        private void btnDireccion_Click(object sender, EventArgs e)
        {
            if(!descriptionValid)
            {
                MessageBox.Show("Por favor completar la descripcion");
                descriptionTouched = true;
                estiloDescripcion();
                txtDescripcion.Focus();
                return;
            }

            if (!priceValid)
            {
                MessageBox.Show("Por favor ingresar un precio valido");
                priceTouched = true;
                estiloPrecio();
                txtPrecio.Focus();
                return;
            }

            double precio;

            if (double.TryParse(txtPrecio.Text, out precio))
            {
                gestor.cargarTotal(precio);
            }
            else
            {
                MessageBox.Show("Por favor ingresar un precio valido");
                priceTouched = true;
                estiloPrecio();
                txtPrecio.Focus();
                return;
            }

            resetTxts();
            gestor.crearFormDireccionComercio("Dirección Comercio");
        }

        public void validarDescripcion()
        {
            if (descriptionValue.Trim() == "" )
            {
                descriptionValid = false;
                return;
            }

            descriptionValid = true;
            return;
        }

        public void estiloDescripcion()
        {
            if (!descriptionValid && descriptionTouched)
            {
                label2.Visible = true;
                label2.Text = "*Por favor ingrese una descripción";
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

            if (priceValue.Trim().Length == 0)
            {
                priceValid = false;
                return;
            }

            double precio;
            if (double.TryParse(priceValue, out precio))
            {
                priceValid = true;
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
                label3.Text = "*Por favor ingrese un precio valido";
                label3.ForeColor = gestor.setErrorText();

                txtPrecio.BackColor = gestor.setErrorColor();
            } else
            {
                label3.Visible = false;

                txtPrecio.BackColor = gestor.clearErrorColor();
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            descriptionValue = txtDescripcion.Text;
            validarDescripcion();
            estiloDescripcion();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            priceValue = txtPrecio.Text;
            validarPrecio();
            estiloPrecio();
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            descriptionTouched = true;
            validarDescripcion();
            estiloDescripcion();
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            priceTouched = true;
            validarPrecio();
            estiloPrecio();
        }

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
        }
    }
}
