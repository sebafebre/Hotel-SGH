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
        HabitacionBLL habitacionBLL = new HabitacionBLL();
        ValidacionesBLL validacionesBLL = new ValidacionesBLL();

        private ClienteBE clienteSeleccionado;
        private HabitacionBE habitacionSeleccionada;

        int PrecioDiario = 0;
        int nroHabitacion = 0;

        private DateTime fechaInicio;
        private DateTime fechaFin;

        public frmAgregarReserva()
        {
            InitializeComponent();
            reservaBLL.ListarReservasEnDataGridView(dgvReservas);
        }

        

        

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
                this.clienteSeleccionado = buscarClienteForm.ClienteSeleccionado;
                txtClienteDNI.Text = clienteSeleccionado.Persona.DNI.ToString();

            }
        }

        private void btnBuscarHabitacion_Click(object sender, EventArgs e)
        {
            frmBuscarHabitacion buscarHabitacionForm = new frmBuscarHabitacion();
            buscarHabitacionForm.ShowDialog(); // Abre el formulario de búsqueda de habitación como un cuadro de diálogo

            // Verifica si se seleccionó una habitación y si sí, actualiza los datos en el formulario frmReservas
            if (buscarHabitacionForm.HabitacionSeleccionada != null)
            {
                this.fechaFin = buscarHabitacionForm.FechaFin;
                this.fechaInicio = buscarHabitacionForm.FechaInicio;

                this.habitacionSeleccionada = buscarHabitacionForm.HabitacionSeleccionada;
                txtNroHabitacion.Text = habitacionSeleccionada.NroHabitacion.ToString();
                PrecioDiario = Convert.ToInt32(habitacionSeleccionada.PrecioDiario);

                dtpFechaIda.Value = fechaFin;
                dtpFechaLlegada.Value = fechaInicio;
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNroHabitacion.Text != "")
                {
                    if(txtClienteDNI.Text != "")
                    {
                        // Obtener los valores necesarios del formulario
                        int nroHabitacion = Convert.ToInt32(txtNroHabitacion.Text); // Implementa este método
                        DateTime fechaInicio = dtpFechaLlegada.Value; // Obtener la fecha de llegada del control DateTimePicker
                        DateTime fechaFin = dtpFechaIda.Value; // Obtener la fecha de ida del control DateTimePicker
                        decimal subtotal = Convert.ToDecimal(lblSubtotal.Text); // Implementa este método
                        decimal imp = Convert.ToDecimal(lblImpuestos.Text); // Implementa este método
                        decimal total = Convert.ToDecimal(lblTotal.Text); // Implementa este método

                        int ClienteDNI = Convert.ToInt32(txtClienteDNI.Text); // Implementa este método
                        reservaBLL.GuardarReserva(ClienteDNI, nroHabitacion, fechaInicio, fechaFin, subtotal, imp, total);

                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un cliente", "Guardar Reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    

                }
                else
                {
                    MessageBox.Show("Debe seleccionar una habitacion", "Guardar Reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }





                reservaBLL.ListarReservasEnDataGridView(dgvReservas);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique haber elegido un cliente y una habitacion \n con disponibilidad con las fachas seleccionadas " + ex.Message);
            }
        }

        private void txtClienteDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaLlegada_ValueChanged(object sender, EventArgs e)
        {
            CalcularPrecios();
            //reservaBLL.DateTimePickerCambia(dtpFechaLlegada, dtpFechaIda, dgvHabitaciones);
            reservaBLL.VerificarHabitacionesDisponibles(dtpFechaLlegada, dtpFechaIda, lblError);
        }
        private void dtpFechaIda_ValueChanged(object sender, EventArgs e)
        {
            CalcularPrecios();
            //reservaBLL.DateTimePickerCambia(dtpFechaLlegada, dtpFechaIda, dgvHabitaciones);
            reservaBLL.VerificarHabitacionesDisponibles(dtpFechaLlegada, dtpFechaIda, lblError);
        }

        public void CalcularPrecios()
        {
            double Total = 0;

            int dias = (dtpFechaIda.Value.Date - dtpFechaLlegada.Value.Date).Days;

            double PrecioDiarioHab = PrecioDiario;

            double SubTotal = PrecioDiarioHab * dias;

            double Impuestos = SubTotal * 0.21; //IVA 21%

            Total = SubTotal + Impuestos;

            if (Total >= 0)
            {
                lblSubtotal.Text = SubTotal.ToString();

                lblImpuestos.Text = Impuestos.ToString();

                lblTotal.Text = Total.ToString();
            }

        }

        private void txtNroHabitacion_TextChanged(object sender, EventArgs e)
        {
            CalcularPrecios();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdReserva.Text != "" || txtClienteDNI.Text == "" || txtNroHabitacion.Text == "")
                {
                    ReservaBE reserva = new ReservaBE();

                    int DNICliente = Convert.ToInt32(txtClienteDNI.Text);
                    int NroHabitacion = Convert.ToInt32(txtNroHabitacion.Text);

                    reserva.Cliente = new ClienteBE();
                    reserva.Habitacion = new HabitacionBE();

                    reserva.Id = Convert.ToInt32(txtIdReserva.Text);

                    DateTime fechaInicio = dtpFechaLlegada.Value; // Obtener la fecha de llegada del control DateTimePicker
                    DateTime fechaFin = dtpFechaIda.Value; // Obtener la fecha de ida del control DateTimePicker

                    reserva.FechaLlegada = dtpFechaLlegada.Value;
                    reserva.FechaIda = dtpFechaIda.Value;
                    reserva.NroReserva = Convert.ToInt32(txtNroReserva.Text);
                    reserva.Subtotal = Convert.ToDecimal(lblSubtotal.Text);
                    reserva.Impuestos = Convert.ToDecimal(lblImpuestos.Text);
                    reserva.Total = Convert.ToDecimal(lblTotal.Text);

                    reservaBLL.ModificarReserva(reserva, DNICliente, NroHabitacion, fechaInicio, fechaFin);

                }
                else
                {
                    MessageBox.Show("Debe seleccionar una reserva la cual modificar", "Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reservaBLL.ListarReservasEnDataGridView(dgvReservas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique haber marcado una reserva la cual modificar " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdReserva.Text != "")
                {
                    ReservaBE reserva = new ReservaBE();
                    int IdReserva = Convert.ToInt32(txtIdReserva.Text);
                    reservaBLL.EliminarReserva(IdReserva);
                    MessageBox.Show("Reserva eliminada correctamente", "Eliminar Reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una reserva", "Eliminar Reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reservaBLL.ListarReservasEnDataGridView(dgvReservas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvReservas_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvReservas.CurrentRow != null)
                {
                    txtIdReserva.Text = dgvReservas.CurrentRow.Cells[0].Value.ToString();
                    txtNroReserva.Text = dgvReservas.CurrentRow.Cells[1].Value.ToString();
                    dtpFechaIda.Value = Convert.ToDateTime(dgvReservas.CurrentRow.Cells[3].Value.ToString());
                    dtpFechaLlegada.Value = Convert.ToDateTime(dgvReservas.CurrentRow.Cells[2].Value.ToString());

                    lblTotal.Text = dgvReservas.CurrentRow.Cells[4].Value.ToString();


                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
