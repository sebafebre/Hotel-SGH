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

namespace Vista.Paneles.Reservas
{
    public partial class frmBuscarHabitacion : Form
    {
        HabitacionBLL habitacionBLL = new HabitacionBLL();
        ReservaBLL reservaBLL = new ReservaBLL();

        public HabitacionBE HabitacionSeleccionada { get; private set; }
        public DateTime FechaInicio { get; private set; }
        public DateTime FechaFin { get; private set; }

        #region Variables
        int PrecioDiario = 0;
        int nroHabitacion = 0;
        string tipoHabitacion = "";
        string camas = "";

        #endregion

        public frmBuscarHabitacion()
        {
            InitializeComponent();
            habitacionBLL.BuscarHabitacionesDGV(dgvHabitaciones);

        }

        private void dgvHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHabitaciones.CurrentRow != null)
                {
                    
                    nroHabitacion = Convert.ToInt32(dgvHabitaciones.CurrentRow.Cells[0].Value);
                    txtNroHabitacion.Text = dgvHabitaciones.CurrentRow.Cells[0].Value.ToString();

                    cbTipoHabitacion.Text = dgvHabitaciones.CurrentRow.Cells[1].Value.ToString();
                    tipoHabitacion = dgvHabitaciones.CurrentRow.Cells[1].Value.ToString();

                    cbNroCamas.Text = dgvHabitaciones.CurrentRow.Cells[2].Value.ToString();
                    camas = dgvHabitaciones.CurrentRow.Cells[2].Value.ToString();

                    PrecioDiario = Convert.ToInt32(dgvHabitaciones.CurrentRow.Cells[3].Value);
                    CalcularPrecios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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
                lblTotal.Text = Total.ToString();
            }

        }

        private void btnTodasHabs_Click(object sender, EventArgs e)
        {
            cbNroCamas.SelectedIndex = -1;
            cbTipoHabitacion.SelectedIndex = -1;
            reservaBLL.filtrarHabitacionesDisponiblesDTP(dtpFechaLlegada, dtpFechaIda, cbTipoHabitacion.Text, cbNroCamas.Text, dgvHabitaciones, lblError);
        }

        private void dtpFechaLlegada_ValueChanged(object sender, EventArgs e)
        {
            reservaBLL.filtrarHabitacionesDisponiblesDTP(dtpFechaLlegada, dtpFechaIda, cbTipoHabitacion.Text, cbNroCamas.Text, dgvHabitaciones, lblError);
            CalcularPrecios();
        }

        private void dtpFechaIda_ValueChanged(object sender, EventArgs e)
        {
            reservaBLL.filtrarHabitacionesDisponiblesDTP(dtpFechaLlegada, dtpFechaIda, cbTipoHabitacion.Text, cbNroCamas.Text, dgvHabitaciones, lblError);
            CalcularPrecios();
        }

        private void cbTipoHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            reservaBLL.filtrarHabitacionesDisponiblesDTP(dtpFechaLlegada, dtpFechaIda, cbTipoHabitacion.Text, cbNroCamas.Text, dgvHabitaciones, lblError);
        }

        private void cbNroCamas_SelectedIndexChanged(object sender, EventArgs e)
        {
            reservaBLL.filtrarHabitacionesDisponiblesDTP(dtpFechaLlegada, dtpFechaIda, cbTipoHabitacion.Text, cbNroCamas.Text, dgvHabitaciones, lblError);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            FechaFin = dtpFechaIda.Value;
            FechaInicio = dtpFechaLlegada.Value;

            HabitacionSeleccionada = new HabitacionBE();
            HabitacionSeleccionada.NroHabitacion = nroHabitacion;
            HabitacionSeleccionada.PrecioDiario = PrecioDiario;
            HabitacionSeleccionada.TipoCamas = camas;
            HabitacionSeleccionada.TipoHabitacion = tipoHabitacion;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
