using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo
{
    public class HabitacionesDAL
    {
        //ContextoBD con = new ContextoBD();
        ContextoBD con = new ContextoBD();

        #region ABM Habitacion
        public void AgregarHabitacion(HabitacionBE habitacion)
        {

            try
            {
                if (ExisteHabitacionEnPiso(habitacion.Piso, habitacion.NroHabitacion))
                {
                    MessageBox.Show("Ya existe una habitación con el número " + habitacion.NroHabitacion + " en el piso " + habitacion.Piso);
                    //return; // Salir del método sin agregar la habitación
                }
                else
                {
                    con.Habitacion.Add(habitacion);
                    con.SaveChanges();
                    MessageBox.Show("Habitacion agregada correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar la habitacion. ");
                //   return "No se pudo agregar la habitacion. " + ex.Message;

            }
        }

        public bool ExisteHabitacionEnPiso(int numeroPiso, int numeroHabitacion)
        {

            var habitacionExistente = con.Habitacion
                .FirstOrDefault(h => h.Piso == numeroPiso && h.NroHabitacion == numeroHabitacion);

            return habitacionExistente != null; // Devuelve true si la habitación existe, false si no existe.
        }



        //Eliminar habitacion
        public string EliminarHabitacion(HabitacionBE habitacion)
        {
            try
            {

                HabitacionBE habitacionEliminar = con.Habitacion.FirstOrDefault(h => h.Id == habitacion.Id);
                if (habitacionEliminar != null)
                {
                    con.Habitacion.Remove(habitacionEliminar);
                    // Guardar los cambios en la habitacion
                    con.SaveChanges();
                    return "Habitacion eliminada correctamente";
                }
                else
                {
                    return "No se pudo eliminar la habitacion";
                }
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar la habitacion. " + ex.Message;
            }
        }

        //Modificar habitacion
        public string ModificarHabitacion(HabitacionBE habitacion)
        {
            try
            {
                HabitacionBE habitacionModificar = con.Habitacion.FirstOrDefault(h => h.Id == habitacion.Id);
                if (habitacionModificar != null)
                {
                    habitacionModificar.Id = habitacion.Id;
                    habitacionModificar.NroHabitacion = habitacion.NroHabitacion;
                    habitacionModificar.Piso = habitacion.Piso;
                    habitacionModificar.TipoHabitacion = habitacion.TipoHabitacion;
                    habitacionModificar.Estado = habitacion.Estado;
                    habitacionModificar.PrecioDiario = habitacion.PrecioDiario;
                    habitacionModificar.TipoCamas = habitacion.TipoCamas;
                    con.SaveChanges();
                    return "Habitacion modificada correctamente";
                }
                else
                {
                    return "No se pudo modificar la habitacion";
                }
            }
            catch (Exception ex)
            {
                return "No se pudo modificar la habitacion. " + ex.Message;
            }
        }

        #endregion



        #region Listar Habitaciones en DataGridView

        //Listar las Habitaciones para ponerlos en el data grid view 
        public void ListarHabitacionesEnDataGridView(DataGridView dataGridView)
        {
            // Limpiamos las filas existentes en el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // Obtener la lista de las Habitaciones
            List<HabitacionBE> listaHabitaciones = con.Habitacion.ToList();

            // Iteramos sobre la lista de clientes activos y agregamos cada cliente al DataGridView

            dataGridView.Columns.Add("IdHabitacion", "ID Habitacion");
            dataGridView.Columns.Add("Nro de Habitacion", "Nro de Habitacion");
            dataGridView.Columns.Add("Piso", "Piso");
            dataGridView.Columns.Add("Tipo de Habitacion", "Tipo de Habitacion");
            dataGridView.Columns.Add("Estado", "Estado");
            dataGridView.Columns.Add("Precio Diario", "Precio Diario");
            dataGridView.Columns.Add("Camas", "Camas");
            
            foreach (var habitacion in listaHabitaciones)
            {
                // Agregamos una fila al DataGridView
                int rowIndex = dataGridView.Rows.Add();

                dataGridView.Rows[rowIndex].Cells[0].Value = habitacion.Id; // Suponiendo que "IdCliente" es la primera columna agregada
                dataGridView.Rows[rowIndex].Cells[1].Value = habitacion.NroHabitacion; // Suponiendo que "Nombre" es la segunda columna agregada
                dataGridView.Rows[rowIndex].Cells[2].Value = habitacion.Piso; // y así sucesivamente
                dataGridView.Rows[rowIndex].Cells[3].Value = habitacion.TipoHabitacion;
                dataGridView.Rows[rowIndex].Cells[4].Value = habitacion.Estado;
                dataGridView.Rows[rowIndex].Cells[5].Value = habitacion.PrecioDiario;
                dataGridView.Rows[rowIndex].Cells[6].Value = habitacion.TipoCamas;
            }
        }


        public void BuscarHabitacionDGV(DataGridView dataGridView)
        {
            // Limpiamos las filas existentes en el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // Obtener la lista de las Habitaciones
            List<HabitacionBE> listaHabitaciones = con.Habitacion.ToList();

            // Iteramos sobre la lista de clientes activos y agregamos cada cliente al DataGridView

            dataGridView.Columns.Add("Nro de Habitacion", "Nro de Habitacion");
            dataGridView.Columns.Add("Piso", "Piso");
            dataGridView.Columns.Add("Tipo de Habitacion", "Tipo de Habitacion");
            dataGridView.Columns.Add("Camas", "Camas");
            dataGridView.Columns.Add("Precio Diario", "Precio Diario");

            foreach (var habitacion in listaHabitaciones)
            {
                // Agregamos una fila al DataGridView
                int rowIndex = dataGridView.Rows.Add();

                dataGridView.Rows[rowIndex].Cells[0].Value = habitacion.NroHabitacion; // Suponiendo que "Nombre" es la segunda columna agregada
                dataGridView.Rows[rowIndex].Cells[1].Value = habitacion.Piso; // y así sucesivamente
                dataGridView.Rows[rowIndex].Cells[2].Value = habitacion.TipoHabitacion;
                dataGridView.Rows[rowIndex].Cells[3].Value = habitacion.PrecioDiario;
                dataGridView.Rows[rowIndex].Cells[4].Value = habitacion.TipoCamas;
            }
        }

        #endregion





        public string ObtenerEstadoSeleccionado(Control flowLayoutPanel)
        {
            foreach (Control control in flowLayoutPanel.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    // Devuelve el texto del RadioButton seleccionado como estado.
                    return radioButton.Text;
                }
            }
            // Si no se encontró ningún RadioButton seleccionado, puedes devolver un estado predeterminado o lanzar una excepción.
            return null;
        }
        
        
        
        
        
        
        
        
        
        
        
        
        


        /*
        //Mostrar datos en el DataGridView
        public List<HabitacionBE> ListarHabitaciones()
        {
            return con.Habitacion.ToList();
        }



        

        public HabitacionBE ObtenerHabitacion(int idHabitacion)
        {
            return con.Habitacion.Find(idHabitacion);
        }
        */




        /*
        //Calcular proximo Id
        public int ProximoId()
        {
            //return con.Habitacion.Max(h => h.Id) + 1;

            return con.Habitacion.Any() ? con.Habitacion.Max(h => h.Id) + 1 : 1;

        }*/
    }
}
