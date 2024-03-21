using Controladora;
using Controladora.SeguridadBLL;
using Entidades;
using Entidades.Seguridad;
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
        private Dictionary<int, int> pedidosPorDia;
        GrupoBLL grupoBLL = new GrupoBLL();

        string usuarioActual = UsuarioBE.usaurioLogueado;

        public frmOcupacion()
        {
            InitializeComponent();
            VerificasPermisos();
        }


        public void VerificasPermisos()
        {     
            List<PermisoBE> permisosUsuario = grupoBLL.ObtenerPermisosDelUsuario(usuarioActual);

            List<string> permisos = new List<string>();

            foreach (var item in permisosUsuario)
            {
                permisos.Add(item.Componente.Nombre);
            }
            if (permisos.Contains("GA002 verGanancias"))
            {
                lblGanancia.Visible = true;
                txtGananciaMensual.Visible = true;
            }
            else
            {
                lblGanancia.Visible = false;
                txtGananciaMensual.Visible = false;
            }
        }

        private void frmOcupacion_Load(object sender, EventArgs e)
        {
            MostrarGraficoReservas();
            MostrarGraficoPedidos();
            gananciaMensualEsperada();
            reservaBLL.VerificarCancelacionReservas();
            reservaBLL.MostrarProgresBar(pBarDisponibles, lblCantDisponible, pBarOcupadas, lblCantOcupada, pBarLimpieza, lblCantLimpieza);
            reservaBLL.CargarDatosChart(ctEstadosHabitaciones);
        }

        private void MostrarGraficoReservas()
        {
            reservasPorDia = reservaBLL.ContarReservasPorDiaDelMes();
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

        private void MostrarGraficoPedidos()
        {
            pedidosPorDia = reservaBLL.ContarPedidosPorDiaDelMes();
            ctPedidosPorDia.Series.Clear();
            Series series = new Series("Pedidos por día");

            foreach (var kvp in pedidosPorDia)
            {
                series.Points.AddXY(kvp.Key, kvp.Value);
            }

            ctPedidosPorDia.Series.Add(series);
            ctPedidosPorDia.ChartAreas[0].AxisX.Title = "Día del mes";
            ctPedidosPorDia.ChartAreas[0].AxisY.Title = "Cantidad de pedidos";
        }

        
        private void gananciaMensualEsperada()
        {
            float gananciaTotal = reservaBLL.Prueba();
            txtGananciaMensual.Text = gananciaTotal.ToString();
        }

        
    }
}
