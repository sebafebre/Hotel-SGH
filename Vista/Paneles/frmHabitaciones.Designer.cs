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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.dgvHabitaciones = new System.Windows.Forms.DataGridView();
            this.flpEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(763, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 39;
            this.label9.Text = "Precio Diario:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(745, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "Tipo Habitacion:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(754, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "Nro Habitacion";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(814, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Piso:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(828, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "ID:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Location = new System.Drawing.Point(995, 418);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(102, 49);
            this.btnEliminar.TabIndex = 30;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.Location = new System.Drawing.Point(750, 418);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(102, 49);
            this.btnModificar.TabIndex = 29;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Location = new System.Drawing.Point(875, 418);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(102, 49);
            this.btnAgregar.TabIndex = 28;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtIdHabitacion
            // 
            this.txtIdHabitacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdHabitacion.Location = new System.Drawing.Point(875, 53);
            this.txtIdHabitacion.Name = "txtIdHabitacion";
            this.txtIdHabitacion.ReadOnly = true;
            this.txtIdHabitacion.Size = new System.Drawing.Size(121, 22);
            this.txtIdHabitacion.TabIndex = 27;
            // 
            // txtPrecioDiario
            // 
            this.txtPrecioDiario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrecioDiario.Location = new System.Drawing.Point(875, 175);
            this.txtPrecioDiario.Name = "txtPrecioDiario";
            this.txtPrecioDiario.ReadOnly = true;
            this.txtPrecioDiario.Size = new System.Drawing.Size(121, 22);
            this.txtPrecioDiario.TabIndex = 22;
            // 
            // cbPiso
            // 
            this.cbPiso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPiso.FormattingEnabled = true;
            this.cbPiso.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cbPiso.Location = new System.Drawing.Point(875, 91);
            this.cbPiso.Name = "cbPiso";
            this.cbPiso.Size = new System.Drawing.Size(121, 24);
            this.cbPiso.TabIndex = 40;
            // 
            // cbTipoHabitacion
            // 
            this.cbTipoHabitacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTipoHabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoHabitacion.FormattingEnabled = true;
            this.cbTipoHabitacion.Items.AddRange(new object[] {
            "Basica",
            "Medium",
            "Premium",
            "Suit"});
            this.cbTipoHabitacion.Location = new System.Drawing.Point(875, 207);
            this.cbTipoHabitacion.Name = "cbTipoHabitacion";
            this.cbTipoHabitacion.Size = new System.Drawing.Size(121, 24);
            this.cbTipoHabitacion.TabIndex = 42;
            this.cbTipoHabitacion.SelectedIndexChanged += new System.EventHandler(this.cbTipoHabitacion_SelectedIndexChanged);
            // 
            // cbNroCamas
            // 
            this.cbNroCamas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbNroCamas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNroCamas.FormattingEnabled = true;
            this.cbNroCamas.Items.AddRange(new object[] {
            "1-Simple",
            "2-Simple",
            "1-Matrimonial",
            "2-Matrimoniales"});
            this.cbNroCamas.Location = new System.Drawing.Point(875, 241);
            this.cbNroCamas.Name = "cbNroCamas";
            this.cbNroCamas.Size = new System.Drawing.Size(121, 24);
            this.cbNroCamas.TabIndex = 43;
            this.cbNroCamas.SelectedIndexChanged += new System.EventHandler(this.cbNroCamas_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(773, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 44;
            this.label4.Text = "Nro Camas:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(798, 288);
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
            this.flpEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flpEstado.Controls.Add(this.rbDisponible);
            this.flpEstado.Controls.Add(this.rbOcupado);
            this.flpEstado.Controls.Add(this.rbLimpieza);
            this.flpEstado.Location = new System.Drawing.Point(875, 288);
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
            this.cbNumHabitacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.cbNumHabitacion.Location = new System.Drawing.Point(875, 134);
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
            // dgvHabitaciones
            // 
            this.dgvHabitaciones.AllowUserToAddRows = false;
            this.dgvHabitaciones.AllowUserToDeleteRows = false;
            this.dgvHabitaciones.AllowUserToResizeColumns = false;
            this.dgvHabitaciones.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(135)))), ((int)(((byte)(88)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(205)))));
            this.dgvHabitaciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHabitaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHabitaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHabitaciones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(154)))), ((int)(((byte)(153)))));
            this.dgvHabitaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHabitaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvHabitaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(152)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(135)))), ((int)(((byte)(88)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHabitaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(242)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(135)))), ((int)(((byte)(88)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(152)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHabitaciones.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHabitaciones.EnableHeadersVisualStyles = false;
            this.dgvHabitaciones.Location = new System.Drawing.Point(12, 12);
            this.dgvHabitaciones.Name = "dgvHabitaciones";
            this.dgvHabitaciones.ReadOnly = true;
            this.dgvHabitaciones.RowHeadersVisible = false;
            this.dgvHabitaciones.RowHeadersWidth = 51;
            this.dgvHabitaciones.RowTemplate.Height = 24;
            this.dgvHabitaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHabitaciones.Size = new System.Drawing.Size(703, 455);
            this.dgvHabitaciones.TabIndex = 50;
            this.dgvHabitaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHabitaciones_CellClick_1);
            // 
            // frmHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(154)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(1110, 491);
            this.Controls.Add(this.dgvHabitaciones);
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
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtIdHabitacion);
            this.Controls.Add(this.txtPrecioDiario);
            this.Name = "frmHabitaciones";
            this.Text = "frmHabitaciones";
            this.flpEstado.ResumeLayout(false);
            this.flpEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.DataGridView dgvHabitaciones;
    }
}