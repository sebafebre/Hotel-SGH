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
        private AutoCompleteStringCollection autoCompleteCollection;

        public frmClientes()
        {
            InitializeComponent();
            clienteBLL.ListarClientesActivosEnDataGridView(dgvClientes);
            validacionesBLL.AutocompletarNacionalidad(txtNacionalidad);
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
                
                if (ValidarCampos() )
                {
                    ClienteBE cliente = new ClienteBE();
                    cliente.Persona = new PersonaBE();
                    cliente.Persona.EstadoActivo = true;
                    cliente.Persona.Nombre = txtNombre.Text;
                    cliente.Persona.Apellido = txtApellido.Text;
                    cliente.Persona.DNI = Convert.ToInt32(txtDNI.Text);
                    cliente.Persona.Direccion = txtNacionalidad.Text;
                    cliente.Persona.Telefono =Convert.ToDouble(txtTelefono.Text);
                    cliente.Persona.Mail = txtMail.Text;
                    cliente.Persona.FechaNacimiento = dtpFechaNacimiento.Value;
                    cliente.FechaDeAlta = DateTime.Now;

                    clienteBLL.AgregarCliente(cliente);
                  

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
                        cliente.Persona.DNI = Convert.ToInt32(txtDNI.Text);
                        cliente.Persona.Direccion = txtNacionalidad.Text;
                        cliente.Persona.Telefono = Convert.ToDouble(txtTelefono.Text);
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
            else if (txtNacionalidad.Text == "")
            {
                MessageBox.Show("El campo Dirección no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNacionalidad.Focus();
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
            else if (!validacionesBLL.ValidarEmail(txtMail.Text))
            {
                MessageBox.Show("El mail no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMail.Focus();
                return false;
            }

            

            return true;
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                
                validacionesBLL.ValidarSoloLetras((TextBox)sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                validacionesBLL.ValidarSoloLetras((TextBox)sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private bool usuarioEscribiendo = false;

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (usuarioEscribiendo)
                {
                    if (!string.IsNullOrEmpty(txtDNI.Text))
                    {
                        string dniBusqueda = txtDNI.Text.Trim().ToLower();
                        validacionesBLL.BuscarPorDNI(dniBusqueda, dgvClientes);
                    }

                    // Restablecer usuarioEscribiendo solo cuando el usuario ha terminado de escribir
                    usuarioEscribiendo = false;
                }
                if (string.IsNullOrEmpty(txtDNI.Text))
                {
                    clienteBLL.ListarClientesActivosEnDataGridView(dgvClientes);
                }

                string dni = txtDNI.Text;
                //validacionesBLL.ValidarDni(dni);
                validacionesBLL.ValidarSoloNumeros((TextBox)sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        











        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string numero = txtTelefono.Text;
                validacionesBLL.ValidarSoloNumeros((TextBox)sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                
                validacionesBLL.ValidarFechaNac(dtpFechaNacimiento.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarioEscribiendo = e.KeyChar != '\b';
        }

        private void dgvClientes_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvClientes.CurrentRow != null)
                {
                    txtID.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                    txtApellido.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                    txtDNI.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();

                    txtNacionalidad.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();

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
    }
}
