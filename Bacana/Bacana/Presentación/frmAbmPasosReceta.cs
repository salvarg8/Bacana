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
    public partial class frmAbmPasosReceta : Form
    {
        private Torta oTortaSelected;
        private PasosTortaService oPasosTortaService;
        private FormMode formMode = FormMode.nuevo;
        public frmAbmPasosReceta()
        {
            oPasosTortaService = new PasosTortaService();
            InitializeComponent();
        }

        public enum FormMode
        {
            nuevo,
            actualizar,
            eliminar
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Guardar Los Cambios?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (dgvPasos.Rows.Count > 0)
                {
                    int cont = 0;
                    try
                    {
                        List<PasosTorta> pasos = new List<PasosTorta>();
                        foreach (DataGridViewRow row in dgvPasos.Rows)
                        {
                            cont += 1;
                            string paso = Convert.ToString(row.Cells["pasos"].Value);
                            PasosTorta obj = new PasosTorta(cont, paso);
                            pasos.Add(obj);

                        }
                        oPasosTortaService.actualizar(cont, oTortaSelected.id_torta, pasos);
                        MessageBox.Show("Pasos guardados!");
                        this.Close();

                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Error al Guardar los Cambios! " + ex.Message + ex.StackTrace, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    msgError("Ingrese al menos un paso");
            }
            
        }



        internal void InicializarFormulario(FormMode actualizar, Torta selected)
        {
            formMode = actualizar;
            oTortaSelected = selected;
        }

        
        private void actualizarPasos(System.Object sender, System.EventArgs e)
        {
            dgvPasos.Rows.Clear();

            IList<PasosTorta> lst = oPasosTortaService.getPasosPorIdTorta(oTortaSelected.id_torta);
            foreach (PasosTorta obj in lst)
            {
                dgvPasos.Rows.Add(new object[] { obj.id, obj.posicion, obj.Paso });
            }

            
        }

        private bool validarCampos()
        {
            if (txtPaso.Text == "")
            {
                msgError("Ingrese un Paso");
                txtPaso.Focus();
                return false;
            }
            return true;
        }

        private void msgError(string mensaje)
        {
            lblError.Text = "      " + mensaje;
            lblError.Visible = true;
        }

        private void frmAbmcPasosReceta_Load(object sender, EventArgs e)
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
                        actualizarPasos(sender,e);
                        break;
                    };
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea Salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea Salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        internal void IniciarFormulario(FormMode nuevo, Torta selected)
        {
            throw new NotImplementedException();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        if (validarCampos())
                        {
                            var oPasosTorta = new PasosTorta();
                            oPasosTortaService.crearPaso(oPasosTorta);
                            MessageBox.Show("Carga realizada Exitosamente");
                            this.Close();
                        }
                    }
                    break;
                case FormMode.actualizar:
                    {
                        if (validarCampos())
                        {
                            var oPasosTorta = new PasosTorta();
                            dgvPasos.Rows.Add(new object[] {0,dgvPasos.Rows.Count,txtPaso.Text });
                            txtPaso.Clear();

                        }
                    }
                    break;
            }
        }

        

        private void btnUp_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvPasos;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell 
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index; 
                if (rowIndex == 0) 
                    return;
                // get index of the column for the selected cell 
                int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows.Remove(selectedRow); 
                dgv.Rows.Insert(rowIndex - 1, selectedRow);
                //dgv.ClearSelection();
                dgv.Rows[rowIndex - 1].Selected = true;
                //dgv.Rows[rowIndex - 1].Cells[colIndex].Selected = true;

            }
            catch { }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvPasos;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell 
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows.Remove(selectedRow); 
                dgv.Rows.Insert(rowIndex + 1, selectedRow);
                //dgv.ClearSelection();
                dgv.Rows[rowIndex + 1].Selected = true;

                // dgv.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
                
            }
            catch { }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPasos.Rows.Count >0)
                dgvPasos.Rows.Remove(dgvPasos.CurrentRow);
        }

        
        private void txtPaso_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);

            }
            if (txtPaso.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAgregar_Click(sender, e);
                }
            } 
        }

        private void dgvPasos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancelar_Click(sender, e);
            if (e.KeyCode == Keys.Enter)
                btnGuardar_Click(sender, e);
            if (dgvPasos.Rows.Count != 0)
            {
                
                if (e.KeyCode == Keys.Delete)
                {
                    btnEliminar_Click(sender, e);
                }
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
