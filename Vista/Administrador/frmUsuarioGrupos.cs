using Controladora;
using Controladora.SeguridadBLL;
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
    public partial class frmUsuarioGrupos : Form
    {
        UsuarioBLL usuarioBLL = new UsuarioBLL();

        GrupoBLL grupoBLL = new GrupoBLL();
        PermisoBLL permisoBLL = new PermisoBLL();
        ValidacionesBLL validacionBLL = new ValidacionesBLL();
        PermisoBLL permisosBLL = new PermisoBLL();

        int idComponentePermiso = 0;
        int idComponenteGrupo = 0;
        int idComponenteEliminar = 0;
        public frmUsuarioGrupos()
        {
            InitializeComponent();
            usuarioBLL.ListarUsuariosEnDGV(dgvUsuarios);
            grupoBLL.ListarGruposEnDGV(dgvGrupos);
            permisosBLL.ListarPermisosEnDGV(dgvPermisos);

        }

        private bool ValidarCampos()
        {
            if (txtIdUsuario.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Usuario al cual asignarle el grupo");
                dgvUsuarios.Focus();
                return false;

            }
            if (txtIdComponenteGrupo.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Grupo el cual asignarle al Usuario");
                dgvGrupos.Focus();
                return false;
            }
            
            return true;
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvUsuarios.CurrentRow != null)
                {
                    txtIdUsuario.Text = dgvUsuarios.CurrentRow.Cells[0].Value?.ToString();
                    txtNombreUsuario.Text = dgvUsuarios.CurrentRow.Cells[1].Value?.ToString();
                    txtNombreEmpleado.Text = dgvUsuarios.CurrentRow.Cells[4].Value?.ToString() ?? ""; // Si es null, asigna una cadena vacía
                    txtDNI.Text = dgvUsuarios.CurrentRow.Cells[5].Value?.ToString() ?? ""; // Si es null, asigna una cadena vacía

                    int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value?.ToString());
                    grupoBLL.ListarGruposEnDGV(dgvGrupos);

                    usuarioBLL.ListarGruposYPermisosUsuarioEnDataGridView(dgvGrupoPermisoUsuario, idUsuario);

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvGrupos.CurrentRow != null)
                {
                    txtIdComponenteGrupo.Text = dgvGrupos.CurrentRow.Cells[0].Value?.ToString();

                    int IdComponenteGrupo = Convert.ToInt32(dgvGrupos.CurrentRow.Cells[0].Value?.ToString());
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int idUsuario = Convert.ToInt32(txtIdUsuario.Text);
                int IdComponenteGrupotext = Convert.ToInt32(txtIdComponenteGrupo.Text);
                


                if (txtIdComponenteGrupo.Text != "" && txtIdUsuario.Text != "")
                {
                    usuarioBLL.AgregarGrupoAUsuario(idUsuario, IdComponenteGrupotext);
                    usuarioBLL.ListarGruposYPermisosUsuarioEnDataGridView(dgvGrupoPermisoUsuario, idUsuario);
                    //validacionBLL.LimpiarCampos(this.Controls);

                }
                else
                {
                    MessageBox.Show("Debe seleccionar un grupo y un usuario para eliminar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        
        private void btnEliminarGrupo_Click(object sender, EventArgs e)
        {
            try
            {  
                

            
                if(txtIdEliminar.Text != "" && txtIdUsuario.Text !="")
                {
                    int idUsuario = Convert.ToInt32(txtIdUsuario.Text);
                    int idComponenteEliminar = Convert.ToInt32(txtIdEliminar.Text);

                    usuarioBLL.EliminarGrupoAUsuario(idUsuario, idComponenteEliminar);
                    usuarioBLL.ListarGruposYPermisosUsuarioEnDataGridView(dgvGrupoPermisoUsuario, idUsuario);
                    //validacionBLL.LimpiarCampos(this.Controls);

                }
                else
                {
                    MessageBox.Show("Debe seleccionar un grupo y un usuario para eliminar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtBuscarDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNroHabitacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            grupoBLL.ListarGruposEnDGV(dgvGrupos);
        }

        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                int idUsuario = Convert.ToInt32(txtIdUsuario.Text);

                if (txtIdComponentePermiso.Text != "" && txtIdUsuario.Text != "")
                {
                    usuarioBLL.AgregarPermisoAUsuario(idUsuario, idComponentePermiso);
                    
                    usuarioBLL.ListarGruposYPermisosUsuarioEnDataGridView(dgvGrupoPermisoUsuario, idUsuario);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un permiso y un usuario para eliminar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnEliminarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                

                if (txtIdEliminar.Text != "" && txtIdUsuario.Text != "")
                {
                    int idUsuario = Convert.ToInt32(txtIdUsuario.Text);
                    idComponentePermiso = Convert.ToInt32(txtIdEliminar.Text);

                    usuarioBLL.EliminarPermisoAUsuario(idUsuario, idComponentePermiso );
                    
                    usuarioBLL.ListarGruposYPermisosUsuarioEnDataGridView(dgvGrupoPermisoUsuario, idUsuario);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un permiso y un usuario para eliminar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void dgvPermisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvPermisos.CurrentRow != null)
                {
                    txtIdComponentePermiso.Text = dgvPermisos.CurrentRow.Cells[0].Value?.ToString();
                   
                    idComponentePermiso = (int)dgvPermisos.CurrentRow.Cells[0].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            

        }

        private void dgvGrupoPermisoUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvGrupoPermisoUsuario.CurrentRow != null)
                {
                    
                    txtIdEliminar.Text = dgvGrupoPermisoUsuario.CurrentRow.Cells[0].Value?.ToString();
                    idComponenteEliminar = (int)dgvGrupoPermisoUsuario.CurrentRow.Cells[0].Value;
                }

            }
            catch
            {

            }
        }
    }
}
