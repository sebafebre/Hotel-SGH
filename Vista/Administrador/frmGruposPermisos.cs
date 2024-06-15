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
    public partial class frmGruposPermisos : Form
    {
        GrupoBLL grupoBLL = new GrupoBLL();
        PermisoBLL permisoBLL = new PermisoBLL();
        ValidacionesBLL validacionBLL = new ValidacionesBLL();

        StateBLL stateBLL = new StateBLL();

        int idComponenteGrupo = 0;
        int idComponentePermiso = 0;

        public frmGruposPermisos()
        {
            InitializeComponent();
            grupoBLL.ListarGruposEnDGV(dgvGrupos);
            permisoBLL.ListarPermisosEnDGV(dgvPermisos);

        }

        #region Grupo
        #region Botones
        private void btnAgregarGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreGrupo.Text != "")
                {
                    /*GrupoBE grupo = new GrupoBE();
                    grupo.Componente = new ComponenteBE();
                    grupo.Componente.Nombre = txtNombreGrupo.Text;
                    grupoBLL.AgregarGrupo(grupo);*/

                    ComponenteBE componente = new ComponenteBE();
                    componente.Nombre = txtNombreGrupo.Text;
                    grupoBLL.CrearGrupo(componente);

                    //MessageBox.Show("Grupo agregado correctamente", "Agregar Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grupoBLL.ListarGruposEnDGV(dgvGrupos);
                    validacionBLL.LimpiarCampos(this.Controls);
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos", "Agregar Grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnModificarGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdGrupo.Text != "")
                {
                    if (txtNombreGrupo.Text != "")
                    {
                        /*GrupoBE grupo = new GrupoBE();

                        grupo.Componente = new ComponenteBE();
                        grupo.Id = Convert.ToInt32(txtIdGrupo.Text);
                        grupo.Componente.Nombre = txtNombreGrupo.Text;

                        grupoBLL.ModificarGrupo(grupo);*/

                        ComponenteBE componente = new ComponenteBE();
                        componente.Nombre = txtNombreGrupo.Text;
                        componente.Id = idComponenteGrupo;
                        grupoBLL.ModificarGrupo(componente);


                        validacionBLL.LimpiarCampos(this.Controls);
                        grupoBLL.ListarGruposEnDGV(dgvGrupos);
                        
                    }
                    else
                    {
                        MessageBox.Show("Debe completar todos los campos", "Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                {
                    MessageBox.Show("Debe seleccionar un cliente", "Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (txtIdGrupo.Text != "")
                {
                    /*
                    int Id = Convert.ToInt32(txtIdGrupo.Text);
                    grupoBLL.EliminarGrupo(Id);*/
                    
                    ComponenteBE componente = new ComponenteBE();
                    componente.Nombre = txtNombreGrupo.Text;
                    componente.Id = idComponenteGrupo;
                    grupoBLL.EliminarGrupo(componente);

                    
                    grupoBLL.ListarGruposEnDGV(dgvGrupos);
                    validacionBLL.LimpiarCampos(this.Controls);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un grupo", "Eliminar Grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        #endregion


        private void dgvGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvGrupos.CurrentRow != null)
                {
                    txtIdGrupo.Text = dgvGrupos.CurrentRow.Cells[0].Value?.ToString();
                    txtNombreGrupo.Text = dgvGrupos.CurrentRow.Cells[1].Value?.ToString();
                    
                    idComponenteGrupo = (int)dgvGrupos.CurrentRow.Cells[0].Value;

                    //int idGrupo = Convert.ToInt32(dgvGrupos.CurrentRow.Cells[0].Value?.ToString());
                    permisoBLL.ListarPermisosGrupoEnDGV(dgvPermisos, idComponenteGrupo);

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }



        }
        #endregion
        

        #region Permisos

        #region Botones
        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombrePermiso.Text != "")
                {
                    /*PermisoBE permiso = new PermisoBE();
                    permiso.Componente = new ComponenteBE();
                    permiso.Componente.Nombre = txtNombrePermiso.Text;
                    permisoBLL.AgregarPermiso(permiso);*/

                    ComponenteBE componente = new ComponenteBE();
                    componente.Nombre = txtNombrePermiso.Text;
                    permisoBLL.CrearPermiso(componente);

                    
                    permisoBLL.ListarPermisosEnDGV(dgvPermisos);
                    validacionBLL.LimpiarCampos(this.Controls);
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos", "Agregar Permiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (txtIdPermiso.Text != "")
                {

                    /*int Id = Convert.ToInt32(txtIdPermiso.Text);
                    permisoBLL.EliminarPermiso(Id);*/

                    ComponenteBE componente = new ComponenteBE();
                    componente.Nombre = txtNombrePermiso.Text;
                    componente.Id = idComponentePermiso;
                    permisoBLL.EliminarPermiso(componente);

                    
                    permisoBLL.ListarPermisosEnDGV(dgvPermisos);
                    validacionBLL.LimpiarCampos(this.Controls);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un permiso", "Eliminar Permiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnModificarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdPermiso.Text != "" && txtNombrePermiso.Text != "")
                {
                    /*PermisoBE permiso = new PermisoBE();
                    permiso.Componente = new ComponenteBE();
                    permiso.Id = Convert.ToInt32(txtIdPermiso.Text);
                    permiso.Componente.Nombre = txtNombrePermiso.Text;
                    permisoBLL.ModificarPermiso(permiso);*/

                    ComponenteBE componente = new ComponenteBE();
                    componente.Nombre = txtNombrePermiso.Text;
                    componente.Id = idComponentePermiso;
                    permisoBLL.ModificarPermiso(componente);

                    
                    permisoBLL.ListarPermisosEnDGV(dgvPermisos);
                    validacionBLL.LimpiarCampos(this.Controls);
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos", "Modificar Permiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            permisoBLL.ListarPermisosEnDGV(dgvPermisos);

        }
        #endregion



        private void dgvPermisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvPermisos.CurrentRow != null)
                {
                    txtIdPermiso.Text = dgvPermisos.CurrentRow.Cells[0].Value?.ToString();
                    txtNombrePermiso.Text = dgvPermisos.CurrentRow.Cells[1].Value?.ToString();
                    idComponentePermiso = (int)dgvPermisos.CurrentRow.Cells[0].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        #endregion



        private void btnAgregarPermisoAGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdGrupo.Text != "" && txtIdPermiso.Text != "")
                {
                    grupoBLL.AgregarPermisoAGrupo(idComponenteGrupo, idComponentePermiso);
                    
                    permisoBLL.ListarPermisosGrupoEnDGV(dgvPermisos, idComponenteGrupo);
                    validacionBLL.LimpiarCampos(this.Controls);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un grupo y un permiso", "Agregar Permiso a Grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnQuitarPermisoAGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdGrupo.Text != "" && txtIdPermiso.Text != "")
                {
                    int idGrupo = Convert.ToInt32(txtIdGrupo.Text);
                    int idPermiso = Convert.ToInt32(txtIdPermiso.Text);
                    grupoBLL.QuitarPermisoAGrupo(idGrupo, idComponentePermiso);
                    
                    permisoBLL.ListarPermisosGrupoEnDGV(dgvPermisos, idGrupo);
                    validacionBLL.LimpiarCampos(this.Controls);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un grupo y un permiso", "Quitar Permiso a Grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
