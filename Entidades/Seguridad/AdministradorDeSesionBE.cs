using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades.Seguridad
{
    public class AdministradorDeSesionBE
    {
        

        private static object _lock = new Object();
        
        private static AdministradorDeSesionBE _sesion;

        public UsuarioBE Usuario { get; set; }
        public DateTime FechaInicio { get; set; }


        

        public static AdministradorDeSesionBE ObtenerInstancia
        {
            get
            {
                if (_sesion == null)
                {
                    lock (_lock)
                    {
                        if (_sesion == null)
                        {
                            _sesion = new AdministradorDeSesionBE();
                        }
                    }
                }
                return _sesion;
            }
        }


      
       
        public static void Login(UsuarioBE usuario)
        {
            lock (_lock)
            {
                AdministradorDeSesionBE sesion = ObtenerInstancia;

                if (sesion.Usuario == null)
                {
                    sesion.Usuario = usuario;
                    sesion.FechaInicio = DateTime.Now;
                }
                else
                {
                    MessageBox.Show("Ya hay un usuario logueado");
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
                    MessageBox.Show("Sesion no iniciada");
                }
            }

        }
    }
}
