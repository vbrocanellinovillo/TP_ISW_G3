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
            if(txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("Falta completar la descripcion");
                txtDescripcion.Focus();
                return;
            }

            if (txtPrecio.Text.Trim() == "")
            {
                MessageBox.Show("Falta el precio");
                txtPrecio.Focus();
                return;
            }

            double precio;

            if (double.TryParse(txtPrecio.Text, out precio))
            {
                gestor.cargarTotal(precio);
            } else
            {
                MessageBox.Show("El precio ingresado no es válido. Por favor, ingrese un número válido.");
                precio = 0.0;
                txtPrecio.Focus();
                return;
            }

            gestor.crearFormDireccionComercio("Dirección Comercio");
        }
    }
}
