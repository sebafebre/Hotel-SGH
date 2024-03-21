namespace Vista.Paneles
{
    partial class frmOcupacion
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ctReservasPorDia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ctEstadosHabitaciones = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtGananciaMensual = new System.Windows.Forms.TextBox();
            this.pBarDisponibles = new System.Windows.Forms.ProgressBar();
            this.pBarOcupadas = new System.Windows.Forms.ProgressBar();
            this.pBarLimpieza = new System.Windows.Forms.ProgressBar();
            this.lblCantDisponible = new System.Windows.Forms.Label();
            this.lblCantOcupada = new System.Windows.Forms.Label();
            this.lblCantLimpieza = new System.Windows.Forms.Label();
            this.lblGanancia = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ctPedidosPorDia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.ctReservasPorDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctEstadosHabitaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctPedidosPorDia)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctReservasPorDia
            // 
            this.ctReservasPorDia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            this.ctReservasPorDia.BorderSkin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            this.ctReservasPorDia.BorderSkin.PageColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            chartArea1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.Gray;
            this.ctReservasPorDia.ChartAreas.Add(chartArea1);
            this.ctReservasPorDia.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            legend1.Name = "Legend1";
            this.ctReservasPorDia.Legends.Add(legend1);
            this.ctReservasPorDia.Location = new System.Drawing.Point(312, 26);
            this.ctReservasPorDia.Name = "ctReservasPorDia";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ctReservasPorDia.Series.Add(series1);
            this.ctReservasPorDia.Size = new System.Drawing.Size(613, 297);
            this.ctReservasPorDia.TabIndex = 0;
            this.ctReservasPorDia.Text = "chart1";
            // 
            // ctEstadosHabitaciones
            // 
            this.ctEstadosHabitaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            this.ctEstadosHabitaciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ctEstadosHabitaciones.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            this.ctEstadosHabitaciones.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            this.ctEstadosHabitaciones.BorderSkin.PageColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(154)))), ((int)(((byte)(141)))));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            chartArea2.BackImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            chartArea2.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            chartArea2.Name = "ChartArea1";
            this.ctEstadosHabitaciones.ChartAreas.Add(chartArea2);
            this.ctEstadosHabitaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            legend2.Name = "Legend1";
            this.ctEstadosHabitaciones.Legends.Add(legend2);
            this.ctEstadosHabitaciones.Location = new System.Drawing.Point(3, 26);
            this.ctEstadosHabitaciones.Name = "ctEstadosHabitaciones";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.ctEstadosHabitaciones.Series.Add(series2);
            this.ctEstadosHabitaciones.Size = new System.Drawing.Size(303, 297);
            this.ctEstadosHabitaciones.TabIndex = 1;
            this.ctEstadosHabitaciones.Text = "chart1";
            // 
            // txtGananciaMensual
            // 
            this.txtGananciaMensual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGananciaMensual.Enabled = false;
            this.txtGananciaMensual.Location = new System.Drawing.Point(1121, 411);
            this.txtGananciaMensual.Name = "txtGananciaMensual";
            this.txtGananciaMensual.ReadOnly = true;
            this.txtGananciaMensual.Size = new System.Drawing.Size(276, 22);
            this.txtGananciaMensual.TabIndex = 2;
            // 
            // pBarDisponibles
            // 
            this.pBarDisponibles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pBarDisponibles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pBarDisponibles.Location = new System.Drawing.Point(24, 380);
            this.pBarDisponibles.Name = "pBarDisponibles";
            this.pBarDisponibles.Size = new System.Drawing.Size(358, 23);
            this.pBarDisponibles.TabIndex = 3;
            // 
            // pBarOcupadas
            // 
            this.pBarOcupadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pBarOcupadas.ForeColor = System.Drawing.Color.Red;
            this.pBarOcupadas.Location = new System.Drawing.Point(24, 413);
            this.pBarOcupadas.Name = "pBarOcupadas";
            this.pBarOcupadas.Size = new System.Drawing.Size(358, 23);
            this.pBarOcupadas.TabIndex = 4;
            // 
            // pBarLimpieza
            // 
            this.pBarLimpieza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pBarLimpieza.ForeColor = System.Drawing.Color.Cyan;
            this.pBarLimpieza.Location = new System.Drawing.Point(24, 453);
            this.pBarLimpieza.Name = "pBarLimpieza";
            this.pBarLimpieza.Size = new System.Drawing.Size(358, 23);
            this.pBarLimpieza.TabIndex = 5;
            // 
            // lblCantDisponible
            // 
            this.lblCantDisponible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCantDisponible.AutoSize = true;
            this.lblCantDisponible.BackColor = System.Drawing.SystemColors.Control;
            this.lblCantDisponible.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantDisponible.Location = new System.Drawing.Point(325, 383);
            this.lblCantDisponible.Name = "lblCantDisponible";
            this.lblCantDisponible.Size = new System.Drawing.Size(45, 17);
            this.lblCantDisponible.TabIndex = 7;
            this.lblCantDisponible.Text = "label1";
            // 
            // lblCantOcupada
            // 
            this.lblCantOcupada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCantOcupada.AutoSize = true;
            this.lblCantOcupada.BackColor = System.Drawing.SystemColors.Control;
            this.lblCantOcupada.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblCantOcupada.Location = new System.Drawing.Point(325, 416);
            this.lblCantOcupada.Name = "lblCantOcupada";
            this.lblCantOcupada.Size = new System.Drawing.Size(45, 17);
            this.lblCantOcupada.TabIndex = 8;
            this.lblCantOcupada.Text = "label1";
            // 
            // lblCantLimpieza
            // 
            this.lblCantLimpieza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCantLimpieza.AutoSize = true;
            this.lblCantLimpieza.BackColor = System.Drawing.SystemColors.Control;
            this.lblCantLimpieza.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblCantLimpieza.Location = new System.Drawing.Point(325, 456);
            this.lblCantLimpieza.Name = "lblCantLimpieza";
            this.lblCantLimpieza.Size = new System.Drawing.Size(45, 17);
            this.lblCantLimpieza.TabIndex = 9;
            this.lblCantLimpieza.Text = "label2";
            // 
            // lblGanancia
            // 
            this.lblGanancia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGanancia.AutoSize = true;
            this.lblGanancia.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblGanancia.Location = new System.Drawing.Point(1090, 378);
            this.lblGanancia.Name = "lblGanancia";
            this.lblGanancia.Size = new System.Drawing.Size(390, 25);
            this.lblGanancia.TabIndex = 11;
            this.lblGanancia.Text = "Ganancia mensual esperada para fin de mes:";
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Estado actual de las habitaciones:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(388, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Disponible:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(388, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ocupada";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(388, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Limpieza";
            // 
            // label5
            // 
            this.label5.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(312, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(613, 23);
            this.label5.TabIndex = 16;
            this.label5.Text = "Cantidad de reservas registradas por dias del mes:";
            // 
            // ctPedidosPorDia
            // 
            this.ctPedidosPorDia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            this.ctPedidosPorDia.BorderSkin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            this.ctPedidosPorDia.BorderSkin.PageColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            chartArea3.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            chartArea3.Name = "ChartArea1";
            chartArea3.ShadowColor = System.Drawing.Color.Gray;
            this.ctPedidosPorDia.ChartAreas.Add(chartArea3);
            this.ctPedidosPorDia.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            legend3.Name = "Legend1";
            this.ctPedidosPorDia.Legends.Add(legend3);
            this.ctPedidosPorDia.Location = new System.Drawing.Point(931, 26);
            this.ctPedidosPorDia.Name = "ctPedidosPorDia";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.ctPedidosPorDia.Series.Add(series3);
            this.ctPedidosPorDia.Size = new System.Drawing.Size(614, 297);
            this.ctPedidosPorDia.TabIndex = 17;
            this.ctPedidosPorDia.Text = "chart1";
            // 
            // label6
            // 
            this.label6.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(931, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(614, 23);
            this.label6.TabIndex = 18;
            this.label6.Text = "Cantidad de reservas registradas por dias del mes:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.ctReservasPorDia, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ctEstadosHabitaciones, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ctPedidosPorDia, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.216495F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.78351F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1548, 326);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // frmOcupacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(154)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(1590, 493);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGananciaMensual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblGanancia);
            this.Controls.Add(this.lblCantLimpieza);
            this.Controls.Add(this.lblCantOcupada);
            this.Controls.Add(this.lblCantDisponible);
            this.Controls.Add(this.pBarLimpieza);
            this.Controls.Add(this.pBarOcupadas);
            this.Controls.Add(this.pBarDisponibles);
            this.Name = "frmOcupacion";
            this.Text = "frmOcupacion";
            this.Load += new System.EventHandler(this.frmOcupacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctReservasPorDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctEstadosHabitaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctPedidosPorDia)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ctReservasPorDia;
        private System.Windows.Forms.DataVisualization.Charting.Chart ctEstadosHabitaciones;
        private System.Windows.Forms.TextBox txtGananciaMensual;
        private System.Windows.Forms.ProgressBar pBarDisponibles;
        private System.Windows.Forms.ProgressBar pBarOcupadas;
        private System.Windows.Forms.ProgressBar pBarLimpieza;
        private System.Windows.Forms.Label lblCantDisponible;
        private System.Windows.Forms.Label lblCantOcupada;
        private System.Windows.Forms.Label lblCantLimpieza;
        private System.Windows.Forms.Label lblGanancia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart ctPedidosPorDia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}