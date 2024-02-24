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
using Entidades;

namespace Vista
{
    public partial class Login : Form
    {
        UsuarioBLL _controladoraUsuario = new UsuarioBLL();

        

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


            frmMenu ForM = new frmMenu();
            ForM.Show();
            this.Hide();








            

            // Realizar la autenticación del usuario
            /*
            UsuarioBE usuario = _controladoraUsuario.ValidarCredenciales(nombre, clave);
            if (usuario != null)
            {

                // Abrir el formulario de permisos y pasar el usuario autenticado
                //MostrarPermisosForm(usuarioAutenticado);
                frmMenu ForM = new frmMenu(usuario);
                ForM.Show();

                this.Hide(); // Ocultar el formulario de inicio de sesión
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Inténtelo de nuevo.");
            }*/

        }
    }
}
