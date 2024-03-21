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
using System.Windows.Forms;
using System.ComponentModel;

namespace Controladora
{
    public class UsuarioBLL
    {

        UsuarioDAL usuarioDAL = new UsuarioDAL();


        //ValidarCredenciales de Modelo.UsuarioDAL
        /*
        public UsuarioBE ValidarCredenciales(string usuario, string password)
        {
            return usuarioDAL.ValidarCredenciales(usuario, password);
        }*/
        public bool VerificarCredencialesEncriptadas(string nombreUsuario, string clave)
        {
            return usuarioDAL.VerificarContraseña(nombreUsuario, clave);
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






        
        public List<PermisoBE> ObtenerPermisosUsuario(string Usuario)
        {
            return usuarioDAL.ObtenerPermisosUsuario(Usuario);
        }

        




        



        public List<ComponenteBE> ObtenerPermisosDelUsuario(string nombreUsuario)
        {
            return usuarioDAL.ObtenerPermisosDelUsuario(nombreUsuario);

        }





        public UsuarioBE obtenerUsuarioLogueado(string nombreUsuario)
        {
            return usuarioDAL.obtenerUsuarioLogueado(nombreUsuario);
        }

















        public void AgregarGrupoAUsuario(int idUsuario, int idComponente)
        {
             usuarioDAL.AgregarGrupoAUsuario(idUsuario, idComponente);
        }


        //Eliminar Grupo del Usuario
        public void EliminarGrupoAUsuario(int idUsuario, int idComponente)
        {
             usuarioDAL.EliminarGrupoAUsuario(idUsuario, idComponente);
        }


        public void AgregarPermisoAUsuario(int idUsuario, int idComponente)
        {
            usuarioDAL.AgregarPermisoAUsuario(idUsuario, idComponente);
        }


        public void EliminarPermisoAUsuario(int idUsuario, int idComponente)
        {
            usuarioDAL.EliminarPermisoAUsuario(idUsuario, idComponente);
        }


        public void ListarGruposYPermisosUsuarioEnDataGridView(DataGridView dgvGruposPermisosUsuario, int idUsuario)
        {
            usuarioDAL.ListarGruposYPermisosUsuarioEnDataGridView(dgvGruposPermisosUsuario, idUsuario);
        }







        #region ABM Usaurio
        //Agregar usuario
        public void AgregarUsuarioEncriptado(UsuarioBE usuario)
        {
            usuarioDAL.AgregarUsuarioEncriptado(usuario);
            

        }


        //Modificar usuario
        public void ModificarUsuarioEncriptado(UsuarioBE usuario)
        {
             usuarioDAL.ModificarUsuarioEncriptado(usuario);

        }

        //Eliminar usuario
        public void EliminarUsuarioEncriptado(UsuarioBE usuario)
        {
             usuarioDAL.EliminarUsuarioEncriptado(usuario);

        }

        public bool VerificarContraseña(string nombreUsuario, string contraseña)
        {
            return usuarioDAL.VerificarContraseña(nombreUsuario, contraseña);

        }
        #endregion





    }
}
