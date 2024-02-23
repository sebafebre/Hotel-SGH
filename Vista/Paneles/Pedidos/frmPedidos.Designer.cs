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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModificarPedidos
            // 
            this.btnModificarPedidos.Location = new System.Drawing.Point(193, 0);
            this.btnModificarPedidos.Name = "btnModificarPedidos";
            this.btnModificarPedidos.Size = new System.Drawing.Size(161, 26);
            this.btnModificarPedidos.TabIndex = 118;
            this.btnModificarPedidos.Text = "Modificar Pedidos";
            this.btnModificarPedidos.UseVisualStyleBackColor = true;
            this.btnModificarPedidos.Click += new System.EventHandler(this.btnModificarPedidos_Click);
            // 
            // btnAgregarProductoStock
            // 
            this.btnAgregarProductoStock.Location = new System.Drawing.Point(366, 0);
            this.btnAgregarProductoStock.Name = "btnAgregarProductoStock";
            this.btnAgregarProductoStock.Size = new System.Drawing.Size(161, 26);
            this.btnAgregarProductoStock.TabIndex = 119;
            this.btnAgregarProductoStock.Text = "Stock de Productos";
            this.btnAgregarProductoStock.UseVisualStyleBackColor = true;
            this.btnAgregarProductoStock.Click += new System.EventHandler(this.btnAgregarProductoStock_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.btnAgregarPedido);
            this.panel1.Controls.Add(this.btnModificarPedidos);
            this.panel1.Controls.Add(this.btnAgregarProductoStock);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1525, 26);
            this.panel1.TabIndex = 133;
            // 
            // btnAgregarPedido
            // 
            this.btnAgregarPedido.Location = new System.Drawing.Point(20, 0);
            this.btnAgregarPedido.Name = "btnAgregarPedido";
            this.btnAgregarPedido.Size = new System.Drawing.Size(161, 26);
            this.btnAgregarPedido.TabIndex = 120;
            this.btnAgregarPedido.Text = "Agregar Pedidos";
            this.btnAgregarPedido.UseVisualStyleBackColor = true;
            this.btnAgregarPedido.Click += new System.EventHandler(this.btnAgregarPedido_Click);
            // 
            // panelPedidos
            // 
            this.panelPedidos.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelPedidos.Location = new System.Drawing.Point(1, 34);
            this.panelPedidos.Name = "panelPedidos";
            this.panelPedidos.Size = new System.Drawing.Size(1525, 449);
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnModificarPedidos;
        private System.Windows.Forms.Button btnAgregarProductoStock;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelPedidos;
        private System.Windows.Forms.Button btnAgregarPedido;
    }
}