﻿//Creado por Sebastian Febre
// https://github.com/sebafebre
using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
using System.IO;
using OfficeOpenXml;
using ClosedXML.Excel;
using ClosedXML;
using System.Net.Mail;
using System.Net;








namespace Modelo
{
    public class ReservaDAL
    {
        ContextoBD con = new ContextoBD();

        private List<ReservaBE> reservas = new List<ReservaBE>();

        



        public bool HabitacionDisponible(int idHabitacion, DateTime fechaInicio, DateTime fechaFin)
        {
            foreach (var reserva in reservas)
            {
                if (reserva.Habitacion.Id == idHabitacion &&
                    !(fechaFin <= reserva.FechaLlegada || fechaInicio >= reserva.FechaIda))
                {
                    // Se encontró una reserva existente que se superpone
                    return false;
                }
            }
            // No hay superposiciones, la habitación está disponible
            return true;
        }





        private bool VerificarDisponibilidadHabitacion(int nroHabitacion, DateTime fechaInicio, DateTime fechaFin)
        {
            // Verificar si hay reservas existentes que se superpongan con las fechas seleccionadas
            bool habitacionDisponible = !con.Reserva.Any(r =>
                                        r.Habitacion.NroHabitacion == nroHabitacion &&
                                        ((fechaInicio >= r.FechaLlegada && fechaInicio < r.FechaIda) ||
                                         (fechaFin > r.FechaLlegada && fechaFin <= r.FechaIda) ||
                                         (fechaInicio <= r.FechaLlegada && fechaFin >= r.FechaIda)));

            return habitacionDisponible;
        }


        public void GuardarReservaNueva(int ClienteDNI, int nroHabitacion, DateTime fechaInicio, DateTime fechaFin, decimal subtotal, decimal imp, decimal total)
        {
            try
            {
                // Obtener el cliente y la habitación correspondientes a los IDs proporcionados
                ClienteBE cliente = con.Cliente.FirstOrDefault(h => h.Persona.DNI == ClienteDNI);

                HabitacionBE habitacion = con.Habitacion.FirstOrDefault(h => h.NroHabitacion == nroHabitacion);

                if (cliente == null || habitacion == null)
                {
                    MessageBox.Show("El cliente o la habitación no existen.");

                }
                else
                {
                    // Verificar si la habitación está disponible para las fechas seleccionadas
                    bool habitacionDisponible = VerificarDisponibilidadHabitacion(nroHabitacion, fechaInicio, fechaFin);

                    if (!habitacionDisponible)
                    {
                        MessageBox.Show("La habitación no está disponible para las fechas seleccionadas.");

                    }
                    else
                    {
                        // Crear una nueva instancia de Reserva
                        ReservaBE nuevaReserva = new ReservaBE
                        {
                            Habitacion = habitacion,
                            Cliente = cliente,
                            FechaLlegada = fechaInicio,
                            FechaIda = fechaFin,
                            NroReserva = con.Reserva.Any() ? con.Reserva.Max(h => h.NroReserva) + 1 : 1,
                            Estado = "Pendiente",
                            Subtotal = subtotal,
                            Impuestos = imp,
                            Total = total
                        };


                        // Agregar la nueva reserva al contexto y guardar los cambios
                        con.Reserva.Add(nuevaReserva);
                        con.SaveChanges();

                        string destinatario = nuevaReserva.Cliente.Persona.Mail;
                        string asunto = "Información de la Reserva";

                        EnviarReservaPorEmail(destinatario, asunto, nuevaReserva);

                        MessageBox.Show("Reserva guardada correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar la reserva: " + ex.Message);

            }
        }



        public void EnviarReservaPorEmail(string destinatario, string asunto, ReservaBE reserva)
        {
            try
            {
                // Crear un objeto de correo electrónico
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("   *MAIL*    "); // Reemplaza con tu dirección de correo
                correo.To.Add(destinatario);
                correo.Subject = asunto;

                // Configurar el contenido del cuerpo del correo
                string cuerpo = $"Detalles de la reserva:\n" +
                                $"Cliente: {reserva.Cliente.Persona.Nombre} {reserva.Cliente.Persona.Apellido}\n" +
                                $"Habitación: {reserva.Habitacion.NroHabitacion}\n" +
                                $"Fecha de inicio: {reserva.FechaLlegada}\n" +
                                $"Fecha de fin: {reserva.FechaIda}\n" +
                                $"Subtotal: {reserva.Subtotal}\n" +
                                $"Impuestos: {reserva.Impuestos}\n" +
                                $"Total: {reserva.Total}\n";

                correo.Body = cuerpo;

                // Configurar el servidor SMTP
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.office365.com"; // Reemplaza con el servidor SMTP que estás utilizando
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false; // No usar las credenciales predeterminadas
                smtp.Credentials = new NetworkCredential("    *MAIL*    ", "   *CLAVE*   "); // Reemplaza con tus credenciales
                smtp.EnableSsl = true;

                // Enviar el correo electrónico
                smtp.Send(correo);

                // Liberar recursos
                correo.Dispose();

                Console.WriteLine("Correo electrónico enviado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo electrónico: " + ex.Message);
            }
        }















        private bool VerificarDisponibilidadHabitacion(int idHabitacion, DateTime fechaInicio, DateTime fechaFin, int idReservaExcluida)
        {
            // Verificar si hay reservas existentes que se superpongan con las fechas seleccionadas
            bool habitacionDisponible = !con.Reserva.Any(r =>
                                        r.Habitacion.Id == idHabitacion &&
                                        r.Id != idReservaExcluida && // Excluir la reserva que estamos modificando
                                        ((fechaInicio >= r.FechaLlegada && fechaInicio < r.FechaIda) ||
                                         (fechaFin > r.FechaLlegada && fechaFin <= r.FechaIda) ||
                                         (fechaInicio <= r.FechaLlegada && fechaFin >= r.FechaIda)));

            return habitacionDisponible;
        }


        public void ModificarReserva(ReservaBE reserva, int DNICliente, int NroHabitacion, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
               

                ClienteBE cliente = con.Cliente.FirstOrDefault(h => h.Persona.DNI == DNICliente);

                HabitacionBE habitacion = con.Habitacion.FirstOrDefault(h => h.NroHabitacion == NroHabitacion);

                if (cliente == null || habitacion == null)
                {
                    MessageBox.Show("El cliente o la habitación no existen.");
                    return;
                }

                // Verificar si la habitación está disponible para las fechas seleccionadas
                bool habitacionDisponible = VerificarDisponibilidadHabitacion(habitacion.Id, fechaInicio, fechaFin, reserva.Id);

                if (!habitacionDisponible)
                {
                    MessageBox.Show("La habitación no está disponible para las fechas seleccionadas.");
                    return;
                }
                if (habitacionDisponible)
                {
                    ReservaBE reservaModificar = con.Reserva.Find(reserva.Id);
                    reservaModificar.Cliente = cliente;
                    reservaModificar.Habitacion = habitacion;
                    reservaModificar.FechaLlegada = fechaInicio;
                    reservaModificar.FechaIda = fechaFin;
                    reservaModificar.NroReserva = reserva.NroReserva;
                    reservaModificar.Subtotal = reserva.Subtotal;
                    reservaModificar.Impuestos = reserva.Impuestos;
                    reservaModificar.Total = reserva.Total;
                    con.SaveChanges();
                    MessageBox.Show("Reserva modificada correctamente");
                }

                // Resto del código para modificar la reserva...
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar la reserva. " + ex.Message);
            }
        }




        //Eliminar Reserva
        public string EliminarReserva(int IdReserva)
        {
            try
            {
                // Buscar la reserva en la base de datos
                var reservaExistente = con.Reserva.Find(IdReserva);

                // Verificar si la reserva existe
                if (reservaExistente == null)
                {
                    return "La reserva no existe.";
                }

                // Eliminar la reserva de la base de datos
                con.Reserva.Remove(reservaExistente);
                con.SaveChanges();

                return "Reserva eliminada correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar la reserva. " + ex.Message;
            }
        }










        public void ListarReservasEnDataGridView(DataGridView dataGridView)
        {
            // Limpiamos las filas existentes en el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // Obtener la lista de las Habitaciones
            List<ReservaBE> listaReservas = con.Reserva.ToList();

            // Iteramos sobre la lista de clientes activos y agregamos cada cliente al DataGridView

            dataGridView.Columns.Add("IdReserva", "ID Reserva");
            dataGridView.Columns.Add("Nro de Reserva", "Nro de Reserva");
            dataGridView.Columns.Add("Fecha de Llegada", "Fecha de Llegada");
            dataGridView.Columns.Add("Fecha de Ida", "Fecha de Ida");
            dataGridView.Columns.Add("Total", "Total");
            dataGridView.Columns.Add("IdCliente", "ID Cliente");
            dataGridView.Columns.Add("DNI", "DNI");
            dataGridView.Columns.Add("Nro de Habitacion", "Nro de Habitacion");
            dataGridView.Columns.Add("Tipo de Habitacion", "Tipo de Habitacion");
            dataGridView.Columns.Add("Tipo de Camas", "Tipo de Camas");
            dataGridView.Columns.Add("ID Habitacion", "ID Habitacion");


            foreach (var reserva in listaReservas)
            {
                // Agregamos una fila al DataGridView
                int rowIndex = dataGridView.Rows.Add();

                dataGridView.Rows[rowIndex].Cells[0].Value = reserva.Id; // Suponiendo que "IdCliente" es la primera columna agregada
                dataGridView.Rows[rowIndex].Cells[1].Value = reserva.NroReserva; // Suponiendo que "Nombre" es la segunda columna agregada
                dataGridView.Rows[rowIndex].Cells[2].Value = reserva.FechaLlegada;
                dataGridView.Rows[rowIndex].Cells[3].Value = reserva.FechaIda;
                dataGridView.Rows[rowIndex].Cells[4].Value = reserva.Total;
                //Creado por Sebastian Febre
                // https://github.com/sebafebre
                dataGridView.Rows[rowIndex].Cells[5].Value = reserva.Cliente.Id; // y así sucesivamente
                dataGridView.Rows[rowIndex].Cells[6].Value = reserva.Cliente.Persona.DNI;

                dataGridView.Rows[rowIndex].Cells[7].Value = reserva.Habitacion.NroHabitacion;
                dataGridView.Rows[rowIndex].Cells[8].Value = reserva.Habitacion.TipoHabitacion;
                dataGridView.Rows[rowIndex].Cells[9].Value = reserva.Habitacion.TipoCamas;
                dataGridView.Rows[rowIndex].Cells[10].Value = reserva.Habitacion.Id;



            }
        }





        #region DataGridView Cliente
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




        /// ///LISTAR CLIENTE ACTIVOS EN EL DATAGRIDVIEW
        /*
        public void BuscarClientesDGVReserva(DataGridView dataGridView)
        {
            // Limpiamos las filas y columnas existentes en el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // Agregamos las columnas una vez fuera del bucle
            dataGridView.Columns.Add("IdCliente", "ID Cliente");
            dataGridView.Columns.Add("Nombre", "Nombre");
            dataGridView.Columns.Add("Apellido", "Apellido");
            dataGridView.Columns.Add("DNI", "DNI");
            dataGridView.Columns.Add("Telefono", "Telefono");

            // Obtener la lista de clientes cuya persona asociada tiene EstadoActivo = true
            List<ClienteBE> listaClientesActivos = con.Cliente.ToList().Where(c => c.Persona.EstadoActivo).ToList();

            // Iteramos sobre la lista de clientes activos y agregamos cada cliente al DataGridView
            foreach (var cliente in listaClientesActivos)
            {
                // Agregamos una fila al DataGridView
                int rowIndex = dataGridView.Rows.Add();

                dataGridView.Rows[rowIndex].Cells[0].Value = cliente.Id; // Suponiendo que "IdCliente" es la primera columna agregada
                dataGridView.Rows[rowIndex].Cells[1].Value = cliente.Persona.Nombre; // Suponiendo que "Nombre" es la segunda columna agregada
                dataGridView.Rows[rowIndex].Cells[2].Value = cliente.Persona.Apellido; // y así sucesivamente
                dataGridView.Rows[rowIndex].Cells[3].Value = cliente.Persona.DNI;
                dataGridView.Rows[rowIndex].Cells[4].Value = cliente.Persona.Telefono;
            }
        }*/

        /*
        public List<ClienteBE> ListarClientes()
        {
            return con.Cliente.ToList();
        }*/
        #endregion






        #region Validaciones para filtrar habitaciones y generar la reserva 

        public void FiltrarHabitaciones(string cbTipoHabitacion, string cbNroCamas, DataGridView dataGridViewHabitaciones)
        {
            // Recorremos todas las filas del DataGridView
            foreach (DataGridViewRow row in dataGridViewHabitaciones.Rows)
            {
                string tipoHabitacionFila = row.Cells["Tipo de Habitacion"].Value?.ToString() ?? ""; // Manejo de valores nulos
                string nroCamasFila = row.Cells["Camas"].Value?.ToString() ?? ""; // Manejo de valores nulos

                // Comparamos los valores de las filas con los valores seleccionados en los ComboBox
                bool tipoHabitacionCoincide = string.IsNullOrEmpty(cbTipoHabitacion) || tipoHabitacionFila == cbTipoHabitacion;
                bool nroCamasCoincide = string.IsNullOrEmpty(cbNroCamas) || nroCamasFila == cbNroCamas;

                if (tipoHabitacionCoincide && nroCamasCoincide)
                {
                    row.Visible = true; // Si hay coincidencia, mostramos la fila
                }
                else
                {
                    row.Visible = false; // Si no hay coincidencia, ocultamos la fila
                }
            }
        }
        #region Verificar Habitaciones -> frmAgregarReserva
        public void VerificarHabitacionesDisponibles(DateTimePicker fechaLlegadaDateTimePicker, DateTimePicker fechaIdaDateTimePicker, Label labelError)
        {
            // Obtener la fecha de llegada y la fecha de ida seleccionadas
            DateTime fechaLlegada = fechaLlegadaDateTimePicker.Value;
            DateTime fechaIda = fechaIdaDateTimePicker.Value;

            // Verificar si la fecha de llegada es menor que la fecha de ida
            if (fechaLlegada > fechaIda)
            {
                // Mostrar un mensaje de error o realizar alguna acción
                labelError.Text = "La fecha de llegada no puede ser mayor que la fecha de ida.";

            }
            if (fechaLlegada <= fechaIda)
            {
                // Mostrar un mensaje de error o realizar alguna acción
                labelError.Text = "";
                // Consultar las habitaciones disponibles para el rango de fechas seleccionado y los criterios de tipo de habitación y número de camas
                List<HabitacionBE> habitacionesDisponibles = ConsultarTodasHabitacionesDisponibles(fechaLlegada, fechaIda);

                if (habitacionesDisponibles == null || habitacionesDisponibles.Count == 0)
                {
                    labelError.Text = "No hay habitaciones disponibles para el rango de fechas seleccionado.";
                }


            }


        }

        public List<HabitacionBE> ConsultarTodasHabitacionesDisponibles(DateTime fechaLlegada, DateTime fechaIda)
        {
            List<HabitacionBE> habitacionesDisponibles = new List<HabitacionBE>();

            // Consultar las reservas que se superponen con el rango de fechas dado
            var reservasSuperpuestas = con.Reserva.Where(r => !(r.FechaLlegada >= fechaIda || r.FechaIda <= fechaLlegada)).ToList();

            // Obtener todas las habitaciones
            var todasLasHabitaciones = con.Habitacion.ToList();

            // Filtrar las habitaciones disponibles
            foreach (var habitacion in todasLasHabitaciones)
            {
                // Verificar si la habitación está disponible para el rango de fechas dado
                bool estaDisponible = !reservasSuperpuestas.Any(r => r.Habitacion.Id == habitacion.Id);


                // Si la habitación está disponible y cumple con los criterios de filtrado, se agrega a la lista de habitaciones disponibles
                if (estaDisponible )
                {
                    habitacionesDisponibles.Add(habitacion);
                }
            }

            return habitacionesDisponibles;
        }




        #endregion

        #region Verificar Habitaciones -> frmBuscarHabitacion
        public void filtrarHabitacionesDisponiblesDTP(DateTimePicker fechaLlegadaDateTimePicker, DateTimePicker fechaIdaDateTimePicker, string tipoHabitacion, string nroCamas, DataGridView dataGridViewHabitaciones, Label labelError)
        {
            // Obtener la fecha de llegada y la fecha de ida seleccionadas
            DateTime fechaLlegada = fechaLlegadaDateTimePicker.Value;
            DateTime fechaIda = fechaIdaDateTimePicker.Value;

            // Verificar si la fecha de llegada es menor que la fecha de ida
            if (fechaLlegada > fechaIda)
            {
                // Mostrar un mensaje de error o realizar alguna acción
                labelError.Text = "La fecha de llegada no puede ser mayor que la fecha de ida.";

            }
            if (fechaLlegada <= fechaIda)
            {
                // Mostrar un mensaje de error o realizar alguna acción
                labelError.Text = "";
                // Consultar las habitaciones disponibles para el rango de fechas seleccionado y los criterios de tipo de habitación y número de camas
                List<HabitacionBE> habitacionesDisponibles = ConsultarHabitacionesDisponibles(fechaLlegada, fechaIda, tipoHabitacion, nroCamas);

                // Mostrar las habitaciones disponibles en el DataGridView
                MostrarHabitacionesDisponibles(habitacionesDisponibles, dataGridViewHabitaciones, labelError);

            }


        }

        public List<HabitacionBE> ConsultarHabitacionesDisponibles(DateTime fechaLlegada, DateTime fechaIda, string tipoHabitacion, string nroCamas)
        {
            List<HabitacionBE> habitacionesDisponibles = new List<HabitacionBE>();

            // Consultar las reservas que se superponen con el rango de fechas dado
            var reservasSuperpuestas = con.Reserva.Where(r => !(r.FechaLlegada >= fechaIda || r.FechaIda <= fechaLlegada)).ToList();

            // Obtener todas las habitaciones
            var todasLasHabitaciones = con.Habitacion.ToList();

            // Filtrar las habitaciones disponibles
            foreach (var habitacion in todasLasHabitaciones)
            {
                // Verificar si la habitación está disponible para el rango de fechas dado
                bool estaDisponible = !reservasSuperpuestas.Any(r => r.Habitacion.Id == habitacion.Id);

                // Verificar si la habitación coincide con los criterios de filtrado de tipo de habitación y número de camas
                bool tipoHabitacionCoincide = string.IsNullOrEmpty(tipoHabitacion) || habitacion.TipoHabitacion == tipoHabitacion;
                bool nroCamasCoincide = string.IsNullOrEmpty(nroCamas) || habitacion.TipoCamas == nroCamas;

                // Si la habitación está disponible y cumple con los criterios de filtrado, se agrega a la lista de habitaciones disponibles
                if (estaDisponible && tipoHabitacionCoincide && nroCamasCoincide)
                {
                    habitacionesDisponibles.Add(habitacion);
                }
            }

            return habitacionesDisponibles;
        }


        public void MostrarHabitacionesDisponibles(List<HabitacionBE> habitaciones, DataGridView dataGridViewHabitaciones, Label labelError)
        {
            // Limpiar el DataGridView antes de mostrar las nuevas habitaciones
            dataGridViewHabitaciones.Rows.Clear();

            // Verificar si hay habitaciones disponibles para mostrar
            if (habitaciones.Count > 0)
            {
                labelError.Text = "";
                // Agregar cada habitación disponible al DataGridView
                foreach (var habitacion in habitaciones)
                {
                    dataGridViewHabitaciones.Rows.Add(habitacion.NroHabitacion, habitacion.TipoHabitacion, habitacion.TipoCamas, habitacion.PrecioDiario);
                }
            }
            else
            {
                // Si no hay habitaciones disponibles, puedes mostrar un mensaje o realizar alguna acción
                //MessageBox.Show("No hay habitaciones disponibles para el rango de fechas seleccionado.");
                labelError.Text = "No hay habitaciones disponibles para el rango de fechas seleccionado.";

            }
        }


        #endregion






        #region Verificar Habitaciones -> frmReservas


        public void DateTimePickerCambia2(DateTimePicker fechaLlegadaDateTimePicker, DateTimePicker fechaIdaDateTimePicker, string tipoHabitacion, string nroCamas, DataGridView dataGridViewHabitaciones, Label labelError)
        {
            // Obtener la fecha de llegada y la fecha de ida seleccionadas
            DateTime fechaLlegada = fechaLlegadaDateTimePicker.Value;
            DateTime fechaIda = fechaIdaDateTimePicker.Value;

            // Verificar si la fecha de llegada es menor que la fecha de ida
            if (fechaLlegada > fechaIda)
            {
                // Mostrar un mensaje de error o realizar alguna acción
                labelError.Text = "La fecha de llegada no puede ser mayor que la fecha de ida.";

            }
            if (fechaLlegada <= fechaIda)
            {
                // Mostrar un mensaje de error o realizar alguna acción
                labelError.Text = "";
                // Consultar las habitaciones disponibles para el rango de fechas seleccionado y los criterios de tipo de habitación y número de camas
                List<HabitacionBE> habitacionesDisponibles = ConsultarHabitacionesDisponibles2(fechaLlegada, fechaIda, tipoHabitacion, nroCamas);

                // Mostrar las habitaciones disponibles en el DataGridView
                MostrarHabitacionesDisponiblesEnDataGridView(habitacionesDisponibles, dataGridViewHabitaciones, labelError);

            }


        }


        public List<HabitacionBE> ConsultarHabitacionesDisponibles2(DateTime fechaLlegada, DateTime fechaIda, string tipoHabitacion, string nroCamas)
        {
            List<HabitacionBE> habitacionesDisponibles = new List<HabitacionBE>();

            // Consultar las reservas que se superponen con el rango de fechas dado
            var reservasSuperpuestas = con.Reserva.Where(r => !(r.FechaLlegada >= fechaIda || r.FechaIda <= fechaLlegada)).ToList();

            // Obtener todas las habitaciones
            var todasLasHabitaciones = con.Habitacion.ToList();

            // Filtrar las habitaciones disponibles
            foreach (var habitacion in todasLasHabitaciones)
            {
                // Verificar si la habitación está disponible para el rango de fechas dado
                bool estaDisponible = !reservasSuperpuestas.Any(r => r.Habitacion.Id == habitacion.Id);

                // Verificar si la habitación coincide con los criterios de filtrado de tipo de habitación y número de camas
                bool tipoHabitacionCoincide = string.IsNullOrEmpty(tipoHabitacion) || habitacion.TipoHabitacion == tipoHabitacion;
                bool nroCamasCoincide = string.IsNullOrEmpty(nroCamas) || habitacion.TipoCamas == nroCamas;

                // Si la habitación está disponible y cumple con los criterios de filtrado, se agrega a la lista de habitaciones disponibles
                if (estaDisponible && tipoHabitacionCoincide && nroCamasCoincide)
                {
                    habitacionesDisponibles.Add(habitacion);
                }
            }

            return habitacionesDisponibles;
        }


        public void MostrarHabitacionesDisponiblesEnDataGridView(List<HabitacionBE> habitaciones, DataGridView dataGridViewHabitaciones, Label labelError)
        {
            // Limpiar el DataGridView antes de mostrar las nuevas habitaciones
            dataGridViewHabitaciones.Rows.Clear();

            // Verificar si hay habitaciones disponibles para mostrar
            if (habitaciones.Count > 0)
            {
                labelError.Text = "";
                // Agregar cada habitación disponible al DataGridView
                foreach (var habitacion in habitaciones)
                {
                    dataGridViewHabitaciones.Rows.Add(habitacion.Id, habitacion.NroHabitacion, habitacion.TipoHabitacion, habitacion.Estado, habitacion.Piso, habitacion.PrecioDiario, habitacion.TipoCamas);
                }
            }
            else
            {
                // Si no hay habitaciones disponibles, puedes mostrar un mensaje o realizar alguna acción
                labelError.Text = "No hay habitaciones disponibles para el rango de fechas seleccionado.";

            }
        }

        #endregion


        #endregion



        #region Listar en DGView
        public void ListarReservasPendientesEnDataGridView(DataGridView dataGridView)
        {
            // Limpiamos las filas existentes en el DataGridView
            dataGridView.Rows.Clear();

            dataGridView.Columns.Clear();
            



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



            List<ReservaBE> listaReservas = con.Reserva.ToList().Where(c => c.Estado == "Pendiente").ToList();

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
 
            dataGridView.Rows.Clear();

            dataGridView.Columns.Clear();
            


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



            List<ReservaBE> listaReservas = con.Reserva.ToList().Where(c => c.Estado == "Activa").ToList();

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



            List<ReservaBE> listaReservas = con.Reserva.ToList().Where(c => c.Estado == "Finalizada").ToList();

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
            dataGridView.Rows.Clear();

            dataGridView.Columns.Clear();
            


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


       






        #region Metodo Chart Bastones Reservas por Dia del Mes
        public Dictionary<int, int> ContarReservasPorDiaDelMes()
        {
            DateTime fechaActual = DateTime.Now;
            DateTime primerDiaDelMes = new DateTime(fechaActual.Year, fechaActual.Month, 1);
            DateTime ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

            

            List<ReservaBE> reservasDelMes = con.Reserva
            .Where(r =>
            // La reserva comienza antes o durante el mes actual
            (r.FechaLlegada <= ultimoDiaDelMes && r.FechaIda >= primerDiaDelMes) ||
            // La reserva termina después o durante el mes actual
            (r.FechaIda >= primerDiaDelMes && r.FechaIda <= ultimoDiaDelMes))
            .ToList();

            Dictionary<int, int> reservasPorDia = new Dictionary<int, int>();

            for (int dia = 1; dia <= ultimoDiaDelMes.Day; dia++)
            {
                reservasPorDia.Add(dia, 0);
            }

            foreach (var reserva in reservasDelMes)
            {
                DateTime fechaInicio = reserva.FechaLlegada > primerDiaDelMes ? reserva.FechaLlegada : primerDiaDelMes;
                DateTime fechaFin = reserva.FechaIda < ultimoDiaDelMes ? reserva.FechaIda : ultimoDiaDelMes;

                for (DateTime fecha = fechaInicio; fecha <= fechaFin; fecha = fecha.AddDays(1))
                {
                    int diaReserva = fecha.Day;
                    reservasPorDia[diaReserva]++;
                }
            }

            return reservasPorDia;
        }

        #endregion








        #region Metodo Chart Circular Estado actual de las habitaciones

        public List<HabitacionBE> ObtenerHabitacionesDesdeBaseDeDatos()
        {
            // Aquí suponemos que "con" es tu contexto de base de datos
            // Puedes reemplazar "con" con el nombre real de tu contexto
            using (var contexto = new ContextoBD())
            {
                try
                {
                    // Consulta para obtener las habitaciones desde la base de datos
                    List<HabitacionBE> habitaciones = con.Habitacion.ToList();
                    return habitaciones;
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones si ocurre algún error al acceder a la base de datos
                    Console.WriteLine("Error al obtener las habitaciones desde la base de datos: " + ex.Message);
                    return null; // O devuelve una lista vacía o lanza una excepción según lo que necesites
                }
            }
        }





        public Tuple<List<string>, List<int>> PrepararDatosParaGrafico(List<HabitacionBE> habitaciones)
        {
            var estadoHabitaciones = habitaciones.GroupBy(h => h.Estado)
                                                 .Select(g => new { Estado = g.Key, Cantidad = g.Count() })
                                                 .ToList();

            List<string> estados = new List<string>();
            List<int> cantidades = new List<int>();

            foreach (var estadoHabitacion in estadoHabitaciones)
            {
                estados.Add(estadoHabitacion.Estado);
                cantidades.Add(estadoHabitacion.Cantidad);
            }

            return Tuple.Create(estados, cantidades);
        }






        public void CargarDatosChart(Chart chartPIE)
        {
            // Limpia los puntos existentes en el Chart
            chartPIE.Series[0].Points.Clear();

            // Consulta a la base de datos para obtener la cantidad de habitaciones en cada estado
            int totalHabitaciones = con.Habitacion.Count();
            int habitacionesDisponibles = con.Habitacion.Where(h => h.Estado == "Disponible").Count();
            int habitacionesOcupadas = con.Habitacion.Where(h => h.Estado == "Ocupado").Count();
            int habitacionesLimpieza = con.Habitacion.Where(h => h.Estado == "Limpieza").Count();

            // Calcula los porcentajes
            double porcentajeDisponibles = Math.Round((double)habitacionesDisponibles / totalHabitaciones * 100);
            double porcentajeOcupadas = Math.Round((double)habitacionesOcupadas / totalHabitaciones * 100);
            double porcentajeLimpieza = Math.Round((double)habitacionesLimpieza / totalHabitaciones * 100);


            // Agrega los datos al Chart
            chartPIE.Series[0].Points.AddXY($"Disponible {porcentajeDisponibles}%", porcentajeDisponibles);
            chartPIE.Series[0].Points.AddXY($"Ocupada {porcentajeOcupadas}%", porcentajeOcupadas);
            chartPIE.Series[0].Points.AddXY($"Limpieza {porcentajeLimpieza}%", porcentajeLimpieza);

            // Configura los colores de los segmentos del Chart
            chartPIE.Series[0].Points[0].Color = Color.Lime; // Color para "Disponible"
            chartPIE.Series[0].Points[1].Color = Color.OrangeRed;   // Color para "Ocupada"
            chartPIE.Series[0].Points[2].Color = Color.Cyan;  // Color para "Limpieza"

            
        }








        #endregion








        #region Metodo TextBox Dinero realizado hasta fin de mes
        
        public decimal CalcularGananciaFuturaAproximada()
        {


            using (var con = new ContextoBD())
            {
                try
                {
                    //SAca los dias del mes
                    DateTime fechaActual = DateTime.Now;
                    DateTime primerDiaDelMes = new DateTime(fechaActual.Year, fechaActual.Month, 1);
                    DateTime ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

                    decimal PrecioTotalReservas = 0;

                    List<ReservaBE> reservasActivas = ObtenerReservasActivasMes(primerDiaDelMes, ultimoDiaDelMes);
                    

                    foreach (var reserva in reservasActivas)
                    {

                        DateTime fechaInicio = reserva.FechaLlegada > primerDiaDelMes ? reserva.FechaLlegada : primerDiaDelMes;
                        DateTime fechaFin = reserva.FechaIda < ultimoDiaDelMes ? reserva.FechaIda : ultimoDiaDelMes;
                        

                        int Dias = Convert.ToInt32((fechaFin - fechaInicio).TotalDays);
                        PrecioTotalReservas += reserva.Habitacion.PrecioDiario * Dias;
                    }


                    return PrecioTotalReservas;
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones si ocurre algún error al acceder a la base de datos
                    Console.WriteLine("Error al obtener las reservas activas para el día especificado: " + ex.Message);
                    return 0; ; // Devuelve una lista vacía en caso de error
                }
            }



        }


        private List<ReservaBE> ObtenerReservasActivasMes(DateTime primerDiaDelMes, DateTime ultimoDiaDelMes)
        {
            using (var contexto = new ContextoBD())
            {
                try
                {
                    List<ReservaBE> reservasActivasMes = con.Reserva
                        .Include(r => r.Habitacion) // Cargar la relación Habitacion
                        .Where(r => r.Estado == "Activa" &&
                                    ((r.FechaLlegada <= ultimoDiaDelMes && r.FechaIda >= primerDiaDelMes) ||
                                    (r.FechaIda >= primerDiaDelMes && r.FechaIda <= ultimoDiaDelMes)))
                        .ToList();

                    return reservasActivasMes;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las reservas activas del mes: " + ex.Message);
                    return new List<ReservaBE>();
                }
            }
        }









        //Obtener los pedidos de las reservas que vencen desntro de este mes
        private float ObtenerPedidosFinMes(DateTime primerDiaDelMes, DateTime ultimoDiaDelMes)
        {
            using (var contexto = new ContextoBD())
            {
                try
                {
                    float TotalGanancia = 0;


                    List<PedidoBE> pedidosVencenMesActual = con.Pedido.Where(p => p.Estado == "PagoPendiente" && p.Reserva.Estado == "Activa" && (p.Reserva.FechaIda >= primerDiaDelMes && p.Reserva.FechaIda <= ultimoDiaDelMes)).ToList();

                    foreach (var pedido in pedidosVencenMesActual)
                    {
                        TotalGanancia = +(float)pedido.Total;
                    }

                    return TotalGanancia;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los pedidos activos del mes: " + ex.Message);
                    return -101;
                }
            }
        }

        public float Prueba()
        {


            using (var contexto = new ContextoBD())
            {
                try
                {
                    //SAca los dias del mes
                    DateTime fechaActual = DateTime.Now;
                    DateTime primerDiaDelMes = new DateTime(fechaActual.Year, fechaActual.Month, 1);
                    DateTime ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

                    float PrecioTotalReservas = 0;

                    List<ReservaBE> reservasActivas = ObtenerReservasActivasMes(primerDiaDelMes, ultimoDiaDelMes);


                    foreach (var reserva in reservasActivas)
                    {

                        DateTime fechaInicio = reserva.FechaLlegada > primerDiaDelMes ? reserva.FechaLlegada : primerDiaDelMes;
                        DateTime fechaFin = reserva.FechaIda < ultimoDiaDelMes ? reserva.FechaIda : ultimoDiaDelMes;

                        int Dias = Convert.ToInt32((fechaFin - fechaInicio).TotalDays);
                        PrecioTotalReservas += (float)reserva.Habitacion.PrecioDiario * Dias;
                    }
                    float totalPedidos = ObtenerPedidosFinMes(primerDiaDelMes, ultimoDiaDelMes);

                    return PrecioTotalReservas + totalPedidos;
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones si ocurre algún error al acceder a la base de datos
                    Console.WriteLine("Error al obtener las reservas activas para el día especificado: " + ex.Message);
                    return -101; ; // Devuelve una lista vacía en caso de error
                }
            }



        }

        #endregion






        #region ProgressBar Estado de reservas


        public void MostrarProgresBar(ProgressBar pbarDisponible, Label lblDisponible, ProgressBar pbarOcupadas, Label lblOcupadas, ProgressBar pbarLimpieza, Label lblLimpieza)
        {
            using (var contexto = new ContextoBD())
            {

                int totalHabitaciones = con.Habitacion.Count();

                int habitacionesDisponibles = con.Habitacion.Where(h => h.Estado == "Disponible").Count();
                int habitacionesOcupadas = con.Habitacion.Where(h => h.Estado == "Ocupado").Count();
                int habitacionesLimpieza = con.Habitacion.Where(h => h.Estado == "Limpieza").Count();

                pbarDisponible.Maximum = totalHabitaciones;
                pbarDisponible.Value = habitacionesDisponibles;
                pbarDisponible.ForeColor = Color.Lime;
                lblDisponible.Text = habitacionesDisponibles.ToString();

                pbarOcupadas.Maximum = totalHabitaciones;
                pbarOcupadas.Value = habitacionesOcupadas;
                pbarOcupadas.ForeColor = Color.OrangeRed;
                lblOcupadas.Text = habitacionesOcupadas.ToString();

                pbarLimpieza.Maximum = totalHabitaciones;
                pbarLimpieza.Value = habitacionesLimpieza;
                pbarLimpieza.ForeColor = Color.Cyan;
                lblLimpieza.Text = habitacionesLimpieza.ToString();

            }
        }

        #endregion








        public void VerificarCancelacionReservas()
        {
            //En todo cado cambiar por si a la mitad de la estadia sigue pendiente (  && fechalleagda > fechalleagda.AddDays(fechallegada-fechaIda) /2 )

            List<ReservaBE> listaReservas = new List<ReservaBE>();

            listaReservas = con.Reserva.Where(h => h.Estado == "Pendiente" && h.FechaIda < DateTime.Now).ToList();

            foreach (var reserva in listaReservas)
            {
                reserva.Estado = "Cancelada";
                con.SaveChanges();

            }
        }



























    }
}




























//Creado por Sebastian Febre
// https://github.com/sebafebre