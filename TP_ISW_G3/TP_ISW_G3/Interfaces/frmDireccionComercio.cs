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

        private void btnDireccionEntrega_Click(object sender, EventArgs e)
        {

        }

    }
}
