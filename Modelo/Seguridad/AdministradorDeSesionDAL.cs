using Entidades.Seguridad;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Modelo.Seguridad
{
    public class AdministradorDeSesionDAL
    {
        ContextoBD con = new ContextoBD();
        UsuarioDAL usuarioDAL = new UsuarioDAL();

        
        //AdministradorDeSesionBE admSesion = AdministradorDeSesionBE.obtenerInstancia;

        


        public void Login(UsuarioBE usuario)
        {
            if(usuarioDAL .VerificarCredencialesEncriptadas(usuario.Nombre, usuario.Clave) == true)
            {
                UsuarioBE usuarioNuevo = con.Usuario.Where(u => u.Nombre == usuario.Nombre).FirstOrDefault();
                AdministradorDeSesionBE.Login(usuarioNuevo);
            }
            else
            {
                throw new Exception("Error en el login");
            }
        }


        public static void LogOut(UsuarioBE usuario)
        {
            AdministradorDeSesionBE.LogOut(usuario);

        }

        



    }
}
