namespace Vista.Paneles
{
    partial class frmHabitaciones
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
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHabitaciones = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtIdHabitacion = new System.Windows.Forms.TextBox();
            this.txtPrecioDiario = new System.Windows.Forms.TextBox();
            this.cbPiso = new System.Windows.Forms.ComboBox();
            this.cbTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.cbNroCamas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rbDisponible = new System.Windows.Forms.RadioButton();
            this.flpEstado = new System.Windows.Forms.FlowLayoutPanel();
            this.rbOcupado = new System.Windows.Forms.RadioButton();
            this.rbLimpieza = new System.Windows.Forms.RadioButton();
            this.cbNumHabitacion = new System.Windows.Forms.ComboBox();
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).BeginInit();
            this.flpEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1175, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 39;
            this.label9.Text = "Precio Diario:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1157, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "Tipo Habitacion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1166, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "Nro Habitacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1226, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Piso:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1240, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "ID:";
            // 
            // dgvHabitaciones
            // 
            this.dgvHabitaciones.AllowUserToAddRows = false;
            this.dgvHabitaciones.AllowUserToDeleteRows = false;
            this.dgvHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitaciones.Location = new System.Drawing.Point(92, 43);
            this.dgvHabitaciones.Name = "dgvHabitaciones";
            this.dgvHabitaciones.ReadOnly = true;
            this.dgvHabitaciones.RowHeadersWidth = 51;
            this.dgvHabitaciones.RowTemplate.Height = 24;
            this.dgvHabitaciones.Size = new System.Drawing.Size(988, 409);
            this.dgvHabitaciones.TabIndex = 31;
            this.dgvHabitaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHabitaciones_CellClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(1409, 422);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(102, 49);
            this.btnEliminar.TabIndex = 30;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(1164, 422);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(102, 49);
            this.btnModificar.TabIndex = 29;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(1289, 422);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(102, 49);
            this.btnAgregar.TabIndex = 28;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtIdHabitacion
            // 
            this.txtIdHabitacion.Location = new System.Drawing.Point(1287, 48);
            this.txtIdHabitacion.Name = "txtIdHabitacion";
            this.txtIdHabitacion.ReadOnly = true;
            this.txtIdHabitacion.Size = new System.Drawing.Size(121, 22);
            this.txtIdHabitacion.TabIndex = 27;
            // 
            // txtPrecioDiario
            // 
            this.txtPrecioDiario.Location = new System.Drawing.Point(1287, 170);
            this.txtPrecioDiario.Name = "txtPrecioDiario";
            this.txtPrecioDiario.ReadOnly = true;
            this.txtPrecioDiario.Size = new System.Drawing.Size(121, 22);
            this.txtPrecioDiario.TabIndex = 22;
            // 
            // cbPiso
            // 
            this.cbPiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPiso.FormattingEnabled = true;
            this.cbPiso.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cbPiso.Location = new System.Drawing.Point(1287, 86);
            this.cbPiso.Name = "cbPiso";
            this.cbPiso.Size = new System.Drawing.Size(121, 24);
            this.cbPiso.TabIndex = 40;
            // 
            // cbTipoHabitacion
            // 
            this.cbTipoHabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoHabitacion.FormattingEnabled = true;
            this.cbTipoHabitacion.Items.AddRange(new object[] {
            "Basica",
            "Medium",
            "Premium",
            "Suit"});
            this.cbTipoHabitacion.Location = new System.Drawing.Point(1287, 202);
            this.cbTipoHabitacion.Name = "cbTipoHabitacion";
            this.cbTipoHabitacion.Size = new System.Drawing.Size(121, 24);
            this.cbTipoHabitacion.TabIndex = 42;
            this.cbTipoHabitacion.SelectedIndexChanged += new System.EventHandler(this.cbTipoHabitacion_SelectedIndexChanged);
            // 
            // cbNroCamas
            // 
            this.cbNroCamas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNroCamas.FormattingEnabled = true;
            this.cbNroCamas.Items.AddRange(new object[] {
            "1-Simple",
            "2-Simple",
            "1-Matrimonial",
            "2-Matrimoniales"});
            this.cbNroCamas.Location = new System.Drawing.Point(1287, 236);
            this.cbNroCamas.Name = "cbNroCamas";
            this.cbNroCamas.Size = new System.Drawing.Size(121, 24);
            this.cbNroCamas.TabIndex = 43;
            this.cbNroCamas.SelectedIndexChanged += new System.EventHandler(this.cbNroCamas_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1185, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 44;
            this.label4.Text = "Nro Camas:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1210, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 45;
            this.label6.Text = "Estado:";
            // 
            // rbDisponible
            // 
            this.rbDisponible.AutoSize = true;
            this.rbDisponible.Location = new System.Drawing.Point(3, 3);
            this.rbDisponible.Name = "rbDisponible";
            this.rbDisponible.Size = new System.Drawing.Size(93, 20);
            this.rbDisponible.TabIndex = 46;
            this.rbDisponible.TabStop = true;
            this.rbDisponible.Text = "Disponible";
            this.rbDisponible.UseVisualStyleBackColor = true;
            // 
            // flpEstado
            // 
            this.flpEstado.Controls.Add(this.rbDisponible);
            this.flpEstado.Controls.Add(this.rbOcupado);
            this.flpEstado.Controls.Add(this.rbLimpieza);
            this.flpEstado.Location = new System.Drawing.Point(1287, 283);
            this.flpEstado.Name = "flpEstado";
            this.flpEstado.Size = new System.Drawing.Size(116, 88);
            this.flpEstado.TabIndex = 47;
            // 
            // rbOcupado
            // 
            this.rbOcupado.AutoSize = true;
            this.rbOcupado.Location = new System.Drawing.Point(3, 29);
            this.rbOcupado.Name = "rbOcupado";
            this.rbOcupado.Size = new System.Drawing.Size(84, 20);
            this.rbOcupado.TabIndex = 47;
            this.rbOcupado.TabStop = true;
            this.rbOcupado.Text = "Ocupado";
            this.rbOcupado.UseVisualStyleBackColor = true;
            // 
            // rbLimpieza
            // 
            this.rbLimpieza.AutoSize = true;
            this.rbLimpieza.Location = new System.Drawing.Point(3, 55);
            this.rbLimpieza.Name = "rbLimpieza";
            this.rbLimpieza.Size = new System.Drawing.Size(82, 20);
            this.rbLimpieza.TabIndex = 48;
            this.rbLimpieza.TabStop = true;
            this.rbLimpieza.Text = "Limpieza";
            this.rbLimpieza.UseVisualStyleBackColor = true;
            // 
            // cbNumHabitacion
            // 
            this.cbNumHabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNumHabitacion.FormattingEnabled = true;
            this.cbNumHabitacion.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cbNumHabitacion.Location = new System.Drawing.Point(1287, 129);
            this.cbNumHabitacion.Name = "cbNumHabitacion";
            this.cbNumHabitacion.Size = new System.Drawing.Size(121, 24);
            this.cbNumHabitacion.TabIndex = 48;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(1157, 394);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 16);
            this.lblError.TabIndex = 49;
            // 
            // frmHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1595, 495);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.cbNumHabitacion);
            this.Controls.Add(this.flpEstado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbNroCamas);
            this.Controls.Add(this.cbTipoHabitacion);
            this.Controls.Add(this.cbPiso);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHabitaciones);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtIdHabitacion);
            this.Controls.Add(this.txtPrecioDiario);
            this.Name = "frmHabitaciones";
            this.Text = "frmHabitaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).EndInit();
            this.flpEstado.ResumeLayout(false);
            this.flpEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHabitaciones;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtIdHabitacion;
        private System.Windows.Forms.TextBox txtPrecioDiario;
        private System.Windows.Forms.ComboBox cbPiso;
        private System.Windows.Forms.ComboBox cbTipoHabitacion;
        private System.Windows.Forms.ComboBox cbNroCamas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbDisponible;
        private System.Windows.Forms.FlowLayoutPanel flpEstado;
        private System.Windows.Forms.RadioButton rbOcupado;
        private System.Windows.Forms.RadioButton rbLimpieza;
        private System.Windows.Forms.ComboBox cbNumHabitacion;
        private System.Windows.Forms.Label lblError;
    }
}