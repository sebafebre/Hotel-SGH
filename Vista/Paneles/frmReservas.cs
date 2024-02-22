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
        public frmReservas()
        {
            InitializeComponent();
            //reservaBLL.BuscarClientesDGVReserva(dgvClientes);
            clienteBLL.ListarClientesActivosEnDataGridView(dgvClientes);

            habitacionBLL.ListarHabitacionesEnDataGridView(dgvHabitaciones);
            //reservaBLL.ListarHabitacionesDGVReservas(dgvHabitaciones);
            reservaBLL.ListarReservasEnDataGridView(dgvReservas);
            //dtpFechaIda.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            //dtpFechaLlegada.CustomFormat = "yyyy-MM-dd HH:mm:ss";

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                // Obtener los valores necesarios del formulario
                int idCliente = Convert.ToInt32(txtIdCliente.Text); // Implementa este método
                int idHabitacion = Convert.ToInt32(txtIdHabitacion.Text); // Implementa este método
                DateTime fechaInicio = dtpFechaLlegada.Value; // Obtener la fecha de llegada del control DateTimePicker
                DateTime fechaFin = dtpFechaIda.Value; // Obtener la fecha de ida del control DateTimePicker
                decimal subtotal = Convert.ToDecimal(lblSubtotal.Text); // Implementa este método
                decimal imp = Convert.ToDecimal(lblImpuestos.Text); // Implementa este método
                decimal total = Convert.ToDecimal(lblTotal.Text); // Implementa este método

                // Llamar al método GuardarReserva con los valores obtenidos
                bool resultado = reservaBLL.GuardarReserva(idCliente, idHabitacion, fechaInicio, fechaFin, subtotal, imp, total);

                // Mostrar un mensaje al usuario dependiendo del resultado de la operación
                if (resultado)
                {
                    MessageBox.Show("Reserva guardada correctamente", "Guardar Reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la reserva", "Guardar Reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                reservaBLL.ListarReservasEnDataGridView(dgvReservas);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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
            float Total = 0;
            
            int dias = (dtpFechaIda.Value.Date - dtpFechaLlegada.Value.Date).Days;

            float PrecioDiarioHab = PrecioDiario;

            float SubTotal = PrecioDiarioHab * dias;

            float Impuestos = SubTotal * (21 / 100); //IVA 21%

            lblSubtotal.Text = SubTotal.ToString();

            lblImpuestos.Text = Impuestos.ToString();

            Total = SubTotal + Impuestos;

            lblTotal.Text = Total.ToString();
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
                    PrecioDiario = Convert.ToInt32(dgvHabitaciones.CurrentRow.Cells[4].Value);
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
                if (txtIdReserva.Text != "")
                {
                    ReservaBE reserva = new ReservaBE();
                    
                    int IdDelCliente = Convert.ToInt32(txtIdCliente.Text);
                    int IdDeHabitacion = Convert.ToInt32(txtIdHabitacion.Text);

                    reserva.Cliente = new ClienteBE();
                    reserva.Habitacion = new HabitacionBE();

                    reserva.Id = Convert.ToInt32(txtIdReserva.Text);
                    
                    reserva.FechaLlegada = dtpFechaLlegada.Value;
                    reserva.FechaIda = dtpFechaIda.Value;
                    reserva.NroReserva = Convert.ToInt32(txtNroReserva.Text);
                    reserva.Subtotal = Convert.ToDecimal(lblSubtotal.Text);
                    reserva.Impuestos = Convert.ToDecimal(lblImpuestos.Text);
                    reserva.Total = Convert.ToDecimal(lblTotal.Text);

                    reservaBLL.ModificarReserva(reserva, IdDelCliente, IdDeHabitacion);
                    MessageBox.Show("Reserva modificada correctamente", "Modificar Reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un cliente", "Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reservaBLL.ListarReservasEnDataGridView(dgvReservas);
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
    }
}
