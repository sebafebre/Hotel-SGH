using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Modelo;
using Entidades;
using Entidades.Seguridad;
using System.Runtime.Remoting.Contexts;
using System.Drawing;

namespace Controladora
{
    public class UsuarioBLL
    {

        UsuarioDAL usuarioDAL = new UsuarioDAL();


        //ValidarCredenciales de Modelo.UsuarioDAL
        public UsuarioBE ValidarCredenciales(string usuario, string password)
        {
            return usuarioDAL.ValidarCredenciales(usuario, password);
        }
        



        //Agregar usuario
        public string AgregarUsuario(UsuarioBE usuario)
        {
            return usuarioDAL.AgregarUsuario(usuario);
        }

        //Modificar usuario
        public string ModificarUsuario(UsuarioBE usuario)
        {
            return usuarioDAL.ModificarUsuario(usuario);

        }

        //Eliminar usuario
        public string EliminarUsuario(UsuarioBE usuario)
        {
            return usuarioDAL.EliminarUsuario(usuario);
        }
        




        //Listar usuarios en DataGridView
        public void ListarUsuariosEnDGV(System.Windows.Forms.DataGridView dgvUsuarios)
        {
            usuarioDAL.ListarUsuariosEnDGV(dgvUsuarios);
        }






        
        public List<PermisoBE> ObtenerPermisosUsuario(int idUsuario)
        {
            return usuarioDAL.ObtenerPermisosUsuario(idUsuario);
        }




        public string AgregarGrupoAUsuario(int idUsuario, int idGrupo)
        {
            return usuarioDAL.AgregarGrupoAUsuario(idUsuario, idGrupo);
        }


        //Eliminar Grupo del Usuario
        public string EliminarGrupoAUsuario(int idUsuario, int idGrupo)
        {
            return usuarioDAL.EliminarGrupoAUsuario(idUsuario, idGrupo);
        }











    }
}
