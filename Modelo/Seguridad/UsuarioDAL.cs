using Entidades;
using Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo
{
    public class UsuarioDAL
    {
        //ContextoBD con = new ContextoBD();
        ContextoBD con = ContextoBD.Instance();

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
                // Encriptar la contraseña antes de almacenarla
                usuario.Clave = CalcularHash(usuario.Clave);
                // Agregar el usuario a la base de datos
                //buscar el empleado mediante el id
                usuario.Empleado = con.Empleado.FirstOrDefault(e => e.Id == usuario.Empleado.Id);
                con.Usuario.Add(usuario);
                con.SaveChanges();

                return "El usuario se agregó correctamente";
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
        public string AgregarGrupoAUsuario(int idUsuario, int idGrupo)
        {
            try
            {
                // Buscar el usuario por id
                UsuarioBE usuario = con.Usuario.FirstOrDefault(u => u.Id == idUsuario);

                // Buscar el grupo por id
                GrupoBE grupo = con.Grupo.FirstOrDefault(g => g.Id == idGrupo);

                if (usuario != null && grupo != null)
                {
                    UsuarioGrupoBE usuarioGrupo = new UsuarioGrupoBE
                    {
                        Usuario = usuario,
                        Grupo = grupo
                    };

                    // Agregar el grupo al usuario
                    con.UsuarioGrupo.Add(usuarioGrupo);

                    // Guardar los cambios en la base de datos
                    con.SaveChanges();

                    return "El grupo se agregó al usuario correctamente";
                }
                else
                {
                    return "No se encontró el usuario o el grupo";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el grupo al usuario: " + ex.Message);
                return "Error al agregar el grupo al usuario";
            }
        }


        //Eliminar Grupo del Usuario
        public string EliminarGrupoAUsuario(int idUsuario, int idGrupo)
        {
            try
            {
                // Buscar el usuario por id
                UsuarioBE usuario = con.Usuario.FirstOrDefault(u => u.Id == idUsuario);

                // Buscar el grupo por id
                GrupoBE grupo = con.Grupo.FirstOrDefault(g => g.Id == idGrupo);

                if (usuario != null && grupo != null)
                {
                    //UsuarioGrupoBE usuarioGrupo = new UsuarioGrupoBE
                    UsuarioGrupoBE usuarioGrupo = con.UsuarioGrupo.Where(gp => gp.Grupo.Id == idGrupo && gp.Usuario.Id == idUsuario).FirstOrDefault();
                    // Agregar el grupo al usuario
                    con.UsuarioGrupo.Remove(usuarioGrupo);

                    // Guardar los cambios en la base de datos
                    con.SaveChanges();

                    return "El grupo se agregó al usuario correctamente";
                }
                else
                {
                    return "No se encontró el usuario o el grupo";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el grupo al usuario: " + ex.Message);
                return "Error al agregar el grupo al usuario";
            }
        }




        
        


        #endregion




























        public List<PermisoBE> ObtenerPermisosUsuario(int idUsuario)
        {
            var permisosUsuario = new List<PermisoBE>();

            var usuario = con.Usuario.FirstOrDefault(u => u.Id == idUsuario);

            if (usuario != null)
            {
                var gruposUsuarioIds = con.UsuarioGrupo
                                .Where(ug => ug.Usuario.Id == usuario.Id)
                                .Select(ug => ug.Grupo.Id)
                                .ToList();

                foreach (var grupoId in gruposUsuarioIds)
                {
                    var permisosGrupoIds = con.GrupoPermiso
                                                    .Where(gp => gp.Grupo.Id == grupoId)
                                                    .Select(gp => gp.Permiso.Id)
                                                    .ToList();

                    foreach (var permisoId in permisosGrupoIds)
                    {
                        var permiso = con.Permiso.FirstOrDefault(p => p.Id == permisoId);
                        if (permiso != null)
                        {
                            permisosUsuario.Add(permiso);
                        }
                    }
                }

            }

            return permisosUsuario;
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



















































        // Método para obtener los permisos de un usuario mediante las clase (usuario --> usuarioGrupo --> grupo --> grupoPermiso --> permiso)
        //teniendo el id del usuario, buscar las tablas UsuarioGrupo donde Id sea el Usuario.Id
        //Ver todos los grupos que hay con es el IdUsuario y buscar en la tabla GrupoPermiso donde el Id sea el Grupo.Id
        //Despues con eses Grupos.Id, buscar los nombres de los Permisos.Id














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
                using (var context = ContextoBD.Instance())
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
