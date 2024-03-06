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
using Controladora;
using System.Security.Cryptography;

namespace Vista.Paneles
{
    public partial class frmReservas : Form
    {
        ReservaBLL reservaBLL = new ReservaBLL();

        HabitacionBLL habitacionBLL = new HabitacionBLL();

        ClienteBLL clienteBLL = new ClienteBLL();

        ValidacionesBLL validacionesBLL = new ValidacionesBLL();

        int PrecioDiario = 0;
        int nroHabitacion = 0;
        public frmReservas()
        {
            InitializeComponent();
            
            clienteBLL.ListarClientesActivosEnDataGridView(dgvClientes);

            habitacionBLL.ListarHabitacionesEnDataGridView(dgvHabitaciones);
            
            reservaBLL.ListarReservasEnDataGridView(dgvReservas);


            /* Falla ya que cuando se selecciona, se carga lal fecha antigua y ocurre un error con el min date
            dtpFechaIda.MinDate = DateTime.Today.AddDays(+1);
            dtpFechaLlegada.MinDate = DateTime.Today;
            dtpFechaLlegada.Value = DateTime.Today.AddDays(+1);
            dtpFechaIda.Value = DateTime.Today.AddDays(+1);
            */
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            frmAgregarReserva frmAgregarReserva = new frmAgregarReserva();
            frmAgregarReserva.ShowDialog();
            

            /*
            try
            {
                if(txtIdHabitacion.Text != "")
                {
                    // Obtener los valores necesarios del formulario
                    
                    int idHabitacion = Convert.ToInt32(txtIdHabitacion.Text); // Implementa este método
                    DateTime fechaInicio = dtpFechaLlegada.Value; // Obtener la fecha de llegada del control DateTimePicker
                    DateTime fechaFin = dtpFechaIda.Value; // Obtener la fecha de ida del control DateTimePicker
                    decimal subtotal = Convert.ToDecimal(lblSubtotal.Text); // Implementa este método
                    decimal imp = Convert.ToDecimal(lblImpuestos.Text); // Implementa este método
                    decimal total = Convert.ToDecimal(lblTotal.Text); // Implementa este método

                    
                    if (cbNuevoCliente.Checked == false && txtIdCliente.Text != "")
                    {
                        int idCliente = Convert.ToInt32(txtIdCliente.Text); // Implementa este método
                        reservaBLL.GuardarReserva(idCliente, idHabitacion, fechaInicio, fechaFin, subtotal, imp, total);
                    }
                    if (cbNuevoCliente.Checked == true)
                    {
                        
                        frmClienteReserva frmNuevoClientes = new frmClienteReserva( idHabitacion, fechaInicio, fechaFin, subtotal, imp, total, nroHabitacion);
                        frmNuevoClientes.ShowDialog();
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
            }*/
        }


        private void dtpFechaLlegada_ValueChanged(object sender, EventArgs e)
        {
            CalcularPrecios();
            //reservaBLL.DateTimePickerCambia(dtpFechaLlegada, dtpFechaIda, dgvHabitaciones);
            reservaBLL.DateTimePickerCambia2(dtpFechaLlegada, dtpFechaIda, cbTipoHabitacion.Text, cbNroCamas.Text, dgvHabitaciones, lblError);
        }

        private void dtpFechaIda_ValueChanged(object sender, EventArgs e)
        {
            CalcularPrecios();

            //reservaBLL.DateTimePickerCambia(dtpFechaLlegada, dtpFechaIda, dgvHabitaciones);
            reservaBLL.DateTimePickerCambia2(dtpFechaLlegada, dtpFechaIda, cbTipoHabitacion.Text, cbNroCamas.Text, dgvHabitaciones, lblError);
        }

        public void CalcularPrecios()
        {
            double Total = 0;
            
            int dias = (dtpFechaIda.Value.Date - dtpFechaLlegada.Value.Date ).Days;

            double PrecioDiarioHab = PrecioDiario;

            double SubTotal = PrecioDiarioHab * dias;

            double Impuestos = SubTotal * 0.21; //IVA 21%

            Total = SubTotal + Impuestos;

            if(Total >= 0)
            {
                lblSubtotal.Text = SubTotal.ToString();

                lblImpuestos.Text = Impuestos.ToString();

                lblTotal.Text = Total.ToString();
            }

        }

        private void txtBuscarDNI_TextChanged(object sender, EventArgs e)
        {
            //string dni = txtBuscarDNI.Text.Trim();
            string dni = txtBuscarDNI.Text.Trim().ToLower();
            //reservaBLL.BuscarClientePorDNI(dni , dgvClientes);

            validacionesBLL.BuscarPorDNI(dni, dgvClientes);
        }

        private void cbTipoHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            reservaBLL.DateTimePickerCambia2(dtpFechaLlegada, dtpFechaIda, cbTipoHabitacion.Text, cbNroCamas.Text, dgvHabitaciones, lblError);
            //reservaBLL.FiltrarHabitaciones(cbTipoHabitacion.Text, cbNroCamas.Text, dgvHabitaciones);
            CalcularPrecios();
        }

        private void cbNroCamas_SelectedIndexChanged(object sender, EventArgs e)
        {
            reservaBLL.DateTimePickerCambia2(dtpFechaLlegada, dtpFechaIda, cbTipoHabitacion.Text, cbNroCamas.Text, dgvHabitaciones, lblError);
            //reservaBLL.FiltrarHabitaciones(cbTipoHabitacion.Text, cbNroCamas.Text, dgvHabitaciones);
            CalcularPrecios();
        }

        private void dgvHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvHabitaciones.CurrentRow != null)
                {
                    txtIdHabitacion.Text = dgvHabitaciones.CurrentRow.Cells[0].Value.ToString();
                    PrecioDiario = Convert.ToInt32(dgvHabitaciones.CurrentRow.Cells[5].Value);
                    nroHabitacion = Convert.ToInt32(dgvHabitaciones.CurrentRow.Cells[1].Value);
                    CalcularPrecios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvReservas_CellClick(object sender, DataGridViewCellEventArgs e)
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

                    txtIdCliente.Text = dgvReservas.CurrentRow.Cells[5].Value.ToString();
                    txtIdHabitacion.Text = dgvReservas.CurrentRow.Cells[6].Value.ToString();
                    
                    cbTipoHabitacion.SelectedItem = dgvReservas.CurrentRow.Cells[8].Value.ToString();
                    cbNroCamas.SelectedItem = dgvReservas.CurrentRow.Cells[9].Value.ToString();
                    txtIdHabitacion.Text = dgvReservas.CurrentRow.Cells[10].Value.ToString();
                    

                    
                    

                    
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvClientes.CurrentRow != null)
                {
                    txtIdCliente.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();

                    
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
                if (txtIdReserva.Text != "" || txtIdCliente.Text == "" || txtIdHabitacion.Text == "" )
                {
                    ReservaBE reserva = new ReservaBE();
                    
                    int IdDelCliente = Convert.ToInt32(txtIdCliente.Text);
                    int IdDeHabitacion = Convert.ToInt32(txtIdHabitacion.Text);

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

                    reservaBLL.ModificarReserva(reserva, IdDelCliente, IdDeHabitacion, fechaInicio, fechaFin);
                    
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

        private void btnTodasHabs_Click(object sender, EventArgs e)
        {
            habitacionBLL.ListarHabitacionesEnDataGridView(dgvHabitaciones);
            cbNroCamas.SelectedIndex = -1;
            cbTipoHabitacion.SelectedIndex = -1;
        }
    }
}
