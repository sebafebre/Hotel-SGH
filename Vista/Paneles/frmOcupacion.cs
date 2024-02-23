using Controladora;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Vista.Paneles
{
    public partial class frmOcupacion : Form
    {
        ReservaBLL reservaBLL = new ReservaBLL();
        private Dictionary<int, int> reservasPorDia;

        public frmOcupacion()
        {
            InitializeComponent();
            
        }

        private void frmOcupacion_Load(object sender, EventArgs e)
        {
            reservasPorDia = reservaBLL.ContarReservasPorDiaDelMes();
            MostrarGraficoBarras();
            CargarDatosAlChart();
            MostrarGananciaTotal();
            CargarProgressBar();
        }

        private void MostrarGraficoBarras()
        {
            ctReservasPorDia.Series.Clear();
            Series series = new Series("Reservas por día");

            foreach (var kvp in reservasPorDia)
            {
                series.Points.AddXY(kvp.Key, kvp.Value);
            }

            ctReservasPorDia.Series.Add(series);
            ctReservasPorDia.ChartAreas[0].AxisX.Title = "Día del mes";
            ctReservasPorDia.ChartAreas[0].AxisY.Title = "Cantidad de reservas";
        }

        private void CargarDatosAlChart()
        {
            // Obtener las habitaciones desde la base de datos
            var habitaciones = reservaBLL.ObtenerHabitacionesDesdeBaseDeDatos();

            // Preparar los datos para el gráfico
            var datosParaGrafico = reservaBLL.PrepararDatosParaGrafico(habitaciones);

            // Añadir los datos al chart
            for (int i = 0; i < datosParaGrafico.Item1.Count; i++)
            {
                ctEstadosHabitaciones.Series["Series1"].Points.AddXY(datosParaGrafico.Item1[i], datosParaGrafico.Item2[i]);
            }
        }

        private void MostrarGananciaTotal()
        {
            decimal gananciaTotal = reservaBLL.CalcularGananciaFuturaAproximada();
            txtGananciaMensual.Text = gananciaTotal.ToString("C"); // Muestra la ganancia total en formato de moneda
        }

        private void CargarProgressBar()
        {
            // Llama al método para obtener las habitaciones desde la base de datos
            List<HabitacionBE> habitaciones = reservaBLL.ObtenerHabitacionesDesdeBaseDeDatos();

            // Verifica si se obtuvieron las habitaciones correctamente
            if (habitaciones != null)
            {
                // Prepara los datos para el gráfico
                Tuple<List<string>, List<int>> datosGrafico = reservaBLL.PrepararDatosParaGrafico(habitaciones);

                // Extrae los datos del gráfico
                List<string> estados = datosGrafico.Item1;
                List<int> cantidades = datosGrafico.Item2;

                // Actualiza las ProgressBar
                // Asigna los valores a las ProgressBar
                if (cantidades.Count == 3)
                {
                    pBarDisponibles.Value = cantidades[0];
                    pBarOcupadas.Value = cantidades[1];
                    pBarMantenimiento.Value = cantidades[2];
                }
                else if (cantidades.Count == 2)
                {
                    // Si solo hay dos estados, asume que el tercero (mantenimiento) está en cero
                    pBarDisponibles.Value = cantidades[0];
                    pBarOcupadas.Value = cantidades[1];
                    pBarMantenimiento.Value = 0;
                }
            }
            else
            {
                // Maneja el caso en el que no se pudieron obtener las habitaciones correctamente
                // Puedes mostrar un mensaje de error o tomar alguna acción apropiada
                MessageBox.Show("No se pudieron obtener las habitaciones correctamente.");
            }


        }

    }
}
