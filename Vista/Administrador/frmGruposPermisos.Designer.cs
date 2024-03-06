namespace Vista.Administrador
{
    partial class frmGruposPermisos
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
            this.btnModificarGrupo = new System.Windows.Forms.Button();
            this.btnModificarPermiso = new System.Windows.Forms.Button();
            this.btnEliminarGrupo = new System.Windows.Forms.Button();
            this.txtNombrePermiso = new System.Windows.Forms.TextBox();
            this.btnTodos = new System.Windows.Forms.Button();
            this.btnEliminarPermiso = new System.Windows.Forms.Button();
            this.txtNombreGrupo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdPermiso = new System.Windows.Forms.TextBox();
            this.dgvPermisos = new System.Windows.Forms.DataGridView();
            this.dgvGrupos = new System.Windows.Forms.DataGridView();
            this.btnAgregarGrupo = new System.Windows.Forms.Button();
            this.btnAgregarPermiso = new System.Windows.Forms.Button();
            this.txtIdGrupo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAgregarPermisoAGrupo = new System.Windows.Forms.Button();
            this.btnQuitarPermisoAGrupo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModificarGrupo
            // 
            this.btnModificarGrupo.Location = new System.Drawing.Point(462, 227);
            this.btnModificarGrupo.Name = "btnModificarGrupo";
            this.btnModificarGrupo.Size = new System.Drawing.Size(124, 37);
            this.btnModificarGrupo.TabIndex = 181;
            this.btnModificarGrupo.Text = "Modificar Grupo";
            this.btnModificarGrupo.UseVisualStyleBackColor = true;
            this.btnModificarGrupo.Click += new System.EventHandler(this.btnModificarGrupo_Click);
            // 
            // btnModificarPermiso
            // 
            this.btnModificarPermiso.Location = new System.Drawing.Point(1079, 290);
            this.btnModificarPermiso.Name = "btnModificarPermiso";
            this.btnModificarPermiso.Size = new System.Drawing.Size(124, 38);
            this.btnModificarPermiso.TabIndex = 180;
            this.btnModificarPermiso.Text = "Modificar Permiso";
            this.btnModificarPermiso.UseVisualStyleBackColor = true;
            this.btnModificarPermiso.Click += new System.EventHandler(this.btnModificarPermiso_Click);
            // 
            // btnEliminarGrupo
            // 
            this.btnEliminarGrupo.Location = new System.Drawing.Point(462, 269);
            this.btnEliminarGrupo.Name = "btnEliminarGrupo";
            this.btnEliminarGrupo.Size = new System.Drawing.Size(124, 37);
            this.btnEliminarGrupo.TabIndex = 179;
            this.btnEliminarGrupo.Text = "Eliminar Grupo";
            this.btnEliminarGrupo.UseVisualStyleBackColor = true;
            this.btnEliminarGrupo.Click += new System.EventHandler(this.btnEliminarGrupo_Click);
            // 
            // txtNombrePermiso
            // 
            this.txtNombrePermiso.Location = new System.Drawing.Point(1064, 137);
            this.txtNombrePermiso.Name = "txtNombrePermiso";
            this.txtNombrePermiso.Size = new System.Drawing.Size(160, 22);
            this.txtNombrePermiso.TabIndex = 170;
            // 
            // btnTodos
            // 
            this.btnTodos.Location = new System.Drawing.Point(1079, 185);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(124, 26);
            this.btnTodos.TabIndex = 173;
            this.btnTodos.Text = "Mostrar Todos";
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // btnEliminarPermiso
            // 
            this.btnEliminarPermiso.Location = new System.Drawing.Point(1079, 330);
            this.btnEliminarPermiso.Name = "btnEliminarPermiso";
            this.btnEliminarPermiso.Size = new System.Drawing.Size(124, 38);
            this.btnEliminarPermiso.TabIndex = 171;
            this.btnEliminarPermiso.Text = "Eliminar Permiso";
            this.btnEliminarPermiso.UseVisualStyleBackColor = true;
            this.btnEliminarPermiso.Click += new System.EventHandler(this.btnEliminarPermiso_Click);
            // 
            // txtNombreGrupo
            // 
            this.txtNombreGrupo.Location = new System.Drawing.Point(462, 136);
            this.txtNombreGrupo.Name = "txtNombreGrupo";
            this.txtNombreGrupo.Size = new System.Drawing.Size(160, 22);
            this.txtNombreGrupo.TabIndex = 163;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 164;
            this.label3.Text = "Nombre Grupo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1061, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 165;
            this.label2.Text = "Id Permiso:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1061, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 166;
            this.label5.Text = "Nombre Permiso:";
            // 
            // txtIdPermiso
            // 
            this.txtIdPermiso.Enabled = false;
            this.txtIdPermiso.Location = new System.Drawing.Point(1064, 80);
            this.txtIdPermiso.Name = "txtIdPermiso";
            this.txtIdPermiso.Size = new System.Drawing.Size(160, 22);
            this.txtIdPermiso.TabIndex = 169;
            // 
            // dgvPermisos
            // 
            this.dgvPermisos.AllowUserToAddRows = false;
            this.dgvPermisos.AllowUserToDeleteRows = false;
            this.dgvPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermisos.Location = new System.Drawing.Point(628, 12);
            this.dgvPermisos.Name = "dgvPermisos";
            this.dgvPermisos.ReadOnly = true;
            this.dgvPermisos.RowHeadersWidth = 51;
            this.dgvPermisos.RowTemplate.Height = 24;
            this.dgvPermisos.Size = new System.Drawing.Size(394, 385);
            this.dgvPermisos.TabIndex = 158;
            this.dgvPermisos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPermisos_CellClick);
            // 
            // dgvGrupos
            // 
            this.dgvGrupos.AllowUserToAddRows = false;
            this.dgvGrupos.AllowUserToDeleteRows = false;
            this.dgvGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupos.Location = new System.Drawing.Point(7, 12);
            this.dgvGrupos.Name = "dgvGrupos";
            this.dgvGrupos.ReadOnly = true;
            this.dgvGrupos.RowHeadersWidth = 51;
            this.dgvGrupos.RowTemplate.Height = 24;
            this.dgvGrupos.Size = new System.Drawing.Size(425, 385);
            this.dgvGrupos.TabIndex = 157;
            this.dgvGrupos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrupos_CellClick);
            // 
            // btnAgregarGrupo
            // 
            this.btnAgregarGrupo.Location = new System.Drawing.Point(462, 185);
            this.btnAgregarGrupo.Name = "btnAgregarGrupo";
            this.btnAgregarGrupo.Size = new System.Drawing.Size(124, 37);
            this.btnAgregarGrupo.TabIndex = 182;
            this.btnAgregarGrupo.Text = "Agregar Grupo";
            this.btnAgregarGrupo.UseVisualStyleBackColor = true;
            this.btnAgregarGrupo.Click += new System.EventHandler(this.btnAgregarGrupo_Click);
            // 
            // btnAgregarPermiso
            // 
            this.btnAgregarPermiso.Location = new System.Drawing.Point(1079, 246);
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.Size = new System.Drawing.Size(124, 38);
            this.btnAgregarPermiso.TabIndex = 183;
            this.btnAgregarPermiso.Text = "Agregar Permiso";
            this.btnAgregarPermiso.UseVisualStyleBackColor = true;
            this.btnAgregarPermiso.Click += new System.EventHandler(this.btnAgregarPermiso_Click);
            // 
            // txtIdGrupo
            // 
            this.txtIdGrupo.Enabled = false;
            this.txtIdGrupo.Location = new System.Drawing.Point(462, 79);
            this.txtIdGrupo.Name = "txtIdGrupo";
            this.txtIdGrupo.Size = new System.Drawing.Size(160, 22);
            this.txtIdGrupo.TabIndex = 186;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(459, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 187;
            this.label4.Text = "Id Grupo:";
            // 
            // btnAgregarPermisoAGrupo
            // 
            this.btnAgregarPermisoAGrupo.Location = new System.Drawing.Point(616, 407);
            this.btnAgregarPermisoAGrupo.Name = "btnAgregarPermisoAGrupo";
            this.btnAgregarPermisoAGrupo.Size = new System.Drawing.Size(178, 38);
            this.btnAgregarPermisoAGrupo.TabIndex = 188;
            this.btnAgregarPermisoAGrupo.Text = "Agregar Permiso A Grupo";
            this.btnAgregarPermisoAGrupo.UseVisualStyleBackColor = true;
            this.btnAgregarPermisoAGrupo.Click += new System.EventHandler(this.btnAgregarPermisoAGrupo_Click);
            // 
            // btnQuitarPermisoAGrupo
            // 
            this.btnQuitarPermisoAGrupo.Location = new System.Drawing.Point(844, 407);
            this.btnQuitarPermisoAGrupo.Name = "btnQuitarPermisoAGrupo";
            this.btnQuitarPermisoAGrupo.Size = new System.Drawing.Size(178, 38);
            this.btnQuitarPermisoAGrupo.TabIndex = 189;
            this.btnQuitarPermisoAGrupo.Text = "Quitar Permiso A Grupo";
            this.btnQuitarPermisoAGrupo.UseVisualStyleBackColor = true;
            this.btnQuitarPermisoAGrupo.Click += new System.EventHandler(this.btnQuitarPermisoAGrupo_Click);
            // 
            // frmGruposPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(154)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(1473, 457);
            this.Controls.Add(this.btnQuitarPermisoAGrupo);
            this.Controls.Add(this.btnAgregarPermisoAGrupo);
            this.Controls.Add(this.txtIdGrupo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAgregarPermiso);
            this.Controls.Add(this.btnAgregarGrupo);
            this.Controls.Add(this.btnModificarGrupo);
            this.Controls.Add(this.btnModificarPermiso);
            this.Controls.Add(this.btnEliminarGrupo);
            this.Controls.Add(this.txtNombrePermiso);
            this.Controls.Add(this.btnTodos);
            this.Controls.Add(this.btnEliminarPermiso);
            this.Controls.Add(this.txtNombreGrupo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIdPermiso);
            this.Controls.Add(this.dgvPermisos);
            this.Controls.Add(this.dgvGrupos);
            this.Name = "frmGruposPermisos";
            this.Text = "frmGruposPermisos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModificarGrupo;
        private System.Windows.Forms.Button btnModificarPermiso;
        private System.Windows.Forms.Button btnEliminarGrupo;
        private System.Windows.Forms.TextBox txtNombrePermiso;
        private System.Windows.Forms.Button btnTodos;
        private System.Windows.Forms.Button btnEliminarPermiso;
        private System.Windows.Forms.TextBox txtNombreGrupo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdPermiso;
        private System.Windows.Forms.DataGridView dgvPermisos;
        private System.Windows.Forms.DataGridView dgvGrupos;
        private System.Windows.Forms.Button btnAgregarGrupo;
        private System.Windows.Forms.Button btnAgregarPermiso;
        private System.Windows.Forms.TextBox txtIdGrupo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAgregarPermisoAGrupo;
        private System.Windows.Forms.Button btnQuitarPermisoAGrupo;
    }
}