using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladora;
using Entidades;

namespace Vista.Paneles
{
    public partial class frmClientes : Form
    {

        ClienteBLL clienteBLL = new ClienteBLL();
        ValidacionesBLL validacionesBLL = new ValidacionesBLL();

        public frmClientes()
        {
            InitializeComponent();
            clienteBLL.ListarClientesActivosEnDataGridView(dgvClientes);
        }


        #region AMB Cliente
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "")
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar el cliente?", "Eliminar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ClienteBE cliente = new ClienteBE();
                        cliente.Persona = new PersonaBE();
                        cliente.Id = Convert.ToInt32(txtID.Text);
                        clienteBLL.EliminarCliente(cliente);

                        MessageBox.Show("Cliente eliminado correctamente", "Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un cliente", "Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                clienteBLL.ListarClientesActivosEnDataGridView(dgvClientes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {   
                if(ValidarCampos())
                {
                    ClienteBE cliente = new ClienteBE();
                    cliente.Persona = new PersonaBE();
                    //cliente.Id = Convert.ToInt32(txtID.Text);
                    cliente.Persona.EstadoActivo = true;
                    cliente.Persona.Nombre = txtNombre.Text;
                    cliente.Persona.Apellido = txtApellido.Text;
                    cliente.Persona.DNI = txtDNI.Text;
                    cliente.Persona.Direccion = txtDireccion.Text;
                    cliente.Persona.Telefono = txtTelefono.Text;
                    cliente.Persona.Mail = txtMail.Text;
                    cliente.Persona.FechaNacimiento = dtpFechaNacimiento.Value;
                    cliente.FechaDeAlta = DateTime.Now;

                    string resultado = clienteBLL.AgregarCliente(cliente);
                    MessageBox.Show(resultado);

                    //this.clienteTableAdapter.Fill(this.sGHDataSet.Cliente);

                    clienteBLL.ListarClientesActivosEnDataGridView(dgvClientes);
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos", "Agregar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "")
                {
                    if(ValidarCampos())
                    {
                        ClienteBE cliente = new ClienteBE();
                 
                        cliente.Persona = new PersonaBE();
                        cliente.Id = Convert.ToInt32(txtID.Text);
                        cliente.Persona.Nombre = txtNombre.Text;
                        cliente.Persona.Apellido = txtApellido.Text;
                        cliente.Persona.DNI = txtDNI.Text;
                        cliente.Persona.Direccion = txtDireccion.Text;
                        cliente.Persona.Telefono = txtTelefono.Text;
                        cliente.Persona.Mail = txtMail.Text;
                        cliente.Persona.FechaNacimiento = dtpFechaNacimiento.Value;
                        cliente.FechaDeAlta = DateTime.Now;
                        clienteBLL.ModificarCliente(cliente);
                        validacionesBLL.LimpiarCampos(this.Controls);
                        MessageBox.Show("Cliente modificado correctamente", "Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {                         
                        MessageBox.Show("Debe completar todos los campos", "Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                {
                    MessageBox.Show("Debe seleccionar un cliente", "Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                clienteBLL.ListarClientesActivosEnDataGridView(dgvClientes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            

        }
        #endregion


        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            validacionesBLL.LimpiarCampos(this.Controls);
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvClientes.CurrentRow != null)
                {
                    txtID.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                    txtApellido.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                    txtDNI.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();

                    txtDireccion.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();

                    txtTelefono.Text = dgvClientes.CurrentRow.Cells[5].Value.ToString();
                    txtMail.Text = dgvClientes.CurrentRow.Cells[6].Value.ToString();
                    dtpFechaNacimiento.Value = Convert.ToDateTime(dgvClientes.CurrentRow.Cells[7].Value.ToString());


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            if(txtNombre.Text == "")
            {
                MessageBox.Show("El campo Nombre no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            else if (txtApellido.Text == "")
            {
                MessageBox.Show("El campo Apellido no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellido.Focus();
                return false;
            }
            else if (txtDNI.Text == "")
            {
                MessageBox.Show("El campo DNI no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDNI.Focus();
                return false;
            }
            else if (txtDireccion.Text == "")
            {
                MessageBox.Show("El campo Dirección no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDireccion.Focus();
                return false;
            }
            else if (txtTelefono.Text == "")
            {
                MessageBox.Show("El campo Teléfono no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                return false;
            }
            else if (txtMail.Text == "")
            {
                MessageBox.Show("El campo Mail no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMail.Focus();
                return false;
            }
            else if(dtpFechaNacimiento.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser mayor a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFechaNacimiento.Focus();
                return false;
            }
            
            return true;
            
        }
    }
}
