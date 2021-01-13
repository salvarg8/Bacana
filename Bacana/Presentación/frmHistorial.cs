using Bacana.Negocio.Servicios;
using Bacana.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Bacana.Reportes;

namespace Bacana.Presentación
{
    public partial class frmHistorial : Form
    {
        private FacturaService oFacturaService;
        public frmHistorial()
        {
            oFacturaService= new FacturaService();
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            txtFactura.Focus();
            dtpHasta.Value = DateTime.Today;

            dgvHistorial.Rows.Clear();
            IList<Factura> lst = oFacturaService.getAll();
            foreach (Factura obj in lst)
            {
                var a = obj.IdFactura.ToString().PadLeft(10, '0');

                if (obj.Anulado)
                    dgvHistorial.Rows.Add(new object[] { a, obj.Fecha, obj.Cliente.Nombre, obj.Cliente.Apellido,"Anulado",obj.ImporteTotal});
                else
                    dgvHistorial.Rows.Add(new object[] { a, obj.Fecha, obj.Cliente.Nombre, obj.Cliente.Apellido, "Vigente", obj.ImporteTotal });
            }
            if (dgvHistorial.Rows.Count == 0)
            {
                btnAnular.Enabled = false;
                btnVer.Enabled = false;
            }
            else
            {
                btnAnular.Enabled = true;
                btnVer.Enabled = true;
            }
        }

        private void actualizar()
        {
            dgvHistorial.Rows.Clear();
            var desde = dtpDesde.Value.Date.ToString("yyyyMMdd");
            var hasta = dtpHasta.Value.Date.ToString("yyyyMMdd");

            IList<Factura> lst = oFacturaService.getByFilter(txtFactura.Text, desde, hasta);
            foreach (Factura obj in lst)
            {
                var nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(obj.Cliente.Nombre);
                var apellido = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(obj.Cliente.Apellido);

                var a = obj.IdFactura.ToString().PadLeft(10, '0');
                if (obj.Anulado)
                    dgvHistorial.Rows.Add(new object[] { a, obj.Fecha, nombre, apellido, "Anulado", obj.ImporteTotal });
                else
                    dgvHistorial.Rows.Add(new object[] { a, obj.Fecha, nombre, apellido, "Vigente", obj.ImporteTotal });

            }
            if (dgvHistorial.Rows.Count == 0)
            {
                btnAnular.Enabled = false;
                btnVer.Enabled = false;
            }
            else
            {
                btnAnular.Enabled = true;
                btnVer.Enabled = true;
            }
        }

        private void txtFactura_TextChanged(object sender, EventArgs e)
        {
            actualizar();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
           actualizar();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            actualizar();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Seguro que desea Anular la Factura seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvHistorial.CurrentRow.Cells["id_factura"].Value);
                    if (oFacturaService.anularFactura(id))
                    {
                        MessageBox.Show("Factura Anulada", "Aviso");
                    }

                }
                else
                    MessageBox.Show("Ha ocurrido un error al intentar anular la factura", "Error");
            }
            actualizar();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.CurrentRow.Cells["estado"].Value.ToString() == "Vigente")
            {
                int selected = Convert.ToInt32(dgvHistorial.CurrentRow.Cells["id_factura"].Value);
                frmReporteFactura frm = new frmReporteFactura();
                frm.InicializarFormulario(frmReporteFactura.FormMode.actualizar, selected);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("La factura se encuentra anulada, no se puede visualizar", "Aviso");
            }


        }

        private void btnTopVendidas_Click(object sender, EventArgs e)
        {
            frmAbmFechas frm = new frmAbmFechas();
            frm.ShowDialog();
        }

        private void dgvHistorial_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvHistorial.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnVer_Click(sender, e);
                }
                if (e.KeyCode == Keys.Delete)
                {
                    btnAnular_Click(sender, e);
                }   
            }
            if (e.KeyCode == Keys.Escape)
                if (MessageBox.Show("¿Seguro que desea volver al menú principal?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    this.Close();

        }

        private void frmHistorial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                if (MessageBox.Show("¿Seguro que desea volver al menú principal?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
        }
    }
    
}
