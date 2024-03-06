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

namespace Vista.Administrador
{
    public partial class frmAdministrador : Form
    {
        EmpleadoBLL empleadoBLL = new EmpleadoBLL();

        ValidacionesBLL validacionBLL = new ValidacionesBLL();
        public frmAdministrador()
        {
            InitializeComponent();
            ValidacionesBLL.CambiarPanel(typeof(Vista.Administrador.frmEmpleado), this);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Vista.Administrador.frmUsuarios), this);
        }

        private void btnGrupoPermisos_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Vista.Administrador.frmUsuarioGrupos), this);
        }

        private void btnGruposUsuario_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Vista.Administrador.frmUsuarioGrupos), this);
        }

        private void btnGruposPermisos_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Vista.Administrador.frmGruposPermisos), this);
        }

        

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Vista.Administrador.frmEmpleado), this);
        }

        private void btnBackups_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Vista.Administrador.frmBackUps), this);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Vista.Administrador.frmReportes), this);
        }
    }
}
