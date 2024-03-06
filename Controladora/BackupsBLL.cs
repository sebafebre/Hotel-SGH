using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controladora
{
    public class BackupsBLL
    {

        BackUpsDAL backupDAL = new BackUpsDAL();
        public void CrearBackup()
        {
            backupDAL.CrearBackup();
        }

        public void EliminarBackup(BackupBE backup)
        {
            backupDAL.EliminarBackup(backup);
        }

        public void ActualizarBackup(BackupBE backup)
        {
            backupDAL.ActualizarBackup(backup);
        }

        public void ActualizarBaseDatosConBackup(BackupBE backup)
        {
            backupDAL.ActualizarBaseDatosConBackup(backup);
        }

        public List<BackupBE> ObtenerBackups()
        {
            return backupDAL.ObtenerBackups();
        }
    }
}
