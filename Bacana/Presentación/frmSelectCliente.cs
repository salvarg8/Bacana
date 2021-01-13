using Bacana.Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacana.Presentación
{
    public partial class frmSelectCliente : Form
    {
        private ClientesService cliente;

        public frmSelectCliente()
        {
            cliente = new ClientesService();
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void actualizar(System.Object sender, System.EventArgs e)
        {
            dgvClientes.Rows.Clear();
            IList<Cliente> lst = cliente.GetClientesNombreApellido(txtNombre.Text, txtApellido.Text);
            foreach (Cliente obj in lst)
            {
                dgvClientes.Rows.Add(new object[] { obj.Id, obj.Nombre, obj.Apellido, obj.Telefono, obj.Domicilio });
            }
            if (dgvClientes.Rows.Count == 0)
            {
                btnSeleccionar.Enabled = false;
            }
            else
                btnSeleccionar.Enabled = true;
           
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            actualizar(sender, e);
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            actualizar(sender, e);
        }

        
        public string varId;

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            varId = dgvClientes.CurrentRow.Cells["id"].Value.ToString();
            this.Close();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSeleccionar.Enabled = true;
        }

        private void frmSelectCliente_Load(object sender, EventArgs e)
        {
            actualizar(sender, e);

        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSeleccionar_Click(sender, e);
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAbmClientes frm = new frmAbmClientes();
            frm.ShowDialog();
            actualizar(sender, e);
        }
    }
}