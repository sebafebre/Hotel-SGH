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
        ValidacionesBLL validacionesBLL = new ValidacionesBLL();

        private ClienteBE clienteCreado;

        int DNI = 0;

        public frmBuscarCliente()
        {
            InitializeComponent();
            clienteBLL.ListarClientesActivosEnDataGridView(dgvClientes);
            
        }


       
        public ClienteBE ClienteSeleccionado { get; private set; }


        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (DNI != 0)
            {
                
                ClienteSeleccionado = new ClienteBE();
                ClienteSeleccionado.Persona = new PersonaBE(); 
                ClienteSeleccionado.Persona.DNI = DNI;

                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente antes de continuar.");
            }

            
        }
        
        

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvClientes.CurrentRow != null)
                {
                    txtBuscarDNI.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                    DNI = Convert.ToInt32(dgvClientes.CurrentRow.Cells[3].Value);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        

        private void txtBuscarDNI_TextChanged(object sender, EventArgs e)
        {
            validacionesBLL.BuscarPorDNI(txtBuscarDNI.Text, dgvClientes);
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            frmCrearCliente crearClienteForm = new frmCrearCliente();
            crearClienteForm.ShowDialog(); 

            
            if (crearClienteForm.ClienteCreado != null)
            {
                this.clienteCreado = crearClienteForm.ClienteCreado;
                txtBuscarDNI.Text = clienteCreado.Persona.DNI.ToString();
                DNI = clienteCreado.Persona.DNI;

            }
        }
    }
}
