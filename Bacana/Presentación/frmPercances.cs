using Bacana.Negocio.Entidades;
using Bacana.Negocio.Servicios;
using Bacana.Presentación;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacana
{
    public partial class frmPercances : Form
    {
        private PercancesService percance;

        public frmPercances()
        {
            percance = new PercancesService();
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmInicio frm = new frmInicio();
            frm.Show();
            this.Close();
        }

        private void frmPercances_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmInicio frminicio = new frmInicio();
            frminicio.Show();

        }
        

        private void frmPercances_Load(object sender, EventArgs e)
        {
            actualizar(sender, e);
            dgvPercances.Focus();
        }

        private void actualizar(System.Object sender, System.EventArgs e)
        {
            dgvPercances.Rows.Clear();
            IList<Percances> lst = percance.GetPercances();
            foreach (Percances obj in lst)
            {
                var producto = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(obj.Producto);
                var costo = string.Format("{0:C2}", Convert.ToSingle(obj.Costo.ToString()));
                dgvPercances.Rows.Add(new object[] { obj.Id, producto, obj.Fecha, costo, obj.Descripcion });

            }
            if (dgvPercances.Rows.Count > 0)
            {
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
            }
            else
            {
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAbmPercances frm = new frmAbmPercances();
            frm.ShowDialog();
            actualizar(sender, e);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAbmPercances formulario = new frmAbmPercances();
            int id = Convert.ToInt32(dgvPercances.CurrentRow.Cells["id_percance"].Value);
            IList<Percances> lst = percance.GetPercanceId(id);
            Percances selected = new Percances(lst[0].Id, lst[0].Producto, lst[0].Fecha, lst[0].Costo, lst[0].Descripcion);
            formulario.InicializarFormulario(frmAbmPercances.FormMode.actualizar, selected);
            formulario.ShowDialog();
            actualizar(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPercances.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Seguro que desea Eliminar el Objetivo seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvPercances.CurrentRow.Cells["id_percance"].Value);
                    if (percance.borrarPercance(id))
                    {
                        dgvPercances.Rows.RemoveAt(dgvPercances.CurrentRow.Index);
                        MessageBox.Show("Objetivo Eliminado", "Aviso");
                    }
                }
                else
                    MessageBox.Show("Ha ocurrido un error al intentar borrar el Objetivo", "Error");
            }
            actualizar(sender, e);
        }

        private void dgvPercances_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvPercances.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                    btnModificar_Click(sender, e);
                if (e.KeyCode == Keys.Delete)
                    btnEliminar_Click(sender, e);
            }
            
            if (e.KeyCode == Keys.Add)
                btnAgregar_Click(sender, e);
            if (e.KeyCode == Keys.Escape)
                if (MessageBox.Show("¿Seguro que desea volver al menú principal?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    this.Close();

        }

        private void frmPercances_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                if (MessageBox.Show("¿Seguro que desea volver al menú principal?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
        }
    }
}
