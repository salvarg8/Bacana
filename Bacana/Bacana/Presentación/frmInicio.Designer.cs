namespace Bacana
{
    partial class frmInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicio));
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnPercance = new System.Windows.Forms.Button();
            this.btnInsumo = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnTortas = new System.Windows.Forms.Button();
            this.btnReceta = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnHistoriaVentas = new System.Windows.Forms.Button();
            this.btnFacturacion = new System.Windows.Forms.Button();
            this.btnVenta = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlContenedor.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Controls.Add(this.pnlPrincipal);
            this.pnlContenedor.Controls.Add(this.pnlMenu);
            this.pnlContenedor.Controls.Add(this.pnlBarra);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 0);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1023, 543);
            this.pnlContenedor.TabIndex = 0;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipal.Controls.Add(this.label2);
            this.pnlPrincipal.Controls.Add(this.pictureBox1);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(200, 20);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(823, 523);
            this.pnlPrincipal.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Cursor = System.Windows.Forms.Cursors.Help;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(780, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Info";
            this.toolTip1.SetToolTip(this.label2, "Versión: 1.0\r\nDiseñado por: Rodriguez Garraza, Salvador\r\n");
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(821, 521);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(192)))));
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Controls.Add(this.btnPercance);
            this.pnlMenu.Controls.Add(this.btnInsumo);
            this.pnlMenu.Controls.Add(this.btnCliente);
            this.pnlMenu.Controls.Add(this.btnTortas);
            this.pnlMenu.Controls.Add(this.btnReceta);
            this.pnlMenu.Controls.Add(this.btnSalir);
            this.pnlMenu.Controls.Add(this.btnHistoriaVentas);
            this.pnlMenu.Controls.Add(this.btnFacturacion);
            this.pnlMenu.Controls.Add(this.btnVenta);
            this.pnlMenu.Controls.Add(this.pictureBox2);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 20);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 523);
            this.pnlMenu.TabIndex = 14;
            // 
            // btnPercance
            // 
            this.btnPercance.BackColor = System.Drawing.Color.White;
            this.btnPercance.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPercance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPercance.Font = new System.Drawing.Font("Script MT Bold", 16F, System.Drawing.FontStyle.Bold);
            this.btnPercance.ForeColor = System.Drawing.Color.Black;
            this.btnPercance.Image = ((System.Drawing.Image)(resources.GetObject("btnPercance.Image")));
            this.btnPercance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPercance.Location = new System.Drawing.Point(0, 368);
            this.btnPercance.Name = "btnPercance";
            this.btnPercance.Size = new System.Drawing.Size(198, 42);
            this.btnPercance.TabIndex = 7;
            this.btnPercance.Text = "Percances";
            this.btnPercance.UseVisualStyleBackColor = false;
            this.btnPercance.Click += new System.EventHandler(this.btnPercance_Click);
            this.btnPercance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnVenta_KeyDown);
            // 
            // btnInsumo
            // 
            this.btnInsumo.BackColor = System.Drawing.Color.White;
            this.btnInsumo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsumo.Font = new System.Drawing.Font("Script MT Bold", 16F, System.Drawing.FontStyle.Bold);
            this.btnInsumo.ForeColor = System.Drawing.Color.Black;
            this.btnInsumo.Image = ((System.Drawing.Image)(resources.GetObject("btnInsumo.Image")));
            this.btnInsumo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsumo.Location = new System.Drawing.Point(0, 326);
            this.btnInsumo.Name = "btnInsumo";
            this.btnInsumo.Size = new System.Drawing.Size(198, 42);
            this.btnInsumo.TabIndex = 6;
            this.btnInsumo.Text = "Insumos";
            this.btnInsumo.UseVisualStyleBackColor = false;
            this.btnInsumo.Click += new System.EventHandler(this.btnInsumo_Click);
            this.btnInsumo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnVenta_KeyDown);
            // 
            // btnCliente
            // 
            this.btnCliente.BackColor = System.Drawing.Color.White;
            this.btnCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Font = new System.Drawing.Font("Script MT Bold", 16F, System.Drawing.FontStyle.Bold);
            this.btnCliente.ForeColor = System.Drawing.Color.Black;
            this.btnCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnCliente.Image")));
            this.btnCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCliente.Location = new System.Drawing.Point(0, 284);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(198, 42);
            this.btnCliente.TabIndex = 5;
            this.btnCliente.Text = "Clientes";
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            this.btnCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnVenta_KeyDown);
            // 
            // btnTortas
            // 
            this.btnTortas.BackColor = System.Drawing.Color.White;
            this.btnTortas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTortas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTortas.Font = new System.Drawing.Font("Script MT Bold", 16F, System.Drawing.FontStyle.Bold);
            this.btnTortas.ForeColor = System.Drawing.Color.Black;
            this.btnTortas.Image = ((System.Drawing.Image)(resources.GetObject("btnTortas.Image")));
            this.btnTortas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTortas.Location = new System.Drawing.Point(0, 242);
            this.btnTortas.Name = "btnTortas";
            this.btnTortas.Size = new System.Drawing.Size(198, 42);
            this.btnTortas.TabIndex = 4;
            this.btnTortas.Text = "Tortas";
            this.btnTortas.UseVisualStyleBackColor = false;
            this.btnTortas.Click += new System.EventHandler(this.btnTortas_Click);
            this.btnTortas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnVenta_KeyDown);
            // 
            // btnReceta
            // 
            this.btnReceta.BackColor = System.Drawing.Color.White;
            this.btnReceta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReceta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceta.Font = new System.Drawing.Font("Script MT Bold", 16F, System.Drawing.FontStyle.Bold);
            this.btnReceta.ForeColor = System.Drawing.Color.Black;
            this.btnReceta.Image = ((System.Drawing.Image)(resources.GetObject("btnReceta.Image")));
            this.btnReceta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceta.Location = new System.Drawing.Point(0, 200);
            this.btnReceta.Name = "btnReceta";
            this.btnReceta.Size = new System.Drawing.Size(198, 42);
            this.btnReceta.TabIndex = 3;
            this.btnReceta.Text = "Recetas";
            this.btnReceta.UseVisualStyleBackColor = false;
            this.btnReceta.Click += new System.EventHandler(this.btnReceta_Click);
            this.btnReceta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnVenta_KeyDown);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Script MT Bold", 16F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(0, 479);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(198, 42);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnSalir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnVenta_KeyDown);
            // 
            // btnHistoriaVentas
            // 
            this.btnHistoriaVentas.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnHistoriaVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHistoriaVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistoriaVentas.Font = new System.Drawing.Font("Script MT Bold", 14F, System.Drawing.FontStyle.Bold);
            this.btnHistoriaVentas.ForeColor = System.Drawing.Color.Black;
            this.btnHistoriaVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoriaVentas.Image")));
            this.btnHistoriaVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistoriaVentas.Location = new System.Drawing.Point(0, 164);
            this.btnHistoriaVentas.Name = "btnHistoriaVentas";
            this.btnHistoriaVentas.Size = new System.Drawing.Size(198, 36);
            this.btnHistoriaVentas.TabIndex = 2;
            this.btnHistoriaVentas.Text = "Historial";
            this.btnHistoriaVentas.UseVisualStyleBackColor = false;
            this.btnHistoriaVentas.Visible = false;
            this.btnHistoriaVentas.Click += new System.EventHandler(this.btnHistoriaVentas_Click);
            this.btnHistoriaVentas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnVenta_KeyDown);
            // 
            // btnFacturacion
            // 
            this.btnFacturacion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFacturacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturacion.Font = new System.Drawing.Font("Script MT Bold", 14F, System.Drawing.FontStyle.Bold);
            this.btnFacturacion.ForeColor = System.Drawing.Color.Black;
            this.btnFacturacion.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturacion.Image")));
            this.btnFacturacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturacion.Location = new System.Drawing.Point(0, 128);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Size = new System.Drawing.Size(198, 36);
            this.btnFacturacion.TabIndex = 1;
            this.btnFacturacion.Text = "Facturación";
            this.btnFacturacion.UseVisualStyleBackColor = false;
            this.btnFacturacion.Visible = false;
            this.btnFacturacion.Click += new System.EventHandler(this.btnFacturacion_Click);
            this.btnFacturacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnVenta_KeyDown);
            // 
            // btnVenta
            // 
            this.btnVenta.BackColor = System.Drawing.Color.White;
            this.btnVenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVenta.Font = new System.Drawing.Font("Script MT Bold", 16F, System.Drawing.FontStyle.Bold);
            this.btnVenta.ForeColor = System.Drawing.Color.Black;
            this.btnVenta.Image = ((System.Drawing.Image)(resources.GetObject("btnVenta.Image")));
            this.btnVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVenta.Location = new System.Drawing.Point(0, 86);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(198, 42);
            this.btnVenta.TabIndex = 0;
            this.btnVenta.Text = "Ventas";
            this.btnVenta.UseVisualStyleBackColor = false;
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            this.btnVenta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnVenta_KeyDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(198, 86);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // pnlBarra
            // 
            this.pnlBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(192)))));
            this.pnlBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBarra.Controls.Add(this.label1);
            this.pnlBarra.Controls.Add(this.btnRestaurar);
            this.pnlBarra.Controls.Add(this.btnMinimizar);
            this.pnlBarra.Controls.Add(this.btnMaximizar);
            this.pnlBarra.Controls.Add(this.btnClose);
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Location = new System.Drawing.Point(0, 0);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Size = new System.Drawing.Size(1023, 20);
            this.pnlBarra.TabIndex = 13;
            this.pnlBarra.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBarra_Paint);
            this.pnlBarra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlBarra_MouseMove);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(556, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bacana Pastelería";
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("btnRestaurar.Image")));
            this.btnRestaurar.Location = new System.Drawing.Point(987, 1);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(16, 16);
            this.btnRestaurar.TabIndex = 15;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            this.btnRestaurar.MouseEnter += new System.EventHandler(this.btnRestaurar_MouseEnter);
            this.btnRestaurar.MouseLeave += new System.EventHandler(this.btnRestaurar_MouseLeave);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(969, 1);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(16, 16);
            this.btnMinimizar.TabIndex = 14;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            this.btnMinimizar.MouseEnter += new System.EventHandler(this.btnMinimizar_MouseEnter);
            this.btnMinimizar.MouseLeave += new System.EventHandler(this.btnMinimizar_MouseLeave);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(987, 1);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(16, 16);
            this.btnMaximizar.TabIndex = 14;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            this.btnMaximizar.MouseEnter += new System.EventHandler(this.btnMaximizar_MouseEnter);
            this.btnMaximizar.MouseLeave += new System.EventHandler(this.btnMaximizar_MouseLeave);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1004, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(16, 16);
            this.btnClose.TabIndex = 12;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // frmInicio
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1023, 543);
            this.Controls.Add(this.pnlContenedor);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1023, 543);
            this.Name = "frmInicio";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bacana";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInicio_FormClosed);
            this.Load += new System.EventHandler(this.frmInicio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInicio_KeyDown);
            this.pnlContenedor.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlBarra.ResumeLayout(false);
            this.pnlBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnPercance;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnInsumo;
        private System.Windows.Forms.Button btnReceta;
        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlBarra;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnTortas;
        private System.Windows.Forms.Button btnHistoriaVentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnFacturacion;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}