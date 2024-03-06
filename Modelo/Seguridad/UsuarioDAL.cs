using Entidades;
using Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.ComponentModel;

namespace Modelo
{
    public class UsuarioDAL
    {
        //ContextoBD con = new ContextoBD();
        ContextoBD con = new ContextoBD();

        #region Encriptar con SHA256
        public string CalcularHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        #endregion



        #region ABM Usaurio
        //Agregar usuario
        public string AgregarUsuario(UsuarioBE usuario)
        {
            try
            {
                if (con.Usuario.Any(u => u.Nombre == usuario.Nombre))
                {
                    return "El nombre de usuario ya existe";
                }
                else
                {
                    // Encriptar la contraseña antes de almacenarla
                    usuario.Clave = CalcularHash(usuario.Clave);
                    // Agregar el usuario a la base de datos
                    //buscar el empleado mediante el id
                    usuario.Empleado = con.Empleado.FirstOrDefault(e => e.Id == usuario.Empleado.Id);
                    con.Usuario.Add(usuario);
                    con.SaveChanges();

                    return "El usuario se agregó correctamente";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el usuario: " + ex.Message);
                return "Error al agregar el usuario";
            }
        }


        //Modificar usuario
        public string ModificarUsuario(UsuarioBE usuario)
        {
            try
            {
                // Buscar el usuario por id
                UsuarioBE usuarioExistente = con.Usuario.FirstOrDefault(u => u.Id == usuario.Id);

                if (usuarioExistente != null)
                {
                    // Modificar el usuario
                    usuarioExistente.Nombre = usuario.Nombre;
                    usuarioExistente.Clave = CalcularHash(usuario.Clave);
                    usuarioExistente.Empleado = con.Empleado.FirstOrDefault(e => e.Id == usuario.Empleado.Id);

                    // Guardar los cambios en la base de datos
                    con.SaveChanges();

                    return "El usuario se modificó correctamente";
                }
                else
                {
                    return "No se encontró el usuario";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar el usuario: " + ex.Message);
                return "Error al modificar el usuario";
            }
        }

        //Eliminar usuario
        public string EliminarUsuario(UsuarioBE usuario)
        {
            try
            {
                // Buscar el usuario por id
                UsuarioBE usuarioAEliminar = con.Usuario.FirstOrDefault(u => u.Id == usuario.Id);

                if (usuarioAEliminar != null)
                {
                    // Eliminar el usuario
                    con.Usuario.Remove(usuarioAEliminar);

                    // Guardar los cambios en la base de datos
                    con.SaveChanges();

                    return "El usuario se eliminó correctamente";
                }
                else
                {
                    return "No se encontró el usuario";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el usuario: " + ex.Message);
                return "Error al eliminar el usuario";
            }
        }

        #endregion



        #region Listar Usuarios en DGView
        //Listar usuarios en dgv
        public void ListarUsuariosEnDGV(DataGridView dataGridView)
        {
            // Limpiamos las filas existentes en el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // Obtener la lista de los usuarios
            List<UsuarioBE> listaUsuarios = con.Usuario.ToList();

            // Iteramos sobre la lista de usuarios activos y agregamos cada usuario al DataGridView
            dataGridView.Columns.Add("Id Usuario", "Id Usuario");
            dataGridView.Columns.Add("Nombre", "Nombre");
            dataGridView.Columns.Add("Clave", "Clave");
            dataGridView.Columns.Add("Id Empleado", "Id Empleado");
            dataGridView.Columns.Add("Nombre Empleado", "Nombre Empleado");
            dataGridView.Columns.Add("DNI", "DNI");

            foreach (var usuario in listaUsuarios)
            {
                // Agregamos una fila al DataGridView
                int rowIndex = dataGridView.Rows.Add();
                dataGridView.Rows[rowIndex].Cells["Id Usuario"].Value = usuario.Id;
                dataGridView.Rows[rowIndex].Cells["Nombre"].Value = usuario.Nombre;
                dataGridView.Rows[rowIndex].Cells["Clave"].Value = usuario.Clave;
                dataGridView.Rows[rowIndex].Cells["Id Empleado"].Value = usuario.Empleado?.Id ?? null; // Aquí se asignará null si el objeto usuario.Empleado es null
                dataGridView.Rows[rowIndex].Cells["Nombre Empleado"].Value = usuario.Empleado != null ? usuario.Empleado.Persona.Nombre + " " + usuario.Empleado.Persona.Apellido : null; // Aquí se asignará null si el objeto usuario.Empleado o usuario.Empleado.Persona es null
                dataGridView.Rows[rowIndex].Cells["DNI"].Value = usuario.Empleado?.Persona.DNI ?? null; // Aquí se asignará null si el objeto usuario.Empleado o usuario.Empleado.Persona es null
            }
        }

        #endregion



        #region Agregar / Quitar Permisos al Grupo --> GrupoPermiso

        //Agregar Grupo a Usuario
        public void AgregarGrupoAUsuario(int idUsuario, int idComponenteGrupo)
        {


            try
            {
                // Buscar el usuario por id
                UsuarioBE usuario = con.Usuario.FirstOrDefault(u => u.Id == idUsuario);

                // Buscar el grupo por id
                //ComponenteBE componente = con.Componente.FirstOrDefault(g => g.Id == idComponenteGrupo);
                GrupoBE grupo = con.Grupo.Include(gp => gp.Componente).Where(gp => gp.Componente.Id == idComponenteGrupo).FirstOrDefault();

                if (usuario != null && grupo != null)
                {
                    if (con.UsuarioGrupoComponente.Any(ug => ug.Usuario.Id == idUsuario && ug.Componente.Id == idComponenteGrupo))
                    {
                        MessageBox.Show("El usuario ya tiene asignado el grupo");
                    }

                    UsuarioGrupoComponenteBE usuarioGrupoComponente = new UsuarioGrupoComponenteBE
                    {
                        Usuario = usuario,
                        Componente = grupo.Componente
                    };

                    // Agregar el grupo al usuario
                    con.UsuarioGrupoComponente.Add(usuarioGrupoComponente);

                    // Guardar los cambios en la base de datos
                    con.SaveChanges();

                    //return "El grupo se agregó al usuario correctamente";
                    MessageBox.Show("El grupo se agregó al usuario correctamente");
                }
                else
                {
                    //return "No se encontró el usuario o el grupo";
                    MessageBox.Show("No se encontró el usuario o el grupo");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el grupo al usuario: " + ex.Message);
                //return "Error al agregar el grupo al usuario";
                MessageBox.Show("Error al agregar el grupo al usuario");
            }
        }


        //Eliminar Grupo del Usuario
        public void EliminarGrupoAUsuario(int idUsuario, int idComponente)
        {
            try
            {
                // Buscar el usuario por id
                UsuarioBE usuario = con.Usuario.FirstOrDefault(u => u.Id == idUsuario);

                // Buscar el grupo por id
                ComponenteBE componente = con.Componente.FirstOrDefault(g => g.Id == idComponente);

                if (usuario != null && componente != null)
                {
                    //UsuarioGrupoBE usuarioGrupo = new UsuarioGrupoBE
                    UsuarioGrupoComponenteBE usuarioGrupoComponente = con.UsuarioGrupoComponente.Where(gp => gp.Componente.Id == idComponente && gp.Usuario.Id == idUsuario).FirstOrDefault();
                    // Agregar el grupo al usuario
                    con.UsuarioGrupoComponente.Remove(usuarioGrupoComponente);

                    // Guardar los cambios en la base de datos
                    con.SaveChanges();

                    MessageBox.Show("El grupo se agregó al usuario correctamente");
                }
                else
                {

                    MessageBox.Show("No se encontró el usuario o el grupo");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el grupo al usuario: " + ex.Message);
                MessageBox.Show("Error al agregar el grupo al usuario");
            }
        }

        public void AgregarPermisoAUsuario(int idUsuario, int idComponente)
        {
            try
            {
                // Buscar el usuario por id
                UsuarioBE usuario = con.Usuario.FirstOrDefault(u => u.Id == idUsuario);

                // Buscar el grupo por id
                ComponenteBE componente = con.Componente.FirstOrDefault(g => g.Id == idComponente);

                if (usuario != null && componente != null)
                {
                    if (con.UsuarioGrupoComponente.Any(ug => ug.Usuario.Id == idUsuario && ug.Componente.Id == idComponente))
                    {
                        MessageBox.Show("El usuario ya tiene asignado el Permiso");
                    }
                    else
                    {
                        UsuarioGrupoComponenteBE usuarioGrupoComponente = new UsuarioGrupoComponenteBE
                        {
                            Usuario = usuario,
                            Componente = componente
                        };

                        // Agregar el grupo al usuario
                        con.UsuarioGrupoComponente.Add(usuarioGrupoComponente);

                        // Guardar los cambios en la base de datos
                        con.SaveChanges();

                        //return "El grupo se agregó al usuario correctamente";
                        MessageBox.Show("El permiso se agregó al usuario correctamente");
                    }
                }
                else
                {
                    //return "No se encontró el usuario o el grupo";
                    MessageBox.Show("No se encontró el usuario o el permiso");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el permiso al usuario: " + ex.Message);
                //return "Error al agregar el grupo al usuario";
                MessageBox.Show("Error al agregar el permiso al usuario");
            }

        }


        public void EliminarPermisoAUsuario(int idUsuario, int idComponente)
        {
            try
            {
                // Buscar el usuario por id
                UsuarioBE usuario = con.Usuario.FirstOrDefault(u => u.Id == idUsuario);

                // Buscar el grupo por id
                ComponenteBE componente = con.Componente.FirstOrDefault(g => g.Id == idComponente);

                if (usuario != null && componente != null)
                {
                    //UsuarioGrupoBE usuarioGrupo = new UsuarioGrupoBE
                    UsuarioGrupoComponenteBE usuarioGrupoComponente = con.UsuarioGrupoComponente.Where(gp => gp.Componente.Id == idComponente && gp.Usuario.Id == idUsuario).FirstOrDefault();
                    // Agregar el grupo al usuario
                    con.UsuarioGrupoComponente.Remove(usuarioGrupoComponente);

                    // Guardar los cambios en la base de datos
                    con.SaveChanges();

                    MessageBox.Show("El permiso se agregó al usuario correctamente");
                }
                else
                {

                    MessageBox.Show("No se encontró el usuario o el permiso");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el permiso al usuario: " + ex.Message);
                MessageBox.Show("Error al agregar el permiso al usuario");
            }
        }





        //Listar Grupos y permisos del usuario 
        public void ListarGruposYPermisosUsuarioEnDataGridView(DataGridView dgvGruposPermisosUsuario, int idUsuario)
        {
            // Limpiamos las filas existentes en el DataGridView
            dgvGruposPermisosUsuario.Rows.Clear();
            dgvGruposPermisosUsuario.Columns.Clear();

            // Obtener la lista de los grupos del usuario
            List<UsuarioGrupoComponenteBE> listaGruposPermisosUsuario = con.UsuarioGrupoComponente.Include(ug => ug.Componente).Where(ug => ug.Usuario.Id == idUsuario).ToList();

            /*------->No trae el .include(Componente)
            List<ComponenteBE> componentesUsuario = new List<ComponenteBE>();
            foreach (var grupopermiso in listaGruposPermisosUsuario)
            {
                ComponenteBE comp = con.Componente.FirstOrDefault(p => p.Id == grupopermiso.Componente.Id);
                if (comp != null)
                {
                    componentesUsuario.Add(comp);
                }
            }*/

            // Agregamos las columnas al DataGridView

            dgvGruposPermisosUsuario.Columns.Add("Id", "Id");
            dgvGruposPermisosUsuario.Columns.Add("Nombre", "Nombre");

            // Iteramos sobre la lista de grupos del usuario y agregamos cada grupo al DataGridView
            foreach (var grupoPermiso in listaGruposPermisosUsuario)
            {
                
                 
                 int? id = grupoPermiso.Componente.Id;
                 
                


                int rowIndex = dgvGruposPermisosUsuario.Rows.Add();
                dgvGruposPermisosUsuario.Rows[rowIndex].Cells["Id"].Value = id ?? 0;  /*grupoPermiso.Componente.Id ?? 0;*/
                dgvGruposPermisosUsuario.Rows[rowIndex].Cells["Nombre"].Value = grupoPermiso.Componente.Nombre ?? "";
            }
        }









        #endregion











        public List<ComponenteBE> ObtenerPermisosDelUsuario(string nombreUsuario)
        {
            // Obtener el usuario por su nombre
            var usuario = con.Usuario.FirstOrDefault(u => u.Nombre == nombreUsuario);

            if (usuario != null)
            {
                // Obtener permisos directamente asignados al usuario
                var permisosUsuario = con.UsuarioGrupoComponente
                    .Where(ugc => ugc.Usuario.Id == usuario.Id)
                    .Select(ugc => ugc.Componente)
                    .ToList();

                var permisosUsuarios = con.UsuarioGrupoComponente
                    .Where(ugc => ugc.Usuario.Id == usuario.Id)
                    .Select(ugc => ugc.Componente)
                    .ToList();
                var permisosSimples = new List<ComponenteBE>();
                foreach (var permiso in permisosUsuarios)
                {
                    var permisos = con.Permiso.FirstOrDefault(p => p.Componente.Id == permiso.Id);
                    if (permisos != null)
                    {
                        permisosSimples.Add(permiso);
                    }
                }
                /*
                // Obtener los grupos del usuario y los permisos asociados a esos grupos
                var gruposUsuario = con.UsuarioGrupoComponente
                    .Where(ugc => ugc.Usuario.Id == usuario.Id)
                    .Select(ugc => ugc.Componente)
                    .ToList();


                var permisosGrupos = new List<GrupoBE>();
                
                foreach (var componente in gruposUsuario)
                {
                    var permisosGrupo = con.GrupoComponente.Include( gc => gc.Grupo)
                        .Where(gc => gc.Componente.Id == componente.Id).Select(gc => gc.Grupo.Id).ToList();

                    permisosGrupos.Add(componente);
                }

                var listaPermisos = new List<ComponenteBE>();
                foreach (var permiso in permisosGrupos)
                {
                    var permisosGrupo = con.GrupoComponente
                        .Where(gc => gc.Grupo.Id == permiso.Id)
                        .Select(gc => gc.Componente)
                        .ToList();

                    permisosGrupos.AddRange(listaPermisos);
                }*/

                // Obtener los grupos del usuario y los permisos asociados a esos grupos
                var gruposUsuario = con.UsuarioGrupoComponente
                    .Where(ugc => ugc.Usuario.Id == usuario.Id)
                    .Select(ugc => ugc.Componente)
                    .ToList();

                var permisosGrupos = new List<GrupoBE>();



                var gruposAsociados = con.GrupoComponente
                         .Include(gc => gc.Grupo)
                         .Where(c => con.Grupo.Any(p => p.Componente.Id == c.Id))
                         .Select(gc => gc.Grupo)
                         .ToList();

                // Guardar los grupos en la lista de permisosGrupos
                permisosGrupos.AddRange(gruposAsociados);









                var listaPermisos = new List<ComponenteBE>();
                foreach (var permiso in permisosGrupos)
                {
                    // Obtener los componentes asociados a los grupos que también están en la tabla de permisos
                    var componentesGrupoConPermisos = con.GrupoComponente
                        .Where(gc => gc.Grupo.Id == permiso.Id) // Filtrar por el grupo actual
                        .Select(gc => gc.Componente) // Seleccionar los componentes asociados al grupo
                        .Where(c => con.Permiso.Any(p => p.Componente.Id == c.Id)) // Filtrar por los componentes que también están en los permisos
                        .ToList();

                    // Agregar los componentes a la lista de permisos si no están ya en ella
                    foreach (var componente in componentesGrupoConPermisos)
                    {
                        if (!listaPermisos.Any(p => p.Id == componente.Id))
                        {
                            listaPermisos.Add(componente);
                        }
                    }
                }

                // Unir los permisos directos del usuario y los permisos de los grupos

                var todosLosPermisos = listaPermisos.Union(permisosSimples).ToList();

                // Devolver los permisos únicos
                return todosLosPermisos;
            }
            else
            {
                // Si el usuario no existe, devolver una lista vacía de permisos
                return new List<ComponenteBE>();
            }
        }









        public List<PermisoBE> ObtenerPermisosUsuario(string nombreUsuario)
        {
            try
            {
                var permisosUsuario = new List<PermisoBE>();

                // Obtener el usuario por su nombre de usuario
                UsuarioBE usuario = con.Usuario.FirstOrDefault(u => u.Nombre == nombreUsuario);

                if (usuario != null)
                {
                    var gruposUsuarioIds = con.UsuarioGrupoComponente
                                            .Where(ug => ug.Usuario.Id == usuario.Id)
                                            .Select(ug => ug.Componente.Id)
                                            .ToList();

                    foreach (var grupoId in gruposUsuarioIds)
                    {
                        var permisosGrupoIds = con.GrupoComponente
                                                .Where(gp => gp.Grupo.Id == grupoId)
                                                .Select(gp => gp.Componente.Id)
                                                .ToList();

                        foreach (var permisoId in permisosGrupoIds)
                        {
                            var permiso = con.Permiso.Include(u => u.Componente).FirstOrDefault(p => p.Componente.Id == permisoId);
                            if (permiso != null)
                            {
                                permisosUsuario.Add(permiso);
                            }

                        }
                    }
                }

                return permisosUsuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los permisos del usuario: " + ex.Message);
                return new List<PermisoBE>(); // Devolver una lista vacía en caso de error
            }
        }









        /* ObtenerPermisosUsuario
        public List<PermisoBE> ObtenerPermisosUsuario(string nombreUsuario)
        {
            var permisosUsuario = new List<PermisoBE>();

            var usuario = contexto.Usuario.FirstOrDefault(u => u.Nombre == nombreUsuario);

            if (usuario != null)
            {
                var gruposUsuarioIds = contexto.UsuarioGrupo
                                .Where(ug => ug.Usuario.Id == usuario.Id)
                                .Select(ug => ug.Grupo.Id)
                                .ToList();

                foreach (var grupoId in gruposUsuarioIds)
                {
                    var permisosGrupoIds = contexto.GrupoPermiso
                                                    .Where(gp => gp.Grupo.Id == grupoId)
                                                    .Select(gp => gp.Permiso.Id)
                                                    .ToList();

                    foreach (var permisoId in permisosGrupoIds)
                    {
                        var permiso = contexto.Permiso.FirstOrDefault(p => p.Id == permisoId);
                        if (permiso != null)
                        {
                            permisosUsuario.Add(permiso);
                        }
                    }
                }

            }

            return permisosUsuario;
        }
        */






        /*
        public List<GrupoPermisoBE> ObtenerPermisosUsuario(int idUsuario)
        {
            try
            {
                // Buscar los grupos del usuario
                List<UsuarioGrupoBE> usuarioGrupos = contexto.UsuarioGrupo.Where(ug => ug.Id == idUsuario).ToList();

                // Buscar los permisos de los grupos del usuario
                List<GrupoPermisoBE> grupoPermisos = new List<GrupoPermisoBE>();
                foreach (UsuarioGrupoBE usuarioGrupo in usuarioGrupos)
                {
                    List<GrupoPermisoBE> permisos = contexto.GrupoPermiso.Where(gp => gp.Id == usuarioGrupo.Id).ToList();
                    grupoPermisos.AddRange(permisos);
                }

                // Devolver los permisos
                return grupoPermisos;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los permisos del usuario: " + ex.Message);
                return null;
            }
        }*/







        /*
        public List<GrupoPermisoBE> ObtenerPermisosUsuario(int idUsuario)
        {
            try
            {
                // Buscar el usuario por id
                UsuarioBE usuario = contexto.Usuario.FirstOrDefault(u => u.Id == idUsuario);

                // Buscar los grupos del usuario
                List<UsuarioGrupoBE> usuarioGrupos = contexto.UsuarioGrupo.Where(ug => ug.Usuario.Id == idUsuario).ToList();

                // Buscar los permisos de los grupos del usuario
                List<GrupoPermisoBE> grupoPermisos = new List<GrupoPermisoBE>();
                foreach (UsuarioGrupoBE usuarioGrupo in usuarioGrupos)
                {
                    List<GrupoPermisoBE> permisos = contexto.GrupoPermiso.Where(gp => gp.Grupo == usuarioGrupo.Grupo).ToList();
                    grupoPermisos.AddRange(permisos);
                }

                // Devolver los permisos
                return grupoPermisos;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los permisos del usuario: " + ex.Message);
                return null;
            }
        }*/




        public bool VerificarCredencialesEncriptadas(string nombreUsuario, string clave)
        {
            // Obtener el usuario de la base de datos por su nombre
            UsuarioBE usuario = con.Usuario.FirstOrDefault(u => u.Nombre == nombreUsuario);

            if (usuario != null)
            {
                // Calcular el hash de la contraseña ingresada
                string claveHash = CalcularHash(clave);

                // Comparar el hash calculado con el hash almacenado en la base de datos
                if (claveHash == usuario.Clave)
                {
                    return true; // Las credenciales son válidas
                }
            }
            return false; // Las credenciales son inválidas
        }





        public UsuarioBE ValidarCredenciales(string nombre, string clave)
        {
            try
            {
                using (var context = new ContextoBD())
                {
                    // Buscar el usuario por nombre de usuario y contraseña
                    UsuarioBE usuario = context.Usuario.FirstOrDefault(u => u.Nombre == nombre && u.Clave == clave);

                    // Devolver el usuario si se encuentra
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al validar las credenciales del usuario: " + ex.Message);
                return null;
            }
        }






        
        

        



    }





}













