using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Controladora;

namespace Vista.Administrador
{
    public partial class frmReportes : Form
    {
        ReservaBLL reservaBLL = new ReservaBLL();
        int mes = 0;
        string tipoReporte = "";

        public frmReportes()
        {
            InitializeComponent();
        }

        
        

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            mes = cbMes.SelectedIndex + 1; // El índice es base cero, por lo que sumamos 1 para obtener el mes real
            CargasDatos();


        }

        private void cbReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbReporte.SelectedItem == "Reservas del mes")
            {
                tipoReporte = "Reserva";
            }
            if (cbReporte.SelectedItem == "Pedidos del mes")
            {
                tipoReporte = "Pedido";
            }
            CargasDatos();
        }

        private void btnEmitirReporte_Click(object sender, EventArgs e)
        {
            if(tipoReporte != "")
            {
                if(mes != 0)
                {
                    try
                    {
                        if(tipoReporte == "Pedido")
                        {
                            Dictionary<int, int> pedidosPorDia = reservaBLL.ContarPedidosPorDiaDelMesSeleccionado(mes);
                            // Exportar los datos a un archivo Excel
                            reservaBLL.ExportarPedidosPorDiaDelMesAExcel(pedidosPorDia, mes);

                            MessageBox.Show("Datos exportados y gráfico creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        if(tipoReporte == "Reserva")
                        {
                            Dictionary<int, int> reservasPorDia = reservaBLL.ContarReservasPorDiaDelMesSeleccionado(mes);
                            // Exportar los datos a un archivo Excel
                            reservaBLL.ExportarReservasPorDiaDelMesAExcel(reservasPorDia, mes);

                            MessageBox.Show("Datos exportados y gráfico creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar a Excel: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un mes para generar el reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Seleccione un tipo de reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        #region Mostrar datos en DGV y Chart
        public void MostrarPedidosEnDataGridView()
        {
            Dictionary<int, int> pedidosPorDia = reservaBLL.ContarPedidosPorDiaDelMesSeleccionado(mes); ;

            dgvDatos.Rows.Clear();
            dgvDatos.Columns.Clear();

            dgvDatos.Columns.Add("Dia", "Día");
            dgvDatos.Columns.Add("Cantidad Pedidos", "Cantidad Pedidos");

            foreach (var kvp in pedidosPorDia)
            {
                dgvDatos.Rows.Add(kvp.Key, kvp.Value);
            }
        }


        public void MostrarPedidosGrafico()
        {
            Dictionary<int, int> pedidosPorDia = reservaBLL.ContarPedidosPorDiaDelMesSeleccionado(mes);

            chartDatos.Series.Clear();


            Series series = chartDatos.Series.Add("Cantidad de Pedidos");
            foreach (var kvp in pedidosPorDia)
            {
                series.Points.AddXY(kvp.Key, kvp.Value);
            }

            // Ajustar el estilo del gráfico según tus preferencias
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.Blue;

            // Configurar el título del gráfico
            chartDatos.Titles.Clear();
            chartDatos.Titles.Add($"Pedidos por Día - {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes)}");
        }



        public void MostrarReservasEnDataGridView()
        {
            Dictionary<int, int> reservasPorDia = reservaBLL.ContarReservasPorDiaDelMesSeleccionado(mes);

            dgvDatos.Rows.Clear();
            dgvDatos.Columns.Clear();

            dgvDatos.Columns.Add("Dia", "Día");
            dgvDatos.Columns.Add("Cantidad Reservas", "Cantidad Reservas");

            foreach (var kvp in reservasPorDia)
            {
                dgvDatos.Rows.Add(kvp.Key, kvp.Value);
            }
        }


        public void MostrarReservasGrafico()
        {
            Dictionary<int, int> reservasPorDia = reservaBLL.ContarReservasPorDiaDelMesSeleccionado(mes);

            chartDatos.Series.Clear();

            Series series = chartDatos.Series.Add("Cantidad de Reservas");
            foreach (var kvp in reservasPorDia)
            {
                series.Points.AddXY(kvp.Key, kvp.Value);
            }

            // Ajustar el estilo del gráfico según tus preferencias
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.Blue;

            // Configurar el título del gráfico
            chartDatos.Titles.Clear();
            chartDatos.Titles.Add($"Reservas por Día - {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes)}");
        }
        
        
        public void CargasDatos()
        {
            if(tipoReporte == "Reserva" &&  mes != 0)
            {
                MostrarReservasEnDataGridView();
                MostrarReservasGrafico();
            }
            if (tipoReporte == "Pedido" && mes != 0)
            {
                MostrarPedidosEnDataGridView();
                MostrarPedidosGrafico();
            }
        }


        #endregion



        




    }
}
