using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SeguridadBLL
{
    public class GrupoBLL
    {
        GrupoDAL grupoDAL = new GrupoDAL();

        #region Listar en DGVieww

        

        
        public void ListarGruposEnDGV(System.Windows.Forms.DataGridView dgvGruposPermisosUsuario)
        {
            grupoDAL.ListarGruposEnDGV(dgvGruposPermisosUsuario);
        }
        
        #endregion

        #region ABM Grupo
        public void AgregarGrupo(GrupoBE grupo)
        {
            grupoDAL.AgregarGrupo(grupo);

        }

        public void ModificarGrupo(GrupoBE grupo)
        {
            grupoDAL.ModificarGrupo(grupo);
        }

        public void EliminarGrupo(int idGrupo)
        {
            grupoDAL.EliminarGrupo(idGrupo);
        }

        #endregion



        #region Agregar / Quitar Permisos al Grupo --> GrupoPermiso
        //Quitar el permiso del grupo, mediante GrupoPermiso
        public void QuitarPermisoAGrupo(int idGrupo, int idPermiso)
        {
            grupoDAL.QuitarPermisoAGrupo(idGrupo, idPermiso);
        }

        //Agregar el permiso al grupo
        public void AgregarPermisoAGrupo(int idGrupo, int idPermiso)
        {
            grupoDAL.AgregarPermisoAGrupo(idGrupo, idPermiso);
        }
        #endregion




        public List<PermisoBE> ObtenerPermisosDelUsuario(string nombreUsuario)
        {
            return grupoDAL.ObtenerPermisosDelUsuario(nombreUsuario);

        }




        #region Composite

        private Componente grupo;
        

        public GrupoBLL()
        {
            grupo = new GrupoComposite();
        }

        public void CrearGrupo(ComponenteBE componente)
        {
            grupo.Crear(componente);
        }

        public void EliminarGrupo(ComponenteBE componente)
        {
            grupo.Eliminar(componente);
        }

        public void ModificarGrupo(ComponenteBE componente)
        {
            grupo.Modificar(componente);
        }

        




        #endregion









    }
}
