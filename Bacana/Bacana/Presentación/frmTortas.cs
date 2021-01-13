using Bacana.Negocio.Entidades;
using Bacana.Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacana.Presentación
{
    public partial class frmTortas : Form
    {
        private InsumosService oInsumo;
        private InsumosTortasService oInsumoTorta;
        private TortasService oTorta;

        public frmTortas()
        {
            oInsumo = new InsumosService(); 
            oInsumoTorta = new InsumosTortasService();
            oTorta = new TortasService();
            InitializeComponent();
        }

        private void dgvTorta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }

        private void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            frmAbmTortas frm = new frmAbmTortas();
            frm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int id_torta = Convert.ToInt32(dgvTortas.CurrentRow.Cells["idTorta"].Value);
            IList<Torta> lst = oTorta.getTortaId(id_torta);
            Torta selected = new Torta(lst[0].id_torta, lst[0].nombre, lst[0].borrado, lst[0].porcentaje);
            frmSeleccionarInsumo frm = new frmSeleccionarInsumo();
            frm.IniciarFormulario(frmSeleccionarInsumo.FormMode.nuevo, selected);
            frm.ShowDialog();
            actualizarInsumos(sender, e);
        }

        private void btnDeleteInsumo_Click(object sender, EventArgs e)
        {
            if (dgvInsumosTorta.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Seguro que desea Eliminar el Insumo seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    int id_torta = Convert.ToInt32(dgvInsumosTorta.CurrentRow.Cells["id_torta"].Value);
                    int id_insumo = Convert.ToInt32(dgvInsumosTorta.CurrentRow.Cells["idInsumo"].Value);
                    if (oInsumoTorta.borrarInsumoTorta(id_torta,id_insumo))
                    {
                        dgvInsumosTorta.Rows.RemoveAt(dgvInsumosTorta.CurrentRow.Index);
                        MessageBox.Show("Objetivo Eliminado", "Aviso");
                    }
                }
                else
                    MessageBox.Show("Ha ocurrido un error al intentar borrar el Insumo", "Error");
            }
            actualizar(sender, e);
            actualizarInsumos(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAbmTortas frm = new frmAbmTortas();
            frm.ShowDialog();
            actualizar(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTortas.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Seguro que desea Eliminar la torta seleccionada?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvTortas.CurrentRow.Cells["idTorta"].Value);
                    if (oTorta.borrarTorta(id))
                    {
                        dgvTortas.Rows.RemoveAt(dgvTortas.CurrentRow.Index);
                        MessageBox.Show("Torta Eliminada", "Aviso");
                    }
                }
                else
                    MessageBox.Show("Ha ocurrido un error al intentar borrar la Torta", "Error");
            }
            actualizar(sender, e);
        }

        private void frmTortas_Load(object sender, EventArgs e)
        {
            actualizar(sender, e);
            txtNombreTorta.Focus();
        }

        private void actualizar(System.Object sender, System.EventArgs e)
        {
            dgvTortas.Rows.Clear();
            IList<Torta> lst = oTorta.getTorta(txtNombreTorta.Text);
            foreach (Torta obj in lst)
            {
                var nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(obj.nombre);
                dgvTortas.Rows.Add(new object[] { obj.id_torta ,nombre,"%"+obj.porcentaje, obj.borrado });
            }
            if (dgvTortas.Rows.Count == 0)
            {
                btnAddInsumo.Enabled = false;
                btnDelete.Enabled = false;
                btnEditar.Enabled = false;
            }
            else
            {
                btnAddInsumo.Enabled = true;
                btnDelete.Enabled = true;
                btnEditar.Enabled = true;
            }

            
        }

        private void dgvTortas_SelectionChanged(object sender, EventArgs e)
        {
            actualizarInsumos(sender, e);
        }

        private void actualizarInsumos(System.Object sender, System.EventArgs e)
        {
            dgvInsumosTorta.Rows.Clear();
            int id = Convert.ToInt32(dgvTortas.CurrentRow.Cells["idTorta"].Value);
            IList<InsumoTorta> lst = oInsumoTorta.getInsumos(id);
            foreach (InsumoTorta obj in lst)
            {
                string nombreInsumo = oInsumo.buscarInsumoPorId(obj.insumo.CodigoInsumo);
                string tipoInsumo = oInsumo.buscarTipoPorId(obj.insumo.CodigoInsumo);
                var nomInsumo = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(nombreInsumo);
                dgvInsumosTorta.Rows.Add(new object[] { obj.torta.id_torta, obj.insumo.CodigoInsumo, nomInsumo,obj.cantidad, tipoInsumo});
            }
            if (dgvInsumosTorta.Rows.Count == 0)
            {
                btnDeleteInsumo.Enabled = false;
            }
            else
            {
                btnDeleteInsumo.Enabled = true;
            }
        }

        
        private void txtNombreTorta_TextChanged(object sender, EventArgs e)
        {
            actualizar(sender, e);
        }

        
        private void dgvTortas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            actualizarInsumos(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmAbmTortas formulario = new frmAbmTortas();
            int id = Convert.ToInt32(dgvTortas.CurrentRow.Cells["idTorta"].Value);
            IList<Torta> lst = oTorta.getTortaId(id);
            Torta selected = new Torta(lst[0].id_torta,lst[0].nombre, lst[0].borrado, lst[0].porcentaje);
            formulario.InicializarFormulario(frmAbmTortas.FormMode.actualizar, selected);
            formulario.ShowDialog();
            actualizar(sender, e);
        }

        private void dgvTortas_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvTortas.Rows.Count >0)
            {
                if (e.KeyCode == Keys.Delete)
                    btnDelete_Click(sender, e);
                if (e.KeyCode == Keys.Right)
                    dgvInsumosTorta.Focus();
            }
            if (e.KeyCode == Keys.Insert)
                btnAdd_Click(sender, e);
            if (e.KeyCode == Keys.Add)
                btnAdd_Click(sender, e);
            if (e.KeyCode == Keys.Escape)
                if (MessageBox.Show("¿Seguro que desea volver al menú principal?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
        }

        private void dgvInsumosTorta_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvInsumosTorta.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Delete)
                    btnDeleteInsumo_Click(sender, e);
            }
            if (e.KeyCode == Keys.Left)
                dgvTortas.Focus();
            if (e.KeyCode == Keys.Insert)
                pictureBox2_Click(sender, e);
            if (e.KeyCode == Keys.Add)
                pictureBox2_Click(sender, e);
            if (e.KeyCode == Keys.Escape)
                if (MessageBox.Show("¿Seguro que desea volver al menú principal?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    this.Close();

        }

        private void frmTortas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                if (MessageBox.Show("¿Seguro que desea volver al menú principal?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
        }
    }
}
