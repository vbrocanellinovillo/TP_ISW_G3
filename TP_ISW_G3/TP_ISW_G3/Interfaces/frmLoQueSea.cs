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
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    string rutaImagen = openFileDialog1.FileName;
            //    // Aquí puedes usar la ruta de la imagen seleccionada como desees.
            //    // Por ejemplo, mostrarla en un PictureBox si tienes uno en tu formulario.
            //    pictureBox1.ImageLocation = rutaImagen;
            //}
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
            if(txtDescripcion.Text.Length > 0)
            {
                gestor.crearFormDireccionComercio("Dirección Comercio");
            }
            else
            {
                MessageBox.Show("Falta completar la descripcion");
            }
        }
    }
}
