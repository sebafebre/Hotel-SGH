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
            this.pBarMantenimiento = new System.Windows.Forms.ProgressBar();
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
            this.pBarDisponibles.Location = new System.Drawing.Point(61, 357);
            this.pBarDisponibles.Name = "pBarDisponibles";
            this.pBarDisponibles.Size = new System.Drawing.Size(229, 23);
            this.pBarDisponibles.TabIndex = 3;
            // 
            // pBarOcupadas
            // 
            this.pBarOcupadas.Location = new System.Drawing.Point(61, 386);
            this.pBarOcupadas.Name = "pBarOcupadas";
            this.pBarOcupadas.Size = new System.Drawing.Size(229, 23);
            this.pBarOcupadas.TabIndex = 4;
            // 
            // pBarMantenimiento
            // 
            this.pBarMantenimiento.Location = new System.Drawing.Point(61, 415);
            this.pBarMantenimiento.Name = "pBarMantenimiento";
            this.pBarMantenimiento.Size = new System.Drawing.Size(229, 23);
            this.pBarMantenimiento.TabIndex = 5;
            // 
            // frmOcupacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1480, 450);
            this.Controls.Add(this.pBarMantenimiento);
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
        private System.Windows.Forms.ProgressBar pBarMantenimiento;
    }
}