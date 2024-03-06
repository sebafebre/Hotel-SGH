﻿namespace Vista.Administrador
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
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnBackups = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnGruposPermisos = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnGruposUsuario = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPedidos
            // 
            this.panelPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(154)))), ((int)(((byte)(141)))));
            this.panelPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPedidos.Location = new System.Drawing.Point(0, 34);
            this.panelPedidos.Name = "panelPedidos";
            this.panelPedidos.Size = new System.Drawing.Size(1538, 479);
            this.panelPedidos.TabIndex = 136;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.btnReportes);
            this.panel1.Controls.Add(this.btnBackups);
            this.panel1.Controls.Add(this.btnEmpleados);
            this.panel1.Controls.Add(this.btnGruposPermisos);
            this.panel1.Controls.Add(this.btnUsuarios);
            this.panel1.Controls.Add(this.btnGruposUsuario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1538, 34);
            this.panel1.TabIndex = 135;
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(1383, 3);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(107, 26);
            this.btnReportes.TabIndex = 123;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnBackups
            // 
            this.btnBackups.Location = new System.Drawing.Point(1270, 3);
            this.btnBackups.Name = "btnBackups";
            this.btnBackups.Size = new System.Drawing.Size(107, 26);
            this.btnBackups.TabIndex = 122;
            this.btnBackups.Text = "Backups";
            this.btnBackups.UseVisualStyleBackColor = true;
            this.btnBackups.Click += new System.EventHandler(this.btnBackups_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.Location = new System.Drawing.Point(14, 3);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(239, 26);
            this.btnEmpleados.TabIndex = 121;
            this.btnEmpleados.Text = "Registrar Empleados";
            this.btnEmpleados.UseVisualStyleBackColor = true;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnGruposPermisos
            // 
            this.btnGruposPermisos.Location = new System.Drawing.Point(750, 3);
            this.btnGruposPermisos.Name = "btnGruposPermisos";
            this.btnGruposPermisos.Size = new System.Drawing.Size(239, 26);
            this.btnGruposPermisos.TabIndex = 120;
            this.btnGruposPermisos.Text = "Gestionar Grupos y Permisos";
            this.btnGruposPermisos.UseVisualStyleBackColor = true;
            this.btnGruposPermisos.Click += new System.EventHandler(this.btnGruposPermisos_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(260, 3);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(239, 26);
            this.btnUsuarios.TabIndex = 118;
            this.btnUsuarios.Text = "Gestionar Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnGruposUsuario
            // 
            this.btnGruposUsuario.Location = new System.Drawing.Point(505, 3);
            this.btnGruposUsuario.Name = "btnGruposUsuario";
            this.btnGruposUsuario.Size = new System.Drawing.Size(239, 26);
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
            this.ClientSize = new System.Drawing.Size(1538, 513);
            this.Controls.Add(this.panelPedidos);
            this.Controls.Add(this.panel1);
            this.Name = "frmAdministrador";
            this.Text = "frmAdministrador";
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnBackups;
    }
}