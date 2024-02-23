using Entidades;
using Controladora;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmMenu : Form
    {
        private UsuarioBE usuario;
        private UsuarioBLL controladorPermisos;



        public frmMenu(/*UsuarioBE usuario*/)
        {
            InitializeComponent();
            this.usuario = usuario;
            controladorPermisos = new UsuarioBLL();
            //---------------------->//VerificarP();
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmOcupacion), this);
        }

        private void VerificarP()
        {
            List<PermisoBE> permisosUsuario = controladorPermisos.ObtenerPermisosUsuario(usuario.Id);

            List<string> permisos = new List<string>();
            foreach (var item in permisosUsuario)
            {
                permisos.Add(item.Componente.Nombre);
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
            
            /**
            List<PermisoBE> permisosUsuario = controladorPermisos.ObtenerPermisosUsuario(usuario.Id);

            List<int> permisos = new List<int>();
            foreach (var item in permisosUsuario)
            {
                permisos.Add(item.Id);
            }
            if (permisos.Contains(1))
            {
                btnOcupacion.Enabled = true;
                btnOcupacion.BackColor = Color.Green;
            }
            else
            {
                btnOcupacion.Enabled = false;
                btnOcupacion.BackColor = Color.Gray;
            }
            if (permisos.Contains(2))
            {
                btnHabitaciones.Enabled = true;
                btnHabitaciones.BackColor = Color.Green;
            }
            else
            {
                btnHabitaciones.Enabled = false;
                btnHabitaciones.BackColor = Color.Gray;
            }
            if (permisos.Contains(3))
            {
                btnClientes.Enabled = true;
                btnClientes.BackColor = Color.Green;
            }
            else
            {
                btnClientes.Enabled = false;
                btnClientes.BackColor = Color.Gray;
            }
            if (permisos.Contains(4))
            {
                btnReservas.Enabled = true;
                btnReservas.BackColor = Color.Green;
            }
            else
            {
                btnReservas.Enabled = false;
                btnReservas.BackColor = Color.Gray;
            }
            if (permisos.Contains(5))
            {
                btnCheckIn.Enabled = true;
                btnCheckIn.BackColor = Color.Green;
            }
            else
            {
                btnCheckIn.Enabled = false;
                btnCheckIn.BackColor = Color.Gray;
            }
            if (permisos.Contains(6))
            {
                btnCheckOut.Enabled = true;
                btnCheckOut.BackColor = Color.Green;
            }
            else
            {
                btnCheckOut.Enabled = false;
                btnCheckOut.BackColor = Color.Gray;
            }
            if (permisos.Contains(7))
            {
                btnPedidos.Enabled = true;
                btnPedidos.BackColor = Color.Green;
            }
            else
            {
                btnPedidos.Enabled = false;
                btnPedidos.BackColor = Color.Gray;
            }
            if (permisos.Contains(8))
            {
                btnAdministrador.Enabled = true;
                btnAdministrador.BackColor = Color.Green;
            }
            else
            {
                btnAdministrador.Enabled = false;
                btnAdministrador.BackColor = Color.Gray;
            }*/
        }

        private void btnOcupacion_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmOcupacion), this);
        }

        private void btnHabitaciones_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmHabitaciones), this);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmClientes), this);
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmReservas), this);
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmCheckIn), this);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmCheckOut), this);
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmPedidos), this);
        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Administrador.frmAdministrador), this);
        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            Login frmLogIn = new Login();
            frmLogIn.Show();
            this.Hide();
        }
    }
}
