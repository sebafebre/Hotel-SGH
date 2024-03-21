namespace Vista.Paneles
{
    partial class frmPedidos
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
            this.btnModificarPedidos = new System.Windows.Forms.Button();
            this.btnAgregarProductoStock = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.btnAgregarPedido = new System.Windows.Forms.Button();
            this.panelPedidos = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModificarPedidos
            // 
            this.btnModificarPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarPedidos.FlatAppearance.BorderSize = 0;
            this.btnModificarPedidos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(92)))), ((int)(((byte)(75)))));
            this.btnModificarPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarPedidos.Location = new System.Drawing.Point(1169, 21);
            this.btnModificarPedidos.Name = "btnModificarPedidos";
            this.btnModificarPedidos.Size = new System.Drawing.Size(161, 26);
            this.btnModificarPedidos.TabIndex = 118;
            this.btnModificarPedidos.Text = "Modificar Pedidos";
            this.btnModificarPedidos.UseVisualStyleBackColor = true;
            this.btnModificarPedidos.Click += new System.EventHandler(this.btnModificarPedidos_Click);
            // 
            // btnAgregarProductoStock
            // 
            this.btnAgregarProductoStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarProductoStock.FlatAppearance.BorderSize = 0;
            this.btnAgregarProductoStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(92)))), ((int)(((byte)(75)))));
            this.btnAgregarProductoStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProductoStock.Location = new System.Drawing.Point(1342, 21);
            this.btnAgregarProductoStock.Name = "btnAgregarProductoStock";
            this.btnAgregarProductoStock.Size = new System.Drawing.Size(161, 26);
            this.btnAgregarProductoStock.TabIndex = 119;
            this.btnAgregarProductoStock.Text = "Stock de Productos";
            this.btnAgregarProductoStock.UseVisualStyleBackColor = true;
            this.btnAgregarProductoStock.Click += new System.EventHandler(this.btnAgregarProductoStock_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(154)))), ((int)(((byte)(153)))));
            this.panel1.Controls.Add(this.lblFormulario);
            this.panel1.Controls.Add(this.btnAgregarPedido);
            this.panel1.Controls.Add(this.btnModificarPedidos);
            this.panel1.Controls.Add(this.btnAgregarProductoStock);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1538, 58);
            this.panel1.TabIndex = 133;
            // 
            // lblFormulario
            // 
            this.lblFormulario.AutoSize = true;
            this.lblFormulario.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormulario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFormulario.Location = new System.Drawing.Point(24, 9);
            this.lblFormulario.Name = "lblFormulario";
            this.lblFormulario.Size = new System.Drawing.Size(133, 38);
            this.lblFormulario.TabIndex = 122;
            this.lblFormulario.Text = "SubMenu";
            // 
            // btnAgregarPedido
            // 
            this.btnAgregarPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarPedido.FlatAppearance.BorderSize = 0;
            this.btnAgregarPedido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(92)))), ((int)(((byte)(75)))));
            this.btnAgregarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPedido.Location = new System.Drawing.Point(996, 21);
            this.btnAgregarPedido.Name = "btnAgregarPedido";
            this.btnAgregarPedido.Size = new System.Drawing.Size(161, 26);
            this.btnAgregarPedido.TabIndex = 120;
            this.btnAgregarPedido.Text = "Agregar Pedidos";
            this.btnAgregarPedido.UseVisualStyleBackColor = true;
            this.btnAgregarPedido.Click += new System.EventHandler(this.btnAgregarPedido_Click);
            // 
            // panelPedidos
            // 
            this.panelPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(154)))), ((int)(((byte)(141)))));
            this.panelPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPedidos.Location = new System.Drawing.Point(0, 58);
            this.panelPedidos.Name = "panelPedidos";
            this.panelPedidos.Size = new System.Drawing.Size(1538, 448);
            this.panelPedidos.TabIndex = 134;
            // 
            // frmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1538, 506);
            this.Controls.Add(this.panelPedidos);
            this.Controls.Add(this.panel1);
            this.Name = "frmPedidos";
            this.Text = "frmPedidos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnModificarPedidos;
        private System.Windows.Forms.Button btnAgregarProductoStock;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelPedidos;
        private System.Windows.Forms.Button btnAgregarPedido;
        private System.Windows.Forms.Label lblFormulario;
    }
}