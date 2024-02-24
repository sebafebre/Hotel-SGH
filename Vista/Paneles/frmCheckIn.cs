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
    public partial class frmCheckIn : Form
    {
        CheckInBLL checkinBLL = new CheckInBLL();
        public frmCheckIn()
        {
            InitializeComponent();
            checkinBLL.ListarReservasPendientesEnDataGridView(dgvReservas);
        }


        private bool ValidarCampos()
        {
            if (txtIdReserva.Text == "")
            {
                MessageBox.Show("Debe seleccionar una reserva");
                dgvReservas.Focus();
                return false;

            }
            return true;
        }






        private void txtBuscarDNI_TextChanged(object sender, EventArgs e)
        {
            string dni = txtBuscarDNI.Text.Trim().ToLower();
            checkinBLL.BuscarClientePorDNI(dni, dgvReservas);
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                int IdReserva = Convert.ToInt32(txtIdReserva.Text);

                checkinBLL.CambiarEstadoReserva(IdReserva);
                checkinBLL.ListarReservasPendientesEnDataGridView(dgvReservas);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una reserva");
            }
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
                    //cambiar tipo de dato a fecha
                    DateTime fechallegada = Convert.ToDateTime(dgvReservas.CurrentRow.Cells[3].Value);
                    DateTime fechaIda = Convert.ToDateTime(dgvReservas.CurrentRow.Cells[4].Value);
                    lblFechaLlegada.Text = fechallegada.ToString("dd/MM/yyyy");
                    lblFechaIda.Text = fechaIda.ToString("dd/MM/yyyy");


                    //lblFechaLlegada.Text = dgvReservas.CurrentRow.Cells[3].Value.ToString();
                    //lblFechaIda.Text = dgvReservas.CurrentRow.Cells[4].Value.ToString();
                    lblNroHabitacion.Text = dgvReservas.CurrentRow.Cells[5].Value.ToString();
                    lblTipoHabitacion.Text = dgvReservas.CurrentRow.Cells[6].Value.ToString();
                    lblCamas.Text = dgvReservas.CurrentRow.Cells[7].Value.ToString();
                    lblTotal.Text = dgvReservas.CurrentRow.Cells[8].Value.ToString();
                    txtIdReserva.Text = dgvReservas.CurrentRow.Cells[9].Value.ToString();
                    txtIdCliente.Text = dgvReservas.CurrentRow.Cells[10].Value.ToString();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnResPendientes_Click(object sender, EventArgs e)
        {
            checkinBLL.ListarReservasPendientesEnDataGridView(dgvReservas);
        }

        private void btnResActivas_Click(object sender, EventArgs e)
        {
            checkinBLL.ListarReservasActivasEnDataGridView(dgvReservas);
        }

        private void btnResFinalizadas_Click(object sender, EventArgs e)
        {
            checkinBLL.ListarReservasFinalizadasEnDataGridView(dgvReservas);
        }

        private void btnResTodas_Click(object sender, EventArgs e)
        {
            checkinBLL.ListarReservasTodasEnDataGridView(dgvReservas);
        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtNroReserva_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdReserva_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
