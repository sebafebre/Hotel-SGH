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

namespace Vista.Paneles.Reservas
{
    public partial class frmBuscarCliente : Form
    {
        ClienteBLL clienteBLL = new ClienteBLL();
        public frmBuscarCliente()
        {
            InitializeComponent();
            clienteBLL.ListarClientesActivosEnDataGridView(dgvClientes);
        }


        // Propiedad para almacenar el cliente seleccionado
        public ClienteBE ClienteSeleccionado { get; private set; }

        /*// Método para procesar la selección del usuario y cerrar el formulario
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Obtener el cliente seleccionado del DataGridView
            ClienteSeleccionado = ObtenerClienteSeleccionado();

            // Cerrar el formulario
            this.DialogResult = DialogResult.OK;
            this.Close();
        }*/

        /*// Método para obtener el cliente seleccionado del DataGridView
        private ClienteBE ObtenerClienteSeleccionado()
        {
            ClienteBE clienteSeleccionado = null;

            // Verificar si hay al menos una fila seleccionada en el DataGridView
            if (dgvClientes.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dgvClientes.SelectedRows[0];

                // Obtener los valores de las celdas de la fila seleccionada
                int idCliente = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value); // Suponiendo que la columna que contiene el Id se llama "Id"
                string nombreCliente = Convert.ToString(filaSeleccionada.Cells["Nombre"].Value); // Suponiendo que la columna que contiene el nombre se llama "Nombre"
                                                                                                 // Aquí debes obtener los valores de las otras columnas según corresponda

                // Crear un nuevo objeto Cliente con los valores obtenidos
                //clienteSeleccionado = new ClienteBE(idCliente, nombreCliente );
            }

            return clienteSeleccionado;
        }*/

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            // Verifica si se seleccionó un cliente en el DataGridView
            if (dgvClientes.SelectedRows.Count > 0)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow filaSeleccionada = dgvClientes.SelectedRows[0];

                // Obtén la información del cliente seleccionado de la fila del DataGridView
                ClienteSeleccionado = new ClienteBE
                {
                    // Suponiendo que las columnas 0 y 1 representan el ID y el nombre del cliente respectivamente
                    Id = Convert.ToInt32(filaSeleccionada.Cells[0].Value),
                    Nombre = filaSeleccionada.Cells[1].Value.ToString(),
                    // Añade más propiedades del cliente según sea necesario
                };

                // Cierra el formulario frmBuscarCliente
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente antes de continuar.");
            }
        }
    }
}
