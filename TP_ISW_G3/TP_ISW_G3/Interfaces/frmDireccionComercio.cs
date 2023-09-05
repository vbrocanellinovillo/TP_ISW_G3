using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_ISW_G3.Interfaces
{
    public partial class frmDireccionComercio : Form
    {
        public frmDireccionComercio(Control.gestorLoQueSea gestorLoQueSea)
        {
            InitializeComponent();
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

        public void validarCampos()
        {
            // Validar que se haya seleccionado una ciudad
            if (cmbCiudades.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona una ciudad.");
                return;
            }

            // Validar que el nombre de la calle y el número no estén en blanco
            string nombreCalle = txtCalle.Text.Trim();
            string numero = txtNro.Text.Trim();

            if (string.IsNullOrEmpty(nombreCalle) || string.IsNullOrEmpty(numero))
            {
                MessageBox.Show("Por favor, completa el nombre de la calle y el número.");
                return;
            }

            // Validar que al menos uno de los campos de referencia se haya llenado
            string referencia = txtReferencia.Text.Trim();

            if (string.IsNullOrEmpty(referencia))
            {
                DialogResult resultado = MessageBox.Show("¿No has proporcionado una referencia. ¿Deseas continuar?", "Confirmación", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.No)
                {
                    return;
                }
            }

            // Si todas las validaciones son exitosas, puedes guardar la información
            string ciudad = cmbCiudades.SelectedItem.ToString();

            // Aquí puedes realizar la acción deseada, como guardar la información en una base de datos o realizar otro proceso.
            MessageBox.Show($"Información válida: Calle: {nombreCalle}, Número: {numero}, Ciudad: {ciudad}, Referencia: {referencia}");
        }

        private void btnDireccionEntrega_Click(object sender, EventArgs e)
        {
            validarCampos();            
        }

    }
}
