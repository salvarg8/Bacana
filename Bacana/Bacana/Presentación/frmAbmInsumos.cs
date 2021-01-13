//using Bacana.Datos.Helper;
using Bacana.Negocio.Servicios;
using Bacana.Negocio.Entidades;
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
    public partial class frmAbmInsumos : Form
    {
        private FormMode formMode = FormMode.nuevo;

        private readonly InsumosService oInsumoService;

        private Insumo oInsumoSelected;



        public frmAbmInsumos()
        {

            InitializeComponent();
            oInsumoService = new InsumosService();
            llenarCombo(cmbTipo, "tipo_insumos", "tipo_Insumo", "id_tipo");

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void llenarCombo(ComboBox cbo, string tabla, string display, string value)
        {
            cbo.DataSource = DataManager.GetInstance().ConsultarTabla(tabla);
            cbo.ValueMember = value;
            cbo.DisplayMember = display;

        }
        public enum FormMode
        {
            nuevo,
            actualizar,
            eliminar
        }
        private bool validarCampos()
        {
            if (txtNombre.Text == "")
            {
                msgError("El Insumo debe llevar un Nombre");
                txtNombre.Focus();
                return false;
            }
            if (txtprecio.Text == "")
            {
                msgError("El Insumo debe llevar un Precio");
                txtprecio.Focus();
                return false;
            }
            float valor;
            if (!float.TryParse(txtCantidad.Text, out valor))
            {
                msgError("Ingrese una Cantidad Valida");
                txtCantidad.Focus();
                return false;
            }
            if (Convert.ToInt32(txtCantidad.Text) <= 0)
            {
                msgError("Ingrese una Cantidad Valida");
                txtCantidad.Focus();
                return false;
            }

            return true;
        }

        internal void IniciarFormulario(FormMode actualizar, Insumo insumo)
        {
            {
                formMode = actualizar;
                oInsumoSelected = insumo;
            }
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
              case FormMode.nuevo:
                    {
                        if (validarCampos())
                        {
                            var oInsumo = new Insumo();
                            var a = Convert.ToSingle(txtprecio.Tag);

                            //unidades
                            if (Convert.ToInt32(cmbTipo.SelectedIndex)== 0)
                            {
                                oInsumo.NombreInsumo = txtNombre.Text;
                                a = a / Convert.ToSingle(txtCantidad.Text);
                                oInsumo.PrecioInsumo = a;
                                oInsumo.ProveedorInsumo = txtProveedor.Text;
                                oInsumo.TipoInsumo = Convert.ToInt32(cmbTipo.SelectedIndex + 1);
                                oInsumoService.crearInsumo(oInsumo);

                            }
                            //gramos o mililitros
                            if (Convert.ToInt32(cmbTipo.SelectedIndex) == 1 || Convert.ToInt32(cmbTipo.SelectedIndex) == 3)
                            {
                                oInsumo.NombreInsumo = txtNombre.Text;
                                a = a / Convert.ToSingle(txtCantidad.Text);
                                oInsumo.PrecioInsumo = a;
                                oInsumo.ProveedorInsumo = txtProveedor.Text;
                                oInsumo.TipoInsumo = Convert.ToInt32(cmbTipo.SelectedIndex + 1);
                                oInsumoService.crearInsumo(oInsumo);

                                oInsumo.NombreInsumo = txtNombre.Text;
                                a = a* 1000;
                                oInsumo.PrecioInsumo = a;
                                oInsumo.ProveedorInsumo = txtProveedor.Text;
                                oInsumo.TipoInsumo = Convert.ToInt32(cmbTipo.SelectedIndex +2);
                                oInsumoService.crearInsumo(oInsumo);
                            }
                            //kilogramos o litros
                            if (Convert.ToInt32(cmbTipo.SelectedIndex) == 2 || Convert.ToInt32(cmbTipo.SelectedIndex) == 4 )
                            {
                                oInsumo.NombreInsumo = txtNombre.Text;
                                a = a / Convert.ToSingle(txtCantidad.Text);
                                a = a/1000;
                                oInsumo.PrecioInsumo = a;
                                oInsumo.ProveedorInsumo = txtProveedor.Text;
                                oInsumo.TipoInsumo = Convert.ToInt32(cmbTipo.SelectedIndex );
                                oInsumoService.crearInsumo(oInsumo);

                                oInsumo.NombreInsumo = txtNombre.Text;
                                oInsumo.PrecioInsumo = a*1000;
                                oInsumo.ProveedorInsumo = txtProveedor.Text;
                                oInsumo.TipoInsumo = Convert.ToInt32(cmbTipo.SelectedIndex + 1);
                                oInsumoService.crearInsumo(oInsumo);
                            }
                            

                            MessageBox.Show("Carga realizada Exitosamente");
                            this.Close();
                        }


                    }
                    break;
                case FormMode.actualizar:
                    {

                        if (validarCampos())
                        {
                            var a = Convert.ToSingle(txtprecio.Tag);
                            if (oInsumoSelected.TipoInsumo == 1)
                            {
                                oInsumoSelected.NombreInsumo = txtNombre.Text;
                                a = a / Convert.ToSingle(txtCantidad.Text);
                                oInsumoSelected.PrecioInsumo = a;
                                oInsumoSelected.ProveedorInsumo = txtProveedor.Text;
                                if (oInsumoService.actualizarInsumo(oInsumoSelected))
                                {
                                    MessageBox.Show("Insumo actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Dispose();
                                }
                                return;

                            }
                            //gramos o mililitros
                            if (oInsumoSelected.TipoInsumo == 2 || oInsumoSelected.TipoInsumo == 4)
                            {
                                oInsumoSelected.NombreInsumo = txtNombre.Text;
                                a /= Convert.ToSingle(txtCantidad.Text);
                                oInsumoSelected.PrecioInsumo = a;
                                oInsumoSelected.ProveedorInsumo = txtProveedor.Text;
                                oInsumoService.actualizarInsumo(oInsumoSelected);

                                oInsumoSelected.CodigoInsumo = oInsumoSelected.CodigoInsumo + 1;
                                a = a * 1000;
                                oInsumoSelected.PrecioInsumo = a;
                                oInsumoSelected.TipoInsumo = oInsumoSelected.TipoInsumo + 1;
                                if (oInsumoService.actualizarInsumo(oInsumoSelected))
                                {
                                    MessageBox.Show("Insumo actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Dispose();
                                }
                                return;
                            }
                            if (oInsumoSelected.TipoInsumo == 3 || oInsumoSelected.TipoInsumo == 5)
                            {
                                oInsumoSelected.NombreInsumo = txtNombre.Text;
                                a /= Convert.ToSingle(txtCantidad.Text);
                                oInsumoSelected.PrecioInsumo = a;
                                oInsumoSelected.ProveedorInsumo = txtProveedor.Text;
                                oInsumoService.actualizarInsumo(oInsumoSelected);

                                oInsumoSelected.CodigoInsumo = oInsumoSelected.CodigoInsumo - 1;
                                a = a / 1000;
                                oInsumoSelected.PrecioInsumo = a;
                                oInsumoSelected.TipoInsumo = oInsumoSelected.TipoInsumo - 1;
                                if (oInsumoService.actualizarInsumo(oInsumoSelected))
                                {
                                    MessageBox.Show("Insumo actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Dispose();
                                }
                                return;
                            }


                        }
                    }
                    break;

            }

        }

        private void MostrarDatos()
        {
            if (oInsumoSelected != null)
            {
                txtNombre.Text = oInsumoSelected.NombreInsumo;
                txtProveedor.Text = oInsumoSelected.ProveedorInsumo;
                txtprecio.Text = string.Format("{0:C2}",Convert.ToSingle(oInsumoSelected.PrecioInsumo.ToString()));
                txtprecio.Tag = oInsumoSelected.PrecioInsumo.ToString();
                cmbTipo.SelectedIndex = oInsumoSelected.TipoInsumo-1;
            }
        }

        internal void InicializarFormulario(FormMode op, Insumo insumoSelected)
        {
            formMode = op;
            oInsumoSelected = insumoSelected;
        }

        private void frmAbmInsumos_Load(object sender, EventArgs e)
        {

            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        this.Text = "Nuevo Insumo";
                        break;
                    };
                case FormMode.actualizar:
                    {
                        this.Text = "Actualizar Insumo";
                        MostrarDatos();
                        cmbTipo.Enabled = false;
                        break;
                    }
               
            }
        }

        private void msgError(string mensaje)
        {
            lblError.Text = "      " + mensaje;
            lblError.Visible = true;

        }

        private void txtprecio_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = Convert.ToString(tb.Tag);
        }

        private void txtprecio_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            decimal numero = default(decimal);
            bool bln = decimal.TryParse(tb.Text, out numero);
            if ((!(bln)))
                {
                    tb.Clear();
                    return;
                }
            if (numero <0)
            {
                msgError("Ingrese un Precio Valido");
                tb.Clear();
                return;
            }
            tb.Tag = numero;
            tb.Text = string.Format("{0:C2}", numero);
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
                txtprecio.Focus();
        }

        private void txtprecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
                txtProveedor.Focus();
        }

        private void txtProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
                txtCantidad.Focus();
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
                cmbTipo.Focus();
        }

        private void cmbTipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
                btnGuardar_Click(sender, e);
        }

        private void frmAbmInsumos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            
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
