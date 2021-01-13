using Bacana.Negocio.Entidades;
using Bacana.Negocio.Servicios;
using Bacana.Presentación;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Bacana
{
    public partial class frmInsumos : Form
    {
        private InsumosService insumo;
        private InsumosTipoService insumosTipo;
        private InsumosTortasService insumosTortas;

        public frmInsumos()
        {
            insumo = new InsumosService();
            insumosTipo = new InsumosTipoService();
            insumosTortas = new InsumosTortasService();
            InitializeComponent();
        }


        private void frmInsumos_Load(object sender, EventArgs e)
        {
            actualizar(sender, e);

        }

        

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAbmInsumos frm = new frmAbmInsumos();
            frm.ShowDialog();
            actualizar(sender, e);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvInsumos.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Seguro que desea Eliminar el Objetivo seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string tipo = dgvInsumos.CurrentRow.Cells["tipo"].Value.ToString();
                    int id = Convert.ToInt32(dgvInsumos.CurrentRow.Cells["id_insumo"].Value);
                    if (insumosTortas.insumoUtilizado(id).Count == 0)
                    {
                        if (insumo.borrarInsumo(id))
                        {
                            dgvInsumos.Rows.RemoveAt(dgvInsumos.CurrentRow.Index);
                            MessageBox.Show("Objetivo Eliminado", "Aviso");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El insumo seleccionado esta asignado a una torta, no se puede eliminar", "Error");

                    }

                }
                else
                    MessageBox.Show("Ha ocurrido un error al intentar borrar el Objetivo", "Error");
            }
            actualizar(sender, e);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAbmInsumos formulario = new frmAbmInsumos();
            int id = Convert.ToInt32(dgvInsumos.CurrentRow.Cells["id_insumo"].Value);
            IList<Insumo> lst = insumo.GetInsumosId(id);
            Insumo selected = new Insumo(lst[0].CodigoInsumo, lst[0].NombreInsumo, lst[0].PrecioInsumo, lst[0].ProveedorInsumo, lst[0].TipoInsumo);
            formulario.InicializarFormulario(frmAbmInsumos.FormMode.actualizar, selected);
            formulario.ShowDialog();
            actualizar(sender, e);
        }

        private void actualizar(System.Object sender, System.EventArgs e)
        {
            dgvInsumos.Rows.Clear();
            IList<Insumo> lst = insumo.GetInsumos(txtProducto.Text);
            foreach (Insumo obj in lst)
            {
                var nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(obj.NombreInsumo);
                var proveedor = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(obj.ProveedorInsumo);


                IList<InsumosTipo> lst2 = insumosTipo.GetOneInsumo(obj.TipoInsumo);
                dgvInsumos.Rows.Add(new object[] { obj.CodigoInsumo, nombre, obj.PrecioInsumo, proveedor, lst2[0].NombreTipoInsumo });
            }
            if (dgvInsumos.Rows.Count > 0)
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

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            actualizar(sender, e);
        }

        private void dgvInsumos_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvInsumos.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                    btnModificar_Click(sender, e);
                if (e.KeyCode == Keys.Delete)
                    btnEliminar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
                if (MessageBox.Show("¿Seguro que desea volver al menú principal?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    this.Close();

            if (e.KeyCode == Keys.Add)
                btnNuevo_Click(sender, e);
            if (e.KeyCode == Keys.Insert)
                btnNuevo_Click(sender, e);
        }

        private void frmInsumos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                if (MessageBox.Show("¿Seguro que desea volver al menú principal?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
        }
    }
}
