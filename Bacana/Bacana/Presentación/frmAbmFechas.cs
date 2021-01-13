using Bacana.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacana.Presentación
{
    public partial class frmAbmFechas : Form
    {
        public frmAbmFechas()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                lblError.Text = ("    Fechas Incorrectas");
                lblError.Visible = true;
            }
            else
            {
                frmReporteTortas frm = new frmReporteTortas();
                frm.InicializarFormulario(frmReporteTortas.FormMode.actualizar, dtpDesde.Value.Date, dtpHasta.Value.Date);
                frm.ShowDialog();
            }
            
        }

        private void frmAbmFechas_Load(object sender, EventArgs e)
        {
            dtpHasta.Value = DateTime.Today;
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpDesde.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
                dtpHasta.Focus();
        }

        private void dtpHasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
                btnGenerar_Click(sender, e);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(255, 234, 234);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(255, 194, 192);
        }
    }
}
