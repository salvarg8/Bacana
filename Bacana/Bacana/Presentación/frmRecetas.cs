//using Bacana.Datos.Helper;
using Bacana.Negocio.Entidades;
using Bacana.Negocio.Servicios;
using Bacana.Presentación;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacana
{
    public partial class frmRecetas : Form
    {
        private PasosTortaService oPasosTorta;
        private TortasService oTortaService;
        private InsumosTortasService oInsumoTorta;
        private InsumosService oInsumo;
        public frmRecetas()
        {
            oTortaService = new TortasService();
            oPasosTorta = new PasosTortaService();
            oInsumoTorta = new InsumosTortasService();
            oInsumo = new InsumosService();
            InitializeComponent();
            llenarCombo(cmbTorta, "tortas", "nombre", "id_torta");
        }


        private void frmRecetas_Load(object sender, EventArgs e)
        {
            actualizarPasos(sender, e);
            actualizarInsumos(sender, e);
            cmbTorta.Focus();

        }

        private void llenarCombo(ComboBox cbo, string tabla, string display, string value)
        {
            cbo.DataSource = DataManager.GetInstance().ConsultarTabla2(tabla);
            cbo.ValueMember = value;
            cbo.DisplayMember = display;
            if (cmbTorta.Items.Count > 0)
                btnEditar.Enabled = true;
            else
                btnEditar.Enabled = false;

        }

        private void cmbTorta_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            actualizarPasos(sender, e);
            actualizarInsumos(sender, e);
        }


        private void actualizarInsumos(System.Object sender, System.EventArgs e)
        {
            dgvInsumoTorta.Rows.Clear();
            IList<InsumoTorta> lst = oInsumoTorta.getInsumosPorNombreTorta(cmbTorta.Text);
            foreach (InsumoTorta obj in lst)
            {
                string nombreInsumo = oInsumo.buscarInsumoPorId(obj.insumo.CodigoInsumo);
                string tipoInsumo = oInsumo.buscarTipoPorId(obj.insumo.CodigoInsumo);
                var nomInsumo = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(nombreInsumo);
                dgvInsumoTorta.Rows.Add(new object[] { nomInsumo, tipoInsumo, obj.cantidad });
            }
        }

        private void actualizarPasos(System.Object sender, System.EventArgs e)
        {
            dgvPasos.Rows.Clear();
            IList<Torta> t = oTortaService.getTorta(cmbTorta.Text);
            foreach (Torta obj in t)
            {
                IList<PasosTorta> lst = oPasosTorta.getPasosPorIdTorta(obj.id_torta);
                foreach (PasosTorta obj2 in lst)
                {
                    dgvPasos.Rows.Add(new object[] { obj2.posicion, obj2.Paso});
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmAbmPasosReceta formulario = new frmAbmPasosReceta();
            IList<Torta> lst = oTortaService.getTorta(cmbTorta.Text);
            Torta selected = new Torta(lst[0].id_torta, lst[0].nombre, lst[0].borrado, lst[0].porcentaje);
            formulario.InicializarFormulario(frmAbmPasosReceta.FormMode.actualizar, selected);
            formulario.ShowDialog();
            actualizarPasos(sender, e);
        }

        private void frmRecetas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                if (MessageBox.Show("¿Seguro que desea volver al menú principal?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
        }
    }
}
