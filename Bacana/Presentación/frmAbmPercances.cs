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
    public partial class frmAbmPercances : Form
    {
        private FormMode formMode = FormMode.nuevo;

        private readonly PercancesService oPercanceService;

        private Percances oPercanceSelected;

        


        public frmAbmPercances()
        {
            oPercanceService = new PercancesService();
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public enum FormMode
        {
            nuevo,
            actualizar,
            eliminar
        }

        internal void InicializarFormulario(FormMode op, Percances percance)
        {
            formMode = op;
            oPercanceSelected = percance;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        if (validarCampos())
                        {
                            var oPercance = new Percances();
                            oPercance.Producto = txtProducto.Text;
                            oPercance.Fecha = Convert.ToDateTime(dtpFecha.Value);
                            oPercance.Costo = Convert.ToSingle(txtCosto.Tag);
                            oPercance.Descripcion = txtDescripcion.Text;

                            oPercanceService.crearPercance(oPercance);
                            MessageBox.Show("Carga realizada Exitosamente");
                            this.Close();
                        }


                    }
                    break;
                case FormMode.actualizar:
                    {

                        if (validarCampos())
                        {
                            oPercanceSelected.Producto = txtProducto.Text;
                            oPercanceSelected.Fecha = Convert.ToDateTime(dtpFecha.Value);
                            oPercanceSelected.Costo = Convert.ToSingle(txtCosto.Tag);
                            oPercanceSelected.Descripcion = txtDescripcion.Text;
                            if (oPercanceService.actualizarPercance(oPercanceSelected))
                            {
                                MessageBox.Show("Percance actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                        }
                    }
                    break;
            }
        }
        private void msgError(string mensaje)
        {
            lblError.Text = "      " + mensaje;
            lblError.Visible = true;

        }

        private bool validarCampos()
        {
            if (txtProducto.Text == "")
            {
                msgError("El Percance debe llevar un Nombre");
                return false;
            }
            if (txtCosto.Text == "")
            {
                msgError("El Percance debe llevar un Costo");
                return false;
            }
            if (Convert.ToSingle(txtCosto.Tag) <= 0)
            {
                msgError("El Percance debe llevar un Costo");
                return false;
            }
            if (Convert.ToDateTime(dtpFecha.Value.Date) > DateTime.Today.Date)
            {
                msgError("La Fecha es Incorrecta");
                return false;
            }
            
            return true;
        }

        private void txtCosto_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = Convert.ToString(tb.Tag);
        }

        private void txtCosto_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            decimal numero = default(decimal);
            bool bln = decimal.TryParse(tb.Text, out numero);
            if ((!(bln)))
            {
                tb.Clear();
                return;
            }
            if (numero < 0)
            {
                msgError("Ingrese un Precio Valido");
                tb.Clear();
                return;
            }
            tb.Tag = numero;
            tb.Text = string.Format("{0:C2}", numero);
        }

        private void frmAbmPercances_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        this.Text = "Nuevo Percance";
                        break;
                    };
                case FormMode.actualizar:
                    {
                        this.Text = "Actualizar Percance";
                        MostrarDatos();
                        break;
                    }

            }
        }
        private void MostrarDatos()
        {
            if (oPercanceSelected != null)
            {
                txtProducto.Text = oPercanceSelected.Producto;
                txtCosto.Text = string.Format("{0:C2}", Convert.ToSingle(oPercanceSelected.Costo.ToString()));
                txtCosto.Tag = oPercanceSelected.Costo.ToString();
                dtpFecha.Value = oPercanceSelected.Fecha;
                txtDescripcion.Text = oPercanceSelected.Descripcion;
            }
        }

        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);

            }
        }

        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.FromArgb(255, 234, 234);

        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.FromArgb(255, 194, 192);

        }
    }
}
