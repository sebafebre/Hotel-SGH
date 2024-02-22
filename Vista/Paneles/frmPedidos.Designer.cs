namespace Vista.Paneles
{
    partial class frmPedidos
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.txtBuscarDNI = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNroReserva = new System.Windows.Forms.TextBox();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnModificarPedidos = new System.Windows.Forms.Button();
            this.btnAgregarProductoStock = new System.Windows.Forms.Button();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.txtCantProducto = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnFinalizarPedido = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtNroHabitacion = new System.Windows.Forms.TextBox();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.lblTotalPedido = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flpEstado = new System.Windows.Forms.FlowLayoutPanel();
            this.rbAPagar = new System.Windows.Forms.RadioButton();
            this.rbPagoInstantaneo = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelPedidos = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.flpEstado.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelPedidos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(933, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 110;
            this.label3.Text = "Nombre Cliente:";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Enabled = false;
            this.txtNombreCliente.Location = new System.Drawing.Point(1038, 69);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(160, 22);
            this.txtNombreCliente.TabIndex = 109;
            // 
            // txtBuscarDNI
            // 
            this.txtBuscarDNI.Location = new System.Drawing.Point(1038, 41);
            this.txtBuscarDNI.Name = "txtBuscarDNI";
            this.txtBuscarDNI.Size = new System.Drawing.Size(160, 22);
            this.txtBuscarDNI.TabIndex = 106;
            this.txtBuscarDNI.TextChanged += new System.EventHandler(this.txtBuscarDNI_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(955, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 105;
            this.label6.Text = "DNI Cliente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(945, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 104;
            this.label4.Text = "Nro Reserva:";
            // 
            // txtNroReserva
            // 
            this.txtNroReserva.Enabled = false;
            this.txtNroReserva.Location = new System.Drawing.Point(1038, 13);
            this.txtNroReserva.Name = "txtNroReserva";
            this.txtNroReserva.Size = new System.Drawing.Size(103, 22);
            this.txtNroReserva.TabIndex = 103;
            this.txtNroReserva.TextChanged += new System.EventHandler(this.txtNroReserva_TextChanged);
            // 
            // dgvReservas
            // 
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.AllowUserToDeleteRows = false;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Location = new System.Drawing.Point(3, 3);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.RowHeadersWidth = 51;
            this.dgvReservas.RowTemplate.Height = 24;
            this.dgvReservas.Size = new System.Drawing.Size(931, 185);
            this.dgvReservas.TabIndex = 101;
            this.dgvReservas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservas_CellClick);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(3, 221);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.Size = new System.Drawing.Size(507, 169);
            this.dgvProductos.TabIndex = 111;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(972, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 113;
            this.label2.Text = "Producto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(972, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 114;
            this.label5.Text = "Cantidad:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(975, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 16);
            this.label7.TabIndex = 115;
            this.label7.Text = "Precio del Producto:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(937, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 16);
            this.label9.TabIndex = 116;
            this.label9.Text = "Nro Habitacion:";
            // 
            // btnModificarPedidos
            // 
            this.btnModificarPedidos.Location = new System.Drawing.Point(15, 0);
            this.btnModificarPedidos.Name = "btnModificarPedidos";
            this.btnModificarPedidos.Size = new System.Drawing.Size(161, 26);
            this.btnModificarPedidos.TabIndex = 118;
            this.btnModificarPedidos.Text = "Modificar Pedidos";
            this.btnModificarPedidos.UseVisualStyleBackColor = true;
            this.btnModificarPedidos.Click += new System.EventHandler(this.btnModificarPedidos_Click);
            // 
            // btnAgregarProductoStock
            // 
            this.btnAgregarProductoStock.Location = new System.Drawing.Point(199, 0);
            this.btnAgregarProductoStock.Name = "btnAgregarProductoStock";
            this.btnAgregarProductoStock.Size = new System.Drawing.Size(161, 26);
            this.btnAgregarProductoStock.TabIndex = 119;
            this.btnAgregarProductoStock.Text = "Stock de Productos";
            this.btnAgregarProductoStock.UseVisualStyleBackColor = true;
            this.btnAgregarProductoStock.Click += new System.EventHandler(this.btnAgregarProductoStock_Click);
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(1038, 223);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(160, 22);
            this.txtNombreProducto.TabIndex = 120;
            this.txtNombreProducto.TextChanged += new System.EventHandler(this.txtNombreProducto_TextChanged);
            // 
            // txtCantProducto
            // 
            this.txtCantProducto.Location = new System.Drawing.Point(1038, 251);
            this.txtCantProducto.Name = "txtCantProducto";
            this.txtCantProducto.Size = new System.Drawing.Size(160, 22);
            this.txtCantProducto.TabIndex = 121;
            this.txtCantProducto.TextChanged += new System.EventHandler(this.txtCantProducto_TextChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(976, 342);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(124, 38);
            this.btnAgregar.TabIndex = 122;
            this.btnAgregar.Text = "Agregar Producto";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnFinalizarPedido
            // 
            this.btnFinalizarPedido.Location = new System.Drawing.Point(1126, 342);
            this.btnFinalizarPedido.Name = "btnFinalizarPedido";
            this.btnFinalizarPedido.Size = new System.Drawing.Size(124, 38);
            this.btnFinalizarPedido.TabIndex = 124;
            this.btnFinalizarPedido.Text = "Finalizar Pedido";
            this.btnFinalizarPedido.UseVisualStyleBackColor = true;
            this.btnFinalizarPedido.Click += new System.EventHandler(this.btnFinalizarPedido_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(1109, 284);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(10, 16);
            this.lblTotal.TabIndex = 125;
            this.lblTotal.Text = ".";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1276, 342);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(124, 38);
            this.btnCancelar.TabIndex = 126;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNroHabitacion
            // 
            this.txtNroHabitacion.Location = new System.Drawing.Point(1038, 97);
            this.txtNroHabitacion.Name = "txtNroHabitacion";
            this.txtNroHabitacion.Size = new System.Drawing.Size(160, 22);
            this.txtNroHabitacion.TabIndex = 127;
            this.txtNroHabitacion.TextChanged += new System.EventHandler(this.txtNroHabitacion_TextChanged);
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Location = new System.Drawing.Point(516, 221);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.RowHeadersWidth = 51;
            this.dgvDetalles.RowTemplate.Height = 24;
            this.dgvDetalles.Size = new System.Drawing.Size(418, 169);
            this.dgvDetalles.TabIndex = 128;
            // 
            // lblTotalPedido
            // 
            this.lblTotalPedido.AutoSize = true;
            this.lblTotalPedido.Location = new System.Drawing.Point(1107, 311);
            this.lblTotalPedido.Name = "lblTotalPedido";
            this.lblTotalPedido.Size = new System.Drawing.Size(16, 16);
            this.lblTotalPedido.TabIndex = 129;
            this.lblTotalPedido.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(975, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 130;
            this.label1.Text = "Total del Pedido:";
            // 
            // flpEstado
            // 
            this.flpEstado.Controls.Add(this.rbAPagar);
            this.flpEstado.Controls.Add(this.rbPagoInstantaneo);
            this.flpEstado.Location = new System.Drawing.Point(1301, 251);
            this.flpEstado.Name = "flpEstado";
            this.flpEstado.Size = new System.Drawing.Size(159, 59);
            this.flpEstado.TabIndex = 132;
            // 
            // rbAPagar
            // 
            this.rbAPagar.AutoSize = true;
            this.rbAPagar.Location = new System.Drawing.Point(3, 3);
            this.rbAPagar.Name = "rbAPagar";
            this.rbAPagar.Size = new System.Drawing.Size(77, 20);
            this.rbAPagar.TabIndex = 46;
            this.rbAPagar.TabStop = true;
            this.rbAPagar.Text = "A Pagar";
            this.rbAPagar.UseVisualStyleBackColor = true;
            // 
            // rbPagoInstantaneo
            // 
            this.rbPagoInstantaneo.AutoSize = true;
            this.rbPagoInstantaneo.Location = new System.Drawing.Point(3, 29);
            this.rbPagoInstantaneo.Name = "rbPagoInstantaneo";
            this.rbPagoInstantaneo.Size = new System.Drawing.Size(152, 20);
            this.rbPagoInstantaneo.TabIndex = 47;
            this.rbPagoInstantaneo.TabStop = true;
            this.rbPagoInstantaneo.Text = "Pago en el momento";
            this.rbPagoInstantaneo.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1298, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 16);
            this.label8.TabIndex = 131;
            this.label8.Text = "Metodo de pago:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.btnModificarPedidos);
            this.panel1.Controls.Add(this.btnAgregarProductoStock);
            this.panel1.Location = new System.Drawing.Point(26, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1491, 26);
            this.panel1.TabIndex = 133;
            // 
            // panelPedidos
            // 
            this.panelPedidos.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelPedidos.Controls.Add(this.dgvReservas);
            this.panelPedidos.Controls.Add(this.dgvProductos);
            this.panelPedidos.Controls.Add(this.label1);
            this.panelPedidos.Controls.Add(this.lblTotalPedido);
            this.panelPedidos.Controls.Add(this.flpEstado);
            this.panelPedidos.Controls.Add(this.dgvDetalles);
            this.panelPedidos.Controls.Add(this.label8);
            this.panelPedidos.Controls.Add(this.txtNroReserva);
            this.panelPedidos.Controls.Add(this.label4);
            this.panelPedidos.Controls.Add(this.txtCantProducto);
            this.panelPedidos.Controls.Add(this.btnCancelar);
            this.panelPedidos.Controls.Add(this.txtNroHabitacion);
            this.panelPedidos.Controls.Add(this.btnFinalizarPedido);
            this.panelPedidos.Controls.Add(this.btnAgregar);
            this.panelPedidos.Controls.Add(this.lblTotal);
            this.panelPedidos.Controls.Add(this.label6);
            this.panelPedidos.Controls.Add(this.txtBuscarDNI);
            this.panelPedidos.Controls.Add(this.txtNombreCliente);
            this.panelPedidos.Controls.Add(this.label3);
            this.panelPedidos.Controls.Add(this.label7);
            this.panelPedidos.Controls.Add(this.label2);
            this.panelPedidos.Controls.Add(this.label5);
            this.panelPedidos.Controls.Add(this.txtNombreProducto);
            this.panelPedidos.Controls.Add(this.label9);
            this.panelPedidos.Location = new System.Drawing.Point(26, 44);
            this.panelPedidos.Name = "panelPedidos";
            this.panelPedidos.Size = new System.Drawing.Size(1491, 393);
            this.panelPedidos.TabIndex = 134;
            // 
            // frmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1538, 449);
            this.Controls.Add(this.panelPedidos);
            this.Controls.Add(this.panel1);
            this.Name = "frmPedidos";
            this.Text = "frmPedidos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.flpEstado.ResumeLayout(false);
            this.flpEstado.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelPedidos.ResumeLayout(false);
            this.panelPedidos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.TextBox txtBuscarDNI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNroReserva;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnModificarPedidos;
        private System.Windows.Forms.Button btnAgregarProductoStock;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.TextBox txtCantProducto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnFinalizarPedido;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNroHabitacion;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Label lblTotalPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpEstado;
        private System.Windows.Forms.RadioButton rbAPagar;
        private System.Windows.Forms.RadioButton rbPagoInstantaneo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelPedidos;
    }
}