using Bacana.Negocio.Entidades;
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
    public partial class frmSeleccionarInsumo : Form
    {
        private FormMode formMode = FormMode.nuevo;
        private readonly InsumosTortasService oInsumoTortaService;
        private readonly InsumosService oInsumosService;
        private Torta oTortaSelected;

        public frmSeleccionarInsumo()
        {
            InitializeComponent();
            oInsumosService = new InsumosService();
            oInsumoTortaService = new InsumosTortasService();
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

        private void frmSeleccionarInsumo_Load(object sender, EventArgs e)
        {
            llenarCombo(cmbTipo, "tipo_insumos", "tipo_Insumo", "id_tipo");
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarCombo(cmbInsumo, "insumos where tipo =" + (cmbTipo.SelectedIndex+1), "producto", "id_insumo");
        }

        internal void IniciarFormulario(FormMode actualizar, Torta torta)
        {
            {
                formMode = actualizar;
                oTortaSelected = torta;
            }
        }
        
        public enum FormMode
        {
            nuevo,
            actualizar,
            eliminar
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        if (validarCampos())
                        {
                            
                            int torta = oTortaSelected.id_torta;
                            float cantidad = Convert.ToSingle(txtCantidad.Text);
                            int insumo= oInsumosService.BuscarInsumoPorTipoYnombre((cmbTipo.SelectedIndex+1),cmbInsumo.Text);
                            if (oInsumoTortaService.existe(torta,insumo))
                            {
                                IList<InsumoTorta> x = oInsumoTortaService.getInsumos(torta, insumo);
                                oInsumoTortaService.modificarInsumoTorta(torta, x[0].cantidad + cantidad, insumo);
                            }
                            else
                                oInsumoTortaService.agregarInsumo(torta,cantidad,insumo);
                            MessageBox.Show("Carga realizada Exitosamente");
                            this.Close();
                        }

                    }
                    break;
            }

        }
        private bool validarCampos()
        {
            float valor;
            if (!float.TryParse(txtCantidad.Text, out valor))
            {
                msgError("Ingrese una Cantidad Valida");
                txtCantidad.Focus();
                return false;
            }
            if (Convert.ToSingle(txtCantidad.Text) <= 0)
            {
                msgError("Ingrese una Cantidad Valida");
                txtCantidad.Focus();
                return false;
            }

            return true;
        }

        private void msgError(string mensaje)
        {
            lblError.Text = "      " + mensaje;
            lblError.Visible = true;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);

            }
        }
    }
}
    