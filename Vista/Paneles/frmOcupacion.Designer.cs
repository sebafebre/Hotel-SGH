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
            this.lblGanancia = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ctReservasPorDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctEstadosHabitaciones)).BeginInit();
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
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            legend1.Name = "Legend1";
            this.ctReservasPorDia.Legends.Add(legend1);
            this.ctReservasPorDia.Location = new System.Drawing.Point(803, 38);
            this.ctReservasPorDia.Name = "ctReservasPorDia";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ctReservasPorDia.Series.Add(series1);
            this.ctReservasPorDia.Size = new System.Drawing.Size(648, 198);
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
            legend2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(181)))));
            legend2.Name = "Legend1";
            this.ctEstadosHabitaciones.Legends.Add(legend2);
            this.ctEstadosHabitaciones.Location = new System.Drawing.Point(61, 26);
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
            this.txtGananciaMensual.Location = new System.Drawing.Point(974, 427);
            this.txtGananciaMensual.Name = "txtGananciaMensual";
            this.txtGananciaMensual.ReadOnly = true;
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
            // lblGanancia
            // 
            this.lblGanancia.AutoSize = true;
            this.lblGanancia.Location = new System.Drawing.Point(989, 408);
            this.lblGanancia.Name = "lblGanancia";
            this.lblGanancia.Size = new System.Drawing.Size(279, 16);
            this.lblGanancia.TabIndex = 11;
            this.lblGanancia.Text = "Ganancia mensual esperada para fin de mes:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Estado actual de las habitaciones:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Disponible:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(425, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ocupada";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 433);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Limpieza";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(832, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(313, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Cantidad de reservas registradas por dias del mes:";
            // 
            // frmOcupacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(154)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(1480, 472);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGanancia);
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
        private System.Windows.Forms.Label lblGanancia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}