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
        }

        public void cargarComboCiudades()
        {
            cmbCiudades.Items.Clear();
            cmbCiudades.Items.Add("Córdoba");
            cmbCiudades.Items.Add("Unquillo");
            cmbCiudades.Items.Add("Villa Allende");
            cmbCiudades.Items.Add("La calera");
        }
        private void frmDireccionComercio_Load(object sender, EventArgs e)
        {
            cargarComboCiudades();
        }

        public Direccion validarCampos()
        {
            // Validar que el nombre de la calle y el número no estén en blanco
            string nombreCalle = txtCalle.Text.Trim();
            string numero = txtNro.Text.Trim();

            if (string.IsNullOrEmpty(nombreCalle) || string.IsNullOrEmpty(numero))
            {
                MessageBox.Show("Por favor, completa el nombre de la calle y el número.");
                return null;
            }


            // Validar que se haya seleccionado una ciudad
            if (cmbCiudades.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona una ciudad.");
                return null;
            }


            string referencia = txtReferencia.Text.Trim();
            string ciudad = cmbCiudades.SelectedItem.ToString();

            return new Direccion(nombreCalle, numero, ciudad, referencia);
        }

        private void btnDireccionEntrega_Click(object sender, EventArgs e)
        {
            Direccion direccionComercio = validarCampos();
            gestor.cargarDireccionComercio(direccionComercio);
            gestor.crearFormDireccionEntrega("Direccion Entrega");
        }

    }
}
