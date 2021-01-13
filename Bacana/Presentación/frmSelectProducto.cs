using Bacana.Negocio.Entidades;
using Bacana.Negocio.Servicios;
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
    public partial class frmSelectProducto : Form
    {
        private TortasService oTorta;

        public frmSelectProducto()
        {
            oTorta = new TortasService();
            InitializeComponent();
        }

        private void actualizar(System.Object sender, System.EventArgs e)
        {
            dgvTortas.Rows.Clear();
            IList<Torta> lst = oTorta.getTorta2(txtNombreTorta.Text);
            foreach (Torta obj in lst)
            {
                dgvTortas.Rows.Add(new object[] { obj.id_torta, obj.nombre, "%" + obj.porcentaje, obj.borrado });
            }
        }

        private void frmSelectProducto_Load(object sender, EventArgs e)
        {
            actualizar(sender, e);
        }

        private void txtNombreTorta_TextChanged(object sender, EventArgs e)
        {
            actualizar(sender, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string varId;

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            varId = dgvTortas.CurrentRow.Cells["idTorta"].Value.ToString();
            this.Close();
        }

        private void dgvTortas_DoubleClick(object sender, EventArgs e)
        {
            varId = dgvTortas.CurrentRow.Cells["idTorta"].Value.ToString();
            this.Close();
        }

        private void dgvTortas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSeleccionar.Enabled = true;
        }

        private void btnSeleccionar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);

            }
            if (e.KeyCode == Keys.Enter)
            {
                btnSeleccionar_Click(sender, e);
            }
        }
    }

}
