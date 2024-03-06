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
            this.btnAgregarPedido = new System.Windows.Forms.Button();
            this.panelPedidos = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModificarPedidos
            // 
            this.btnModificarPedidos.Location = new System.Drawing.Point(1150, 9);
            this.btnModificarPedidos.Name = "btnModificarPedidos";
            this.btnModificarPedidos.Size = new System.Drawing.Size(161, 26);
            this.btnModificarPedidos.TabIndex = 118;
            this.btnModificarPedidos.Text = "Modificar Pedidos";
            this.btnModificarPedidos.UseVisualStyleBackColor = true;
            this.btnModificarPedidos.Click += new System.EventHandler(this.btnModificarPedidos_Click);
            // 
            // btnAgregarProductoStock
            // 
            this.btnAgregarProductoStock.Location = new System.Drawing.Point(1349, 9);
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
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnAgregarPedido);
            this.panel1.Controls.Add(this.btnModificarPedidos);
            this.panel1.Controls.Add(this.btnAgregarProductoStock);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1538, 41);
            this.panel1.TabIndex = 133;
            // 
            // btnAgregarPedido
            // 
            this.btnAgregarPedido.Location = new System.Drawing.Point(963, 9);
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
            this.panelPedidos.Location = new System.Drawing.Point(0, 41);
            this.panelPedidos.Name = "panelPedidos";
            this.panelPedidos.Size = new System.Drawing.Size(1538, 465);
            this.panelPedidos.TabIndex = 134;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 121;
            this.label1.Text = "label1";
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
        private System.Windows.Forms.Label label1;
    }
}