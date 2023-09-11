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
    public partial class frmDatosFechaHora : Form
    {
        public frmDatosFechaHora(Control.gestorLoQueSea gestorLoQueSea)
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas es fecha y hora?", "Confirmación", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Pedido confirmado!!");
                this.Hide();
            }
        }
    }
}
