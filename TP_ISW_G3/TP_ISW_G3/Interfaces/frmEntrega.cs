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
    public partial class frmEntrega : Form
    {
        gestorLoQueSea gestor;
        public frmEntrega(Control.gestorLoQueSea gestorLoQueSea)
        {
            InitializeComponent();
            gestor = gestorLoQueSea;
        }

        private void btnAntes_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas continuar?", "Confirmación", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Pedido confirmado, esta en camino");
                this.Hide();
            }
        }

        private void btnFechaHora_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas continuar?", "Confirmación", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                gestor.crearFormFechaHora();
                this.Hide();
            }
            
        }
    }
}
