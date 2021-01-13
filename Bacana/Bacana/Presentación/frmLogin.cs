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
using Bacana.Negocio.Servicios;

namespace Bacana
{
    public partial class frmLogin : Form
    {
        private readonly UsuarioService usuarioService;
        public string UsuarioLogueado { get; internal set; }

        public frmLogin()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
        }

        private void btnLogin_LinkClicked(object sender,EventArgs e)
        {
            if (txtUsuario.Text == "")  
            {
                txtUsuario.Focus();
                msgError("Por favor Ingrese un usuario");
                return;
            }
            if (txtContraseña.Text == "")
            {
                txtContraseña.Focus();
                msgError("Por favor Ingrese Contraseña");
                return;
            }
            var usr = usuarioService.ValidarUsuario(txtUsuario.Text, txtContraseña.Text);
            if (usr != null)
            {
                UsuarioLogueado = usr.User;
                this.Hide();
                frmInicio frm = new frmInicio();
                frm.ShowDialog();
            }
            else
            {

                txtContraseña.Text = "";
                txtContraseña.Focus();
                msgError("Usuario y/o Contraseña Incorrecto");
            }



        }
        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void msgError(string mensaje)
        {
            lblError.Text = "      " + mensaje;
            lblError.Visible = true;

        }

        
       

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea Salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        

        private void txtContraseña_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                pictureBox1_Click_1(sender, e);
            if (e.KeyCode == Keys.Enter)
                btnLogin_LinkClicked(sender, e);
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                pictureBox1_Click_1(sender, e);
            if (e.KeyCode == Keys.Enter)
                btnLogin_LinkClicked(sender, e);
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
