using Bacana.Negocio.Entidades;
using Bacana.Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacana.Presentación
{
    public partial class frmAbmTortas : Form
    {
        private Torta oTortaSelected;
        private FormMode formMode = FormMode.nuevo;
        private readonly TortasService oTortaService;

        public frmAbmTortas()
        {
            InitializeComponent();
            oTortaService = new TortasService();
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
                            var oTorta = new Torta();
                            oTorta.nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtNombre.Text);
                            oTorta.porcentaje = Convert.ToInt32(txtPorcentaje.Text);
                            oTortaService.crearTorta(oTorta);
                            MessageBox.Show("Carga realizada Exitosamente");
                            this.Close();
                        }
                    }break;
                case FormMode.actualizar:
                    {
                        if(validarCampos())
                        {
                            var oTorta = new Torta();
                            oTorta.nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtNombre.Text);
                            oTorta.porcentaje = Convert.ToInt32(txtPorcentaje.Text);
                            oTortaService.actualizar(oTorta,oTortaSelected.id_torta);
                            MessageBox.Show("Actualizacion realizada Exitosamente");
                            this.Close();
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
            if (txtNombre.Text == "")
            {
                msgError("La Torta debe llevar un Nombre");
                txtNombre.Focus();
                return false;
            }
            int valor;
            if (!int.TryParse(txtPorcentaje.Text, out valor))
            {
                msgError("Ingrese un Porcentaje Válido");
                txtPorcentaje.Focus();
                return false;
            }
            if (Convert.ToInt32(txtPorcentaje.Text) <= 0)
            {
                msgError("Ingrese un Porcentaje Válido");
                txtPorcentaje.Focus();
                return false;
            }

            return true;
        }
        private void MostrarDatos()
        {
            if (oTortaSelected != null)
            {
                txtNombre.Text = oTortaSelected.nombre;
                txtPorcentaje.Text = oTortaSelected.porcentaje.ToString();
                
            }
        }

        private void frmAbmTortas_Load(object sender, EventArgs e)
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
                        break;
                    };
            }
        }

        internal void InicializarFormulario(FormMode actualizar, Torta selected)
        {
            formMode = actualizar;
            oTortaSelected = selected;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
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
