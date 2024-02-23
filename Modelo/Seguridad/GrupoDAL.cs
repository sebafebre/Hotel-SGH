using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Entity;


namespace Modelo
{
    public class GrupoDAL : GrupoBE
    {
        //ContextoBD con = new ContextoBD();
        ContextoBD con = ContextoBD.Instance();


        /*
        public override void Crear(ComponenteBE comp) 
        {
            GrupoBE grupo = new GrupoBE();
            grupo.Componente = comp;

            con.Componente.Add(comp);
            con.Grupo.Add(grupo);
            con.SaveChanges();

        }

        public override void Eliminar(ComponenteBE comp)
        {
            // Obtener el Id del componente
            int idcomp = comp.ObtenerId();

            // Buscar el grupo que tiene el Id proporcionado
            GrupoBE grupo = con.Grupo.FirstOrDefault(gr => gr.Componente.ObtenerId() == idcomp);

            if (grupo != null)
            {
                con.Componente.Remove(comp);
                // Si se encontró el grupo, eliminarlo del contexto y guardar los cambios
                con.Grupo.Remove(grupo);
                con.SaveChanges();
            }
        }
        public override void Listar(int depth)
        {

        }
        */



















        #region Listar Grupos en DGView
        public void ListarGruposEnComboBox(System.Windows.Forms.ComboBox cboGrupos)
        {
            var grupos = from g in con.Grupo
                         select g;
            cboGrupos.DataSource = grupos.ToList();
            cboGrupos.DisplayMember = "Nombre";
            cboGrupos.ValueMember = "Id";
        }

        public void ListarGruposEnDGV(System.Windows.Forms.DataGridView dgvGrupos)
        {
            var grupos = from g in con.Grupo
                         select new
                         {
                             Id = g.Id,
                             Nombre = g.Componente.Nombre
                         };
            dgvGrupos.DataSource = grupos.ToList();
        }

        //Listar los grupos que tiene el Usuario
        public void ListarGruposUsuarioEnDataGridView(System.Windows.Forms.DataGridView dgvGrupos, int idUsuario)
        {
            var grupos = from g in con.Grupo
                         join gu in con.UsuarioGrupo on g.Id equals gu.Grupo.Id
                         where gu.Usuario.Id == idUsuario
                         select new
                         {
                             Id = g.Id,
                             Nombre = g.Componente.Nombre
                         };
            dgvGrupos.DataSource = grupos.ToList();
        }
        #endregion

        #region ABM Grupo
        public void AgregarGrupo(GrupoBE grupo)
        {
            try
            {
                if (con.Grupo.Any(g => g.Componente.Nombre == grupo.Componente.Nombre))
                {
                    throw new Exception("Ya existe un grupo con ese nombre.");
                }
                //grupo.Componente.Id = grupo.Id;
                //grupo.Componente.Nombre = grupo.Componente.Nombre;
                con.Grupo.Add(grupo);
                con.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar el grupo. " + ex.Message);
            }

        }

        public void ModificarGrupo(GrupoBE grupo)
        {
            try
            {
                GrupoBE grupoAModificar = con.Grupo.Include(g => g.Componente).FirstOrDefault(g => g.Id == grupo.Id);



                //Ahora modificar el cliente
                grupoAModificar.Componente.Nombre = grupo.Componente.Nombre;

                con.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el producto. " + ex.Message);
            }

        }

        public void EliminarGrupo(int idGrupo)
        {
            try
            {
                GrupoBE grupoAEliminar = con.Grupo.Include(g => g.Componente).FirstOrDefault(g => g.Id == idGrupo);
                con.Componente.Remove(grupoAEliminar.Componente);
                con.Grupo.Remove(grupoAEliminar);
                con.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el producto. " + ex.Message);
            }
        }

        #endregion

        #region Agregar / Quitar Permisos al Grupo --> GrupoPermiso
        //Quitar el permiso del grupo, mediante GrupoPermiso
        public void QuitarPermisoAGrupo(int idGrupo, int idPermiso)
        {
            try
            {
                GrupoBE grupo = con.Grupo.Find(idGrupo);
                PermisoBE permiso = con.Permiso.Find(idPermiso);
                GrupoPermisoBE grupoPermiso = con.GrupoPermiso.Where(gp => gp.Grupo.Id == idGrupo && gp.Permiso.Id == idPermiso).FirstOrDefault();
                con.GrupoPermiso.Remove(grupoPermiso);
                con.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo quitar el permiso del grupo. " + ex.Message);
            }
        }

        //Agregar el permiso al grupo
        public void AgregarPermisoAGrupo(int idGrupo, int idPermiso)
        {
            try
            {
                GrupoBE grupo = con.Grupo.Find(idGrupo);
                PermisoBE permiso = con.Permiso.Find(idPermiso);
                GrupoPermisoBE grupoPermiso = new GrupoPermisoBE();
                grupoPermiso.Grupo = grupo;
                grupoPermiso.Permiso = permiso;
                con.GrupoPermiso.Add(grupoPermiso);
                con.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar el permiso al grupo. " + ex.Message);
            }
        }
        #endregion
    }
}
