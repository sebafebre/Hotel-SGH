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


        public frmUsuarioGrupos()
        {
            InitializeComponent();
            usuarioBLL.ListarUsuariosEnDGV(dgvUsuarios);
            grupoBLL.ListarGruposEnDGV(dgvGrupos);
            

        }

        private bool ValidarCampos()
        {
            if (txtIdUsuario.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Usuario al cual asignarle el grupo");
                dgvUsuarios.Focus();
                return false;

            }
            if (txtIdGrupo.Text == "")
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
                    grupoBLL.ListarGruposUsuarioEnDataGridView(dgvGrupos, idUsuario);

                    /* ObtenerDatosClienteYHabitacion
                    ClienteBE clienteReserva;
                    HabitacionBE habitacionReserva;

                    pedidoBLL.ObtenerDatosClienteYHabitacion(nroReservaDGV, out clienteReserva, out habitacionReserva);

                    txtNroHabitacion.Text = habitacionReserva.NroHabitacion.ToString();
                    txtNombreCliente.Text = clienteReserva.Persona.Nombre + clienteReserva.Persona.Apellido;
                    txtBuscarDNI.Text = clienteReserva.Persona.DNI;*/
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
                    txtIdGrupo.Text = dgvGrupos.CurrentRow.Cells[0].Value?.ToString();

                    int idGrupo = Convert.ToInt32(dgvGrupos.CurrentRow.Cells[0].Value?.ToString());
                    permisoBLL.ListarPermisosGrupoEnDGV(dgvPermisosDelGrupo, idGrupo);

                    /* ObtenerDatosClienteYHabitacion
                    ClienteBE clienteReserva;
                    HabitacionBE habitacionReserva;

                    pedidoBLL.ObtenerDatosClienteYHabitacion(nroReservaDGV, out clienteReserva, out habitacionReserva);

                    txtNroHabitacion.Text = habitacionReserva.NroHabitacion.ToString();
                    txtNombreCliente.Text = clienteReserva.Persona.Nombre + clienteReserva.Persona.Apellido;
                    txtBuscarDNI.Text = clienteReserva.Persona.DNI;*/
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
                int idGrupo = Convert.ToInt32(txtIdGrupo.Text);


                if (ValidarCampos())
                {
                    usuarioBLL.AgregarGrupoAUsuario(idUsuario, idGrupo);
                    grupoBLL.ListarGruposUsuarioEnDataGridView(dgvGrupos, idUsuario);
                    //validacionBLL.LimpiarCampos(this.Controls);
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
                if(ValidarCampos())
                {
                    int idUsuario = Convert.ToInt32(txtIdUsuario.Text);
                    int idGrupo = Convert.ToInt32(txtIdGrupo.Text);

                    usuarioBLL.EliminarGrupoAUsuario(idUsuario, idGrupo);
                    grupoBLL.ListarGruposUsuarioEnDataGridView(dgvGrupos, idUsuario);
                    //validacionBLL.LimpiarCampos(this.Controls);

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
    }
}
