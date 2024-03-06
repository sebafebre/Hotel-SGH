using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladora;

namespace Vista.Administrador
{
    public partial class frmReportes : Form
    {
        ReservaBLL reservaBLL = new ReservaBLL();
        int mes = 0;
        public frmReportes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                //ReservaService reservaService = new ReservaService();

                reservaBLL.ExportarReservasYCrearGrafico(mes);
                MessageBox.Show("Datos exportados y gráfico creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message);
            }*/
            
            // Obtener los datos del gráfico
            Dictionary<int, int> reservasPorDia = reservaBLL.ContarReservasPorDiaDelMes2();

            // Exportar los datos a un archivo Excel
            reservaBLL.ExportarReservasPorDiaDelMesAExcel(reservasPorDia);
            
            //var reservasPorDia = reservaBLL.ContarReservasPorDiaDelMes2(mes);

            //var csvExporter = new reservaBLLCSVExporter();
            //reservaBLL.ExportarReservasPorDiaDelMesACSV(reservasPorDia);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mes = comboBox1.SelectedIndex + 1; // El índice es base cero, por lo que sumamos 1 para obtener el mes real
            //var reservasPorDia = ContarReservasPorDiaDelMes2(month);
            // Luego puedes hacer lo que necesites con las reservas por día

        }
    }
}
