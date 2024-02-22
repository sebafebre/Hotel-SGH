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
    public class ValidacionesBLL
    {
        ValidacionesDAL validacionesDAL = new ValidacionesDAL();
        //retornar las validaciones que se encuentran en ValidacionesDAL
        //AbrirFormulario
        public static void AbrirFormulario(Type tipoFormulario, Form frmMenu)
        {
            ValidacionesDAL.AbrirFormulario(tipoFormulario, frmMenu);
        }

        //CambiarPanel
        public static void CambiarPanel(Type tipoFormulario, Form frmMenu)
        {
            ValidacionesDAL.CambiarPanel(tipoFormulario, frmMenu);
        }

        public void LimpiarCampos(Control.ControlCollection controles)
        {
            validacionesDAL.LimpiarCampos(controles);
        }

        public void BuscarPorDNI(string dni, DataGridView dgvClientes)
        {
            validacionesDAL.BuscarPorDNI(dni, dgvClientes);
        }

        public string ObtenerEstadoSeleccionado(Control flowLayoutPanel)
        {
            return validacionesDAL.ObtenerEstadoSeleccionado(flowLayoutPanel);
        }

    }
}
