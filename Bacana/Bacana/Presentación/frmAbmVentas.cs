using Bacana.Negocio.Entidades;
using Bacana.Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacana.Presentación
{
    public partial class frmAbmVentas : Form
    {
//        private FacturaDetalle oFacturaDetalleSelected;
        private TortasService oTorta;
        private InsumosService oInsumo;
        private InsumosTortasService oInsumosTorta;
        public frmAbmVentas()
        {
            oTorta = new TortasService();
            oInsumo = new InsumosService();
            oInsumosTorta = new InsumosTortasService();
            InitializeComponent();
        }

        private void getArticulo(int id)
        {

            IList<Torta> lst = oTorta.getTortaId(id);
            if (lst.Count < 1)
            {
                frmSelectProducto frm = new frmSelectProducto();
                DialogResult res = frm.ShowDialog();
                if (res == DialogResult.No)
                {
                    txtArticulo.Clear();
                    lblProducto.Text = "";
                    txtUnidades.Clear();
                    lblUnitario.Text = "";
                    btnAceptar.Enabled = false;
                    txtArticulo.Focus();
                }
                else
                {
                    txtArticulo.Text = frm.varId;
                    getArticulo(Convert.ToInt32(txtArticulo.Text));
                }
            }
            else
            {
                nombreTorta();
                calcularUnitario();

            }
        }

        private void txtArticulo_Leave(object sender, EventArgs e)
        {
            if (btnCancelar.Focused)
            {

            }
            else
            {
                if (txtArticulo.Text == "")
                {
                    frmSelectProducto frm = new frmSelectProducto();
                    DialogResult res = frm.ShowDialog();
                    if (res == DialogResult.No)
                    {
                        txtArticulo.Clear();
                        lblProducto.Text = "";
                        txtUnidades.Clear();
                        lblUnitario.Text = "";
                        btnAceptar.Enabled = false;
                        txtArticulo.Focus();

                    }
                    else
                    {
                        txtArticulo.Text = frm.varId;
                        nombreTorta();
                        calcularUnitario();
                    }
                }
                else
                {
                    getArticulo(Convert.ToInt32(txtArticulo.Text));

                }
            }
            
        }
        
        private void txtArticulo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUnidades_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmAbmVentas_Load(object sender, EventArgs e)
        {
            txtArticulo.Focus();
                 

            
            
        }

        

        private void nombreTorta()
        {
            int id_torta = Convert.ToInt32(txtArticulo.Text);
            IList<Torta> lst = oTorta.getTortaId(id_torta);
            Torta selected = new Torta(lst[0].id_torta, lst[0].nombre, lst[0].borrado, lst[0].porcentaje);
            lblProducto.Text = selected.nombre;
        }

        private void calcularUnitario()
        {
            float acumulador = 0;
            int id_torta = Convert.ToInt32(txtArticulo.Text);
            IList<Torta> lst3 = oTorta.getTortaId(id_torta);
            IList<InsumoTorta> lst = oInsumosTorta.getInsumos(id_torta);
            foreach (InsumoTorta obj in lst)
            {
                float precioproduto = 0;
                IList<Insumo> lst2 = oInsumo.GetInsumosId(obj.insumo.CodigoInsumo);
                precioproduto = obj.cantidad * lst2[0].PrecioInsumo;
                acumulador = acumulador + precioproduto;
            }
            float total = 0;
            total = (acumulador * 100) / lst3[0].porcentaje;
            unitario = total;
            lblUnitario.Text = string.Format("{0:C2}", Convert.ToSingle(total.ToString()));

        }

        private void txtUnidades_Leave(object sender, EventArgs e)
        {
            if (btnCancelar.Focused)
            {

            }
            else
            {
                if (txtUnidades.Text == "")
                {
                    lblError.Visible = true;
                    lblError.Text = "   Ingrese Una Cantidad Mayor a Cero";
                    txtUnidades.Focus();
                    btnAceptar.Enabled = false;
                }
                else
                {
                    if (Convert.ToInt32(txtUnidades.Text) >= 1)
                    {
                        lblError.Visible = false;
                        btnAceptar.Enabled = true;
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "   Ingrese Una Cantidad Mayor a Cero";
                        txtUnidades.Focus();
                        btnAceptar.Enabled = false;

                    }
                }
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int articulo;
        public float unitario;
        public int cantidad;
        public string nombre;

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            articulo = Convert.ToInt32(txtArticulo.Text);
            cantidad = Convert.ToInt32(txtUnidades.Text);
            nombre = lblProducto.Text;
            this.Close();
        }

        

        private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtUnidades_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnAceptar_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnCancelar_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtUnidades_TextChanged(object sender, EventArgs e)
        {
            if (txtUnidades.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "   Ingrese Una Cantidad Mayor a Cero";
                txtUnidades.Focus();
                btnAceptar.Enabled = false;
            }
            else
            {
                if (Convert.ToInt32(txtUnidades.Text) >= 1)
                {
                    lblError.Visible = false;
                    btnAceptar.Enabled = true;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "   Ingrese Una Cantidad Mayor a Cero";
                    txtUnidades.Focus();
                    btnAceptar.Enabled = false;

                }
            }

        }

        private void txtArticulo_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);

            }
        }
    }
}
