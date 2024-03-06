namespace Vista.Paneles
{
    partial class frmCheckOut
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
            this.btnResTodas = new System.Windows.Forms.Button();
            this.btnResFinalizadas = new System.Windows.Forms.Button();
            this.btnResActivas = new System.Windows.Forms.Button();
            this.btnResPendientes = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFechaIda = new System.Windows.Forms.Label();
            this.lblFechaLlegada = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.txtBuscarDNI = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNroReserva = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.txtIdReserva = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNroHabitacion = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTotalConExtras = new System.Windows.Forms.Label();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnResTodas
            // 
            this.btnResTodas.Location = new System.Drawing.Point(303, 412);
            this.btnResTodas.Name = "btnResTodas";
            this.btnResTodas.Size = new System.Drawing.Size(91, 25);
            this.btnResTodas.TabIndex = 143;
            this.btnResTodas.Text = "Todas";
            this.btnResTodas.UseVisualStyleBackColor = true;
            this.btnResTodas.Click += new System.EventHandler(this.btnResTodas_Click);
            // 
            // btnResFinalizadas
            // 
            this.btnResFinalizadas.Location = new System.Drawing.Point(206, 412);
            this.btnResFinalizadas.Name = "btnResFinalizadas";
            this.btnResFinalizadas.Size = new System.Drawing.Size(91, 25);
            this.btnResFinalizadas.TabIndex = 142;
            this.btnResFinalizadas.Text = "Finalizadas";
            this.btnResFinalizadas.UseVisualStyleBackColor = true;
            this.btnResFinalizadas.Click += new System.EventHandler(this.btnResFinalizadas_Click);
            // 
            // btnResActivas
            // 
            this.btnResActivas.Location = new System.Drawing.Point(109, 412);
            this.btnResActivas.Name = "btnResActivas";
            this.btnResActivas.Size = new System.Drawing.Size(91, 25);
            this.btnResActivas.TabIndex = 141;
            this.btnResActivas.Text = "Activas";
            this.btnResActivas.UseVisualStyleBackColor = true;
            this.btnResActivas.Click += new System.EventHandler(this.btnResActivas_Click);
            // 
            // btnResPendientes
            // 
            this.btnResPendientes.Location = new System.Drawing.Point(12, 412);
            this.btnResPendientes.Name = "btnResPendientes";
            this.btnResPendientes.Size = new System.Drawing.Size(91, 25);
            this.btnResPendientes.TabIndex = 140;
            this.btnResPendientes.Text = "Pendientes";
            this.btnResPendientes.UseVisualStyleBackColor = true;
            this.btnResPendientes.Click += new System.EventHandler(this.btnResPendientes_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(1342, 336);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(16, 16);
            this.lblTotal.TabIndex = 139;
            this.lblTotal.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1246, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 16);
            this.label5.TabIndex = 138;
            this.label5.Text = "Total Estadia:";
            // 
            // lblFechaIda
            // 
            this.lblFechaIda.AutoSize = true;
            this.lblFechaIda.Location = new System.Drawing.Point(1473, 297);
            this.lblFechaIda.Name = "lblFechaIda";
            this.lblFechaIda.Size = new System.Drawing.Size(16, 16);
            this.lblFechaIda.TabIndex = 131;
            this.lblFechaIda.Text = "...";
            // 
            // lblFechaLlegada
            // 
            this.lblFechaLlegada.AutoSize = true;
            this.lblFechaLlegada.Location = new System.Drawing.Point(1342, 297);
            this.lblFechaLlegada.Name = "lblFechaLlegada";
            this.lblFechaLlegada.Size = new System.Drawing.Size(16, 16);
            this.lblFechaLlegada.TabIndex = 130;
            this.lblFechaLlegada.Text = "...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1402, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 16);
            this.label7.TabIndex = 129;
            this.label7.Text = "hasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 128;
            this.label3.Text = "Nombre Cliente:";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Enabled = false;
            this.txtNombreCliente.Location = new System.Drawing.Point(353, 68);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.ReadOnly = true;
            this.txtNombreCliente.Size = new System.Drawing.Size(160, 22);
            this.txtNombreCliente.TabIndex = 127;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1246, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 126;
            this.label2.Text = "Estadia   de:";
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(1035, 357);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(182, 48);
            this.btnCheckOut.TabIndex = 125;
            this.btnCheckOut.Text = "Check-Out";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(289, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 124;
            this.label8.Text = "ID Cliente:";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(362, 37);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(65, 22);
            this.txtIdCliente.TabIndex = 123;
            // 
            // txtBuscarDNI
            // 
            this.txtBuscarDNI.Location = new System.Drawing.Point(353, 99);
            this.txtBuscarDNI.Name = "txtBuscarDNI";
            this.txtBuscarDNI.Size = new System.Drawing.Size(160, 22);
            this.txtBuscarDNI.TabIndex = 122;
            this.txtBuscarDNI.TextChanged += new System.EventHandler(this.txtBuscarDNI_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 121;
            this.label6.Text = "DNI Cliente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 120;
            this.label4.Text = "Nro Reserva:";
            // 
            // txtNroReserva
            // 
            this.txtNroReserva.Enabled = false;
            this.txtNroReserva.Location = new System.Drawing.Point(119, 62);
            this.txtNroReserva.Name = "txtNroReserva";
            this.txtNroReserva.ReadOnly = true;
            this.txtNroReserva.Size = new System.Drawing.Size(103, 22);
            this.txtNroReserva.TabIndex = 119;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 118;
            this.label1.Text = "ID:";
            // 
            // dgvReservas
            // 
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.AllowUserToDeleteRows = false;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Location = new System.Drawing.Point(12, 134);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.RowHeadersWidth = 51;
            this.dgvReservas.RowTemplate.Height = 24;
            this.dgvReservas.Size = new System.Drawing.Size(931, 272);
            this.dgvReservas.TabIndex = 117;
            this.dgvReservas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservas_CellClick);
            // 
            // txtIdReserva
            // 
            this.txtIdReserva.Location = new System.Drawing.Point(119, 37);
            this.txtIdReserva.Name = "txtIdReserva";
            this.txtIdReserva.ReadOnly = true;
            this.txtIdReserva.Size = new System.Drawing.Size(103, 22);
            this.txtIdReserva.TabIndex = 116;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 16);
            this.label9.TabIndex = 145;
            this.label9.Text = "Nro Habitacion:";
            // 
            // txtNroHabitacion
            // 
            this.txtNroHabitacion.Location = new System.Drawing.Point(119, 96);
            this.txtNroHabitacion.Name = "txtNroHabitacion";
            this.txtNroHabitacion.Size = new System.Drawing.Size(103, 22);
            this.txtNroHabitacion.TabIndex = 144;
            this.txtNroHabitacion.TextChanged += new System.EventHandler(this.txtNroHabitacion_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1246, 373);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(255, 16);
            this.label13.TabIndex = 146;
            this.label13.Text = "Total (Incluyendo consumos adicionales):";
            // 
            // lblTotalConExtras
            // 
            this.lblTotalConExtras.AutoSize = true;
            this.lblTotalConExtras.Location = new System.Drawing.Point(1518, 373);
            this.lblTotalConExtras.Name = "lblTotalConExtras";
            this.lblTotalConExtras.Size = new System.Drawing.Size(16, 16);
            this.lblTotalConExtras.TabIndex = 147;
            this.lblTotalConExtras.Text = "...";
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(980, 134);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowHeadersWidth = 51;
            this.dgvPedidos.RowTemplate.Height = 24;
            this.dgvPedidos.Size = new System.Drawing.Size(616, 146);
            this.dgvPedidos.TabIndex = 148;
            // 
            // frmCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(154)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(1686, 450);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.lblTotalConExtras);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNroHabitacion);
            this.Controls.Add(this.btnResTodas);
            this.Controls.Add(this.btnResFinalizadas);
            this.Controls.Add(this.btnResActivas);
            this.Controls.Add(this.btnResPendientes);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblFechaIda);
            this.Controls.Add(this.lblFechaLlegada);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.txtBuscarDNI);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNroReserva);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvReservas);
            this.Controls.Add(this.txtIdReserva);
            this.Name = "frmCheckOut";
            this.Text = "frmCheckOut";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResTodas;
        private System.Windows.Forms.Button btnResFinalizadas;
        private System.Windows.Forms.Button btnResActivas;
        private System.Windows.Forms.Button btnResPendientes;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFechaIda;
        private System.Windows.Forms.Label lblFechaLlegada;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox txtBuscarDNI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNroReserva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.TextBox txtIdReserva;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNroHabitacion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTotalConExtras;
        private System.Windows.Forms.DataGridView dgvPedidos;
    }
}