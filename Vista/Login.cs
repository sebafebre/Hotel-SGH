using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladora;
using Controladora.SeguridadBLL;
using Entidades;
using Entidades.Seguridad;

namespace Vista
{
    public partial class Login : Form
    {
        UsuarioBLL _controladoraUsuario = new UsuarioBLL();


        //AdministradorDeSesionBE admSesion = AdministradorDeSesionBE.obtenerInstancia;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //PASAR A LA CONTROLADORA
            /*
            lblErrorUsuairo.Text = "";
            lblErrorClave.Text = "";
            if (string.IsNullOrEmpty(txtNombreUsuario.Text))
            {
                lblErrorUsuairo.Text = "Debe ingresar el nombre de usuario";
                return;
            }

            if (string.IsNullOrEmpty(txtClave.Text))
            {
                lblErrorClave.Text = "Debe ingresar la clave";
                return;
            }*/




            string nombre = txtNombreUsuario.Text;
            string clave = txtClave.Text;
            UsuarioBE.usaurioLogueado = nombre;

            /*
            frmMenu ForM = new frmMenu();
            ForM.Show();
            this.Hide();
            */







            AdministradorDeSesionBLL adm = new AdministradorDeSesionBLL();

            // Realizar la autenticación del usuario

            //UsuarioBE usuario = _controladoraUsuario.ValidarCredenciales(nombre, clave);
            //if (usuario != null)
            if (_controladoraUsuario.VerificarCredencialesEncriptadas(nombre, clave))
            {
                UsuarioBE usuario = new UsuarioBE();
                usuario.Nombre = nombre;
                usuario.Clave = clave;

                adm.Login(usuario);
                //AdministradorDeSesionBE pep = AdministradorDeSesionBE.obtenerInstancia;
                // Abrir el formulario de permisos y pasar el usuario autenticado
                //MostrarPermisosForm(usuarioAutenticado);
                //frmMenu ForM = new frmMenu(usuario);

                frmMenu ForM = new frmMenu();
                ForM.Show();

                this.Hide(); // Ocultar el formulario de inicio de sesión
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Inténtelo de nuevo.");
            }

        }

        

        private void label2_Click(object sender, EventArgs e)
        {
            UsuarioBE usuario = new UsuarioBE();
            //usuario.Nombre = usuarioActual;
            AdministradorDeSesionBE.LogOut(usuario);
        }
    }
}
