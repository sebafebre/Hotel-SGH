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
        //private UsuarioBE usuario;
        UsuarioBLL controladorPermisos = new UsuarioBLL();
        GrupoBLL grupoBLL = new GrupoBLL();

        string usuarioActual = UsuarioBE.usaurioLogueado;

        //UsuarioBE.usaurioLogueado = nombre;




        public frmMenu(/*UsuarioBE usuario*/)
        {
            InitializeComponent();
            //this.usuario = usuario;
            //controladorPermisos = new UsuarioBLL();

            VerificarP();
            ValidacionesBLL.AbrirFormulario(typeof(Vista.Paneles.frmOcupacion), this);


            lblUsuario.Text = usuarioActual;


        }

        private void VerificarP()
        {
            //List<PermisoBE> permisosUsuario = controladorPermisos.ObtenerPermisosUsuario(usuarioActual);

            //List<ComponenteBE> listaPermisos = controladorPermisos.ObtenerPermisosPorUsuario(usuarioActual);

            List<PermisoBE> permisosUsuario = grupoBLL.ObtenerPermisosDelUsuario(usuarioActual);

            List<string> permisos = new List<string>();

            //foreach (var item in permisosUsuario)
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            UsuarioBE usuario = new UsuarioBE();
            usuario.Nombre = usuarioActual;
            AdministradorDeSesionBE.LogOut(usuario);

            Login frmLogIn = new Login();
            frmLogIn.Show();
            this.Hide();

        }




    }
}
