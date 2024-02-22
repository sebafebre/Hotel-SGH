﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class PermisoDAL
    {
        //ContextoBD con = new ContextoBD();
        ContextoBD con = ContextoBD.Instance();

        #region Listar en DGV
        //Listar los permisos que tiene el Grupo
        public void ListarPermisosGrupoEnDGV(System.Windows.Forms.DataGridView dgvPermisos, int idGrupo)
        {
            var permisos = from p in con.Permiso
                           join gp in con.GrupoPermiso on p.Id equals gp.Permiso.Id
                           where gp.Grupo.Id == idGrupo
                           select new
                           {
                               Id = p.Id,
                               Nombre = p.Nombre
                           };
            dgvPermisos.DataSource = permisos.ToList();
        }


        //Listar todos los permisos en DGV
        public void ListarPermisosEnDGV(System.Windows.Forms.DataGridView dgvPermisos)
        {
            var permisos = from p in con.Permiso
                           select new
                           {
                               Id = p.Id,
                               Nombre = p.Nombre
                           };
            dgvPermisos.DataSource = permisos.ToList();
        }
        #endregion

        #region ABM Grupo
        

        //Agregar permiso
        public void AgregarPermiso(PermisoBE permiso)
        {
            try
            {
                if (con.Permiso.Any(p => p.Nombre == permiso.Nombre))
                {
                    throw new Exception("Ya existe un permiso con ese nombre.");
                }
                con.Permiso.Add(permiso);
                con.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar el permiso. " + ex.Message);
            }

        }

        public void ModificarPermiso(PermisoBE permiso)
        {
            try
            {
                PermisoBE permisoAModificar = con.Permiso.Find(permiso.Id);
                permisoAModificar.Id = permiso.Id;
                permisoAModificar.Nombre = permiso.Nombre;

                con.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el permiso. " + ex.Message);
            }

        }

        public void EliminarPermiso(int idPermiso)
        {
            try
            {
                PermisoBE permisoAEliminar = con.Permiso.Find(idPermiso);
                con.Permiso.Remove(permisoAEliminar);
                con.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el permiso. " + ex.Message);
            }
        }

        #endregion

    }
}