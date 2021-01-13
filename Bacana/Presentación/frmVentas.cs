using Bacana.Negocio.Entidades;
using Bacana.Negocio.Servicios;
using Bacana.Reportes;
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
    public partial class frmVentas : Form
    {
        private readonly ClientesService cliente;
        private readonly FacturaService oFactura;
        private TortasService oTorta;
        private readonly FacturaService facturaService;

        public frmVentas()
        {
            oFactura = new FacturaService();
            cliente = new ClientesService();
            facturaService = new FacturaService();
            oTorta = new TortasService();
            InitializeComponent();
        }

        private void txtNumCliente_KeyPress(object sender, KeyPressEventArgs e)
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

        private void getCliente(int id)
        {
            IList<Cliente> lst = cliente.GetClientesId(id);
            if (lst.Count < 1)
            {
                frmSelectCliente frm = new frmSelectCliente();
                DialogResult res = frm.ShowDialog();
                if (res == DialogResult.No)
                {
                    txtNumCliente.Clear();
                    lblApellido.Text = "";
                    lblDomicilio.Text = "";
                    lblTeléfono.Text = "";
                    lblNombre.Text = "";
                    btnFacturar.Enabled = false;
                    btnAdd.Enabled = false;
                    txtNumCliente.Focus();


                }
                else
                {
                    txtNumCliente.Text = frm.varId;
                    if (txtNumCliente.Text != "")
                    {
                        getCliente(Convert.ToInt32(txtNumCliente.Text));
                        btnAdd.Enabled = true;
                    }
                    else
                    {
                        txtNumCliente.Clear();
                        lblApellido.Text = "";
                        lblDomicilio.Text = "";
                        lblTeléfono.Text = "";
                        lblNombre.Text = "";
                        btnFacturar.Enabled = false;
                        btnAdd.Enabled = false;
                        txtNumCliente.Focus();
                    }

                }
            }
            else
            {
                lblApellido.Text = lst[0].Apellido;
                lblNombre.Text = lst[0].Nombre;
                lblDomicilio.Text = lst[0].Domicilio;
                lblTeléfono.Text = lst[0].Telefono.ToString();
                btnAdd.Enabled = true;

            }

        }

        private void txtNumCliente_Leave(object sender, EventArgs e)
        {
            if (dgvVentas.Focused)
            {
                if (txtNumCliente.Text == "")
                {
                    frmSelectCliente frm = new frmSelectCliente();
                    DialogResult res = frm.ShowDialog();
                    if (res == DialogResult.No)
                    {
                        txtNumCliente.Clear();
                        lblApellido.Text = "";
                        lblDomicilio.Text = "";
                        lblTeléfono.Text = "";
                        lblNombre.Text = "";
                        btnFacturar.Enabled = false;
                        btnAdd.Enabled = false;
                        txtNumCliente.Focus();

                    }
                    else
                    {
                        txtNumCliente.Text = frm.varId;
                        if (txtNumCliente.Text != "")
                        {
                            getCliente(Convert.ToInt32(txtNumCliente.Text));
                            btnAdd.Enabled = true;
                        }
                        else
                        {
                            txtNumCliente.Clear();
                            lblApellido.Text = "";
                            lblDomicilio.Text = "";
                            lblTeléfono.Text = "";
                            lblNombre.Text = "";
                            btnFacturar.Enabled = false;
                            btnAdd.Enabled = false;
                            txtNumCliente.Focus();
                        }

                    }
                }
                else
                {
                    getCliente(Convert.ToInt32(txtNumCliente.Text));
                    btnAdd.Enabled = true;

                }
            }


        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            txtNumCliente.Focus();
            txtNumCliente.Clear();
            lblFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            int i = oFactura.getNumeroFactura();
            lblFactura.Text = i.ToString().PadLeft(10, '0');
            lblApellido.Text = "";
            lblDomicilio.Text = "";
            lblNombre.Text = "";
            lblTeléfono.Text = "";
            lblTotal.Text = "";
            dgvVentas.Rows.Clear();
            btnDelete.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cargaDGV();
            btnDelete.Enabled = true;
        }

        private void grdVenta_Enter(object sender, EventArgs e)
        {
            if (txtNumCliente.Text == "")
            {
                frmSelectCliente frm = new frmSelectCliente();
                DialogResult res = frm.ShowDialog();
                if (res == DialogResult.No)
                {
                    txtNumCliente.Clear();
                    lblApellido.Text = "";
                    lblDomicilio.Text = "";
                    lblTeléfono.Text = "";
                    lblNombre.Text = "";
                    btnFacturar.Enabled = false;
                    btnAdd.Enabled = false;
                    txtNumCliente.Focus();

                }
                else
                {
                    txtNumCliente.Text = frm.varId;
                    if (txtNumCliente.Text != "")
                    {
                        getCliente(Convert.ToInt32(txtNumCliente.Text));
                        btnAdd.Enabled = true;
                    }
                    else
                    {
                        txtNumCliente.Clear();
                        lblApellido.Text = "";
                        lblDomicilio.Text = "";
                        lblTeléfono.Text = "";
                        lblNombre.Text = "";
                        btnFacturar.Enabled = false;
                        btnAdd.Enabled = false;
                        txtNumCliente.Focus();
                    }

                }
            }
            else
            {
                getCliente(Convert.ToInt32(txtNumCliente.Text));
                btnAdd.Enabled = true;

            }
        }

        private void cargaDGV()
        {
            btnDelete.Enabled = true;
            btnFacturar.Enabled = true;
            bool flag = true;
            frmAbmVentas frm = new frmAbmVentas();
            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {
                if (dgvVentas.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvVentas.Rows)
                    {
                        if (frm.articulo == Convert.ToInt32(row.Cells["articulo"].Value))
                        {
                            row.Cells["unidades"].Value = Convert.ToInt32(row.Cells["unidades"].Value) + frm.cantidad;
                            row.Cells["precioTotal"].Value = Convert.ToInt32(row.Cells["unidades"].Value) * frm.unitario;
                            actualizarTotal();
                            flag = false;
                            break;
                        }
                        
                    }
                    if (flag)
                    {
                        float precioTotal = frm.unitario * frm.cantidad;
                        dgvVentas.Rows.Add(new object[] { frm.articulo, frm.nombre, frm.cantidad, frm.unitario, precioTotal });
                        actualizarTotal();
                    }
                }
                else
                {
                    float precioTotal = frm.unitario * frm.cantidad;
                    dgvVentas.Rows.Add(new object[] { frm.articulo, frm.nombre, frm.cantidad, frm.unitario, precioTotal });
                    actualizarTotal();
                }
                


            }

        }
        float Total;
        private void actualizarTotal()
        {
            float total = 0;
            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                total = total + Convert.ToSingle(row.Cells["precioTotal"].Value);
            }
            lblTotal.Text = total.ToString();
            lblTotal.Text = string.Format("{0:C2}", Convert.ToSingle(total.ToString()));
            Total = Total + total;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVentas.Rows.Count > 0)
            {
                dgvVentas.Rows.Remove(dgvVentas.CurrentRow);

            }
            if (dgvVentas.Rows.Count == 0)
            {
                btnDelete.Enabled = false;
                btnFacturar.Enabled = false;
            } 
            actualizarTotal();

        }

        

        private void dgvVentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                btnAdd_Click(sender, e);

            }
            if (e.KeyCode == Keys.Add)
            {
                btnAdd_Click(sender, e);
            }
            if (e.KeyCode == Keys.Delete)
            {
                btnDelete_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
                if (MessageBox.Show("¿Seguro que desea volver al menú principal?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
        }



        private void btnFacturar_Click(object sender, EventArgs e)
        {
            int asd = oFactura.getNumeroFactura();
            try
            {
                List<FacturaDetalle> listaFacturaDetalle = new List<FacturaDetalle>();
                foreach (DataGridViewRow row in dgvVentas.Rows)
                {
                    int idFactura = asd;
                    var id = (Convert.ToInt32(row.Cells["articulo"].Value));
                    Torta torta = new Torta(id,"a",false,0);
                    float unitario = Convert.ToSingle(row.Cells["precioUnitario"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["unidades"].Value);
                    FacturaDetalle obj = new FacturaDetalle(idFactura,torta,unitario,cantidad);
                    listaFacturaDetalle.Add(obj);

                }


                var factura = new Factura
                {
                    IdFactura = asd,
                    Fecha = DateTime.Today,
                    Cliente = new Cliente(Convert.ToInt32(txtNumCliente.Text),lblNombre.Text,lblApellido.Text,Convert.ToDouble(lblTeléfono.Text),lblDomicilio.Text),
                    FacturaDetalle = listaFacturaDetalle,
                    ImporteTotal = Total,
                    
                };
                facturaService.Crear(factura);
                MessageBox.Show(string.Concat("La factura nro: ", lblFactura.Text, " se generó correctamente."), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("¿Desea Imprimir la Factura?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    frmReporteFactura frm = new frmReporteFactura();
                    frm.InicializarFormulario(frmReporteFactura.FormMode.actualizar, asd);
                    frm.ShowDialog();
                }
                frmVentas_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la factura! " + ex.Message + ex.StackTrace, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmVentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtNumCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                if (MessageBox.Show("¿Seguro que desea volver al menú principal?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
        }
    }
}
