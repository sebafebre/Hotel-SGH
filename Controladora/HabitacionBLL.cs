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
    public class HabitacionBLL
    {
        HabitacionesDAL _habitacionesDAL = new HabitacionesDAL();
        

        public void AgregarHabitacion(HabitacionBE habitacion)
        {
             _habitacionesDAL.AgregarHabitacion(habitacion);
        }




        public string EliminarHabitacion(HabitacionBE habitacion)
        {
            return _habitacionesDAL.EliminarHabitacion(habitacion);
        }

        public string ModificarHabitacion(HabitacionBE habitacion)
        {
            return _habitacionesDAL.ModificarHabitacion(habitacion);
        }


        


        public void ListarHabitacionesEnDataGridView(DataGridView dataGridView)
        {
            _habitacionesDAL.ListarHabitacionesEnDataGridView(dataGridView);
        }

        public void BuscarHabitacionesDGV(DataGridView dataGridView)
        {
            _habitacionesDAL.BuscarHabitacionesDGV(dataGridView);
        }

        public void BuscarHabitacionDGV(DataGridView dataGridView)
        {
            _habitacionesDAL.BuscarHabitacionDGV(dataGridView);
        }

        public string ObtenerEstadoSeleccionado(Control flowLayoutPanel)
        {
            return _habitacionesDAL.ObtenerEstadoSeleccionado(flowLayoutPanel);
        }

        

    }
}
