using Bacana.Negocio.Servicios;
using Bacana.Presentación;
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

namespace Bacana
{
    public partial class frmClientes : Form
    {
        private ClientesService cliente;
        private FacturaService factura;
        public frmClientes()
        {
            cliente = new ClientesService();
            factura = new FacturaService();

            InitializeComponent();

        }

        

        private void frmClientes_Load(object sender, EventArgs e)
        {
            actualizar(sender, e);
            txtNombre.Focus();
        }



        private void actualizar(System.Object sender, System.EventArgs e)
        {
            dgvClientes.Rows.Clear();
            IList<Cliente> lst = cliente.GetClientesNombreApellido(txtNombre.Text, txtApellido.Text);
            foreach (Cliente obj in lst)
            {
                var nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(obj.Nombre);
                var apellido = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(obj.Apellido);
                var domicilio = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(obj.Domicilio);

                dgvClientes.Rows.Add(new object[] { obj.Id, nombre, apellido, obj.Telefono, domicilio });
            }
            if (dgvClientes.Rows.Count == 0)
            {
                btnEliminar.Enabled = false;
                btnHistorial.Enabled = false;
                btnModificar.Enabled = false;
            }
            else
            {
                btnEliminar.Enabled = true;
                btnHistorial.Enabled = true;
                btnModificar.Enabled = true;

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAbmClientes frm = new frmAbmClientes();
            frm.ShowDialog();
            actualizar(sender, e);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAbmClientes formulario = new frmAbmClientes();
            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["id"].Value);
            IList<Cliente> lst = cliente.GetClientesId(id);
            Cliente selected = new Cliente(lst[0].Id, lst[0].Nombre, lst[0].Apellido, lst[0].Telefono, lst[0].Domicilio);
            formulario.InicializarFormulario(frmAbmClientes.FormMode.actualizar, selected);
            formulario.ShowDialog();
            actualizar(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Seguro que desea Eliminar el Cliente seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["id"].Value);
                    if (factura.getbyCliente(id).Count == 0)
                    {
                        if (cliente.borrarCliente(id))
                        {
                            dgvClientes.Rows.RemoveAt(dgvClientes.CurrentRow.Index);
                            MessageBox.Show("Cliente Eliminado", "Aviso");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede borrar un cliente con facturas generadas", "Error");

                    }

                }
                else
                    MessageBox.Show("Ha ocurrido un error al intentar borrar el Cliente", "Error");
            }
            actualizar(sender, e);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            actualizar(sender, e);
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            actualizar(sender, e);
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            frmHistorialCliente formulario = new frmHistorialCliente();
            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["id"].Value);
            IList<Cliente> lst = cliente.GetClientesId(id);
            Cliente selected = new Cliente(lst[0].Id, lst[0].Nombre, lst[0].Apellido, lst[0].Telefono, lst[0].Domicilio);
            formulario.InicializarFormulario(frmHistorialCliente.FormMode.nuevo, selected);
            formulario.ShowDialog();
            actualizar(sender, e);
        }

        private void dgvClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvClientes.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                    btnHistorial_Click(sender, e);
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

        private void frmClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                if (MessageBox.Show("¿Seguro que desea volver al menú principal?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
        }
    }
}
