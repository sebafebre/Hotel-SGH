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

        private AdministradorDeSesionBE _sesionActual;

        AdministradorDeSesionBE admSesion = AdministradorDeSesionBE.ObtenerInstancia;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            
            
            

            string nombre = txtNombreUsuario.Text;
            string clave = txtClave.Text;
            UsuarioBE.usaurioLogueado = nombre;
            

            
            if (_sesionActual == null || _sesionActual.Usuario == null)
            {

                if (_controladoraUsuario.VerificarContraseña(nombre, clave))
                {
                    

                    UsuarioBE usuario = new UsuarioBE();
                    usuario.Nombre = nombre;
                    usuario.Clave = clave;



                    AdministradorDeSesionBE.Login(usuario);

                    frmMenu ForM = new frmMenu();
                    ForM.Show();

                    this.Hide(); // Ocultar el formulario de inicio de sesión
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas. Inténtelo de nuevo.");
                }
            }
            else
            {
                // La sesión ya está iniciada
                MessageBox.Show("La sesión está iniciada para el usuario: " + _sesionActual.Usuario.Nombre);
            }
            

        }

       


        
    }
}
