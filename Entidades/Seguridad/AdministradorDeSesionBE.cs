using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Seguridad
{
    public class AdministradorDeSesionBE
    {
        

        private static object _lock = new Object();
        
        private static AdministradorDeSesionBE _sesion;

        public UsuarioBE Usuario { get; set; }
        public DateTime FechaInicio { get; set; }


        
        public static AdministradorDeSesionBE obtenerInstancia
        {
            get
            {
                if (_sesion == null) //throw new Exception("No hay una sesion iniciada");
                {
                    _sesion = new AdministradorDeSesionBE();
                }
                return _sesion;

            }
        }

        public static void Login(UsuarioBE usuario)
        {
            lock (_lock)
            {
                if (_sesion == null)
                {
                    _sesion = new AdministradorDeSesionBE();
                    _sesion.Usuario = usuario;
                    _sesion.FechaInicio = DateTime.Now;
                }
                else
                {
                    throw new Exception("Ya hay un usuario logueado");
                }

            }

        }


        public static void LogOut(UsuarioBE usuario)
        {
            lock (_lock)
            {
                if (_sesion != null)
                {
                    _sesion = null;
                }
                else
                {
                    throw new Exception("Sesion no iniciada");
                }
            }

        }
    }
}
