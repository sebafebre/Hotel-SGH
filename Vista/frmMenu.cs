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
using Controladora.SeguridadBLL;
using Entidades.Seguridad;

namespace Vista
{
    public partial class frmMenu : Form
    {
        UsuarioBLL usaurioBLL = new UsuarioBLL();
        GrupoBLL grupoBLL = new GrupoBLL();

        string usuarioActual = UsuarioBE.usaurioLogueado;





        public frmMenu()
        {
            InitializeComponent();
            

            VerificarP();
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmOcupacion), this);
            UsuarioBE usuario = usaurioBLL.obtenerUsuarioLogueado(usuarioActual);

            lblUsuario.Text = usuario.Empleado.Persona.Nombre +" "+ usuario.Empleado.Persona.Apellido;
            lblFormulario.Text = "Ocupación";


        }

        private void VerificarP()
        {
            

            List<PermisoBE> permisosUsuario = grupoBLL.ObtenerPermisosDelUsuario(usuarioActual);

            List<string> permisos = new List<string>();

            foreach (var item in permisosUsuario)
            {
                permisos.Add(item.Componente.Nombre);
            }
            if (permisos.Contains("PS01 frmOcupacion"))
            {
                btnOcupacion.Enabled = true;
            }
            else
            {
                btnOcupacion.Enabled = false;
                btnOcupacion.BackColor = Color.Gray;
            }
            if (permisos.Contains("GH001 frmHabitaciones"))
            {
                btnHabitaciones.Enabled = true;
            }
            else
            {
                btnHabitaciones.Enabled = false;
                btnHabitaciones.BackColor = Color.Gray;
            }
            if (permisos.Contains("GC001 frmClientes"))
            {
                btnClientes.Enabled = true;
            }
            else
            {
                btnClientes.Enabled = false;
                btnClientes.BackColor = Color.Gray;
            }
            if (permisos.Contains("GR001 frmReservas"))
            {
                btnReservas.Enabled = true;
            }
            else
            {
                btnReservas.Enabled = false;
                btnReservas.BackColor = Color.Gray;
            }
            if (permisos.Contains("GE001 frmCheckIn"))
            {
                btnCheckIn.Enabled = true;
            }
            else
            {
                btnCheckIn.Enabled = false;
                btnCheckIn.BackColor = Color.Gray;
            }
            if (permisos.Contains("GS001 frmCheckOut"))
            {
                btnCheckOut.Enabled = true;
            }
            else
            {
                btnCheckOut.Enabled = false;
                btnCheckOut.BackColor = Color.Gray;
            }
            if (permisos.Contains("GP001 frmPedidos"))
            {
                btnPedidos.Enabled = true;
                
            }
            else
            {
                btnPedidos.Enabled = false;
                btnPedidos.BackColor = Color.Gray;
            }
            if (permisos.Contains("GA001 frmAdministrador"))
            {
                btnAdministrador.Enabled = true;
                
            }
            else
            {
                btnAdministrador.Enabled = false;
                btnAdministrador.BackColor = Color.Gray;
            }
            
            
        }

        private void btnOcupacion_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmOcupacion), this);
            lblFormulario.Text = "Ocupación";
        }

        private void btnHabitaciones_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmHabitaciones), this);
            lblFormulario.Text = "Habitaciones";
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmClientes), this);
            lblFormulario.Text = "Clientes";
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmAgregarReserva ), this);
            lblFormulario.Text = "Reservas";
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmCheckIn), this);
            lblFormulario.Text = "Check In";
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmCheckOut), this);
            lblFormulario.Text = "Check Out";
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmPedidos), this);
            lblFormulario.Text = "Pedidos";
        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Administrador.frmAdministrador), this);
            lblFormulario.Text = "Administrador";
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            UsuarioBE usuario = new UsuarioBE();
            usuario.Nombre = usuarioActual;
            AdministradorDeSesionBE.LogOut(usuario);

            Login frmLogIn = new Login();
            frmLogIn.Show();
            this.Hide();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
