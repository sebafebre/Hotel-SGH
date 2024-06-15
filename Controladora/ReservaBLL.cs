﻿using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Controladora
{
    public class ReservaBLL
    {
        ReservaDAL reservaDAL = new ReservaDAL();

        public bool HabitacionDisponible(int numeroHabitacion, DateTime fechaInicio, DateTime fechaFin)
        {
            return reservaDAL.HabitacionDisponible(numeroHabitacion, fechaInicio, fechaFin);
        }



        public void ListarReservasEnDataGridView(DataGridView dataGridView)
        {
            reservaDAL.ListarReservasEnDataGridView(dataGridView);
        }





        public void FiltrarHabitaciones(string cbTipoHabitacion, string cbNroCamas, DataGridView dataGridViewHabitaciones)
        {
            reservaDAL.FiltrarHabitaciones(cbTipoHabitacion, cbNroCamas, dataGridViewHabitaciones);
        }



        






        

       
        public void GuardarReserva(int idCliente, int idHabitacion, DateTime fechaInicio, DateTime fechaFin, decimal subtotal, decimal imp, decimal total)
        {
            reservaDAL.GuardarReservaNueva(idCliente, idHabitacion, fechaInicio, fechaFin, subtotal, imp, total);
        }

        //Modificar Reserva
        public void ModificarReserva(ReservaBE reserva, int idCliente, int idHabitacion, DateTime fechaInicio, DateTime fechaFin)
        {
             reservaDAL.ModificarReserva(reserva, idCliente, idHabitacion, fechaInicio, fechaFin);
        }

        public string EliminarReserva(int IdReserva)
        {
            return reservaDAL.EliminarReserva(IdReserva);

        }

            


        public void MostrarHabitacionesDisponiblesEnDataGridView(List<HabitacionBE> habitaciones, DataGridView dataGridViewHabitaciones, Label labelError)
        {
            reservaDAL.MostrarHabitacionesDisponiblesEnDataGridView(habitaciones, dataGridViewHabitaciones, labelError);
        }

        public void filtrarHabitacionesDisponiblesDTP(DateTimePicker fechaLlegadaDateTimePicker, DateTimePicker fechaIdaDateTimePicker, string tipoHabitacion, string nroCamas, DataGridView dataGridViewHabitaciones, Label labelError)
        {
            reservaDAL.filtrarHabitacionesDisponiblesDTP(fechaLlegadaDateTimePicker, fechaIdaDateTimePicker, tipoHabitacion, nroCamas, dataGridViewHabitaciones, labelError);
        }


        public List<HabitacionBE> ConsultarHabitacionesDisponibles2(DateTime fechaLlegada, DateTime fechaIda, string tipoHabitacion, string nroCamas)
        {
            return reservaDAL.ConsultarHabitacionesDisponibles2(fechaLlegada, fechaIda, tipoHabitacion, nroCamas);
        }
        public void DateTimePickerCambia2(DateTimePicker fechaLlegadaDateTimePicker, DateTimePicker fechaIdaDateTimePicker, string tipoHabitacion, string nroCamas, DataGridView dataGridViewHabitaciones, Label labelError)
        {
            reservaDAL.DateTimePickerCambia2(fechaLlegadaDateTimePicker, fechaIdaDateTimePicker, tipoHabitacion, nroCamas, dataGridViewHabitaciones, labelError);
        }

        public void VerificarHabitacionesDisponibles(DateTimePicker fechaLlegadaDateTimePicker, DateTimePicker fechaIdaDateTimePicker, Label labelError)
        {
            reservaDAL.VerificarHabitacionesDisponibles(fechaLlegadaDateTimePicker, fechaIdaDateTimePicker, labelError);
        }



        #region Listar Reservas en DGView
        public void ListarReservasPendientesEnDataGridView(DataGridView dataGridView)
        {
            reservaDAL.ListarReservasPendientesEnDataGridView(dataGridView);
        }
        public void ListarReservasActivasEnDataGridView(DataGridView dataGridView)
        {
            
            reservaDAL.ListarReservasActivasEnDataGridView(dataGridView);
        }
        public void ListarReservasFinalizadasEnDataGridView(DataGridView dataGridView)
        {
            reservaDAL.ListarReservasFinalizadasEnDataGridView(dataGridView);
        }
        public void ListarReservasTodasEnDataGridView(DataGridView dataGridView)
        {
            reservaDAL.ListarReservasTodasEnDataGridView(dataGridView);
        }

        #endregion


        





        public Dictionary<int, int> ContarReservasPorDiaDelMes()
        {
            return reservaDAL.ContarReservasPorDiaDelMes();
        }

        public List<HabitacionBE> ObtenerHabitacionesDesdeBaseDeDatos()
        {
            return reservaDAL.ObtenerHabitacionesDesdeBaseDeDatos();
        }


        public Tuple<List<string>, List<int>> PrepararDatosParaGrafico(List<HabitacionBE> habitaciones)
        {
            return reservaDAL.PrepararDatosParaGrafico(habitaciones);
        }

        

        public decimal CalcularGananciaFuturaAproximada()
        {
            return reservaDAL.CalcularGananciaFuturaAproximada();
        }
        public float Prueba()
        {
            return reservaDAL.Prueba();
        }


        public void CargarDatosChart(Chart chartPIE)
        {
            reservaDAL.CargarDatosChart(chartPIE);

        }


        public void MostrarProgresBar(ProgressBar pbarDisponible, Label lblDisponible, ProgressBar pbarOcupadas, Label lblOcupadas, ProgressBar pbarLimpieza, Label lblLimpieza)
        {
            reservaDAL.MostrarProgresBar(pbarDisponible, lblDisponible, pbarOcupadas, lblOcupadas, pbarLimpieza, lblLimpieza);

        }
        public void VerificarCancelacionReservas()
        {
            reservaDAL.VerificarCancelacionReservas();
        }


        ReportesDAL reportesDAL = new ReportesDAL();


        
        public Dictionary<int, int> ContarReservasPorDiaDelMesActual()
        {
            return reportesDAL.ContarReservasPorDiaDelMesActual();
            
        }

        

        public void ExportarReservasPorDiaDelMesAExcel(Dictionary<int, int> reservasPorDia, int mes)
        {
            reportesDAL.ExportarReservasPorDiaDelMesAExcel(reservasPorDia,  mes);

        }

        public Dictionary<int, int> ContarReservasPorDiaDelMesSeleccionado(int mes)
        {
            return reportesDAL.ContarReservasPorDiaDelMesSeleccionado(mes);
        }

        public Dictionary<int, int> ContarPedidosPorDiaDelMes()
        {
            return reportesDAL.ContarPedidosPorDiaDelMes();
        }

        public void ExportarPedidosPorDiaDelMesAExcel(Dictionary<int, int> reservasPorDia, int mes)
        {
            reportesDAL.ExportarPedidosPorDiaDelMesAExcel(reservasPorDia, mes);

        }

        public Dictionary<int, int> ContarPedidosPorDiaDelMesSeleccionado(int mes)
        {
            return reportesDAL.ContarPedidosPorDiaDelMesSeleccionado(mes);
        }

    }
}
