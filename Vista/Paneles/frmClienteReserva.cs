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
    public partial class frmClienteReserva : Form
    {

        private int idCliente;
        private int idHabitacion;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private decimal subtotal;
        private decimal imp;
        private decimal total;
        private int nroHabitacion;

        ReservaBLL reservaBLL = new ReservaBLL();   
        ClienteBLL clienteBLL = new ClienteBLL();
        ValidacionesBLL validacionesBLL = new ValidacionesBLL();

        public frmClienteReserva(int idHabitacion,DateTime fechaInicio, DateTime fechaFin, decimal subtotal, decimal imp, decimal total, int nroHabitacion)
        {
            InitializeComponent();
            this.idHabitacion = idHabitacion;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.subtotal = subtotal;
            this.imp = imp;
            this.total = total;
            this.nroHabitacion = nroHabitacion;

        }

        private void frmClienteReserva_Load(object sender, EventArgs e)
        {
            lblNroHabitacion.Text = idHabitacion.ToString();
            lblFechaLlegada.Text = fechaInicio.ToString();
            lblFechaIda.Text = fechaFin.ToString();
            lblTotal.Text = total.ToString();

        }

        private void btnAgregarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
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

                    clienteBLL.AgregarCliente(cliente);

                    int idCliente = clienteBLL.ObtenerIdCliente(cliente);

                    //this.clienteTableAdapter.Fill(this.sGHDataSet.Cliente); 
                    reservaBLL.GuardarReserva(idCliente, idHabitacion, fechaInicio, fechaFin, subtotal, imp, total);
                    //MessageBox.Show("Reserva agregada correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos", "Agregar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la reserva: " + ex.Message);
            }



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
            else if (dtpFechaNacimiento.Value > DateTime.Now)
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
    }
}
