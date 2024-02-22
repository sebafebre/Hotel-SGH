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
    public partial class frmUsuarios : Form
    {
        EmpleadoBLL empleadoBLL = new EmpleadoBLL();
        UsuarioBLL usuarioBLL = new UsuarioBLL();
        ValidacionesBLL validacionBLL = new ValidacionesBLL();
        public frmUsuarios()
        {
            InitializeComponent();
            empleadoBLL.ListarEmpleadosEnDGV(dgvEmpleados);
            usuarioBLL.ListarUsuariosEnDGV(dgvUsuarios);
        }


        private bool ValidarCampos()
        {
            if (txtIdEmpleado.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Empleado al cual asignarle el usuario");
                dgvEmpleados.Focus();
                return false;

            }
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre de usuario");
                txtUsuario.Focus();
                return false;
            }
            if (txtClave.Text == "")
            {
                MessageBox.Show("Debe ingresar una clave");
                txtClave.Focus();
                return false;
            }
            return true;
        }









        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    UsuarioBE usuario = new UsuarioBE();
                    usuario.Empleado = new EmpleadoBE();
                    usuario.Empleado.Id = Convert.ToInt32(txtIdEmpleado.Text);
                    usuario.Nombre = txtUsuario.Text;
                    usuario.Clave = txtClave.Text;

                    usuarioBLL.AgregarUsuario(usuario);
                    validacionBLL.LimpiarCampos(this.Controls);

                    usuarioBLL.ListarUsuariosEnDGV(dgvUsuarios);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos() && txtIdUsuario.Text != "")
                {
                    UsuarioBE usuario = new UsuarioBE();
                    usuario.Empleado = new EmpleadoBE();
                    usuario.Empleado.Id = Convert.ToInt32(txtIdEmpleado.Text);
                    usuario.Nombre = txtUsuario.Text;
                    usuario.Clave = txtClave.Text;

                    usuarioBLL.ModificarUsuario(usuario);
                    validacionBLL.LimpiarCampos(this.Controls);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un usuario a modificar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdUsuario.Text != "")
                {
                    UsuarioBE usuario = new UsuarioBE();
                    usuarioBLL.EliminarUsuario(usuario);
                    validacionBLL.LimpiarCampos(this.Controls);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un usuario a eliminar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void txtBuscarDNI_TextChanged(object sender, EventArgs e)
        {
            string dni = txtBuscarDNI.Text.Trim().ToLower();
            empleadoBLL.BuscarEmpleadoPorDNI(dni, dgvEmpleados);
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                validacionBLL.LimpiarCampos(this.Controls);
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvEmpleados.CurrentRow != null)
                {
                    txtIdEmpleado.Text = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();
                    txtNombreEmpleado.Text = dgvEmpleados.CurrentRow.Cells[1].Value.ToString() + " " + dgvEmpleados.CurrentRow.Cells[2].Value.ToString();
                    txtBuscarDNI.Text = dgvEmpleados.CurrentRow.Cells[3].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
