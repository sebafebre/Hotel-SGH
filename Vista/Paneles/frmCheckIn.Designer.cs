namespace Vista.Paneles
{
    partial class frmCheckIn
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtNroReserva = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.txtIdReserva = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.txtBuscarDNI = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFechaLlegada = new System.Windows.Forms.Label();
            this.lblFechaIda = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblNroHabitacion = new System.Windows.Forms.Label();
            this.lblTipoHabitacion = new System.Windows.Forms.Label();
            this.lblCamas = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnResPendientes = new System.Windows.Forms.Button();
            this.btnResActivas = new System.Windows.Forms.Button();
            this.btnResFinalizadas = new System.Windows.Forms.Button();
            this.btnResTodas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(993, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 77;
            this.label4.Text = "Nro Reserva:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtNroReserva
            // 
            this.txtNroReserva.Location = new System.Drawing.Point(1086, 60);
            this.txtNroReserva.Name = "txtNroReserva";
            this.txtNroReserva.Size = new System.Drawing.Size(103, 22);
            this.txtNroReserva.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1057, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 75;
            this.label1.Text = "ID:";
            // 
            // dgvReservas
            // 
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.AllowUserToDeleteRows = false;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Location = new System.Drawing.Point(12, 12);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.RowHeadersWidth = 51;
            this.dgvReservas.RowTemplate.Height = 24;
            this.dgvReservas.Size = new System.Drawing.Size(931, 394);
            this.dgvReservas.TabIndex = 74;
            this.dgvReservas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservas_CellClick);
            // 
            // txtIdReserva
            // 
            this.txtIdReserva.Location = new System.Drawing.Point(1086, 29);
            this.txtIdReserva.Name = "txtIdReserva";
            this.txtIdReserva.ReadOnly = true;
            this.txtIdReserva.Size = new System.Drawing.Size(103, 22);
            this.txtIdReserva.TabIndex = 73;
            this.txtIdReserva.TextChanged += new System.EventHandler(this.txtIdReserva_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1256, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 93;
            this.label8.Text = "ID Cliente:";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(1329, 29);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(65, 22);
            this.txtIdCliente.TabIndex = 92;
            // 
            // txtBuscarDNI
            // 
            this.txtBuscarDNI.Location = new System.Drawing.Point(1329, 60);
            this.txtBuscarDNI.Name = "txtBuscarDNI";
            this.txtBuscarDNI.Size = new System.Drawing.Size(160, 22);
            this.txtBuscarDNI.TabIndex = 91;
            this.txtBuscarDNI.TextChanged += new System.EventHandler(this.txtBuscarDNI_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1246, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 90;
            this.label6.Text = "DNI Cliente:";
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(1141, 389);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(182, 48);
            this.btnCheckIn.TabIndex = 94;
            this.btnCheckIn.Text = "Check-In";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1039, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 96;
            this.label2.Text = "Estadia   de:";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(1329, 88);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(160, 22);
            this.txtNombreCliente.TabIndex = 98;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1220, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 99;
            this.label3.Text = "Nombre Cliente:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1244, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 16);
            this.label7.TabIndex = 101;
            this.label7.Text = "hasta:";
            // 
            // lblFechaLlegada
            // 
            this.lblFechaLlegada.AutoSize = true;
            this.lblFechaLlegada.Location = new System.Drawing.Point(1142, 295);
            this.lblFechaLlegada.Name = "lblFechaLlegada";
            this.lblFechaLlegada.Size = new System.Drawing.Size(16, 16);
            this.lblFechaLlegada.TabIndex = 102;
            this.lblFechaLlegada.Text = "...";
            // 
            // lblFechaIda
            // 
            this.lblFechaIda.AutoSize = true;
            this.lblFechaIda.Location = new System.Drawing.Point(1293, 295);
            this.lblFechaIda.Name = "lblFechaIda";
            this.lblFechaIda.Size = new System.Drawing.Size(16, 16);
            this.lblFechaIda.TabIndex = 103;
            this.lblFechaIda.Text = "...";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1020, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 16);
            this.label10.TabIndex = 104;
            this.label10.Text = "Nro Habitacion:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1014, 212);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 16);
            this.label11.TabIndex = 105;
            this.label11.Text = "Tipo Habitacion:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1067, 244);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 16);
            this.label12.TabIndex = 106;
            this.label12.Text = "Camas:";
            // 
            // lblNroHabitacion
            // 
            this.lblNroHabitacion.AutoSize = true;
            this.lblNroHabitacion.Location = new System.Drawing.Point(1142, 185);
            this.lblNroHabitacion.Name = "lblNroHabitacion";
            this.lblNroHabitacion.Size = new System.Drawing.Size(16, 16);
            this.lblNroHabitacion.TabIndex = 107;
            this.lblNroHabitacion.Text = "...";
            // 
            // lblTipoHabitacion
            // 
            this.lblTipoHabitacion.AutoSize = true;
            this.lblTipoHabitacion.Location = new System.Drawing.Point(1142, 212);
            this.lblTipoHabitacion.Name = "lblTipoHabitacion";
            this.lblTipoHabitacion.Size = new System.Drawing.Size(16, 16);
            this.lblTipoHabitacion.TabIndex = 108;
            this.lblTipoHabitacion.Text = "...";
            // 
            // lblCamas
            // 
            this.lblCamas.AutoSize = true;
            this.lblCamas.Location = new System.Drawing.Point(1138, 244);
            this.lblCamas.Name = "lblCamas";
            this.lblCamas.Size = new System.Drawing.Size(16, 16);
            this.lblCamas.TabIndex = 109;
            this.lblCamas.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1079, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 110;
            this.label5.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(1138, 342);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(16, 16);
            this.lblTotal.TabIndex = 111;
            this.lblTotal.Text = "...";
            // 
            // btnResPendientes
            // 
            this.btnResPendientes.Location = new System.Drawing.Point(12, 412);
            this.btnResPendientes.Name = "btnResPendientes";
            this.btnResPendientes.Size = new System.Drawing.Size(91, 25);
            this.btnResPendientes.TabIndex = 112;
            this.btnResPendientes.Text = "Pendientes";
            this.btnResPendientes.UseVisualStyleBackColor = true;
            this.btnResPendientes.Click += new System.EventHandler(this.btnResPendientes_Click);
            // 
            // btnResActivas
            // 
            this.btnResActivas.Location = new System.Drawing.Point(109, 412);
            this.btnResActivas.Name = "btnResActivas";
            this.btnResActivas.Size = new System.Drawing.Size(91, 25);
            this.btnResActivas.TabIndex = 113;
            this.btnResActivas.Text = "Activas";
            this.btnResActivas.UseVisualStyleBackColor = true;
            this.btnResActivas.Click += new System.EventHandler(this.btnResActivas_Click);
            // 
            // btnResFinalizadas
            // 
            this.btnResFinalizadas.Location = new System.Drawing.Point(206, 412);
            this.btnResFinalizadas.Name = "btnResFinalizadas";
            this.btnResFinalizadas.Size = new System.Drawing.Size(91, 25);
            this.btnResFinalizadas.TabIndex = 114;
            this.btnResFinalizadas.Text = "Finalizadas";
            this.btnResFinalizadas.UseVisualStyleBackColor = true;
            this.btnResFinalizadas.Click += new System.EventHandler(this.btnResFinalizadas_Click);
            // 
            // btnResTodas
            // 
            this.btnResTodas.Location = new System.Drawing.Point(303, 412);
            this.btnResTodas.Name = "btnResTodas";
            this.btnResTodas.Size = new System.Drawing.Size(91, 25);
            this.btnResTodas.TabIndex = 115;
            this.btnResTodas.Text = "Todas";
            this.btnResTodas.UseVisualStyleBackColor = true;
            this.btnResTodas.Click += new System.EventHandler(this.btnResTodas_Click);
            // 
            // frmCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1538, 449);
            this.Controls.Add(this.btnResTodas);
            this.Controls.Add(this.btnResFinalizadas);
            this.Controls.Add(this.btnResActivas);
            this.Controls.Add(this.btnResPendientes);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCamas);
            this.Controls.Add(this.lblTipoHabitacion);
            this.Controls.Add(this.lblNroHabitacion);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblFechaIda);
            this.Controls.Add(this.lblFechaLlegada);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.txtBuscarDNI);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNroReserva);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvReservas);
            this.Controls.Add(this.txtIdReserva);
            this.Name = "frmCheckIn";
            this.Text = "frmCheckIn";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNroReserva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.TextBox txtIdReserva;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox txtBuscarDNI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblFechaLlegada;
        private System.Windows.Forms.Label lblFechaIda;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblNroHabitacion;
        private System.Windows.Forms.Label lblTipoHabitacion;
        private System.Windows.Forms.Label lblCamas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnResPendientes;
        private System.Windows.Forms.Button btnResActivas;
        private System.Windows.Forms.Button btnResFinalizadas;
        private System.Windows.Forms.Button btnResTodas;
    }
}