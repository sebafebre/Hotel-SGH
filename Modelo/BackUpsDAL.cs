using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo
{
    public class BackUpsDAL
    {
        ContextoBD con = new ContextoBD();
        public void CrearBackup()
        {
            try
            {
                string ubicacionProyecto = "SGH - UAI - Final";
                string carpetaBakups = "Backups";

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string backupDirectory = Path.Combine(desktopPath, ubicacionProyecto, carpetaBakups);

                // Verificar y crear el directorio de backups si no existe
                if (!Directory.Exists(backupDirectory))
                {
                    Directory.CreateDirectory(backupDirectory);
                }

                // Nombre del archivo de respaldo con la fecha actual
                string backupFileName = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                string backupPath = Path.Combine(backupDirectory, backupFileName);

                // Consulta SQL para realizar la copia de seguridad de la base de datos actual
                string query = $"BACKUP DATABASE PruebaComponente2 TO DISK = '{backupPath}'";
                con.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, query);

                // Guarda los detalles del backup en la base de datos
                var nuevoBackup = new BackupBE
                {
                    RutaArchivo = backupPath,
                    FechaDeDatos = DateTime.Now
                };

                con.Backup.Add(nuevoBackup);
                con.SaveChanges();

                MessageBox.Show("Copia de seguridad creada exitosamente.");
                // CargarBackups(); // Llamada a método en la capa de vista
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la copia de seguridad: " + ex.Message);
            }
        }

        public void EliminarBackup(BackupBE backup)
        {
            try
            {
                con.Backup.Remove(backup);
                con.SaveChanges();

                if (File.Exists(backup.RutaArchivo))
                {
                    File.Delete(backup.RutaArchivo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el backup.", ex);
            }
        }

        public void ActualizarBackup(BackupBE backup)
        {
            try
            {
                // Verifica si el archivo de backup existe en la ruta especificada
                if (File.Exists(backup.RutaArchivo))
                {
                    // Consulta SQL para realizar la copia de seguridad de la base de datos actual
                    string query = $"BACKUP DATABASE PruebaComponente2 TO DISK = '{backup.RutaArchivo}' WITH INIT";
                    con.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, query);

                    // Actualiza la fecha de los datos al momento actual
                    backup.FechaDeDatos = DateTime.Now;

                    // Marca el objeto como modificado y guarda los cambios en la base de datos
                    con.Entry(backup).State = EntityState.Modified;
                    con.SaveChanges();

                    MessageBox.Show("Backup actualizado exitosamente.");
                }
                else
                {
                    MessageBox.Show("El archivo de backup no existe en la ubicación especificada.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el backup.", ex);
            }

            /*
            try
            {

                // Nombre del archivo de respaldo con la fecha actual
                string ubicacionProyecto = "SGH - UAI";
                string carpetaBakups = "Backups";

                string backupFileName = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                string desktopPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), ubicacionProyecto, carpetaBakups);
                string backupPath = Path.Combine(desktopPath, backupFileName);

                // Consulta SQL para realizar la copia de seguridad de la base de datos actual
                string query = $"BACKUP DATABASE YourDatabase TO DISK = '{backupPath}'";
                con.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, query);

                // Actualiza la ruta del archivo de respaldo en el objeto BackupBE
                backup.RutaArchivo = backupPath;
                backup.FechaDeDatos = DateTime.Now; // Actualiza la fecha al momento actual

                // Marca el objeto como modificado y guarda los cambios en la base de datos
                con.Entry(backup).State = EntityState.Modified;
                con.SaveChanges();

                MessageBox.Show("Backup actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el backup.", ex);
            }*/
        }

        public void ActualizarBaseDatosConBackup(BackupBE backup)
        {
            try
            {
                string query = $"RESTORE DATABASE PruebaComponente2 FROM DISK = '{backup.RutaArchivo}'";
                con.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, query);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la base de datos con el backup seleccionado.", ex);
            }
        }

        public List<BackupBE> ObtenerBackups()
        {
            try
            {
                return con.Backup.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los backups.", ex);
            }
        }

    }
}
