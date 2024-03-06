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
using Vista.Paneles.Reservas;

namespace Vista.Paneles
{
    public partial class frmAgregarReserva : Form
    {
        ClienteBLL clienteBLL = new ClienteBLL();
        ReservaBLL reservaBLL = new ReservaBLL();

        private frmClienteReserva frmCliente;
        public frmAgregarReserva()
        {
            InitializeComponent();
           // abrirPanelCliente();
        }

        

        /*
        private void abrirPanelCliente()
        {
            // Expandir o contraer el formulario principal según el estado del checkbox
            if (cbNuevoCliente.Checked == true)
            {
                //Height = 1080;
                Width = 1080;
                panelFrmCliente.Visible = true;

                // Establece la altura deseada
                //frmCliente.Show(); // Muestra el formulario existente
            }
            else
            {
                //Height = 540;
                Width = 520;
                panelFrmCliente.Visible = false;

                // Establece la altura original
                //frmCliente.Hide(); // Oculta el formulario existente
            }
        }
        */

        private void frmAgregarReserva_Load(object sender, EventArgs e)
        {
         
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarCliente buscarClienteForm = new frmBuscarCliente();
            buscarClienteForm.ShowDialog(); // Abre el formulario de búsqueda de cliente como un cuadro de diálogo

            // Verifica si se seleccionó un cliente y si sí, actualiza los datos en el formulario frmReservas
            if (buscarClienteForm.ClienteSeleccionado != null)
            {
                // Actualiza los datos del formulario frmReservas con la información del cliente seleccionado
                txtNombreCliente.Text = buscarClienteForm.ClienteSeleccionado.Nombre;
                // Asigna más propiedades del cliente según sea necesario
            }
        }

        private void btnBuscarHabitacion_Click(object sender, EventArgs e)
        {

        }
    }
}
