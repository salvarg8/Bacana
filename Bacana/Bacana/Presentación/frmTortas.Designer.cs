namespace Bacana.Presentación
{
    partial class frmTortas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTortas));
            this.dgvInsumosTorta = new System.Windows.Forms.DataGridView();
            this.id_torta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreTorta = new System.Windows.Forms.TextBox();
            this.dgvTortas = new System.Windows.Forms.DataGridView();
            this.idTorta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.torta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.btnDeleteInsumo = new System.Windows.Forms.PictureBox();
            this.btnAddInsumo = new System.Windows.Forms.PictureBox();
            this.btnEditar = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumosTorta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTortas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteInsumo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddInsumo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInsumosTorta
            // 
            this.dgvInsumosTorta.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvInsumosTorta.AllowUserToAddRows = false;
            this.dgvInsumosTorta.AllowUserToDeleteRows = false;
            this.dgvInsumosTorta.AllowUserToResizeColumns = false;
            this.dgvInsumosTorta.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.dgvInsumosTorta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvInsumosTorta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInsumosTorta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInsumosTorta.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsumosTorta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvInsumosTorta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsumosTorta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_torta,
            this.idInsumo,
            this.nombre,
            this.cantidad,
            this.tipoInsumo,
            this.delete});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInsumosTorta.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvInsumosTorta.Location = new System.Drawing.Point(361, 122);
            this.dgvInsumosTorta.MultiSelect = false;
            this.dgvInsumosTorta.Name = "dgvInsumosTorta";
            this.dgvInsumosTorta.ReadOnly = true;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Verdana", 8.25F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsumosTorta.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvInsumosTorta.RowHeadersVisible = false;
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvInsumosTorta.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvInsumosTorta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInsumosTorta.ShowCellErrors = false;
            this.dgvInsumosTorta.ShowCellToolTips = false;
            this.dgvInsumosTorta.Size = new System.Drawing.Size(556, 381);
            this.dgvInsumosTorta.TabIndex = 2;
            this.dgvInsumosTorta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvInsumosTorta_KeyDown);
            // 
            // id_torta
            // 
            this.id_torta.HeaderText = "id_torta";
            this.id_torta.Name = "id_torta";
            this.id_torta.ReadOnly = true;
            this.id_torta.Visible = false;
            // 
            // idInsumo
            // 
            this.idInsumo.HeaderText = "id";
            this.idInsumo.Name = "idInsumo";
            this.idInsumo.ReadOnly = true;
            this.idInsumo.Visible = false;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Insumo";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // cantidad
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle15;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // tipoInsumo
            // 
            this.tipoInsumo.HeaderText = "Tipo Insumo";
            this.tipoInsumo.Name = "tipoInsumo";
            this.tipoInsumo.ReadOnly = true;
            // 
            // delete
            // 
            this.delete.HeaderText = "borrado";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Script MT Bold", 33F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 53);
            this.label1.TabIndex = 25;
            this.label1.Text = "Tortas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Script MT Bold", 25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(227, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 41);
            this.label2.TabIndex = 36;
            this.label2.Text = "Torta:";
            // 
            // txtNombreTorta
            // 
            this.txtNombreTorta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(192)))));
            this.txtNombreTorta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreTorta.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreTorta.Location = new System.Drawing.Point(339, 50);
            this.txtNombreTorta.Name = "txtNombreTorta";
            this.txtNombreTorta.Size = new System.Drawing.Size(306, 27);
            this.txtNombreTorta.TabIndex = 0;
            this.txtNombreTorta.TextChanged += new System.EventHandler(this.txtNombreTorta_TextChanged);
            this.txtNombreTorta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTortas_KeyDown);
            // 
            // dgvTortas
            // 
            this.dgvTortas.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvTortas.AllowUserToAddRows = false;
            this.dgvTortas.AllowUserToDeleteRows = false;
            this.dgvTortas.AllowUserToResizeColumns = false;
            this.dgvTortas.AllowUserToResizeRows = false;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTortas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvTortas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvTortas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTortas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(192)))));
            this.dgvTortas.CausesValidation = false;
            this.dgvTortas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvTortas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTortas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvTortas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTortas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTorta,
            this.torta,
            this.porcentaje,
            this.borrado});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTortas.DefaultCellStyle = dataGridViewCellStyle22;
            this.dgvTortas.GridColor = System.Drawing.Color.White;
            this.dgvTortas.Location = new System.Drawing.Point(12, 122);
            this.dgvTortas.MultiSelect = false;
            this.dgvTortas.Name = "dgvTortas";
            this.dgvTortas.ReadOnly = true;
            this.dgvTortas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvTortas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTortas.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgvTortas.RowHeadersVisible = false;
            this.dgvTortas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.NullValue = null;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvTortas.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvTortas.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTortas.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTortas.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvTortas.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvTortas.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvTortas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTortas.ShowCellErrors = false;
            this.dgvTortas.ShowCellToolTips = false;
            this.dgvTortas.ShowEditingIcon = false;
            this.dgvTortas.ShowRowErrors = false;
            this.dgvTortas.Size = new System.Drawing.Size(321, 381);
            this.dgvTortas.TabIndex = 1;
            this.dgvTortas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTortas_CellEnter);
            this.dgvTortas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTortas_KeyDown);
            // 
            // idTorta
            // 
            this.idTorta.HeaderText = "N°";
            this.idTorta.MaxInputLength = 16;
            this.idTorta.Name = "idTorta";
            this.idTorta.ReadOnly = true;
            this.idTorta.Visible = false;
            // 
            // torta
            // 
            this.torta.FillWeight = 128.934F;
            this.torta.HeaderText = "Torta";
            this.torta.Name = "torta";
            this.torta.ReadOnly = true;
            // 
            // porcentaje
            // 
            dataGridViewCellStyle21.NullValue = null;
            this.porcentaje.DefaultCellStyle = dataGridViewCellStyle21;
            this.porcentaje.FillWeight = 70F;
            this.porcentaje.HeaderText = "Porcentaje";
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.ReadOnly = true;
            this.porcentaje.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // borrado
            // 
            this.borrado.HeaderText = "borrado";
            this.borrado.Name = "borrado";
            this.borrado.ReadOnly = true;
            this.borrado.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(263, 509);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 32);
            this.btnDelete.TabIndex = 78;
            this.btnDelete.TabStop = false;
            this.toolTip1.SetToolTip(this.btnDelete, "Eliminar Torta");
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(225, 509);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 32);
            this.btnAdd.TabIndex = 77;
            this.btnAdd.TabStop = false;
            this.toolTip1.SetToolTip(this.btnAdd, "Agregar Torta");
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDeleteInsumo
            // 
            this.btnDeleteInsumo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteInsumo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteInsumo.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteInsumo.Image")));
            this.btnDeleteInsumo.Location = new System.Drawing.Point(885, 509);
            this.btnDeleteInsumo.Name = "btnDeleteInsumo";
            this.btnDeleteInsumo.Size = new System.Drawing.Size(32, 32);
            this.btnDeleteInsumo.TabIndex = 80;
            this.btnDeleteInsumo.TabStop = false;
            this.toolTip1.SetToolTip(this.btnDeleteInsumo, "Eliminar Insumo");
            this.btnDeleteInsumo.Click += new System.EventHandler(this.btnDeleteInsumo_Click);
            // 
            // btnAddInsumo
            // 
            this.btnAddInsumo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddInsumo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddInsumo.Image = ((System.Drawing.Image)(resources.GetObject("btnAddInsumo.Image")));
            this.btnAddInsumo.Location = new System.Drawing.Point(847, 509);
            this.btnAddInsumo.Name = "btnAddInsumo";
            this.btnAddInsumo.Size = new System.Drawing.Size(32, 32);
            this.btnAddInsumo.TabIndex = 79;
            this.btnAddInsumo.TabStop = false;
            this.toolTip1.SetToolTip(this.btnAddInsumo, "Agregar Insumo");
            this.btnAddInsumo.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Location = new System.Drawing.Point(301, 509);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(32, 32);
            this.btnEditar.TabIndex = 81;
            this.btnEditar.TabStop = false;
            this.toolTip1.SetToolTip(this.btnEditar, "Editar Torta");
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // frmTortas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(931, 553);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnDeleteInsumo);
            this.Controls.Add(this.btnAddInsumo);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvTortas);
            this.Controls.Add(this.txtNombreTorta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvInsumosTorta);
            this.Controls.Add(this.label1);
            this.Name = "frmTortas";
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmTortas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTortas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumosTorta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTortas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteInsumo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddInsumo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvInsumosTorta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreTorta;
        private System.Windows.Forms.DataGridView dgvTortas;
        private System.Windows.Forms.PictureBox btnDelete;
        private System.Windows.Forms.PictureBox btnAdd;
        private System.Windows.Forms.PictureBox btnDeleteInsumo;
        private System.Windows.Forms.PictureBox btnAddInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_torta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn delete;
        private System.Windows.Forms.PictureBox btnEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTorta;
        private System.Windows.Forms.DataGridViewTextBoxColumn torta;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrado;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}