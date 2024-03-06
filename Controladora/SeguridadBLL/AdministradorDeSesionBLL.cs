using Entidades.Seguridad;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Seguridad;
using Modelo;
using System.Drawing;

namespace Controladora.SeguridadBLL
{
    public class AdministradorDeSesionBLL
    {

        AdministradorDeSesionDAL adm = new AdministradorDeSesionDAL();

        public void Login(UsuarioBE usuario)
        {
             adm.Login(usuario);
        }

        
        public void LoginAdm(UsuarioBE usuario)
        {
            AdministradorDeSesionBE.Login(usuario);

        }


        public static void LogOut(UsuarioBE usuario)
        {
            AdministradorDeSesionBE.LogOut(usuario);

        }



    }
}
