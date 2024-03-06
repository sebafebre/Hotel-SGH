using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SeguridadBLL
{
    public class PermisoBLL
    {
        PermisoDAL permisoDAL = new PermisoDAL();

        #region Listar en DGVieww
        public void ListarPermisosGrupoEnDGV(System.Windows.Forms.DataGridView dgvPermisos, int idComponente)
        {
            permisoDAL.ListarPermisosGrupoEnDGV(dgvPermisos, idComponente);
        }
        public void ListarPermisosEnDGV(System.Windows.Forms.DataGridView dgvPermisos)
        {
            permisoDAL.ListarPermisosEnDGV(dgvPermisos);
        }
        #endregion


        #region ABM Grupo

        //Agregar permiso
        public void AgregarPermiso(PermisoBE permiso)
        {
            permisoDAL.AgregarPermiso(permiso);

        }

        public void ModificarPermiso(PermisoBE permiso)
        {
            permisoDAL.ModificarPermiso(permiso);


        }

        public void EliminarPermiso(int idPermiso)
        {
            permisoDAL.EliminarPermiso(idPermiso);
        }

        #endregion




        #region Composite

        private Componente permiso;




        public PermisoBLL()
        {

            permiso = new PermisoComposite();
        }

        public void CrearPermiso(ComponenteBE componente)
        {
            permiso.Crear(componente);
        }

        public void EliminarPermiso(ComponenteBE componente)
        {
            permiso.Eliminar(componente);
        }

        public void ModificarPermiso(ComponenteBE componente)
        {
            permiso.Modificar(componente);
        }







        #endregion







    }














}
