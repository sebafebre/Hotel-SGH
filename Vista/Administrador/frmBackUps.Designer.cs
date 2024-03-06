namespace Vista.Administrador
{
    partial class frmBackUps
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
            this.btnCrearBackup = new System.Windows.Forms.Button();
            this.btnEliminarBackup = new System.Windows.Forms.Button();
            this.btnActualizarBackup = new System.Windows.Forms.Button();
            this.btnActualizarBD = new System.Windows.Forms.Button();
            this.dgvBackUps = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackUps)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrearBackup
            // 
            this.btnCrearBackup.Location = new System.Drawing.Point(51, 140);
            this.btnCrearBackup.Name = "btnCrearBackup";
            this.btnCrearBackup.Size = new System.Drawing.Size(96, 46);
            this.btnCrearBackup.TabIndex = 0;
            this.btnCrearBackup.Text = "Crear BackUp";
            this.btnCrearBackup.UseVisualStyleBackColor = true;
            this.btnCrearBackup.Click += new System.EventHandler(this.btnCrearBackup_Click);
            // 
            // btnEliminarBackup
            // 
            this.btnEliminarBackup.Location = new System.Drawing.Point(50, 189);
            this.btnEliminarBackup.Name = "btnEliminarBackup";
            this.btnEliminarBackup.Size = new System.Drawing.Size(96, 46);
            this.btnEliminarBackup.TabIndex = 1;
            this.btnEliminarBackup.Text = "Eliminar BackUp";
            this.btnEliminarBackup.UseVisualStyleBackColor = true;
            this.btnEliminarBackup.Click += new System.EventHandler(this.btnEliminarBackup_Click_1);
            // 
            // btnActualizarBackup
            // 
            this.btnActualizarBackup.Location = new System.Drawing.Point(50, 241);
            this.btnActualizarBackup.Name = "btnActualizarBackup";
            this.btnActualizarBackup.Size = new System.Drawing.Size(96, 46);
            this.btnActualizarBackup.TabIndex = 2;
            this.btnActualizarBackup.Text = "Actualizar BackUp";
            this.btnActualizarBackup.UseVisualStyleBackColor = true;
            this.btnActualizarBackup.Click += new System.EventHandler(this.btnActualizarBackup_Click);
            // 
            // btnActualizarBD
            // 
            this.btnActualizarBD.Location = new System.Drawing.Point(51, 293);
            this.btnActualizarBD.Name = "btnActualizarBD";
            this.btnActualizarBD.Size = new System.Drawing.Size(96, 46);
            this.btnActualizarBD.TabIndex = 3;
            this.btnActualizarBD.Text = "Actualizar BD";
            this.btnActualizarBD.UseVisualStyleBackColor = true;
            this.btnActualizarBD.Click += new System.EventHandler(this.btnActualizarBD_Click);
            // 
            // dgvBackUps
            // 
            this.dgvBackUps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBackUps.Location = new System.Drawing.Point(418, 87);
            this.dgvBackUps.Name = "dgvBackUps";
            this.dgvBackUps.RowHeadersWidth = 51;
            this.dgvBackUps.RowTemplate.Height = 24;
            this.dgvBackUps.Size = new System.Drawing.Size(509, 325);
            this.dgvBackUps.TabIndex = 4;
            this.dgvBackUps.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBackUps_CellClick);
            // 
            // frmBackUps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(154)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.dgvBackUps);
            this.Controls.Add(this.btnActualizarBD);
            this.Controls.Add(this.btnActualizarBackup);
            this.Controls.Add(this.btnEliminarBackup);
            this.Controls.Add(this.btnCrearBackup);
            this.Name = "frmBackUps";
            this.Text = "frmBackUps";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackUps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrearBackup;
        private System.Windows.Forms.Button btnEliminarBackup;
        private System.Windows.Forms.Button btnActualizarBackup;
        private System.Windows.Forms.Button btnActualizarBD;
        private System.Windows.Forms.DataGridView dgvBackUps;
    }
}