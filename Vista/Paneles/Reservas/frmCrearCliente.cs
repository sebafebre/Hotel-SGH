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

namespace Vista.Paneles
{
    public partial class frmCrearCliente : Form
    {
        public ClienteBE ClienteCreado { get; private set; }

        ReservaBLL reservaBLL = new ReservaBLL();   
        ClienteBLL clienteBLL = new ClienteBLL();
        ValidacionesBLL validacionesBLL = new ValidacionesBLL();

        public frmCrearCliente()
        {
            InitializeComponent();
            validacionesBLL.AutocompletarNacionalidad(txtNacionalidad);
        }

        



        private bool ValidarCampos()
        {
            if (txtNombre.Text == "")
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
            else if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser mayor a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFechaNacimiento.Focus();
                return false;
            }
            else
            {
                return true;
            }
            

        }

        private void btnCrearCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    ClienteCreado = new ClienteBE();
                    ClienteCreado.Persona = new PersonaBE(); 

                    ClienteCreado.Persona.EstadoActivo = true;
                    ClienteCreado.Persona.Nombre = txtNombre.Text;
                    ClienteCreado.Persona.Apellido = txtApellido.Text;
                    ClienteCreado.Persona.DNI = Convert.ToInt32(txtDNI.Text);
                    ClienteCreado.Persona.Direccion = txtNacionalidad.Text;
                    ClienteCreado.Persona.Telefono = Convert.ToDouble(txtTelefono.Text);
                    ClienteCreado.Persona.Mail = txtMail.Text;
                    ClienteCreado.Persona.FechaNacimiento = dtpFechaNacimiento.Value;
                    ClienteCreado.FechaDeAlta = DateTime.Now;

                    clienteBLL.AgregarCliente(ClienteCreado);

                    this.DialogResult = DialogResult.OK;
                    this.Close();



                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos", "Agregar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            string dni = txtDNI.Text;
            validacionesBLL.ValidarSoloNumeros((TextBox)sender);
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string telefono = txtTelefono.Text;
            validacionesBLL.ValidarSoloNumeros((TextBox)sender);
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            string apellido = txtApellido.Text;
            validacionesBLL.ValidarSoloLetras((TextBox)sender);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            validacionesBLL.ValidarSoloLetras((TextBox)sender);
        }
    }
}
