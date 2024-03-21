namespace Vista.Administrador
{
    partial class frmAdministrador
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
            this.panelPedidos = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.btnAuditoria = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnGruposPermisos = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnGruposUsuario = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPedidos
            // 
            this.panelPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(154)))), ((int)(((byte)(141)))));
            this.panelPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPedidos.Location = new System.Drawing.Point(0, 98);
            this.panelPedidos.Name = "panelPedidos";
            this.panelPedidos.Size = new System.Drawing.Size(1132, 489);
            this.panelPedidos.TabIndex = 136;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(154)))), ((int)(((byte)(153)))));
            this.panel1.Controls.Add(this.btnReportes);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnAuditoria);
            this.panel1.Controls.Add(this.btnEmpleados);
            this.panel1.Controls.Add(this.btnGruposPermisos);
            this.panel1.Controls.Add(this.btnUsuarios);
            this.panel1.Controls.Add(this.btnGruposUsuario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 98);
            this.panel1.TabIndex = 135;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblFormulario);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1538, 59);
            this.panel2.TabIndex = 125;
            // 
            // lblFormulario
            // 
            this.lblFormulario.AutoSize = true;
            this.lblFormulario.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormulario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFormulario.Location = new System.Drawing.Point(12, 9);
            this.lblFormulario.Name = "lblFormulario";
            this.lblFormulario.Size = new System.Drawing.Size(133, 38);
            this.lblFormulario.TabIndex = 5;
            this.lblFormulario.Text = "SubMenu";
            // 
            // btnAuditoria
            // 
            this.btnAuditoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuditoria.FlatAppearance.BorderSize = 0;
            this.btnAuditoria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(92)))), ((int)(((byte)(75)))));
            this.btnAuditoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAuditoria.Location = new System.Drawing.Point(898, 62);
            this.btnAuditoria.Name = "btnAuditoria";
            this.btnAuditoria.Size = new System.Drawing.Size(107, 33);
            this.btnAuditoria.TabIndex = 124;
            this.btnAuditoria.Text = "Auditoria";
            this.btnAuditoria.UseVisualStyleBackColor = true;
            this.btnAuditoria.Click += new System.EventHandler(this.btnAuditoria_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(92)))), ((int)(((byte)(75)))));
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReportes.Location = new System.Drawing.Point(1011, 62);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(107, 33);
            this.btnReportes.TabIndex = 123;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEmpleados.FlatAppearance.BorderSize = 0;
            this.btnEmpleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(92)))), ((int)(((byte)(75)))));
            this.btnEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleados.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEmpleados.Location = new System.Drawing.Point(9, 62);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(164, 33);
            this.btnEmpleados.TabIndex = 121;
            this.btnEmpleados.Text = "Registrar Empleados";
            this.btnEmpleados.UseVisualStyleBackColor = true;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnGruposPermisos
            // 
            this.btnGruposPermisos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGruposPermisos.FlatAppearance.BorderSize = 0;
            this.btnGruposPermisos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(92)))), ((int)(((byte)(75)))));
            this.btnGruposPermisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGruposPermisos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGruposPermisos.Location = new System.Drawing.Point(607, 62);
            this.btnGruposPermisos.Name = "btnGruposPermisos";
            this.btnGruposPermisos.Size = new System.Drawing.Size(221, 33);
            this.btnGruposPermisos.TabIndex = 120;
            this.btnGruposPermisos.Text = "Gestionar Grupos y Permisos";
            this.btnGruposPermisos.UseVisualStyleBackColor = true;
            this.btnGruposPermisos.Click += new System.EventHandler(this.btnGruposPermisos_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(154)))), ((int)(((byte)(153)))));
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(92)))), ((int)(((byte)(75)))));
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUsuarios.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUsuarios.Location = new System.Drawing.Point(192, 62);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(149, 33);
            this.btnUsuarios.TabIndex = 118;
            this.btnUsuarios.Text = "Gestionar Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnGruposUsuario
            // 
            this.btnGruposUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGruposUsuario.FlatAppearance.BorderSize = 0;
            this.btnGruposUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(92)))), ((int)(((byte)(75)))));
            this.btnGruposUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGruposUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGruposUsuario.Location = new System.Drawing.Point(360, 62);
            this.btnGruposUsuario.Name = "btnGruposUsuario";
            this.btnGruposUsuario.Size = new System.Drawing.Size(228, 33);
            this.btnGruposUsuario.TabIndex = 119;
            this.btnGruposUsuario.Text = "Gestionar Grupos del usuario";
            this.btnGruposUsuario.UseVisualStyleBackColor = true;
            this.btnGruposUsuario.Click += new System.EventHandler(this.btnGruposUsuario_Click);
            // 
            // frmAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1132, 587);
            this.Controls.Add(this.panelPedidos);
            this.Controls.Add(this.panel1);
            this.Name = "frmAdministrador";
            this.Text = "frmAdministrador";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPedidos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnGruposUsuario;
        private System.Windows.Forms.Button btnGruposPermisos;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnAuditoria;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFormulario;
    }
}