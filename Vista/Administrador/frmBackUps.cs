using Controladora;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Administrador
{
    public partial class frmBackUps : Form
    {
        BackupsBLL backupBLL = new BackupsBLL();
        public frmBackUps()
        {
            InitializeComponent();
            CargarBackups();
        }

       

        

        

        // Método para obtener el backup seleccionado (debe implementarse según tu interfaz)
        private BackupBE ObtenerBackupSeleccionado()
        {
            if (dgvBackUps.SelectedRows.Count > 0)
            {
                int indiceFilaSeleccionada = dgvBackUps.SelectedRows[0].Index;

                // Obtén el objeto asociado a la fila seleccionada y conviértelo en un objeto BackupBE
                BackupBE backupSeleccionado = dgvBackUps.Rows[indiceFilaSeleccionada].DataBoundItem as BackupBE;

                return backupSeleccionado;
            }
            else
            {
                return null; // No se ha seleccionado ninguna fila
            }
        }

        

        private void btnCrearBackup_Click(object sender, EventArgs e)
        {
            try
            {
                
                backupBLL.CrearBackup();
                CargarBackups(); // Vuelve a cargar los backups después de crear uno nuevo

                MessageBox.Show("Backup creado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el backup: " + ex.Message);
            }

        }

        private void btnEliminarBackup_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Obtenemos el backup seleccionado de alguna manera
                BackupBE backupSeleccionado = ObtenerBackupSeleccionado(); // Implementa este método según tu interfaz

                if (backupSeleccionado != null)
                {
                    backupBLL.EliminarBackup(backupSeleccionado);
                    CargarBackups();
                    MessageBox.Show("Backup eliminado exitosamente.");
                }
                else
                {
                    MessageBox.Show("Seleccione un backup para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnActualizarBackup_Click(object sender, EventArgs e)
        {
            BackupBE backupSeleccionado = ObtenerBackupSeleccionado();
            if (backupSeleccionado != null)
            {
                try
                {
                    backupBLL.ActualizarBackup(backupSeleccionado);
                    MessageBox.Show("El backup se actualizado con éxito con la BD.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la base de datos: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un backup para actualizar la base de datos.");
            }
            
        }

        private void btnActualizarBD_Click(object sender, EventArgs e)
        {
            BackupBE backupSeleccionado = ObtenerBackupSeleccionado();
            if (backupSeleccionado != null)
            {
                try
                {
                    backupBLL.ActualizarBaseDatosConBackup(backupSeleccionado);
                    MessageBox.Show("Base de datos actualizada con éxito con el backup seleccionado.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la base de datos: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un backup para actualizar la base de datos.");
            }
        }

        private void CargarBackups()
        {
            try
            {
                dgvBackUps.DataSource = backupBLL.ObtenerBackups();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los backups: " + ex.Message);
            }
        }

        private void dgvBackUps_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
