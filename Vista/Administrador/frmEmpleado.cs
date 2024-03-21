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

namespace Vista.Administrador
{
    public partial class frmEmpleado : Form
    {
        EmpleadoBLL empleadoBLL = new EmpleadoBLL();

        ValidacionesBLL validacionBLL = new ValidacionesBLL();



        public frmEmpleado()
        {
            InitializeComponent();
            empleadoBLL.ListarEmpleadosEnDGV(dgvEmpleados);
            validacionBLL.AutocompletarNacionalidad(txtNacionalidad);
        }

        private bool ValidarCampos()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe completar el campo Nombre", "Agregar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            if (txtApellido.Text == "")
            {
                MessageBox.Show("Debe completar el campo Apellido", "Agregar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellido.Focus();
                return false;
            }
            if (txtDNI.Text == "")
            {
                MessageBox.Show("Debe completar el campo DNI", "Agregar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDNI.Focus();
                return false;
            }
            if (txtNacionalidad.Text == "")
            {
                MessageBox.Show("Debe completar el campo Dirección", "Agregar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNacionalidad.Focus();
                return false;
            }
            if (txtTelefono.Text == "")
            {
                MessageBox.Show("Debe completar el campo Teléfono", "Agregar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                return false;
            }
            if (txtMail.Text == "" /* || validacionBLL.ValidarEmail(txtMail.Text) == false*/)
            {
                MessageBox.Show("Debe completar el campo Mail", "Agregar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMail.Focus();
                return false;
            }
            if (cbCargo.Text == "")
            {
                MessageBox.Show("Debe completar el campo Cargo", "Agregar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbCargo.Focus();
                return false;
            }
            if (cbPuesto.Text == "")
            {
                MessageBox.Show("Debe completar el campo Puesto", "Agregar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbPuesto.Focus();
                return false;
            }
            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser mayor a la fecha actual", "Agregar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            //if(validacionBLL.ValidarDni(txtDNI.Text))
            return true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdEmpleado.Text != "")
                {
                    if (ValidarCampos())
                    {
                        EmpleadoBE empleado = new EmpleadoBE();

                        empleado.Persona = new PersonaBE();
                        empleado.Id = Convert.ToInt32(txtIdEmpleado.Text);
                        empleado.Persona.Nombre = txtNombre.Text;
                        empleado.Persona.Apellido = txtApellido.Text;
                        empleado.Persona.DNI = Convert.ToInt32(txtDNI.Text);
                        empleado.Persona.Direccion = txtNacionalidad.Text;
                        empleado.Persona.Telefono = Convert.ToDouble(txtTelefono.Text);
                        empleado.Persona.Mail = txtMail.Text;
                        empleado.Persona.FechaNacimiento = dtpFechaNacimiento.Value;
                        //empleado.FechaIngreso = DateTime.Now;
                        empleado.Puesto = cbPuesto.Text;
                        empleado.Cargo = cbCargo.Text;

                        empleadoBLL.ModificarEmpleado(empleado);
                        MessageBox.Show("Empleado modificado correctamente", "Modificar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        validacionBLL.LimpiarCampos(this.Controls);
                        empleadoBLL.ListarEmpleadosEnDGV(dgvEmpleados);
                    }
                    else
                    {
                        MessageBox.Show("Debe completar todos los campos", "Modificar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Debe seleccionar un empleado", "Modificar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                if (ValidarCampos())
                {
                    EmpleadoBE empleado = new EmpleadoBE();
                    empleado.Persona = new PersonaBE();
                    empleado.Persona.Nombre = txtNombre.Text;
                    empleado.Persona.Apellido = txtApellido.Text;
                    empleado.Persona.DNI = Convert.ToInt32(txtDNI.Text);
                    empleado.Persona.FechaNacimiento = dtpFechaNacimiento.Value;
                    empleado.Persona.Direccion = txtNacionalidad.Text;
                    empleado.Persona.Telefono = Convert.ToDouble(txtTelefono.Text);
                    empleado.Persona.Mail = txtMail.Text;
                    empleado.Persona.EstadoActivo = true;
                    empleado.Puesto = cbPuesto.Text;
                    empleado.Cargo = cbCargo.Text;
                    empleado.FechaIngreso = DateTime.Now;
                    empleadoBLL.AgregarEmpleado(empleado);
                    MessageBox.Show("Empleado agregado correctamente", "Agregar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    empleadoBLL.ListarEmpleadosEnDGV(dgvEmpleados);
                    validacionBLL.LimpiarCampos(this.Controls);
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos", "Agregar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdEmpleado.Text != "")
                {
                    EmpleadoBE empleado = new EmpleadoBE();
                    empleado.Id = Convert.ToInt32(txtIdEmpleado.Text);
                    empleadoBLL.EliminarEmpleado(empleado);
                    MessageBox.Show("Empleado eliminado correctamente", "Eliminar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    validacionBLL.LimpiarCampos(this.Controls);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un empleado", "Eliminar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvEmpleados.CurrentRow != null)
                {
                    txtIdEmpleado.Text = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = dgvEmpleados.CurrentRow.Cells[1].Value.ToString();
                    txtApellido.Text = dgvEmpleados.CurrentRow.Cells[2].Value.ToString();
                    txtDNI.Text = dgvEmpleados.CurrentRow.Cells[3].Value.ToString();
                    txtNacionalidad.Text = dgvEmpleados.CurrentRow.Cells[4].Value.ToString();
                    txtTelefono.Text = dgvEmpleados.CurrentRow.Cells[5].Value.ToString();
                    txtMail.Text = dgvEmpleados.CurrentRow.Cells[6].Value.ToString();
                    dtpFechaNacimiento.Value = Convert.ToDateTime(dgvEmpleados.CurrentRow.Cells[7].Value.ToString());

                    cbCargo.SelectedItem = dgvEmpleados.CurrentRow.Cells[9].Value.ToString();

                    cbPuesto.SelectedItem = dgvEmpleados.CurrentRow.Cells[8].Value.ToString();
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            try
            {
                validacionBLL.ValidarSoloNumeros((TextBox)sender);
                string dni = txtDNI.Text.Trim().ToLower();
                empleadoBLL.BuscarEmpleadoPorDNI(dni, dgvEmpleados);

                //string dniTexto = txtDNI.Text;
                //validacionBLL.ValidarDni(dniTexto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void cbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPuesto.Items.Clear(); // Limpiamos los elementos previos
            if(cbCargo.Text != "")
            {
                // Dependiendo del sector seleccionado, agregamos las opciones de puestos correspondientes
                switch (cbCargo.SelectedItem.ToString())
                {
                    case "Recepción":
                    case "Recepción/Atención al Cliente":
                        cbPuesto.Items.AddRange(new string[] { "Recepcionista", "Jefe de Recepción", "Supervisor de Recepción", "Bartender" });
                        break;
                    case "Limpieza":
                        cbPuesto.Items.AddRange(new string[] { "Personal de Limpieza", "Jefa de Limpieza", "Supervisora de Limpieza" });
                        break;
                    case "Administrativo":
                        cbPuesto.Items.AddRange(new string[] { "Gerente", "Contador", "Secretaria" });
                        break;
                    // Añadir más casos según tus necesidades
                    default:
                        // En caso de otro sector o ningún sector seleccionado, no se agregan opciones de puesto
                        break;
                }

            }
            
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            validacionBLL.ValidarSoloLetras((TextBox)sender);
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validacionBLL.ValidarSoloLetras((TextBox)sender);
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            try
            {
                validacionBLL.ValidarSoloNumeros((TextBox)sender);
                string telefono = txtTelefono.Text;
                //validacionBLL.ValidarTelefono(telefono);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
