using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controladora
{
    public class EmpleadoBLL
    {

        EmpleadoDAL _empleadoDal = new EmpleadoDAL();


        public string AgregarEmpleado(EmpleadoBE empleado)
        {
            return _empleadoDal.AgregarEmpleado(empleado);
        }
        public string ModificarEmpleado(EmpleadoBE empleado)
        {
            return _empleadoDal.ModificarEmpleado(empleado);
        }
        public string EliminarEmpleado(EmpleadoBE empleado)
        {
            return _empleadoDal.EliminarEmpleado(empleado);
        }


        //ListarEmpleadosEnDataGridView
        public void ListarEmpleadosEnDGV(DataGridView dataGridView)
        {
            _empleadoDal.ListarEmpleadosEnDGV(dataGridView);
        }


        public void BuscarEmpleadoPorDNI(string dni, DataGridView dgvClientes)
        {
            _empleadoDal.BuscarEmpleadoPorDNI(dni, dgvClientes);
        }






    }
}
