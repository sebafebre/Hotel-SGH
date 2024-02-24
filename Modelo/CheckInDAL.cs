using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo
{
    public class CheckInDAL
    {
        //ContextoBD con = new ContextoBD();
        ContextoBD con = ContextoBD.Instance();
        public void BuscarClientePorDNI(string dni, DataGridView dgvClientes)
        {
            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                // Verificamos si el valor en la columna "DNI" contiene el texto ingresado en el TextBox
                if (row.Cells["DNI"].Value != null && row.Cells["DNI"].Value.ToString().ToLower().Contains(dni))
                {
                    row.Visible = true; // Si hay coincidencia, mostramos la fila
                }
                else
                {
                    row.Visible = false; // Si no hay coincidencia, ocultamos la fila
                }
            }
        }




        public void BuscarClientePorNumHabitacion(string NumHabitacion, DataGridView dgvClientes)
        {
            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                // Verificamos si el valor en la columna "DNI" contiene el texto ingresado en el TextBox
                if (row.Cells["Nro de Habitacion"].Value != null && row.Cells["Nro de Habitacion"].Value.ToString().ToLower().Contains(NumHabitacion))
                {
                    row.Visible = true; // Si hay coincidencia, mostramos la fila
                }
                else
                {
                    row.Visible = false; // Si no hay coincidencia, ocultamos la fila
                }
            }
        }






        #region Listar en DGView
        public void ListarReservasPendientesEnDataGridView(DataGridView dataGridView)
        {
            // Limpiamos las filas existentes en el DataGridView
            dataGridView.Rows.Clear();

            dataGridView.Columns.Clear();
            // Obtener la lista de las Habitaciones
            //List<ReservaBE> listaReservas = ListarReservas();

            // Iteramos sobre la lista de clientes activos y agregamos cada cliente al DataGridView

            
            dataGridView.Columns.Add("Nro de Reserva", "Nro de Reserva");
            dataGridView.Columns.Add("Nombre Cliente", "Nombre Cliente");
            dataGridView.Columns.Add("DNI", "DNI");
            dataGridView.Columns.Add("Fecha de Llegada", "Fecha de Llegada");
            dataGridView.Columns.Add("Fecha de Ida", "Fecha de Ida");
            dataGridView.Columns.Add("Nro de Habitacion", "Nro de Habitacion");
            dataGridView.Columns.Add("Tipo de Habitacion", "Tipo de Habitacion");
            dataGridView.Columns.Add("Tipo de Camas", "Tipo de Camas");
            dataGridView.Columns.Add("Total", "Total");
            
            dataGridView.Columns.Add("IdReserva", "ID Reserva");
            dataGridView.Columns.Add("IdCliente", "ID Cliente");

            

            List<ReservaBE> listaReservas = ListarReservas().Where(c => c.Estado == "Pendiente").ToList();

            foreach (var reserva in listaReservas)
            {
                // Agregamos una fila al DataGridView
                int rowIndex = dataGridView.Rows.Add();

                dataGridView.Rows[rowIndex].Cells[0].Value = reserva.NroReserva; // Suponiendo que "Nombre" es la segunda columna agregada
                dataGridView.Rows[rowIndex].Cells[1].Value = reserva.Cliente.Persona.Nombre + reserva.Cliente.Persona.Apellido;
                dataGridView.Rows[rowIndex].Cells[2].Value = reserva.Cliente.Persona.DNI;
                dataGridView.Rows[rowIndex].Cells[3].Value = reserva.FechaLlegada;
                dataGridView.Rows[rowIndex].Cells[4].Value = reserva.FechaIda;
                dataGridView.Rows[rowIndex].Cells[5].Value = reserva.Habitacion.NroHabitacion;
                dataGridView.Rows[rowIndex].Cells[6].Value = reserva.Habitacion.TipoHabitacion;
                dataGridView.Rows[rowIndex].Cells[7].Value = reserva.Habitacion.TipoCamas;
                dataGridView.Rows[rowIndex].Cells[8].Value = reserva.Total;
                dataGridView.Rows[rowIndex].Cells[9].Value = reserva.Id;
                dataGridView.Rows[rowIndex].Cells[10].Value = reserva.Cliente.Id;
                
            }
        }
        public void ListarReservasActivasEnDataGridView(DataGridView dataGridView)
        {
            // Limpiamos las filas existentes en el DataGridView
            dataGridView.Rows.Clear();

            dataGridView.Columns.Clear();
            // Obtener la lista de las Habitaciones
            //List<ReservaBE> listaReservas = ListarReservas();

            // Iteramos sobre la lista de clientes activos y agregamos cada cliente al DataGridView


            dataGridView.Columns.Add("Nro de Reserva", "Nro de Reserva");
            dataGridView.Columns.Add("Nombre Cliente", "Nombre Cliente");
            dataGridView.Columns.Add("DNI", "DNI");
            dataGridView.Columns.Add("Fecha de Llegada", "Fecha de Llegada");
            dataGridView.Columns.Add("Fecha de Ida", "Fecha de Ida");
            dataGridView.Columns.Add("Nro de Habitacion", "Nro de Habitacion");
            dataGridView.Columns.Add("Tipo de Habitacion", "Tipo de Habitacion");
            dataGridView.Columns.Add("Tipo de Camas", "Tipo de Camas");
            dataGridView.Columns.Add("Total", "Total");

            dataGridView.Columns.Add("IdReserva", "ID Reserva");
            dataGridView.Columns.Add("IdCliente", "ID Cliente");



            List<ReservaBE> listaReservas = ListarReservas().Where(c => c.Estado == "Activa").ToList();

            foreach (var reserva in listaReservas)
            {
                // Agregamos una fila al DataGridView
                int rowIndex = dataGridView.Rows.Add();

                dataGridView.Rows[rowIndex].Cells[0].Value = reserva.NroReserva; // Suponiendo que "Nombre" es la segunda columna agregada
                dataGridView.Rows[rowIndex].Cells[1].Value = reserva.Cliente.Persona.Nombre + reserva.Cliente.Persona.Apellido;
                dataGridView.Rows[rowIndex].Cells[2].Value = reserva.Cliente.Persona.DNI;
                dataGridView.Rows[rowIndex].Cells[3].Value = reserva.FechaLlegada;
                dataGridView.Rows[rowIndex].Cells[4].Value = reserva.FechaIda;
                dataGridView.Rows[rowIndex].Cells[5].Value = reserva.Habitacion.NroHabitacion;
                dataGridView.Rows[rowIndex].Cells[6].Value = reserva.Habitacion.TipoHabitacion;
                dataGridView.Rows[rowIndex].Cells[7].Value = reserva.Habitacion.TipoCamas;
                dataGridView.Rows[rowIndex].Cells[8].Value = reserva.Total;
                dataGridView.Rows[rowIndex].Cells[9].Value = reserva.Id;
                dataGridView.Rows[rowIndex].Cells[10].Value = reserva.Cliente.Id;

            }
        }
        public void ListarReservasFinalizadasEnDataGridView(DataGridView dataGridView)
        {
            // Limpiamos las filas existentes en el DataGridView
            dataGridView.Rows.Clear();

            dataGridView.Columns.Clear();
            // Obtener la lista de las Habitaciones
            //List<ReservaBE> listaReservas = ListarReservas();

            // Iteramos sobre la lista de clientes activos y agregamos cada cliente al DataGridView


            dataGridView.Columns.Add("Nro de Reserva", "Nro de Reserva");
            dataGridView.Columns.Add("Nombre Cliente", "Nombre Cliente");
            dataGridView.Columns.Add("DNI", "DNI");
            dataGridView.Columns.Add("Fecha de Llegada", "Fecha de Llegada");
            dataGridView.Columns.Add("Fecha de Ida", "Fecha de Ida");
            dataGridView.Columns.Add("Nro de Habitacion", "Nro de Habitacion");
            dataGridView.Columns.Add("Tipo de Habitacion", "Tipo de Habitacion");
            dataGridView.Columns.Add("Tipo de Camas", "Tipo de Camas");
            dataGridView.Columns.Add("Total", "Total");

            dataGridView.Columns.Add("IdReserva", "ID Reserva");
            dataGridView.Columns.Add("IdCliente", "ID Cliente");



            List<ReservaBE> listaReservas = ListarReservas().Where(c => c.Estado == "Finalizada").ToList();

            foreach (var reserva in listaReservas)
            {
                // Agregamos una fila al DataGridView
                int rowIndex = dataGridView.Rows.Add();

                dataGridView.Rows[rowIndex].Cells[0].Value = reserva.NroReserva; // Suponiendo que "Nombre" es la segunda columna agregada
                dataGridView.Rows[rowIndex].Cells[1].Value = reserva.Cliente.Persona.Nombre + reserva.Cliente.Persona.Apellido;
                dataGridView.Rows[rowIndex].Cells[2].Value = reserva.Cliente.Persona.DNI;
                dataGridView.Rows[rowIndex].Cells[3].Value = reserva.FechaLlegada;
                dataGridView.Rows[rowIndex].Cells[4].Value = reserva.FechaIda;
                dataGridView.Rows[rowIndex].Cells[5].Value = reserva.Habitacion.NroHabitacion;
                dataGridView.Rows[rowIndex].Cells[6].Value = reserva.Habitacion.TipoHabitacion;
                dataGridView.Rows[rowIndex].Cells[7].Value = reserva.Habitacion.TipoCamas;
                dataGridView.Rows[rowIndex].Cells[8].Value = reserva.Total;
                dataGridView.Rows[rowIndex].Cells[9].Value = reserva.Id;
                dataGridView.Rows[rowIndex].Cells[10].Value = reserva.Cliente.Id;

            }
        }
        public void ListarReservasTodasEnDataGridView(DataGridView dataGridView)
        {
            // Limpiamos las filas existentes en el DataGridView
            dataGridView.Rows.Clear();

            dataGridView.Columns.Clear();
            // Obtener la lista de las Habitaciones
            //List<ReservaBE> listaReservas = ListarReservas();

            // Iteramos sobre la lista de clientes activos y agregamos cada cliente al DataGridView


            dataGridView.Columns.Add("Nro de Reserva", "Nro de Reserva");
            dataGridView.Columns.Add("Nombre Cliente", "Nombre Cliente");
            dataGridView.Columns.Add("DNI", "DNI");
            dataGridView.Columns.Add("Fecha de Llegada", "Fecha de Llegada");
            dataGridView.Columns.Add("Fecha de Ida", "Fecha de Ida");
            dataGridView.Columns.Add("Nro de Habitacion", "Nro de Habitacion");
            dataGridView.Columns.Add("Tipo de Habitacion", "Tipo de Habitacion");
            dataGridView.Columns.Add("Tipo de Camas", "Tipo de Camas");
            dataGridView.Columns.Add("Total", "Total");

            dataGridView.Columns.Add("IdReserva", "ID Reserva");
            dataGridView.Columns.Add("IdCliente", "ID Cliente");



            List<ReservaBE> listaReservas = con.Reserva.ToList();

            foreach (var reserva in listaReservas)
            {
                // Agregamos una fila al DataGridView
                int rowIndex = dataGridView.Rows.Add();

                dataGridView.Rows[rowIndex].Cells[0].Value = reserva.NroReserva; // Suponiendo que "Nombre" es la segunda columna agregada
                dataGridView.Rows[rowIndex].Cells[1].Value = reserva.Cliente.Persona.Nombre + reserva.Cliente.Persona.Apellido;
                dataGridView.Rows[rowIndex].Cells[2].Value = reserva.Cliente.Persona.DNI;
                dataGridView.Rows[rowIndex].Cells[3].Value = reserva.FechaLlegada;
                dataGridView.Rows[rowIndex].Cells[4].Value = reserva.FechaIda;
                dataGridView.Rows[rowIndex].Cells[5].Value = reserva.Habitacion.NroHabitacion;
                dataGridView.Rows[rowIndex].Cells[6].Value = reserva.Habitacion.TipoHabitacion;
                dataGridView.Rows[rowIndex].Cells[7].Value = reserva.Habitacion.TipoCamas;
                dataGridView.Rows[rowIndex].Cells[8].Value = reserva.Total;
                dataGridView.Rows[rowIndex].Cells[9].Value = reserva.Id;
                dataGridView.Rows[rowIndex].Cells[10].Value = reserva.Cliente.Id;

            }
        }

        #endregion


        //Busca la reserva del DataGridView y cambia el estado a "Activa"
        public void CambiarEstadoReserva(int idReserva)
        {
            try
            {
                ReservaBE reserva = con.Reserva.Find(idReserva);
                if (reserva == null)
                {
                    MessageBox.Show("No se encontró la reserva");
                }
                if (reserva.Estado == "Activa")
                {
                    MessageBox.Show("La reserva ya está activa ");
                }
                if (reserva.Estado == "Finalizada")
                {
                    MessageBox.Show("La reserva ya a  finalizado");
                }
                if(reserva.Habitacion.Estado == "Ocupada")
                {
                    MessageBox.Show("La habitación está ocupada");
                }
                if (reserva.Habitacion.Estado == "Limpieza")
                {
                    MessageBox.Show("La habitación está siendo Limpiada, \n informe que habra una demora para entregar la habitacion y \n avisele al personal de limpieza que le den prioridad a la habitacion numero:", reserva.Habitacion.NroHabitacion.ToString() );
                }
                reserva.Estado = "Activa";
                reserva.Habitacion.Estado = "Ocupada";
                con.SaveChanges();
                MessageBox.Show("Se realizo el Check-In con exito y la reserva fue Activada");
                //return "Reserva Activa";

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo activar la reserva. " + ex.Message);
            }
            
        }

        //Mostrar datos en el DataGridView
        public List<ReservaBE> ListarReservas()
        {
            return con.Reserva.ToList();
        }

























    }
}
