namespace Vista.Paneles
{
    partial class frmPago
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNroTarjeta = new System.Windows.Forms.TextBox();
            this.btnPagar = new System.Windows.Forms.Button();
            this.txtPIN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTipoFactura = new System.Windows.Forms.ComboBox();
            this.cbPagoEfetivo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(154)))), ((int)(((byte)(153)))));
            this.panel1.Controls.Add(this.lblFormulario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 66);
            this.panel1.TabIndex = 0;
            // 
            // lblFormulario
            // 
            this.lblFormulario.AutoSize = true;
            this.lblFormulario.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormulario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFormulario.Location = new System.Drawing.Point(128, 9);
            this.lblFormulario.Name = "lblFormulario";
            this.lblFormulario.Size = new System.Drawing.Size(197, 38);
            this.lblFormulario.TabIndex = 4;
            this.lblFormulario.Text = "Pagar Factura";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "NroTarjeta:";
            // 
            // txtNroTarjeta
            // 
            this.txtNroTarjeta.Location = new System.Drawing.Point(154, 106);
            this.txtNroTarjeta.Name = "txtNroTarjeta";
            this.txtNroTarjeta.Size = new System.Drawing.Size(190, 22);
            this.txtNroTarjeta.TabIndex = 1;
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(154, 311);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(157, 38);
            this.btnPagar.TabIndex = 2;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // txtPIN
            // 
            this.txtPIN.Location = new System.Drawing.Point(154, 149);
            this.txtPIN.Name = "txtPIN";
            this.txtPIN.Size = new System.Drawing.Size(190, 22);
            this.txtPIN.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "PIN Seguridad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Efectivo:";
            // 
            // cbTipoFactura
            // 
            this.cbTipoFactura.FormattingEnabled = true;
            this.cbTipoFactura.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cbTipoFactura.Location = new System.Drawing.Point(154, 197);
            this.cbTipoFactura.Name = "cbTipoFactura";
            this.cbTipoFactura.Size = new System.Drawing.Size(190, 24);
            this.cbTipoFactura.TabIndex = 6;
            // 
            // cbPagoEfetivo
            // 
            this.cbPagoEfetivo.AutoSize = true;
            this.cbPagoEfetivo.Location = new System.Drawing.Point(154, 252);
            this.cbPagoEfetivo.Name = "cbPagoEfetivo";
            this.cbPagoEfetivo.Size = new System.Drawing.Size(133, 20);
            this.cbPagoEfetivo.TabIndex = 7;
            this.cbPagoEfetivo.Text = "pagar en efectivo";
            this.cbPagoEfetivo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tipo de factura:";
            // 
            // frmPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(154)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(460, 371);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbPagoEfetivo);
            this.Controls.Add(this.cbTipoFactura);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPIN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNroTarjeta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(478, 418);
            this.MinimumSize = new System.Drawing.Size(478, 418);
            this.Name = "frmPago";
            this.Text = "Pagar - SGH";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNroTarjeta;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.TextBox txtPIN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTipoFactura;
        private System.Windows.Forms.CheckBox cbPagoEfetivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFormulario;
    }
}