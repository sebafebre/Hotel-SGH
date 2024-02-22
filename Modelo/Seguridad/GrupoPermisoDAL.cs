using Entidades;
using Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo
{
    public class GrupoPermisoDAL
    {
        //ContextoBD con = new ContextoBD();
        ContextoBD con = ContextoBD.Instance();

        // Método para obtener los permisos de un usuario



        /*


        public static void VerificarPermisos(List<GrupoPermisoBE> permisosUsuario, List<string> permisos, UsuarioBE usuario, Button btnOcupacion, Button btnHabitaciones, Button btnClientes, Button btnReservas, Button btnCheckIn, Button btnCheckOut, Button btnPedidos, Button btnAdministrador)
        {
            foreach (var item in permisosUsuario)
            {
                permisos.Add(item.Permiso.Nombre);
            }
            if (permisos.Contains("frmOcupacion"))
            {
                btnOcupacion.Enabled = true;
                btnOcupacion.BackColor = Color.Green;
            }
            else
            {
                btnOcupacion.Enabled = false;
                btnOcupacion.BackColor = Color.Gray;
            }
            if (permisos.Contains("frmHabitaciones"))
            {
                btnHabitaciones.Enabled = true;
                btnHabitaciones.BackColor = Color.Green;
            }
            else
            {
                btnHabitaciones.Enabled = false;
                btnHabitaciones.BackColor = Color.Gray;
            }
            if (permisos.Contains("frmClientes"))
            {
                btnClientes.Enabled = true;
                btnClientes.BackColor = Color.Green;
            }
            else
            {
                btnClientes.Enabled = false;
                btnClientes.BackColor = Color.Gray;
            }
            if (permisos.Contains("frmReservas"))
            {
                btnReservas.Enabled = true;
                btnReservas.BackColor = Color.Green;
            }
            else
            {
                btnReservas.Enabled = false;
                btnReservas.BackColor = Color.Gray;
            }
            if (permisos.Contains("frmCheckIn"))
            {
                btnCheckIn.Enabled = true;
                btnCheckIn.BackColor = Color.Green;
            }
            else
            {
                btnCheckIn.Enabled = false;
                btnCheckIn.BackColor = Color.Gray;
            }
            if (permisos.Contains("frmCheckOut"))
            {
                btnCheckOut.Enabled = true;
                btnCheckOut.BackColor = Color.Green;
            }
            else
            {
                btnCheckOut.Enabled = false;
                btnCheckOut.BackColor = Color.Gray;
            }
            if (permisos.Contains("frmPedidos"))
            {
                btnPedidos.Enabled = true;
                btnPedidos.BackColor = Color.Green;
            }
            else
            {
                btnPedidos.Enabled = false;
                btnPedidos.BackColor = Color.Gray;
            }
            if (permisos.Contains("frmAdministrador"))
            {
                btnAdministrador.Enabled = true;
                btnAdministrador.BackColor = Color.Green;
            }
            else
            {
                btnAdministrador.Enabled = false;
                btnAdministrador.BackColor = Color.Gray;
            }
        }*/

    }
}
