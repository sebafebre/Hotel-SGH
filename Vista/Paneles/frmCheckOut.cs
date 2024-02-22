using Controladora;
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
    public partial class frmCheckOut : Form
    {
        PedidoBLL pedidoBLL = new PedidoBLL();
        ReservaBLL reservaBLL = new ReservaBLL();
        ValidacionesBLL validacionesBLL = new ValidacionesBLL();
        public frmCheckOut()
        {
            InitializeComponent();
            reservaBLL.ListarReservasActivasEnDataGridView(dgvReservas);
            
        }


        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtIdReserva.Text != "")
                {
                    //reservaBLL.CheckOut(Convert.ToInt32(txtIdReserva.Text));
                    int nroReserva = Convert.ToInt32(txtNroReserva.Text);
                    pedidoBLL.GenerarFacturaTXT(nroReserva, "A", 1);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una reserva");
                    dgvReservas.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnResPendientes_Click(object sender, EventArgs e)
        {
            reservaBLL.ListarReservasPendientesEnDataGridView(dgvReservas);
        }

        private void btnResActivas_Click(object sender, EventArgs e)
        {
            reservaBLL.ListarReservasActivasEnDataGridView(dgvReservas);
        }

        private void btnResFinalizadas_Click(object sender, EventArgs e)
        {
            reservaBLL.ListarReservasFinalizadasEnDataGridView(dgvReservas);
        }

        private void btnResTodas_Click(object sender, EventArgs e)
        {
            reservaBLL.ListarReservasTodasEnDataGridView(dgvReservas);
        }

        private void dgvReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvReservas.CurrentRow != null)
                {

                    txtNroReserva.Text = dgvReservas.CurrentRow.Cells[0].Value.ToString();
                    txtNombreCliente.Text = dgvReservas.CurrentRow.Cells[1].Value.ToString();
                    txtBuscarDNI.Text = dgvReservas.CurrentRow.Cells[2].Value.ToString();

                    lblFechaLlegada.Text = dgvReservas.CurrentRow.Cells[3].Value.ToString();
                    lblFechaIda.Text = dgvReservas.CurrentRow.Cells[4].Value.ToString();                  
                    lblTotal.Text = dgvReservas.CurrentRow.Cells[8].Value.ToString();
                    txtIdReserva.Text = dgvReservas.CurrentRow.Cells[9].Value.ToString();
                    txtIdCliente.Text = dgvReservas.CurrentRow.Cells[10].Value.ToString();

                    pedidoBLL.ListarPedidosDeReservaEnDGV( dgvPedidos, Convert.ToInt32(txtNroReserva.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtNroHabitacion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNroHabitacion.Text != "")
                {
                    int nroHabitacion = Convert.ToInt32(txtNroHabitacion.Text.Trim());
                    pedidoBLL.BuscarPorNumHabitacion(nroHabitacion, dgvPedidos);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void txtBuscarDNI_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscarDNI.Text != "")
                {
                    string dni = txtBuscarDNI.Text.Trim().ToLower();
                    validacionesBLL.BuscarPorDNI(dni, dgvReservas);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            
            
            

        }
    }
}
