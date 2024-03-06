namespace Vista.Administrador
{
    partial class frmUsuarioGrupos
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
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.dgvGrupos = new System.Windows.Forms.DataGridView();
            this.lblTotalPedido = new System.Windows.Forms.Label();
            this.dgvGrupoPermisoUsuario = new System.Windows.Forms.DataGridView();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.btnEliminarGrupo = new System.Windows.Forms.Button();
            this.btnAgregarGrupo = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtNombreEmpleado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdComponenteGrupo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.btnTodos = new System.Windows.Forms.Button();
            this.dgvPermisos = new System.Windows.Forms.DataGridView();
            this.btnAgregarPermiso = new System.Windows.Forms.Button();
            this.btnEliminarPermiso = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdComponentePermiso = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdEliminar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupoPermisoUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 12);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.RowTemplate.Height = 24;
            this.dgvUsuarios.Size = new System.Drawing.Size(931, 203);
            this.dgvUsuarios.TabIndex = 133;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            // 
            // dgvGrupos
            // 
            this.dgvGrupos.AllowUserToAddRows = false;
            this.dgvGrupos.AllowUserToDeleteRows = false;
            this.dgvGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupos.Location = new System.Drawing.Point(7, 265);
            this.dgvGrupos.Name = "dgvGrupos";
            this.dgvGrupos.ReadOnly = true;
            this.dgvGrupos.RowHeadersWidth = 51;
            this.dgvGrupos.RowTemplate.Height = 24;
            this.dgvGrupos.Size = new System.Drawing.Size(449, 180);
            this.dgvGrupos.TabIndex = 140;
            this.dgvGrupos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrupos_CellClick);
            // 
            // lblTotalPedido
            // 
            this.lblTotalPedido.AutoSize = true;
            this.lblTotalPedido.Location = new System.Drawing.Point(1534, 301);
            this.lblTotalPedido.Name = "lblTotalPedido";
            this.lblTotalPedido.Size = new System.Drawing.Size(16, 16);
            this.lblTotalPedido.TabIndex = 153;
            this.lblTotalPedido.Text = "...";
            // 
            // dgvGrupoPermisoUsuario
            // 
            this.dgvGrupoPermisoUsuario.AllowUserToAddRows = false;
            this.dgvGrupoPermisoUsuario.AllowUserToDeleteRows = false;
            this.dgvGrupoPermisoUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupoPermisoUsuario.Location = new System.Drawing.Point(981, 265);
            this.dgvGrupoPermisoUsuario.Name = "dgvGrupoPermisoUsuario";
            this.dgvGrupoPermisoUsuario.ReadOnly = true;
            this.dgvGrupoPermisoUsuario.RowHeadersWidth = 51;
            this.dgvGrupoPermisoUsuario.RowTemplate.Height = 24;
            this.dgvGrupoPermisoUsuario.Size = new System.Drawing.Size(449, 180);
            this.dgvGrupoPermisoUsuario.TabIndex = 152;
            this.dgvGrupoPermisoUsuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrupoPermisoUsuario_CellClick);
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(1077, 102);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(160, 22);
            this.txtNombreUsuario.TabIndex = 151;
            this.txtNombreUsuario.TextChanged += new System.EventHandler(this.txtNroHabitacion_TextChanged);
            // 
            // btnEliminarGrupo
            // 
            this.btnEliminarGrupo.Location = new System.Drawing.Point(1000, 200);
            this.btnEliminarGrupo.Name = "btnEliminarGrupo";
            this.btnEliminarGrupo.Size = new System.Drawing.Size(124, 38);
            this.btnEliminarGrupo.TabIndex = 148;
            this.btnEliminarGrupo.Text = "Eliminar Grupo";
            this.btnEliminarGrupo.UseVisualStyleBackColor = true;
            this.btnEliminarGrupo.Click += new System.EventHandler(this.btnEliminarGrupo_Click);
            // 
            // btnAgregarGrupo
            // 
            this.btnAgregarGrupo.Location = new System.Drawing.Point(1000, 161);
            this.btnAgregarGrupo.Name = "btnAgregarGrupo";
            this.btnAgregarGrupo.Size = new System.Drawing.Size(124, 38);
            this.btnAgregarGrupo.TabIndex = 147;
            this.btnAgregarGrupo.Text = "Agregar Grupo";
            this.btnAgregarGrupo.UseVisualStyleBackColor = true;
            this.btnAgregarGrupo.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(1536, 274);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(10, 16);
            this.lblTotal.TabIndex = 149;
            this.lblTotal.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(972, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 16);
            this.label6.TabIndex = 136;
            this.label6.Text = "DNI Empleado:";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(1077, 46);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(160, 22);
            this.txtDNI.TabIndex = 137;
            this.txtDNI.TextChanged += new System.EventHandler(this.txtBuscarDNI_TextChanged);
            // 
            // txtNombreEmpleado
            // 
            this.txtNombreEmpleado.Enabled = false;
            this.txtNombreEmpleado.Location = new System.Drawing.Point(1077, 74);
            this.txtNombreEmpleado.Name = "txtNombreEmpleado";
            this.txtNombreEmpleado.Size = new System.Drawing.Size(160, 22);
            this.txtNombreEmpleado.TabIndex = 138;
            this.txtNombreEmpleado.TextChanged += new System.EventHandler(this.txtNombreCliente_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(946, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 16);
            this.label3.TabIndex = 139;
            this.label3.Text = "Nombre Empleado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 141;
            this.label2.Text = "Id Grupo:";
            // 
            // txtIdComponenteGrupo
            // 
            this.txtIdComponenteGrupo.Location = new System.Drawing.Point(330, 241);
            this.txtIdComponenteGrupo.Name = "txtIdComponenteGrupo";
            this.txtIdComponenteGrupo.Size = new System.Drawing.Size(78, 22);
            this.txtIdComponenteGrupo.TabIndex = 145;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(962, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 16);
            this.label9.TabIndex = 144;
            this.label9.Text = "Nombre Usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(997, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 157;
            this.label4.Text = "ID Usuario:";
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Location = new System.Drawing.Point(1076, 19);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(78, 22);
            this.txtIdUsuario.TabIndex = 158;
            // 
            // btnTodos
            // 
            this.btnTodos.Location = new System.Drawing.Point(12, 241);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(96, 24);
            this.btnTodos.TabIndex = 159;
            this.btnTodos.Text = "Todos";
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // dgvPermisos
            // 
            this.dgvPermisos.AllowUserToAddRows = false;
            this.dgvPermisos.AllowUserToDeleteRows = false;
            this.dgvPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermisos.Location = new System.Drawing.Point(494, 265);
            this.dgvPermisos.Name = "dgvPermisos";
            this.dgvPermisos.ReadOnly = true;
            this.dgvPermisos.RowHeadersWidth = 51;
            this.dgvPermisos.RowTemplate.Height = 24;
            this.dgvPermisos.Size = new System.Drawing.Size(449, 180);
            this.dgvPermisos.TabIndex = 160;
            this.dgvPermisos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPermisos_CellClick);
            // 
            // btnAgregarPermiso
            // 
            this.btnAgregarPermiso.Location = new System.Drawing.Point(1167, 161);
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.Size = new System.Drawing.Size(124, 38);
            this.btnAgregarPermiso.TabIndex = 162;
            this.btnAgregarPermiso.Text = "Agregar Permiso";
            this.btnAgregarPermiso.UseVisualStyleBackColor = true;
            this.btnAgregarPermiso.Click += new System.EventHandler(this.btnAgregarPermiso_Click);
            // 
            // btnEliminarPermiso
            // 
            this.btnEliminarPermiso.Location = new System.Drawing.Point(1167, 200);
            this.btnEliminarPermiso.Name = "btnEliminarPermiso";
            this.btnEliminarPermiso.Size = new System.Drawing.Size(124, 38);
            this.btnEliminarPermiso.TabIndex = 163;
            this.btnEliminarPermiso.Text = "Eliminar Permiso";
            this.btnEliminarPermiso.UseVisualStyleBackColor = true;
            this.btnEliminarPermiso.Click += new System.EventHandler(this.btnEliminarPermiso_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(775, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 164;
            this.label1.Text = "Id Permiso:";
            // 
            // txtIdComponentePermiso
            // 
            this.txtIdComponentePermiso.Location = new System.Drawing.Point(855, 237);
            this.txtIdComponentePermiso.Name = "txtIdComponentePermiso";
            this.txtIdComponentePermiso.Size = new System.Drawing.Size(78, 22);
            this.txtIdComponentePermiso.TabIndex = 165;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1325, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 16);
            this.label5.TabIndex = 166;
            this.label5.Text = "Id:";
            // 
            // txtIdEliminar
            // 
            this.txtIdEliminar.Location = new System.Drawing.Point(1352, 237);
            this.txtIdEliminar.Name = "txtIdEliminar";
            this.txtIdEliminar.Size = new System.Drawing.Size(78, 22);
            this.txtIdEliminar.TabIndex = 167;
            // 
            // frmUsuarioGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(154)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(1473, 457);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIdEliminar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdComponentePermiso);
            this.Controls.Add(this.btnEliminarPermiso);
            this.Controls.Add(this.btnAgregarPermiso);
            this.Controls.Add(this.dgvPermisos);
            this.Controls.Add(this.btnTodos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIdUsuario);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.dgvGrupos);
            this.Controls.Add(this.lblTotalPedido);
            this.Controls.Add(this.dgvGrupoPermisoUsuario);
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.btnEliminarGrupo);
            this.Controls.Add(this.btnAgregarGrupo);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.txtNombreEmpleado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdComponenteGrupo);
            this.Controls.Add(this.label9);
            this.Name = "frmUsuarioGrupos";
            this.Text = "frmUsuarioGrupos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupoPermisoUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.DataGridView dgvGrupos;
        private System.Windows.Forms.Label lblTotalPedido;
        private System.Windows.Forms.DataGridView dgvGrupoPermisoUsuario;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Button btnEliminarGrupo;
        private System.Windows.Forms.Button btnAgregarGrupo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtNombreEmpleado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdComponenteGrupo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdUsuario;
        private System.Windows.Forms.Button btnTodos;
        private System.Windows.Forms.DataGridView dgvPermisos;
        private System.Windows.Forms.Button btnAgregarPermiso;
        private System.Windows.Forms.Button btnEliminarPermiso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdComponentePermiso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdEliminar;
    }
}