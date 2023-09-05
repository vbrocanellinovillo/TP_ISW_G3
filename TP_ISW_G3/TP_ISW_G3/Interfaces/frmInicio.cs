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

namespace TP_ISW_G3
{
    public partial class frmInicio : Form
    {
        gestorLoQueSea gestor;
        public frmInicio()
        {
            InitializeComponent();
            gestor = new gestorLoQueSea(this);
        }

        private void btnLoQueSea_Click(object sender, EventArgs e)
        {
            gestor.crearFormLoQueSea();
        }
    }
}
