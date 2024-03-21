namespace Vista.Paneles.Reservas
{
    partial class frmBuscarHabitacion
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
            this.btnTodasHabs = new System.Windows.Forms.Button();
            this.labl = new System.Windows.Forms.Label();
            this.txtNroHabitacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbNroCamas = new System.Windows.Forms.ComboBox();
            this.cbTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.dgvHabitaciones = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaIda = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaLlegada = new System.Windows.Forms.DateTimePicker();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTodasHabs
            // 
            this.btnTodasHabs.Location = new System.Drawing.Point(691, 222);
            this.btnTodasHabs.Name = "btnTodasHabs";
            this.btnTodasHabs.Size = new System.Drawing.Size(84, 24);
            this.btnTodasHabs.TabIndex = 101;
            this.btnTodasHabs.Text = "Ver todas";
            this.btnTodasHabs.UseVisualStyleBackColor = true;
            this.btnTodasHabs.Click += new System.EventHandler(this.btnTodasHabs_Click);
            // 
            // labl
            // 
            this.labl.AutoSize = true;
            this.labl.Location = new System.Drawing.Point(327, 130);
            this.labl.Name = "labl";
            this.labl.Size = new System.Drawing.Size(94, 16);
            this.labl.TabIndex = 100;
            this.labl.Text = "NroHabitacion";
            // 
            // txtNroHabitacion
            // 
            this.txtNroHabitacion.Location = new System.Drawing.Point(330, 157);
            this.txtNroHabitacion.Name = "txtNroHabitacion";
            this.txtNroHabitacion.ReadOnly = true;
            this.txtNroHabitacion.Size = new System.Drawing.Size(65, 22);
            this.txtNroHabitacion.TabIndex = 99;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 98;
            this.label5.Text = "Nro Camas:";
            // 
            // cbNroCamas
            // 
            this.cbNroCamas.FormattingEnabled = true;
            this.cbNroCamas.Items.AddRange(new object[] {
            "1-Simple",
            "2-Simple",
            "1-Matrimonial",
            "2-Matrimoniales"});
            this.cbNroCamas.Location = new System.Drawing.Point(184, 155);
            this.cbNroCamas.Name = "cbNroCamas";
            this.cbNroCamas.Size = new System.Drawing.Size(121, 24);
            this.cbNroCamas.TabIndex = 97;
            this.cbNroCamas.SelectedIndexChanged += new System.EventHandler(this.cbNroCamas_SelectedIndexChanged);
            // 
            // cbTipoHabitacion
            // 
            this.cbTipoHabitacion.FormattingEnabled = true;
            this.cbTipoHabitacion.Items.AddRange(new object[] {
            "Basica",
            "Medium",
            "Premium",
            "Suit"});
            this.cbTipoHabitacion.Location = new System.Drawing.Point(27, 155);
            this.cbTipoHabitacion.Name = "cbTipoHabitacion";
            this.cbTipoHabitacion.Size = new System.Drawing.Size(121, 24);
            this.cbTipoHabitacion.TabIndex = 96;
            this.cbTipoHabitacion.SelectedIndexChanged += new System.EventHandler(this.cbTipoHabitacion_SelectedIndexChanged);
            // 
            // dgvHabitaciones
            // 
            this.dgvHabitaciones.AllowUserToAddRows = false;
            this.dgvHabitaciones.AllowUserToDeleteRows = false;
            this.dgvHabitaciones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(154)))), ((int)(((byte)(153)))));
            this.dgvHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitaciones.Location = new System.Drawing.Point(12, 260);
            this.dgvHabitaciones.Name = "dgvHabitaciones";
            this.dgvHabitaciones.ReadOnly = true;
            this.dgvHabitaciones.RowHeadersWidth = 51;
            this.dgvHabitaciones.RowTemplate.Height = 24;
            this.dgvHabitaciones.Size = new System.Drawing.Size(763, 361);
            this.dgvHabitaciones.TabIndex = 95;
            this.dgvHabitaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHabitaciones_CellClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 16);
            this.label7.TabIndex = 94;
            this.label7.Text = "Tipo Habitacion:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(154)))), ((int)(((byte)(153)))));
            this.panel1.Controls.Add(this.lblFormulario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 72);
            this.panel1.TabIndex = 102;
            // 
            // lblFormulario
            // 
            this.lblFormulario.AutoSize = true;
            this.lblFormulario.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormulario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFormulario.Location = new System.Drawing.Point(265, 20);
            this.lblFormulario.Name = "lblFormulario";
            this.lblFormulario.Size = new System.Drawing.Size(250, 38);
            this.lblFormulario.TabIndex = 5;
            this.lblFormulario.Text = "Buscar Habitacion";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(43, 100);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 16);
            this.lblError.TabIndex = 113;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(535, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 16);
            this.label9.TabIndex = 111;
            this.label9.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(595, 155);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(10, 16);
            this.lblTotal.TabIndex = 109;
            this.lblTotal.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 106;
            this.label3.Text = "Fecha Ida:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 105;
            this.label2.Text = "Fecha Llegada";
            // 
            // dtpFechaIda
            // 
            this.dtpFechaIda.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaIda.Location = new System.Drawing.Point(388, 203);
            this.dtpFechaIda.Name = "dtpFechaIda";
            this.dtpFechaIda.Size = new System.Drawing.Size(127, 22);
            this.dtpFechaIda.TabIndex = 104;
            this.dtpFechaIda.Value = new System.DateTime(2024, 3, 9, 0, 0, 0, 0);
            this.dtpFechaIda.ValueChanged += new System.EventHandler(this.dtpFechaIda_ValueChanged);
            // 
            // dtpFechaLlegada
            // 
            this.dtpFechaLlegada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaLlegada.Location = new System.Drawing.Point(132, 204);
            this.dtpFechaLlegada.Name = "dtpFechaLlegada";
            this.dtpFechaLlegada.Size = new System.Drawing.Size(127, 22);
            this.dtpFechaLlegada.TabIndex = 103;
            this.dtpFechaLlegada.Value = new System.DateTime(2024, 3, 8, 0, 0, 0, 0);
            this.dtpFechaLlegada.ValueChanged += new System.EventHandler(this.dtpFechaLlegada_ValueChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(330, 627);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 22);
            this.btnAceptar.TabIndex = 114;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmBuscarHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(154)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(823, 661);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaIda);
            this.Controls.Add(this.dtpFechaLlegada);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTodasHabs);
            this.Controls.Add(this.labl);
            this.Controls.Add(this.txtNroHabitacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbNroCamas);
            this.Controls.Add(this.cbTipoHabitacion);
            this.Controls.Add(this.dgvHabitaciones);
            this.Controls.Add(this.label7);
            this.MaximumSize = new System.Drawing.Size(841, 708);
            this.MinimumSize = new System.Drawing.Size(841, 708);
            this.Name = "frmBuscarHabitacion";
            this.Text = "Habitaciones - SGH";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTodasHabs;
        private System.Windows.Forms.Label labl;
        private System.Windows.Forms.TextBox txtNroHabitacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbNroCamas;
        private System.Windows.Forms.ComboBox cbTipoHabitacion;
        private System.Windows.Forms.DataGridView dgvHabitaciones;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaIda;
        private System.Windows.Forms.DateTimePicker dtpFechaLlegada;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblFormulario;
    }
}