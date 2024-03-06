using Controladora;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Paneles.Reservas
{
    public partial class frmBuscarHabitacion : Form
    {
        HabitacionBLL habitacionBLL = new HabitacionBLL();
        ReservaBLL reservaBLL = new ReservaBLL();
        public frmBuscarHabitacion()
        {
            InitializeComponent();
            habitacionBLL.BuscarHabitacionDGV(dgvHabitaciones);

            //reservaBLL.DateTimePickerCambia2(dtpFechaLlegada, dtpFechaIda, cbTipoHabitacion.Text, cbNroCamas.Text, dgvHabitaciones, lblError);
        }

        // Propiedad para almacenar el cliente seleccionado
        public HabitacionBE HabitacionSeleccionado { get; private set; }

        // Método para procesar la selección del usuario y cerrar el formulario
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Obtener el cliente seleccionado del DataGridView
            HabitacionSeleccionado = ObtenerHabitacionSeleccionado();

            // Cerrar el formulario
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Método para obtener el cliente seleccionado del DataGridView
        private HabitacionBE ObtenerHabitacionSeleccionado()
        {
            HabitacionBE habitacionSeleccionado = null;

            // Verificar si hay al menos una fila seleccionada en el DataGridView
            if (dgvHabitaciones.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dgvHabitaciones.SelectedRows[0];

                // Obtener los valores de las celdas de la fila seleccionada
                int idCliente = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value); // Suponiendo que la columna que contiene el Id se llama "Id"
                string nombreCliente = Convert.ToString(filaSeleccionada.Cells["Nombre"].Value); // Suponiendo que la columna que contiene el nombre se llama "Nombre"
                                                                                                 // Aquí debes obtener los valores de las otras columnas según corresponda

                // Crear un nuevo objeto Cliente con los valores obtenidos
                //habitacionSeleccionado = new HabitacionBE(idCliente, nombreCliente /*, otros valores */);
            }

            return habitacionSeleccionado;
        }
    }
}
