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
            lblFormulario.Text = "Empleados";
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Vista.Administrador.frmUsuarios), this);
            lblFormulario.Text = "Usuarios";
        }

        private void btnGrupoPermisos_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Vista.Administrador.frmUsuarioGrupos), this);
            lblFormulario.Text = "Gestionar Grupos del Usuario";
        }

        private void btnGruposUsuario_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Vista.Administrador.frmUsuarioGrupos), this);
            lblFormulario.Text = "Gestionar Grupos del Usuario";
        }

        private void btnGruposPermisos_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Vista.Administrador.frmGruposPermisos), this);
            lblFormulario.Text = "Gestionar Grupos y Permisos";
        }

        

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Vista.Administrador.frmEmpleado), this);
            lblFormulario.Text = "Empleados";
        }

        

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Vista.Administrador.frmReportes), this);
            lblFormulario.Text = "Reportes";
        }

        private void btnAuditoria_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Vista.Administrador.frmAuditoria), this);
            lblFormulario.Text = "Auditoria";
        }
    }
}
