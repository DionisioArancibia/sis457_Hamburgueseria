namespace CpHamburgueseria
{
    partial class FrmVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVenta));
            this.label1 = new System.Windows.Forms.Label();
            this.gbxDatos = new System.Windows.Forms.GroupBox();
            this.cbxTipoDocumento = new System.Windows.Forms.ComboBox();
            this.gbxCliente = new System.Windows.Forms.GroupBox();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.lblCedulaIdentidad = new System.Windows.Forms.Label();
            this.txtdocumento = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAñadirProducto = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.nudCantidadVenta = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.lblProcucto = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.txtPagaCon = new System.Windows.Forms.TextBox();
            this.txtMontoAPagar = new System.Windows.Forms.TextBox();
            this.lblCambio = new System.Windows.Forms.Label();
            this.lblPagoCon = new System.Windows.Forms.Label();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.erpDocumentoCliente = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpCodigoProducto = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpCantidadVender = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpPagaCon = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFecha = new System.Windows.Forms.DateTimePicker();
            this.gbxDatos.SuspendLayout();
            this.gbxCliente.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpDocumentoCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCodigoProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCantidadVender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpPagaCon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(-4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1211, 80);
            this.label1.TabIndex = 35;
            this.label1.Text = "Sistema de Ventas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxDatos
            // 
            this.gbxDatos.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbxDatos.Controls.Add(this.cbxTipoDocumento);
            this.gbxDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDatos.Location = new System.Drawing.Point(11, 116);
            this.gbxDatos.Margin = new System.Windows.Forms.Padding(4);
            this.gbxDatos.Name = "gbxDatos";
            this.gbxDatos.Padding = new System.Windows.Forms.Padding(4);
            this.gbxDatos.Size = new System.Drawing.Size(385, 68);
            this.gbxDatos.TabIndex = 36;
            this.gbxDatos.TabStop = false;
            this.gbxDatos.Text = "Tipo Documento";
            // 
            // cbxTipoDocumento
            // 
            this.cbxTipoDocumento.FormattingEnabled = true;
            this.cbxTipoDocumento.Items.AddRange(new object[] {
            "Factura",
            "Boleta"});
            this.cbxTipoDocumento.Location = new System.Drawing.Point(24, 28);
            this.cbxTipoDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.cbxTipoDocumento.Name = "cbxTipoDocumento";
            this.cbxTipoDocumento.Size = new System.Drawing.Size(336, 32);
            this.cbxTipoDocumento.TabIndex = 0;
            // 
            // gbxCliente
            // 
            this.gbxCliente.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbxCliente.Controls.Add(this.btnAgregarCliente);
            this.gbxCliente.Controls.Add(this.txtNombre);
            this.gbxCliente.Controls.Add(this.lblNombre);
            this.gbxCliente.Controls.Add(this.btnBuscarCliente);
            this.gbxCliente.Controls.Add(this.lblCedulaIdentidad);
            this.gbxCliente.Controls.Add(this.txtdocumento);
            this.gbxCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCliente.Location = new System.Drawing.Point(404, 116);
            this.gbxCliente.Margin = new System.Windows.Forms.Padding(4);
            this.gbxCliente.Name = "gbxCliente";
            this.gbxCliente.Padding = new System.Windows.Forms.Padding(4);
            this.gbxCliente.Size = new System.Drawing.Size(781, 143);
            this.gbxCliente.TabIndex = 38;
            this.gbxCliente.TabStop = false;
            this.gbxCliente.Text = "Cliente";
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarCliente.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCliente.Image = global::CpHamburgueseria.Properties.Resources.clients;
            this.btnAgregarCliente.Location = new System.Drawing.Point(620, 81);
            this.btnAgregarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAgregarCliente.Size = new System.Drawing.Size(89, 55);
            this.btnAgregarCliente.TabIndex = 127;
            this.btnAgregarCliente.UseVisualStyleBackColor = false;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(231, 98);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(365, 30);
            this.txtNombre.TabIndex = 126;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(21, 103);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(192, 24);
            this.lblNombre.TabIndex = 125;
            this.lblNombre.Text = "Nombre de Cliente:";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCliente.Image = global::CpHamburgueseria.Properties.Resources.search;
            this.btnBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarCliente.Location = new System.Drawing.Point(620, 23);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(5);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(135, 50);
            this.btnBuscarCliente.TabIndex = 124;
            this.btnBuscarCliente.Text = "Buscar";
            this.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // lblCedulaIdentidad
            // 
            this.lblCedulaIdentidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCedulaIdentidad.AutoSize = true;
            this.lblCedulaIdentidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedulaIdentidad.Location = new System.Drawing.Point(12, 39);
            this.lblCedulaIdentidad.Name = "lblCedulaIdentidad";
            this.lblCedulaIdentidad.Size = new System.Drawing.Size(204, 24);
            this.lblCedulaIdentidad.TabIndex = 4;
            this.lblCedulaIdentidad.Text = "Cédula de Identidad:";
            // 
            // txtdocumento
            // 
            this.txtdocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdocumento.Location = new System.Drawing.Point(231, 34);
            this.txtdocumento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdocumento.Name = "txtdocumento";
            this.txtdocumento.Size = new System.Drawing.Size(365, 30);
            this.txtdocumento.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.btnAñadirProducto);
            this.groupBox2.Controls.Add(this.btnQuitar);
            this.groupBox2.Controls.Add(this.txtDescripcion);
            this.groupBox2.Controls.Add(this.btnAgregarProducto);
            this.groupBox2.Controls.Add(this.lblDescripcion);
            this.groupBox2.Controls.Add(this.txtStock);
            this.groupBox2.Controls.Add(this.txtPrecioVenta);
            this.groupBox2.Controls.Add(this.lblStock);
            this.groupBox2.Controls.Add(this.lblPrecio);
            this.groupBox2.Controls.Add(this.nudCantidadVenta);
            this.groupBox2.Controls.Add(this.lblCantidad);
            this.groupBox2.Controls.Add(this.txtCodigoProducto);
            this.groupBox2.Controls.Add(this.lblCodigo);
            this.groupBox2.Controls.Add(this.btnBuscarProducto);
            this.groupBox2.Controls.Add(this.lblProcucto);
            this.groupBox2.Controls.Add(this.txtProducto);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 266);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1175, 145);
            this.groupBox2.TabIndex = 127;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Producto";
            // 
            // btnAñadirProducto
            // 
            this.btnAñadirProducto.BackColor = System.Drawing.Color.Transparent;
            this.btnAñadirProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirProducto.Image = global::CpHamburgueseria.Properties.Resources.new2;
            this.btnAñadirProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAñadirProducto.Location = new System.Drawing.Point(347, 32);
            this.btnAñadirProducto.Margin = new System.Windows.Forms.Padding(5);
            this.btnAñadirProducto.Name = "btnAñadirProducto";
            this.btnAñadirProducto.Size = new System.Drawing.Size(59, 47);
            this.btnAñadirProducto.TabIndex = 137;
            this.btnAñadirProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAñadirProducto.UseVisualStyleBackColor = true;
            this.btnAñadirProducto.Click += new System.EventHandler(this.btnAñadirProducto_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.Image = global::CpHamburgueseria.Properties.Resources.close1;
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuitar.Location = new System.Drawing.Point(1057, 78);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(91, 62);
            this.btnQuitar.TabIndex = 136;
            this.btnQuitar.Text = "Borrar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(556, 38);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(243, 30);
            this.txtDescripcion.TabIndex = 134;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProducto.Image = global::CpHamburgueseria.Properties.Resources.new1;
            this.btnAgregarProducto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarProducto.Location = new System.Drawing.Point(1057, 9);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(91, 62);
            this.btnAgregarProducto.TabIndex = 135;
            this.btnAgregarProducto.Text = "Agregar";
            this.btnAgregarProducto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(413, 43);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(127, 24);
            this.lblDescripcion.TabIndex = 133;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtStock
            // 
            this.txtStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(805, 97);
            this.txtStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(220, 30);
            this.txtStock.TabIndex = 132;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrecioVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioVenta.Location = new System.Drawing.Point(556, 95);
            this.txtPrecioVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(161, 30);
            this.txtPrecioVenta.TabIndex = 131;
            // 
            // lblStock
            // 
            this.lblStock.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(724, 100);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(67, 24);
            this.lblStock.TabIndex = 130;
            this.lblStock.Text = "Stock:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(399, 100);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(142, 24);
            this.lblPrecio.TabIndex = 129;
            this.lblPrecio.Text = "Precio Venta :";
            // 
            // nudCantidadVenta
            // 
            this.nudCantidadVenta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudCantidadVenta.Location = new System.Drawing.Point(918, 38);
            this.nudCantidadVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudCantidadVenta.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCantidadVenta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidadVenta.Name = "nudCantidadVenta";
            this.nudCantidadVenta.Size = new System.Drawing.Size(93, 30);
            this.nudCantidadVenta.TabIndex = 128;
            this.nudCantidadVenta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCantidad
            // 
            this.lblCantidad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(823, 43);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(98, 24);
            this.lblCantidad.TabIndex = 127;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoProducto.Location = new System.Drawing.Point(128, 90);
            this.txtCodigoProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.Size = new System.Drawing.Size(121, 30);
            this.txtCodigoProducto.TabIndex = 126;
            // 
            // lblCodigo
            // 
            this.lblCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(27, 97);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(89, 24);
            this.lblCodigo.TabIndex = 125;
            this.lblCodigo.Text = "Codigo :";
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarProducto.Image = global::CpHamburgueseria.Properties.Resources.search;
            this.btnBuscarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarProducto.Location = new System.Drawing.Point(259, 82);
            this.btnBuscarProducto.Margin = new System.Windows.Forms.Padding(5);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(125, 47);
            this.btnBuscarProducto.TabIndex = 124;
            this.btnBuscarProducto.Text = "Buscar";
            this.btnBuscarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // lblProcucto
            // 
            this.lblProcucto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProcucto.AutoSize = true;
            this.lblProcucto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcucto.Location = new System.Drawing.Point(7, 44);
            this.lblProcucto.Name = "lblProcucto";
            this.lblProcucto.Size = new System.Drawing.Size(106, 24);
            this.lblProcucto.TabIndex = 4;
            this.lblProcucto.Text = "Producto :";
            // 
            // txtProducto
            // 
            this.txtProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducto.Location = new System.Drawing.Point(129, 38);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(208, 30);
            this.txtProducto.TabIndex = 3;
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvVentas.BackgroundColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(11, 428);
            this.dgvVentas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvVentas.MultiSelect = false;
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.Size = new System.Drawing.Size(1177, 340);
            this.dgvVentas.TabIndex = 136;
            // 
            // txtCambio
            // 
            this.txtCambio.Location = new System.Drawing.Point(832, 809);
            this.txtCambio.Margin = new System.Windows.Forms.Padding(5);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(157, 22);
            this.txtCambio.TabIndex = 142;
            // 
            // txtPagaCon
            // 
            this.txtPagaCon.Location = new System.Drawing.Point(551, 810);
            this.txtPagaCon.Margin = new System.Windows.Forms.Padding(5);
            this.txtPagaCon.Name = "txtPagaCon";
            this.txtPagaCon.Size = new System.Drawing.Size(157, 22);
            this.txtPagaCon.TabIndex = 141;
            this.txtPagaCon.Click += new System.EventHandler(this.txtPagaCon_TextChanged);
            // 
            // txtMontoAPagar
            // 
            this.txtMontoAPagar.Location = new System.Drawing.Point(192, 810);
            this.txtMontoAPagar.Margin = new System.Windows.Forms.Padding(5);
            this.txtMontoAPagar.Name = "txtMontoAPagar";
            this.txtMontoAPagar.Size = new System.Drawing.Size(157, 22);
            this.txtMontoAPagar.TabIndex = 140;
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambio.Location = new System.Drawing.Point(732, 810);
            this.lblCambio.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(87, 24);
            this.lblCambio.TabIndex = 139;
            this.lblCambio.Text = "Cambio:";
            // 
            // lblPagoCon
            // 
            this.lblPagoCon.AutoSize = true;
            this.lblPagoCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagoCon.Location = new System.Drawing.Point(376, 811);
            this.lblPagoCon.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPagoCon.Name = "lblPagoCon";
            this.lblPagoCon.Size = new System.Drawing.Size(152, 24);
            this.lblPagoCon.TabIndex = 138;
            this.lblPagoCon.Text = "Monto de Pago";
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.Location = new System.Drawing.Point(31, 809);
            this.lblTotalPagar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(139, 24);
            this.lblTotalPagar.TabIndex = 137;
            this.lblTotalPagar.Text = "Total a Pagar:";
            // 
            // erpDocumentoCliente
            // 
            this.erpDocumentoCliente.ContainerControl = this;
            // 
            // erpCodigoProducto
            // 
            this.erpCodigoProducto.ContainerControl = this;
            // 
            // erpCantidadVender
            // 
            this.erpCantidadVender.ContainerControl = this;
            // 
            // erpPagaCon
            // 
            this.erpPagaCon.ContainerControl = this;
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRegistrarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarVenta.Image = global::CpHamburgueseria.Properties.Resources.select;
            this.btnRegistrarVenta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRegistrarVenta.Location = new System.Drawing.Point(1012, 786);
            this.btnRegistrarVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(103, 69);
            this.btnRegistrarVenta.TabIndex = 143;
            this.btnRegistrarVenta.Text = "Registrar";
            this.btnRegistrarVenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegistrarVenta.UseVisualStyleBackColor = true;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.txtFecha);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 191);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(385, 68);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha Venta";
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(7, 27);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFecha.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(369, 27);
            this.txtFecha.TabIndex = 1;
            this.txtFecha.Value = new System.DateTime(2024, 6, 7, 21, 24, 35, 0);
            // 
            // FrmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1201, 889);
            this.Controls.Add(this.btnRegistrarVenta);
            this.Controls.Add(this.txtCambio);
            this.Controls.Add(this.txtPagaCon);
            this.Controls.Add(this.txtMontoAPagar);
            this.Controls.Add(this.lblCambio);
            this.Controls.Add(this.lblPagoCon);
            this.Controls.Add(this.lblTotalPagar);
            this.Controls.Add(this.dgvVentas);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxCliente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxDatos);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "::: HAMBURGUESERIA - VENTA :::";
            this.Load += new System.EventHandler(this.FrmVenta_Load);
            this.gbxDatos.ResumeLayout(false);
            this.gbxCliente.ResumeLayout(false);
            this.gbxCliente.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpDocumentoCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCodigoProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCantidadVender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpPagaCon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxDatos;
        private System.Windows.Forms.GroupBox gbxCliente;
        private System.Windows.Forms.Label lblCedulaIdentidad;
        private System.Windows.Forms.TextBox txtdocumento;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCodigoProducto;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Label lblProcucto;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.NumericUpDown nudCantidadVenta;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.TextBox txtPagaCon;
        private System.Windows.Forms.TextBox txtMontoAPagar;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.Label lblPagoCon;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Button btnRegistrarVenta;
        private System.Windows.Forms.ErrorProvider erpDocumentoCliente;
        private System.Windows.Forms.ErrorProvider erpCodigoProducto;
        private System.Windows.Forms.ErrorProvider erpCantidadVender;
        private System.Windows.Forms.ErrorProvider erpPagaCon;
        private System.Windows.Forms.ComboBox cbxTipoDocumento;
        private System.Windows.Forms.Button btnAñadirProducto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker txtFecha;
    }
}