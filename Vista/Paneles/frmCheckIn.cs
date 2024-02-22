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

                    lblFechaLlegada.Text = dgvReservas.CurrentRow.Cells[3].Value.ToString();
                    lblFechaIda.Text = dgvReservas.CurrentRow.Cells[4].Value.ToString();
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

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblCamas_Click(object sender, EventArgs e)
        {

        }

        private void lblTipoHabitacion_Click(object sender, EventArgs e)
        {

        }

        private void lblNroHabitacion_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaIda_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaLlegada_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtIdCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtNroReserva_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtIdReserva_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
