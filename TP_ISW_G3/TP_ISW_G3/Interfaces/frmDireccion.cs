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
        private void frmDireccionComercio_Load(object sender, EventArgs e)
        {
            cargarComboCiudades();
        }

        public Direccion validarCampos()
        {
            string nombreCalle = txtCalle.Text.Trim();

            if (string.IsNullOrEmpty(nombreCalle))
            {
                MessageBox.Show("Por favor, completa el nombre de la calle.");
                txtCalle.Focus();
                return null;
            }
            string numero = txtNro.Text.Trim();

            if (string.IsNullOrEmpty(numero))
            {
                MessageBox.Show("Por favor, completa el número de la calle.");
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
    }
}
