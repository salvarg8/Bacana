using Microsoft.Reporting.WinForms;
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

namespace Bacana.Reportes
{
    public partial class frmReporteFactura : Form
    {
        private FormMode formMode = FormMode.nuevo;
        public frmReporteFactura()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        


        private void frmReporteFactura_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
            string strSql = "use DB_bacana select DB_bacana.dbo.[facturas].id_factura as Id_factura, DB_bacana.dbo.[facturas].importe as Total ,DB_bacana.dbo.[facturas].id_cliente as Id_cliente, DB_bacana.dbo.[facturas].fecha as Fecha, DB_bacana.dbo.[detalle_factura].cantidad as Cantidad, DB_bacana.dbo.[detalle_factura].unitario as Unitario, DB_bacana.dbo.[clientes].apellido as Apellido, DB_bacana.dbo.[clientes].nombre as Nombre, DB_bacana.dbo.[clientes].direccion as Direccion, DB_bacana.dbo.[clientes].telefono as Telefono, DB_bacana.dbo.[tortas].nombre as NombreTorta from DB_bacana.dbo.[facturas], DB_bacana.dbo.[detalle_factura], dbo.[clientes], DB_bacana.dbo.[tortas]where(DB_bacana.dbo.facturas.id_factura = "+id+" and DB_bacana.dbo.facturas.id_factura = DB_bacana.dbo.detalle_factura.id_factura and dbo.[facturas].id_cliente = dbo.[clientes].id_cliente and dbo.[detalle_factura].id_articulo = dbo.[tortas].id_torta)group by dbo.[facturas].id_factura, dbo.[facturas].fecha,dbo.[facturas].id_cliente, DB_bacana.dbo.[detalle_factura].id_articulo, DB_bacana.dbo.[detalle_factura].cantidad, DB_bacana.dbo.[detalle_factura].unitario, DB_bacana.dbo.[clientes].apellido, dbo.[clientes].direccion,dbo.[clientes].telefono, DB_bacana.dbo.[clientes].nombre, DB_bacana.dbo.[tortas].nombre, DB_bacana.dbo.[facturas].importe";
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataManager.GetInstance().ConsultaSQL(strSql, parametros)));
            reportViewer1.RefreshReport();
        }

       
        int id;
        internal void InicializarFormulario(FormMode actualizar, int selected)
        {
            formMode = actualizar;
            id = selected;
            btnImprimir.Focus();

        }
        public enum FormMode
        {
            nuevo,
            actualizar,
            eliminar
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea Salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }
        
        int lx, ly;
        int sw, sh;

        private void pnlBarra_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            MinimumSize = this.Size;
            MaximumSize = this.Size;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            MinimumSize = new Size(sw, sh);
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }


        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            reportViewer1.PrintDialog();

        }

        private void btnImprimir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, e);
            }
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            btnVolver.Visible = true;
            btnVistaPrevia.Visible = false;
            btnVolver.Focus();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.reportViewer1.SetDisplayMode(DisplayMode.Normal);
            btnVolver.Visible = false;
            btnVistaPrevia.Visible = true;
            btnVistaPrevia.Focus();

        }

        private void frmReporteFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, e);
            }
        }

        private void btnRestaurar_MouseEnter(object sender, EventArgs e)
        {
            btnRestaurar.BackColor = Color.FromArgb(255, 234, 234);
        }

        private void btnRestaurar_MouseLeave(object sender, EventArgs e)
        {
            btnRestaurar.BackColor = Color.FromArgb(255, 194, 192);
        }

        private void btnMinimizar_MouseEnter(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.FromArgb(255, 234, 234);
        }

        private void btnMaximizar_MouseEnter(object sender, EventArgs e)
        {
            btnMaximizar.BackColor = Color.FromArgb(255, 234, 234);
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(255, 234, 234);
        }

        private void btnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.FromArgb(255, 194, 192);
        }

        private void btnMaximizar_MouseLeave(object sender, EventArgs e)
        {
            btnMaximizar.BackColor = Color.FromArgb(255, 194, 192);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(255, 194, 192);
        }


        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.pnlFrontal.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }


    }
}
