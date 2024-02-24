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
            this.ctReservasPorDia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ctEstadosHabitaciones = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtGananciaMensual = new System.Windows.Forms.TextBox();
            this.pBarDisponibles = new System.Windows.Forms.ProgressBar();
            this.pBarOcupadas = new System.Windows.Forms.ProgressBar();
            this.pBarLimpieza = new System.Windows.Forms.ProgressBar();
            this.lblCantDisponible = new System.Windows.Forms.Label();
            this.lblCantOcupada = new System.Windows.Forms.Label();
            this.lblCantLimpieza = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ctReservasPorDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctEstadosHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // ctReservasPorDia
            // 
            chartArea1.Name = "ChartArea1";
            this.ctReservasPorDia.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ctReservasPorDia.Legends.Add(legend1);
            this.ctReservasPorDia.Location = new System.Drawing.Point(758, 27);
            this.ctReservasPorDia.Name = "ctReservasPorDia";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ctReservasPorDia.Series.Add(series1);
            this.ctReservasPorDia.Size = new System.Drawing.Size(710, 308);
            this.ctReservasPorDia.TabIndex = 0;
            this.ctReservasPorDia.Text = "chart1";
            // 
            // ctEstadosHabitaciones
            // 
            chartArea2.Name = "ChartArea1";
            this.ctEstadosHabitaciones.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ctEstadosHabitaciones.Legends.Add(legend2);
            this.ctEstadosHabitaciones.Location = new System.Drawing.Point(52, 12);
            this.ctEstadosHabitaciones.Name = "ctEstadosHabitaciones";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.ctEstadosHabitaciones.Series.Add(series2);
            this.ctEstadosHabitaciones.Size = new System.Drawing.Size(377, 309);
            this.ctEstadosHabitaciones.TabIndex = 1;
            this.ctEstadosHabitaciones.Text = "chart1";
            // 
            // txtGananciaMensual
            // 
            this.txtGananciaMensual.Location = new System.Drawing.Point(960, 403);
            this.txtGananciaMensual.Name = "txtGananciaMensual";
            this.txtGananciaMensual.Size = new System.Drawing.Size(329, 22);
            this.txtGananciaMensual.TabIndex = 2;
            // 
            // pBarDisponibles
            // 
            this.pBarDisponibles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pBarDisponibles.Location = new System.Drawing.Point(61, 357);
            this.pBarDisponibles.Name = "pBarDisponibles";
            this.pBarDisponibles.Size = new System.Drawing.Size(358, 23);
            this.pBarDisponibles.TabIndex = 3;
            // 
            // pBarOcupadas
            // 
            this.pBarOcupadas.ForeColor = System.Drawing.Color.Red;
            this.pBarOcupadas.Location = new System.Drawing.Point(61, 390);
            this.pBarOcupadas.Name = "pBarOcupadas";
            this.pBarOcupadas.Size = new System.Drawing.Size(358, 23);
            this.pBarOcupadas.TabIndex = 4;
            // 
            // pBarLimpieza
            // 
            this.pBarLimpieza.ForeColor = System.Drawing.Color.Cyan;
            this.pBarLimpieza.Location = new System.Drawing.Point(61, 430);
            this.pBarLimpieza.Name = "pBarLimpieza";
            this.pBarLimpieza.Size = new System.Drawing.Size(358, 23);
            this.pBarLimpieza.TabIndex = 5;
            // 
            // lblCantDisponible
            // 
            this.lblCantDisponible.AutoSize = true;
            this.lblCantDisponible.BackColor = System.Drawing.SystemColors.Control;
            this.lblCantDisponible.Location = new System.Drawing.Point(362, 360);
            this.lblCantDisponible.Name = "lblCantDisponible";
            this.lblCantDisponible.Size = new System.Drawing.Size(44, 16);
            this.lblCantDisponible.TabIndex = 7;
            this.lblCantDisponible.Text = "label1";
            // 
            // lblCantOcupada
            // 
            this.lblCantOcupada.AutoSize = true;
            this.lblCantOcupada.BackColor = System.Drawing.SystemColors.Control;
            this.lblCantOcupada.Location = new System.Drawing.Point(362, 393);
            this.lblCantOcupada.Name = "lblCantOcupada";
            this.lblCantOcupada.Size = new System.Drawing.Size(44, 16);
            this.lblCantOcupada.TabIndex = 8;
            this.lblCantOcupada.Text = "label1";
            // 
            // lblCantLimpieza
            // 
            this.lblCantLimpieza.AutoSize = true;
            this.lblCantLimpieza.BackColor = System.Drawing.SystemColors.Control;
            this.lblCantLimpieza.Location = new System.Drawing.Point(362, 433);
            this.lblCantLimpieza.Name = "lblCantLimpieza";
            this.lblCantLimpieza.Size = new System.Drawing.Size(44, 16);
            this.lblCantLimpieza.TabIndex = 9;
            this.lblCantLimpieza.Text = "label2";
            // 
            // frmOcupacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1480, 472);
            this.Controls.Add(this.lblCantLimpieza);
            this.Controls.Add(this.lblCantOcupada);
            this.Controls.Add(this.lblCantDisponible);
            this.Controls.Add(this.pBarLimpieza);
            this.Controls.Add(this.pBarOcupadas);
            this.Controls.Add(this.pBarDisponibles);
            this.Controls.Add(this.txtGananciaMensual);
            this.Controls.Add(this.ctEstadosHabitaciones);
            this.Controls.Add(this.ctReservasPorDia);
            this.Name = "frmOcupacion";
            this.Text = "frmOcupacion";
            this.Load += new System.EventHandler(this.frmOcupacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctReservasPorDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctEstadosHabitaciones)).EndInit();
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
    }
}