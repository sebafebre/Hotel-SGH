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
            this.label11 = new System.Windows.Forms.Label();
            this.txtIdHabitacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbNroCamas = new System.Windows.Forms.ComboBox();
            this.cbTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.dgvHabitaciones = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTodasHabs
            // 
            this.btnTodasHabs.Location = new System.Drawing.Point(412, 156);
            this.btnTodasHabs.Name = "btnTodasHabs";
            this.btnTodasHabs.Size = new System.Drawing.Size(84, 24);
            this.btnTodasHabs.TabIndex = 101;
            this.btnTodasHabs.Text = "Ver todas";
            this.btnTodasHabs.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(327, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 16);
            this.label11.TabIndex = 100;
            this.label11.Text = "ID Habitacion:";
            // 
            // txtIdHabitacion
            // 
            this.txtIdHabitacion.Location = new System.Drawing.Point(330, 157);
            this.txtIdHabitacion.Name = "txtIdHabitacion";
            this.txtIdHabitacion.ReadOnly = true;
            this.txtIdHabitacion.Size = new System.Drawing.Size(65, 22);
            this.txtIdHabitacion.TabIndex = 99;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 133);
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
            // 
            // dgvHabitaciones
            // 
            this.dgvHabitaciones.AllowUserToAddRows = false;
            this.dgvHabitaciones.AllowUserToDeleteRows = false;
            this.dgvHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitaciones.Location = new System.Drawing.Point(12, 185);
            this.dgvHabitaciones.Name = "dgvHabitaciones";
            this.dgvHabitaciones.ReadOnly = true;
            this.dgvHabitaciones.RowHeadersWidth = 51;
            this.dgvHabitaciones.RowTemplate.Height = 24;
            this.dgvHabitaciones.Size = new System.Drawing.Size(763, 314);
            this.dgvHabitaciones.TabIndex = 95;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 16);
            this.label7.TabIndex = 94;
            this.label7.Text = "Tipo Habitacion:";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1533, 72);
            this.panel1.TabIndex = 102;
            // 
            // frmBuscarHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(154)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(1533, 520);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTodasHabs);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtIdHabitacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbNroCamas);
            this.Controls.Add(this.cbTipoHabitacion);
            this.Controls.Add(this.dgvHabitaciones);
            this.Controls.Add(this.label7);
            this.Name = "frmBuscarHabitacion";
            this.Text = "frmBuscarHabitacion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTodasHabs;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtIdHabitacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbNroCamas;
        private System.Windows.Forms.ComboBox cbTipoHabitacion;
        private System.Windows.Forms.DataGridView dgvHabitaciones;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
    }
}