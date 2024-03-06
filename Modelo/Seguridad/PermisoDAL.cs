using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entidades.Seguridad;
using System.ComponentModel;
using System.Windows.Forms;

namespace Modelo
{
    public class PermisoDAL
    {
        //ContextoBD con = new ContextoBD();
        ContextoBD con = new ContextoBD();

        #region Listar en DGV
        //Listar los permisos que tiene el Grupo
        public void ListarPermisosGrupoEnDGV(System.Windows.Forms.DataGridView dgvGruposPermisosUsuario, int idComponenteGrupo)
        {


            //List<PermisoBE> permisosGrupo = con.Permiso.Include(p => p.Componente).Where(p => p.Componente.Id == idComponente).ToList();
            int GrupoId = con.Grupo.FirstOrDefault(p => p.Componente.Id == idComponenteGrupo).Id;

            List<GrupoComponenteBE> permisosGrupo = con.GrupoComponente.Include(p => p.Componente).Where(p => p.Grupo.Id == GrupoId).ToList();


            // Limpiamos las filas existentes en el DataGridView
            dgvGruposPermisosUsuario.Rows.Clear();
            dgvGruposPermisosUsuario.Columns.Clear();


            // Agregamos las columnas al DataGridView
            dgvGruposPermisosUsuario.Columns.Add("Id", "Id");
            dgvGruposPermisosUsuario.Columns.Add("Nombre", "Nombre");

            // Iteramos sobre la lista de grupos del usuario y agregamos cada grupo al DataGridView
            // Iteramos sobre la lista de permisos del grupo y agregamos cada permiso al DataGridView
            foreach (var permiso in permisosGrupo)
            {
                int rowIndex = dgvGruposPermisosUsuario.Rows.Add();
                dgvGruposPermisosUsuario.Rows[rowIndex].Cells["Id"].Value = permiso.Componente.Id;
                dgvGruposPermisosUsuario.Rows[rowIndex].Cells["Nombre"].Value = permiso.Componente.Nombre;
            }


            /*
            var permisosComponentes = from p in con.Permiso
                                      join pc in con.GrupoComponente on p.Componente.Id equals pc.Componente.Id
                                      where pc.Grupo.Id == idComponente
                                      select new
                                      {
                                          ComponenteId = p.Componente.Id,
                                          ComponenteNombre = p.Componente.Nombre,
                                          
                                      };

            dgvPermisos.DataSource = permisosComponentes.ToList();
            */

            /*var componente = from p in con.Componente
                           join gp in con.GrupoComponente on p.Id equals gp.Componente.Id
                           where gp.Grupo.Id == idGrupo
                           select new
                           {
                               Id = p.Id,
                               Nombre = p.Nombre
                           };
            dgvPermisos.DataSource = componente.ToList();*/
        }







        //Listar todos los permisos en DGV
        public void ListarPermisosEnDGV(System.Windows.Forms.DataGridView dgvGruposPermisosUsuario)
        {

            List<PermisoBE> permisosGrupo = con.Permiso.Include(p => p.Componente).ToList();


            // Limpiamos las filas existentes en el DataGridView
            dgvGruposPermisosUsuario.Rows.Clear();
            dgvGruposPermisosUsuario.Columns.Clear();


            // Agregamos las columnas al DataGridView
            dgvGruposPermisosUsuario.Columns.Add("Id", "Id");
            dgvGruposPermisosUsuario.Columns.Add("Nombre", "Nombre");

            // Iteramos sobre la lista de grupos del usuario y agregamos cada grupo al DataGridView
            // Iteramos sobre la lista de permisos del grupo y agregamos cada permiso al DataGridView
            foreach (var permiso in permisosGrupo)
            {
                int rowIndex = dgvGruposPermisosUsuario.Rows.Add();
                dgvGruposPermisosUsuario.Rows[rowIndex].Cells["Id"].Value = permiso.Componente.Id;
                dgvGruposPermisosUsuario.Rows[rowIndex].Cells["Nombre"].Value = permiso.Componente.Nombre;
            }



            /*
            var permisosComponentes = from p in con.Permiso
                                      select new
                                      {
                                          PermisoId = p.Id,
                                          ComponenteNombre = p.Componente.Nombre,
                                          ComponenteId = p.Componente.Id,
                                      };

            dgvPermisos.DataSource = permisosComponentes.ToList();
            */
            /*
            var permisos = from p in con.Permiso
                           select new
                           {
                               Id = p.Id,
                               Nombre = p.Componente.Nombre
                           };
            dgvPermisos.DataSource = permisos.ToList();*/
        }
        #endregion

        #region ABM Grupo
        

        //Agregar permiso
        public void AgregarPermiso(PermisoBE permiso)
        {
            try
            {
                if (con.Permiso.Any(p => p.Componente.Nombre == permiso.Componente.Nombre))
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
                PermisoBE permisoAModificar = con.Permiso.Include(g => g.Componente).FirstOrDefault(g => g.Id == permiso.Id);
                permisoAModificar.Id = permiso.Id;
                permisoAModificar.Componente.Nombre = permiso.Componente.Nombre;

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
                PermisoBE permisoAEliminar = con.Permiso.Include(g => g.Componente).FirstOrDefault(g => g.Id == idPermiso);
                con.Componente.Remove(permisoAEliminar.Componente);
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









    public class PermisoComposite : Componente
    {
        ContextoBD con = new ContextoBD();
        public override void Crear(ComponenteBE componente)
        {
            /*
            PermisoBE permiso = new PermisoBE();
            permiso.Componente = componente;

            con.Componente.Add(componente);
            con.Permiso.Add(permiso);
            con.SaveChanges();
            */


            try
            {
                if (con.Permiso.Any(p => p.Componente.Nombre == componente.Nombre))
                {
                    MessageBox.Show("Ya existe un permiso con ese nombre.");
                }
                else
                {
                    PermisoBE permiso = new PermisoBE();
                    permiso.Componente = componente;

                    con.Componente.Add(componente);
                    con.Permiso.Add(permiso);
                    con.SaveChanges();
                    MessageBox.Show("Permiso creado con exito");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar el grupo. " + ex.Message);
            }

        }

        public override void Eliminar(ComponenteBE componente)
        {
            PermisoBE permiso = con.Permiso.Include(p => p.Componente).FirstOrDefault(p => p.Componente.Id == componente.Id);
            //permiso.Componente = componente;
            if (permiso != null)
            {
                ComponenteBE compEliminar = con.Componente.FirstOrDefault(p => p.Id == componente.Id);

                List<GrupoComponenteBE> grupoComponentes = con.GrupoComponente.Where(p => p.Componente.Id == componente.Id).ToList();

                List<UsuarioGrupoComponenteBE> usuarioComponentes = con.UsuarioGrupoComponente.Where(p => p.Componente.Id == componente.Id).ToList();

                if (grupoComponentes != null)
                {
                    foreach (var grupoComponente in grupoComponentes)
                    {
                        con.GrupoComponente.Remove(grupoComponente);
                    }

                }
                if (usuarioComponentes != null)
                {
                    foreach (var usuarioComponente in usuarioComponentes)
                    {
                        con.UsuarioGrupoComponente.Remove(usuarioComponente);
                    }
                }
                con.Componente.Remove(compEliminar);
                con.Permiso.Remove(permiso);
                con.SaveChanges();
                MessageBox.Show("Permiso eliminado con exito");
                // Actualizar las propiedades del permiso

            }

        }

        public override void Modificar(ComponenteBE componente)
        {
            // Buscar el PermisoBE existente en la base de datos
            PermisoBE permiso = con.Permiso.Include(p => p.Componente).FirstOrDefault(p => p.Componente.Id == componente.Id);


            if (permiso != null)
            {
                // Actualizar las propiedades del permiso
                permiso.Componente.Nombre = componente.Nombre;

                // Guardar los cambios en la base de datos
                con.SaveChanges();
                MessageBox.Show("Permiso modificado con exito");
            }
        }




    }















}
