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
    public partial class frmAbmClientes : Form
    {
        private FormMode formMode = FormMode.nuevo;
        private readonly ClientesService oClienteService;
        private Cliente oClienteSelected;

        public frmAbmClientes()
        {
            InitializeComponent();
            oClienteService = new ClientesService();
        }

        public enum FormMode
        {
            nuevo,
            actualizar,
            eliminar
        }
        internal void InicializarFormulario(FormMode actualizar, Cliente cliente)
        {
            formMode = actualizar;
            oClienteSelected = cliente;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validarCampos()
        {
            if (txtNombre.Text == "")
            {
                msgError("El Cliente debe llevar un Nombre");
                txtNombre.Focus();
                return false;
            }
            if (txtApellido.Text == "")
            {
                msgError("El Cliente debe llevar un Apellido");
                txtApellido.Focus();
                return false;
            }
            return true;
        }
        private void msgError(string mensaje)
        {
            lblError.Text = "      " + mensaje;
            lblError.Visible = true;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        int id = oClienteService.getIdNuevoCliente();
                        if (validarCampos())
                        {
                            var oCliente = new Cliente();
                            oCliente.Id = id;
                            oCliente.Nombre = txtNombre.Text;
                            oCliente.Apellido = txtApellido.Text;
                            if (txtTelefono.Text == "")
                            {
                                oCliente.Telefono = 0000000000;
                            }
                            else
                            {
                                oCliente.Telefono = Convert.ToDouble(txtTelefono.Text);
                            }
                            oCliente.Domicilio = txtDireccion.Text;
                            oClienteService.crearCliente(oCliente);
                            MessageBox.Show("Carga realizada Exitosamente");
                            this.Close();
                        }


                    }
                    break;
                case FormMode.actualizar:
                    {

                        if (validarCampos())
                        {
                            oClienteSelected.Nombre = txtNombre.Text;
                            oClienteSelected.Apellido = txtApellido.Text;
                            oClienteSelected.Telefono = Convert.ToDouble(txtTelefono.Text);
                            oClienteSelected.Domicilio = txtDireccion.Text;
                            if (oClienteService.actualizarCliente(oClienteSelected))

                            {
                                MessageBox.Show("Cliente actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                        }
                    }
                    break;

            }

        }
        private void MostrarDatos()
        {
            if (oClienteSelected != null)
            {
                txtNombre.Text = oClienteSelected.Nombre;
                txtApellido.Text = oClienteSelected.Apellido;
                txtTelefono.Text = oClienteSelected.Telefono.ToString();
                txtDireccion.Text = oClienteSelected.Domicilio;

            }
        }

        private void frmAbmClientes_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        this.Text = "Nuevo Cliente";
                        break;
                    };
                case FormMode.actualizar:
                    {
                        this.Text = "Actualizar Cliente";
                        MostrarDatos();
                        txtNombre.Enabled = false;
                        txtApellido.Enabled = false;
                        break;
                    }

            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }

                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
                txtApellido.Focus();
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
                txtDireccion.Focus();
        }

        private void btnGuardar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);

            }
        }

        private void btnCancelar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);

            }
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
                txtTelefono.Focus();
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
                btnGuardar_Click(sender, e);
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
