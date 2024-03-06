using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo
{
    public class EmpleadoDAL
    {
        //ContextoBD con = new ContextoBD();
        ContextoBD con = new ContextoBD();


        #region Agregar Modificar ELiminar Clientes
        //Funcion para guardar un cliente en la base de datos
        public string AgregarEmpleado(EmpleadoBE empleado)
        {
            try
            {
                con.Empleado.Add(empleado);
                con.SaveChanges();
                return "Empleado agregado correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo agregar el empleado. " + ex.Message;
            }
        }



        //Funcion para eliminar un cliente de la base de datos
        public string EliminarEmpleado(EmpleadoBE empleado)
        {
            try
            {
                // Obtener el cliente que se va a "eliminar"
                EmpleadoBE empleadoEliminar = con.Empleado.FirstOrDefault(c => c.Id == empleado.Id);
                if (empleadoEliminar != null)
                {
                    // Obtener el ID de la persona asociada
                    int IDpersonaEliminar = empleadoEliminar.Persona.Id;

                    // Marcar el estado de activo del cliente como falso
                    empleadoEliminar.Persona.EstadoActivo = false;

                    // Guardar los cambios en el cliente
                    con.SaveChanges();

                    // Buscar y "eliminar" la persona asociada
                    PersonaBE personaEliminar = con.Persona.FirstOrDefault(p => p.Id == IDpersonaEliminar);
                    if (personaEliminar != null)
                    {
                        // Marcar el estado de activo de la persona como falso
                        personaEliminar.EstadoActivo = false;

                        // Guardar los cambios en la persona
                        con.SaveChanges();
                    }

                    return "Empelado y persona asociada están con Estado Inactivo = 'False'";
                }
                else
                {
                    return "No se encontró el empleado a 'eliminar'";
                }
            }
            catch (Exception ex)
            {
                return "No se pudo 'eliminar' el empleado y la persona asociada. " + ex.Message;
            }
        }



        //Funcion para modificar un cliente de la base de datos
        public string ModificarEmpleado(EmpleadoBE empleado)
        {
            //Obtener empleado con la funcion ObtenerCliente
            EmpleadoBE empleadoModificar = con.Empleado.Find(empleado.Id);

            //Ahora modificar el cliente
            empleadoModificar.Persona.Nombre = empleado.Persona.Nombre;
            empleadoModificar.Persona.Apellido = empleado.Persona.Apellido;
            empleadoModificar.Persona.DNI = empleado.Persona.DNI;
            empleadoModificar.Persona.Direccion = empleado.Persona.Direccion;
            empleadoModificar.Persona.Telefono = empleado.Persona.Telefono;
            empleadoModificar.Persona.Mail = empleado.Persona.Mail;
            empleadoModificar.Persona.FechaNacimiento = empleado.Persona.FechaNacimiento;
            empleadoModificar.FechaIngreso = empleado.FechaIngreso;
            empleadoModificar.Cargo = empleado.Cargo;
            empleadoModificar.Puesto = empleado.Puesto;


            try
            {
                con.SaveChanges();
                return "Empleado modificado correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo modificar el empleado. " + ex.Message;
            }
        }
        #endregion




        #region Metodos para el DataGridView
        //Listar los clientes para ponerlos en el data grid view y los datos de las Persona correspondiente a ese cliente
        public void ListarEmpleadosEnDGV(DataGridView dataGridView)
        {
            // Limpiamos las filas y columnas existentes en el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // Agregamos las columnas una vez fuera del bucle

            dataGridView.Columns.Add("IdEmpleado", "ID Empleado");
            dataGridView.Columns.Add("Nombre", "Nombre");
            dataGridView.Columns.Add("Apellido", "Apellido");
            dataGridView.Columns.Add("DNI", "DNI");
            dataGridView.Columns.Add("Direccion", "Direccion");
            dataGridView.Columns.Add("Telefono", "Telefono");
            dataGridView.Columns.Add("Mail", "Mail");
            dataGridView.Columns.Add("Fecha de Nacimiento", "Fecha de Nacimiento");
            dataGridView.Columns.Add("Puesto", "Puesto");
            dataGridView.Columns.Add("Cargo", "Cargo");
            dataGridView.Columns.Add("Fecha de Ingreso", "Fecha de Ingreso");


            // Obtener la lista de clientes cuya persona asociada tiene EstadoActivo = true
            List<EmpleadoBE> listaEmpleadosActivos = con.Empleado.ToList().Where(c => c.Persona.EstadoActivo).ToList();

            // Iteramos sobre la lista de clientes activos y agregamos cada cliente al DataGridView
            foreach (var empleado in listaEmpleadosActivos)
            {
                // Agregamos una fila al DataGridView
                int rowIndex = dataGridView.Rows.Add();

                dataGridView.Rows[rowIndex].Cells[0].Value = empleado.Id; // Suponiendo que "IdCliente" es la primera columna agregada
                dataGridView.Rows[rowIndex].Cells[1].Value = empleado.Persona.Nombre; // Suponiendo que "Nombre" es la segunda columna agregada
                dataGridView.Rows[rowIndex].Cells[2].Value = empleado.Persona.Apellido; // y así sucesivamente
                dataGridView.Rows[rowIndex].Cells[3].Value = empleado.Persona.DNI;
                dataGridView.Rows[rowIndex].Cells[4].Value = empleado.Persona.Direccion;
                dataGridView.Rows[rowIndex].Cells[5].Value = empleado.Persona.Telefono;
                dataGridView.Rows[rowIndex].Cells[6].Value = empleado.Persona.Mail;
                dataGridView.Rows[rowIndex].Cells[7].Value = empleado.Persona.FechaNacimiento;
                dataGridView.Rows[rowIndex].Cells[8].Value = empleado.Puesto;
                dataGridView.Rows[rowIndex].Cells[9].Value = empleado.Cargo;
                dataGridView.Rows[rowIndex].Cells[10].Value = empleado.FechaIngreso;


            }
        }

        #endregion




        //BuscarClientePorDNI
        public void BuscarEmpleadoPorDNI(string dni, DataGridView dgvClientes)
        {
            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                if (row.Cells["DNI"].Value != null && row.Cells["DNI"].Value.ToString() == dni)
                {
                    row.Selected = true;
                    dgvClientes.CurrentCell = row.Cells[0];
                    return; // Termina la búsqueda una vez que se encuentra el cliente
                }
            }

            // Si no se encuentra el cliente, puedes mostrar un mensaje o realizar alguna acción adicional.
            
        }
    }
}
