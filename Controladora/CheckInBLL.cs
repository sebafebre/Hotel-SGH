using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controladora
{
    public class CheckInBLL
    {
        CheckInDAL checkInDAL = new CheckInDAL();


        public void ListarReservasPendientesEnDataGridView(DataGridView dataGridView)
        {
            checkInDAL.ListarReservasPendientesEnDataGridView(dataGridView);
        }

        public void ListarReservasActivasEnDataGridView(DataGridView dataGridView)
        {
            checkInDAL.ListarReservasActivasEnDataGridView(dataGridView);
        }

        public void ListarReservasFinalizadasEnDataGridView(DataGridView dataGridView)
        {
            checkInDAL.ListarReservasFinalizadasEnDataGridView(dataGridView);
        }

        public void ListarReservasTodasEnDataGridView(DataGridView dataGridView)
        {
            checkInDAL.ListarReservasTodasEnDataGridView(dataGridView);
        }




        public void BuscarClientePorDNI(string dni, DataGridView dgvClientes)
        {
            checkInDAL.BuscarClientePorDNI(dni, dgvClientes);
        }
        public void CambiarEstadoReserva(int idReserva)
        {
            checkInDAL.CambiarEstadoReserva(idReserva);
        }
        public void BuscarClientePorNumHabitacion(string NumHabitacion, DataGridView dgvClientes)
        {
            checkInDAL.BuscarClientePorNumHabitacion(NumHabitacion, dgvClientes);
        }
    }
}
