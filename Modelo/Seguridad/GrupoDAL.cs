using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Entity;
using System.Windows.Forms;
using Entidades.Seguridad;


namespace Modelo
{
    public class GrupoDAL 
    {
        //ContextoBD con = new ContextoBD();
        ContextoBD con = new ContextoBD();


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

        //Listar grupos en el DataGridView
        public void ListarGruposEnDGV(System.Windows.Forms.DataGridView dgvGruposPermisosUsuario)
        {

            List<GrupoBE> Grupos = con.Grupo.Include(p => p.Componente).ToList();


            // Limpiamos las filas existentes en el DataGridView
            dgvGruposPermisosUsuario.Rows.Clear();
            dgvGruposPermisosUsuario.Columns.Clear();


            // Agregamos las columnas al DataGridView
            dgvGruposPermisosUsuario.Columns.Add("Id", "Id");
            dgvGruposPermisosUsuario.Columns.Add("Nombre", "Nombre");

            // Iteramos sobre la lista de grupos del usuario y agregamos cada grupo al DataGridView
            // Iteramos sobre la lista de permisos del grupo y agregamos cada permiso al DataGridView
            foreach (var grupo in Grupos)
            {
                int rowIndex = dgvGruposPermisosUsuario.Rows.Add();
                dgvGruposPermisosUsuario.Rows[rowIndex].Cells["Id"].Value = grupo.Componente.Id;
                dgvGruposPermisosUsuario.Rows[rowIndex].Cells["Nombre"].Value = grupo.Componente.Nombre;
            }
        }

        

        public void ListarGruposYPermisosUsuarioEnDataGridView(DataGridView dgvGruposPermisosUsuario, int idUsuario)
        {
            // Limpiamos las filas existentes en el DataGridView
            dgvGruposPermisosUsuario.Rows.Clear();
            dgvGruposPermisosUsuario.Columns.Clear();

            // Obtener la lista de los grupos del usuario
            List<UsuarioGrupoComponenteBE> listaGruposPermisosUsuario = con.UsuarioGrupoComponente.Include(ug => ug.Componente).Where(ug => ug.Usuario.Id == idUsuario).ToList();

            List<GrupoComponenteBE> listaGrupoComponentes = con.GrupoComponente.Include(p => p.Componente).Where(p => p.Grupo.Id == idUsuario).ToList();

            List<GrupoBE> listaGrupos = con.Grupo.Include(g => g.Componente).ToList();





            // Agregamos las columnas al DataGridView
            dgvGruposPermisosUsuario.Columns.Add("Id", "Id");
            dgvGruposPermisosUsuario.Columns.Add("Nombre", "Nombre");

            // Iteramos sobre la lista de grupos del usuario y agregamos cada grupo al DataGridView
            foreach (var grupoPermiso in listaGruposPermisosUsuario)
            {
                int rowIndex = dgvGruposPermisosUsuario.Rows.Add();
                dgvGruposPermisosUsuario.Rows[rowIndex].Cells["Id"].Value = grupoPermiso.Componente.Id;
                dgvGruposPermisosUsuario.Rows[rowIndex].Cells["Nombre"].Value = grupoPermiso.Componente.Nombre;
            }
        }
        /*
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
                             idComponente = g.Componente.Id,
                             Nombre = g.Componente.Nombre,
                         };
            dgvGrupos.DataSource = grupos.ToList();

        }*/

        //Listar los grupos que tiene el Usuario
        /*
        public void ListarGruposUsuarioEnDataGridView(System.Windows.Forms.DataGridView dgvGrupos, int idUsuario)
        {
            var grupos = from g in con.Grupo
                         join gu in con.UsuarioGrupoComponente on g.Id equals gu.Componente.Id
                         where gu.Usuario.Id == idUsuario
                         select new
                         {
                             idComponente = g.Componente.Id,
                             Nombre = g.Componente.Nombre,
                         };
            dgvGrupos.DataSource = grupos.ToList();
        }*/
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
        public void QuitarPermisoAGrupo(int idGrupo, int idComponente)
        {
            try
            {
                GrupoBE grupo = con.Grupo.Where(gp => gp.Componente.Id == idGrupo).FirstOrDefault();
                ComponenteBE componente = con.Componente.Find(idComponente);
                GrupoComponenteBE grupoComponenteEliminar = con.GrupoComponente.FirstOrDefault((gp => gp.Grupo.Componente.Id == idGrupo && gp.Componente.Id == idComponente));
                //grupoComponente.Grupo = grupo;
                //grupoComponente.Componente = componente;
                con.GrupoComponente.Remove(grupoComponenteEliminar);
                con.SaveChanges();
                MessageBox.Show("Permiso quitado del grupo correctamente", "Quitar Permiso a Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                /*
                GrupoBE grupo = con.Grupo.Find(idGrupo);
                PermisoBE permiso = con.Permiso.Find(idPermiso);
                GrupoComponenteBE grupoPermiso = con.GrupoComponente.Where(gp => gp.Grupo.Id == idGrupo && gp.Componente.Id == idPermiso).FirstOrDefault();
                con.GrupoComponente.Remove(grupoPermiso);
                con.SaveChanges();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo quitar el permiso del grupo. " + ex.Message, "Quitar Permiso a Grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Agregar el permiso al grupo
        public void AgregarPermisoAGrupo(int idComponenteGrupo, int idComponentePermiso)
        {
            try
            {
                GrupoBE grupo = con.Grupo.Where(gp => gp.Componente.Id == idComponenteGrupo).FirstOrDefault();
                ComponenteBE componente = con.Componente.Find(idComponentePermiso);
                if(con.GrupoComponente.Any(gp => gp.Grupo.Componente.Id == idComponenteGrupo && gp.Componente.Id == idComponentePermiso))
                {
                    MessageBox.Show("El permiso ya se encuentra en el grupo.", "Agregar Permiso a Grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    GrupoComponenteBE grupoComponente = new GrupoComponenteBE();
                    grupoComponente.Grupo = grupo;
                    grupoComponente.Componente = componente;
                    con.GrupoComponente.Add(grupoComponente);
                    con.SaveChanges();
                    MessageBox.Show("Permiso agregado al grupo correctamente", "Agregar Permiso a Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar el permiso al grupo. " + ex.Message, "Agregar Permiso a Grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        public List<PermisoBE> ObtenerPermisosDelUsuario(string nombreUsuario)
        {

            // Obtener el usuario por su nombre
            var usuario = con.Usuario.FirstOrDefault(u => u.Nombre == nombreUsuario);

            if (usuario != null)
            {
                // Obtener permisos directamente asignados al usuario
                var listaComponentesUsuario = con.UsuarioGrupoComponente.Include(ugc => ugc.Componente)
                    .Where(ugc => ugc.Usuario.Id == usuario.Id)
                    //.Select(ugc => ugc.Componente)
                    .ToList();


                //PERMISOS SIMPLES
                List<PermisoBE> listaPermisosSimples = new List<PermisoBE>();


                foreach (var usuarioComponente in listaComponentesUsuario)
                {
                    var listPermisos = con.Permiso.Include(gc => gc.Componente)
                        .Where(gc => gc.Componente.Id == usuarioComponente.Componente.Id)
                        //.Where(gc => gc.Componente.Id == usuarioComponente.Id)
                        //.Select(gc => gc.Componente)
                        .ToList();

                    listaPermisosSimples.AddRange(listPermisos);

                }




                //SE BUSCA TODOS LOS COMPOENNETES QUE DEFINAN UN GRUPO
                List<GrupoBE> listaGrupos = new List<GrupoBE>();
                foreach (var usuarioComponente in listaComponentesUsuario)
                {
                    List<GrupoBE> listGrupo = con.Grupo.Include(gc => gc.Componente)
                        .Where(gc => gc.Componente.Id == usuarioComponente.Componente.Id)
                        //.Where(gc => gc.Componente.Id == usuarioComponente.Id)
                        //.Select(gc => gc.Componente)
                        .ToList();
                    listaGrupos.AddRange(listGrupo);
                }


                //SE BUSCA LOS PERMISOS DE LOS GRUPOS
                List<GrupoComponenteBE> listaGrupoComponente = new List<GrupoComponenteBE>();
                foreach (var grupo in listaGrupos)
                {
                    var listGrupoPermisos = con.GrupoComponente.Include(gc => gc.Componente)
                        .Where(gc => gc.Grupo.Id == grupo.Id)
                        .ToList();

                    listaGrupoComponente.AddRange(listGrupoPermisos);
                }

                //SE BUSCA LOS PERMISOS DE LOS GRUPOS
                List<PermisoBE> listaPermisosDeGrupos = new List<PermisoBE>();
                foreach (var permsiso in listaGrupoComponente)
                {
                    var listGrupoPermisos = con.Permiso.Include(gc => gc.Componente)
                        .Where(gc => gc.Componente.Id == permsiso.Componente.Id)
                        //.Select(gc => gc.Componente)
                        .ToList();

                    listaPermisosDeGrupos.AddRange(listGrupoPermisos);
                }



                return listaPermisosSimples.Union(listaPermisosDeGrupos).ToList();

            }

            return null;
        }

        #endregion



    }








    public class GrupoComposite : Componente
    {
        ContextoBD con = new ContextoBD();
        public override void Crear(ComponenteBE componente)
        {
            try
            {
                if (con.Grupo.Any(p => p.Componente.Nombre == componente.Nombre))
                {
                    MessageBox.Show("Ya existe un grupo con ese nombre.");
                }
                else
                {
                    //GrupoBE grupo = new GrupoBE();
                    GrupoBE grupo = new GrupoBE();
                    grupo.Componente = componente;

                    //guardar en bd
                    con.Componente.Add(componente);
                    con.Grupo.Add(grupo);
                    con.SaveChanges();
                    MessageBox.Show("Grupo creado con exito");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar el grupo. " + ex.Message);
            }

        }
        public override void Eliminar(ComponenteBE componente)
        {
            /*
            GrupoBE grupo = con.Grupo.Include(p => p.Componente).FirstOrDefault(p => p.Componente.Id == componente.Id);
            //grupo.Componente = componente;
            ComponenteBE compEliminar = con.Componente.FirstOrDefault(p => p.Id == componente.Id);
            con.Grupo.Remove(grupo);
            con.Componente.Remove(compEliminar);

            con.SaveChanges();
            */

            GrupoBE grupo = con.Grupo.Include(p => p.Componente).FirstOrDefault(p => p.Componente.Id == componente.Id);

            if (grupo != null)
            {
                ComponenteBE compEliminar = con.Componente.FirstOrDefault(p => p.Id == componente.Id);

                List<GrupoComponenteBE> grupoComponentes = con.GrupoComponente.Where(p => p.Grupo.Id == grupo.Id).ToList();

                List<UsuarioGrupoComponenteBE> usuarioComponentes = con.UsuarioGrupoComponente.Where(p => p.Componente.Id == componente.Id).ToList();

                if (grupoComponentes != null)
                {
                    foreach (var grupoComp in grupoComponentes)
                    {
                        con.GrupoComponente.Remove(grupoComp);
                    }

                }
                if (usuarioComponentes != null)
                {
                    foreach (var usuarioComponente in usuarioComponentes)
                    {
                        con.UsuarioGrupoComponente.Remove(usuarioComponente);
                    }
                }
                con.Grupo.Remove(grupo);
                con.Componente.Remove(compEliminar);
                con.SaveChanges();
                MessageBox.Show("Grupo eliminado con exito");
                // Actualizar las propiedades del permiso

            }



        }

        public override void Modificar(ComponenteBE componente)
        {
            GrupoBE grupo = con.Grupo.Include(p => p.Componente).FirstOrDefault(p => p.Componente.Id == componente.Id);
            grupo.Componente.Nombre = componente.Nombre;
            con.SaveChanges();
            MessageBox.Show("Grupo modificado con exito");
        }

    }









}



