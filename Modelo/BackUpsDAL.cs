﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        
        public class AppConfig
        {
            public string DataDirectory { get; set; }
        }

        public void CrearBackup()
        {
            try
            {
                // Get the SQL Server data directory
                var appConfig = (AppConfig)ConfigurationManager.GetSection("entityFramework/appSettings");
                string dataDirectory = appConfig.DataDirectory;

                // Nombre del archivo de respaldo con la fecha actual
                string backupFileName = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                string backupPath = Path.Combine(dataDirectory, backupFileName);

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
                MessageBox.Show("Backup creado exitosamente.");
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
