namespace Vista.Paneles.Pedidos
{
    partial class frmModificarPedidos
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
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.flpEstado = new System.Windows.Forms.FlowLayoutPanel();
            this.rbAPagar = new System.Windows.Forms.RadioButton();
            this.rbPagoInstantaneo = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNroReserva = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantProducto = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtNroHabitacion = new System.Windows.Forms.TextBox();
            this.btnEliminarDetalle = new System.Windows.Forms.Button();
            this.lblPrecioProd = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBuscarDNI = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnEliminarPedido = new System.Windows.Forms.Button();
            this.btnModificarDetalle = new System.Windows.Forms.Button();
            this.txtNroPedido = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIdDetalle = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnModificarEstado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.flpEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(12, 12);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowHeadersWidth = 51;
            this.dgvPedidos.RowTemplate.Height = 24;
            this.dgvPedidos.Size = new System.Drawing.Size(931, 185);
            this.dgvPedidos.TabIndex = 102;
            this.dgvPedidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_CellClick);
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Location = new System.Drawing.Point(12, 235);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.RowHeadersWidth = 51;
            this.dgvDetalles.RowTemplate.Height = 24;
            this.dgvDetalles.Size = new System.Drawing.Size(931, 185);
            this.dgvDetalles.TabIndex = 103;
            this.dgvDetalles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalles_CellClick);
            // 
            // flpEstado
            // 
            this.flpEstado.Controls.Add(this.rbAPagar);
            this.flpEstado.Controls.Add(this.rbPagoInstantaneo);
            this.flpEstado.Location = new System.Drawing.Point(1058, 138);
            this.flpEstado.Name = "flpEstado";
            this.flpEstado.Size = new System.Drawing.Size(159, 59);
            this.flpEstado.TabIndex = 153;
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
            this.label8.Location = new System.Drawing.Point(945, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 16);
            this.label8.TabIndex = 152;
            this.label8.Text = "Metodo de pago:";
            // 
            // txtNroReserva
            // 
            this.txtNroReserva.Enabled = false;
            this.txtNroReserva.Location = new System.Drawing.Point(1056, 67);
            this.txtNroReserva.Name = "txtNroReserva";
            this.txtNroReserva.Size = new System.Drawing.Size(103, 22);
            this.txtNroReserva.TabIndex = 133;
            this.txtNroReserva.TextChanged += new System.EventHandler(this.txtNroReserva_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(963, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 134;
            this.label4.Text = "Nro Reserva:";
            // 
            // txtCantProducto
            // 
            this.txtCantProducto.Location = new System.Drawing.Point(1031, 325);
            this.txtCantProducto.Name = "txtCantProducto";
            this.txtCantProducto.Size = new System.Drawing.Size(160, 22);
            this.txtCantProducto.TabIndex = 144;
            this.txtCantProducto.TextChanged += new System.EventHandler(this.txtCantProducto_TextChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1416, 394);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 26);
            this.btnCancelar.TabIndex = 148;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNroHabitacion
            // 
            this.txtNroHabitacion.Location = new System.Drawing.Point(1055, 97);
            this.txtNroHabitacion.Name = "txtNroHabitacion";
            this.txtNroHabitacion.Size = new System.Drawing.Size(160, 22);
            this.txtNroHabitacion.TabIndex = 149;
            this.txtNroHabitacion.TextChanged += new System.EventHandler(this.txtNroHabitacion_TextChanged);
            // 
            // btnEliminarDetalle
            // 
            this.btnEliminarDetalle.Location = new System.Drawing.Point(1232, 335);
            this.btnEliminarDetalle.Name = "btnEliminarDetalle";
            this.btnEliminarDetalle.Size = new System.Drawing.Size(124, 38);
            this.btnEliminarDetalle.TabIndex = 146;
            this.btnEliminarDetalle.Text = "Eliminar Detalle";
            this.btnEliminarDetalle.UseVisualStyleBackColor = true;
            this.btnEliminarDetalle.Click += new System.EventHandler(this.btnEliminarDetalle_Click);
            // 
            // lblPrecioProd
            // 
            this.lblPrecioProd.AutoSize = true;
            this.lblPrecioProd.Location = new System.Drawing.Point(1100, 370);
            this.lblPrecioProd.Name = "lblPrecioProd";
            this.lblPrecioProd.Size = new System.Drawing.Size(10, 16);
            this.lblPrecioProd.TabIndex = 147;
            this.lblPrecioProd.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(973, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 135;
            this.label6.Text = "DNI Cliente:";
            // 
            // txtBuscarDNI
            // 
            this.txtBuscarDNI.Location = new System.Drawing.Point(1056, 39);
            this.txtBuscarDNI.Name = "txtBuscarDNI";
            this.txtBuscarDNI.Size = new System.Drawing.Size(160, 22);
            this.txtBuscarDNI.TabIndex = 136;
            this.txtBuscarDNI.TextChanged += new System.EventHandler(this.txtBuscarDNI_TextChanged);
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Enabled = false;
            this.txtNombreCliente.Location = new System.Drawing.Point(1057, 13);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(160, 22);
            this.txtNombreCliente.TabIndex = 137;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(952, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 138;
            this.label3.Text = "Nombre Cliente:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(961, 370);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 16);
            this.label7.TabIndex = 141;
            this.label7.Text = "Precio del Producto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(961, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 139;
            this.label2.Text = "Producto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(961, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 140;
            this.label5.Text = "Cantidad:";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(1031, 297);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(160, 22);
            this.txtNombreProducto.TabIndex = 143;
            this.txtNombreProducto.TextChanged += new System.EventHandler(this.txtNombreProducto_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(954, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 16);
            this.label9.TabIndex = 142;
            this.label9.Text = "Nro Habitacion:";
            // 
            // btnEliminarPedido
            // 
            this.btnEliminarPedido.Location = new System.Drawing.Point(1267, 78);
            this.btnEliminarPedido.Name = "btnEliminarPedido";
            this.btnEliminarPedido.Size = new System.Drawing.Size(124, 38);
            this.btnEliminarPedido.TabIndex = 154;
            this.btnEliminarPedido.Text = "Eliminar Pedido";
            this.btnEliminarPedido.UseVisualStyleBackColor = true;
            this.btnEliminarPedido.Click += new System.EventHandler(this.btnEliminarPedido_Click);
            // 
            // btnModificarDetalle
            // 
            this.btnModificarDetalle.Location = new System.Drawing.Point(1232, 382);
            this.btnModificarDetalle.Name = "btnModificarDetalle";
            this.btnModificarDetalle.Size = new System.Drawing.Size(124, 38);
            this.btnModificarDetalle.TabIndex = 155;
            this.btnModificarDetalle.Text = "Modificar Detalle";
            this.btnModificarDetalle.UseVisualStyleBackColor = true;
            this.btnModificarDetalle.Click += new System.EventHandler(this.btnModificarDetalle_Click);
            // 
            // txtNroPedido
            // 
            this.txtNroPedido.Enabled = false;
            this.txtNroPedido.Location = new System.Drawing.Point(1277, 47);
            this.txtNroPedido.Name = "txtNroPedido";
            this.txtNroPedido.ReadOnly = true;
            this.txtNroPedido.Size = new System.Drawing.Size(103, 22);
            this.txtNroPedido.TabIndex = 156;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1279, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 16);
            this.label10.TabIndex = 157;
            this.label10.Text = "Nro Pedido:";
            // 
            // txtIdDetalle
            // 
            this.txtIdDetalle.Enabled = false;
            this.txtIdDetalle.Location = new System.Drawing.Point(1031, 269);
            this.txtIdDetalle.Name = "txtIdDetalle";
            this.txtIdDetalle.ReadOnly = true;
            this.txtIdDetalle.Size = new System.Drawing.Size(103, 22);
            this.txtIdDetalle.TabIndex = 158;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1033, 250);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 16);
            this.label11.TabIndex = 159;
            this.label11.Text = "ID Detalle:";
            // 
            // btnModificarEstado
            // 
            this.btnModificarEstado.Location = new System.Drawing.Point(1267, 144);
            this.btnModificarEstado.Name = "btnModificarEstado";
            this.btnModificarEstado.Size = new System.Drawing.Size(124, 43);
            this.btnModificarEstado.TabIndex = 160;
            this.btnModificarEstado.Text = "Modificar metodo de pago";
            this.btnModificarEstado.UseVisualStyleBackColor = true;
            this.btnModificarEstado.Click += new System.EventHandler(this.btnModificarEstado_Click);
            // 
            // frmModificarPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(154)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(1538, 429);
            this.Controls.Add(this.btnModificarEstado);
            this.Controls.Add(this.txtIdDetalle);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtNroPedido);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnModificarDetalle);
            this.Controls.Add(this.btnEliminarPedido);
            this.Controls.Add(this.flpEstado);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNroReserva);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCantProducto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtNroHabitacion);
            this.Controls.Add(this.btnEliminarDetalle);
            this.Controls.Add(this.lblPrecioProd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBuscarDNI);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNombreProducto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.dgvPedidos);
            this.Name = "frmModificarPedidos";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.flpEstado.ResumeLayout(false);
            this.flpEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.FlowLayoutPanel flpEstado;
        private System.Windows.Forms.RadioButton rbAPagar;
        private System.Windows.Forms.RadioButton rbPagoInstantaneo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNroReserva;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCantProducto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNroHabitacion;
        private System.Windows.Forms.Button btnEliminarDetalle;
        private System.Windows.Forms.Label lblPrecioProd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBuscarDNI;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnEliminarPedido;
        private System.Windows.Forms.Button btnModificarDetalle;
        private System.Windows.Forms.TextBox txtNroPedido;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIdDetalle;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnModificarEstado;
    }
}