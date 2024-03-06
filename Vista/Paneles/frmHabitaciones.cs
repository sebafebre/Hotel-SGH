using Controladora;
using Controladora.SeguridadBLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Paneles
{
    public partial class frmHabitaciones : Form
    {
        HabitacionBLL habitacionBLL = new HabitacionBLL();
        ValidacionesBLL validacionBLL = new ValidacionesBLL();

        GrupoBLL grupoBLL = new GrupoBLL();
        string usuarioActual = UsuarioBE.usaurioLogueado;


        int nroHabitacion;
        public frmHabitaciones()
        {
            InitializeComponent();
            habitacionBLL.ListarHabitacionesEnDataGridView(dgvHabitaciones);
        }



        public void VerificasPermisos()
        {


            List<PermisoBE> permisosUsuario = grupoBLL.ObtenerPermisosDelUsuario(usuarioActual);

            List<string> permisos = new List<string>();

            //foreach (var item in permisosUsuario)
            foreach (var item in permisosUsuario)
            {
                permisos.Add(item.Componente.Nombre);
            }
            if (permisos.Contains("GH003 AgregaHab"))
            {
                btnAgregar.Visible = true;
                
            }
            else
            {
                btnAgregar.Visible = false;
               
            }
            if (permisos.Contains("GH004 EliminarHab"))
            {
                btnEliminar.Visible = true;
            }
            else
            {
                btnEliminar.Visible = false;
            }
            if (permisos.Contains("PL000 Limpieza"))
            {
                cbNroCamas.Enabled = false;
            }
            else
            {
                cbNroCamas.Enabled = true;
            }
            if (permisos.Contains("PL000 Limpieza"))
            {
                cbPiso.Enabled = false;
            }
            else
            {
                cbPiso.Enabled = true;
            }
            if (permisos.Contains("PL000 Limpieza"))
            {
                cbTipoHabitacion.Enabled = false;
            }
            else
            {
                cbTipoHabitacion.Enabled = true;
            }
            if (permisos.Contains("PL000 Limpieza"))
            {
                cbNumHabitacion.Enabled = false;
            }
            else
            {
                cbNumHabitacion.Enabled = true;
            }
            

        }


















        #region ABM Habitaciones
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    HabitacionBE habitacion = new HabitacionBE();
                    habitacion.Id = Convert.ToInt32(txtIdHabitacion.Text);
                    habitacion.Piso = Convert.ToInt32(cbPiso.Text);


                    string numeroCompletoHabitacion = String.Format("{0:D2}{1:D2}", Convert.ToInt32(cbPiso.Text), Convert.ToInt32(cbNumHabitacion.Text));


                    habitacion.NroHabitacion = Convert.ToInt32(numeroCompletoHabitacion);

                    string estadoSeleccionado = habitacionBLL.ObtenerEstadoSeleccionado(flpEstado);
                    habitacion.Estado = estadoSeleccionado;


                    habitacion.PrecioDiario = Convert.ToDecimal(txtPrecioDiario.Text);
                    habitacion.TipoHabitacion = cbTipoHabitacion.Text;
                    habitacion.TipoCamas = cbNroCamas.Text;
                    habitacionBLL.ModificarHabitacion(habitacion);
                    MessageBox.Show("Habitacion modificada correctamente", "Modificar Habitacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    habitacionBLL.ListarHabitacionesEnDataGridView(dgvHabitaciones);
                    validacionBLL.LimpiarCampos(this.Controls);
                }
                else 
                {
                    MessageBox.Show("Debe seleccionar una habitacion", "Modificar Habitacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {

                    HabitacionBE habitacion = new HabitacionBE();
                    //habitacion.Id = habitacionBLL.ProximoId();
                    habitacion.Piso = Convert.ToInt32(cbPiso.Text);


                    string numeroCompletoHabitacion = String.Format("{0:D2}{1:D2}", Convert.ToInt32(cbPiso.Text), Convert.ToInt32(cbNumHabitacion.Text));


                    habitacion.NroHabitacion = Convert.ToInt32(numeroCompletoHabitacion);


                    habitacion.Estado = "Disponible";
                    habitacion.PrecioDiario = Convert.ToDecimal(txtPrecioDiario.Text);
                    habitacion.TipoHabitacion = cbTipoHabitacion.Text;
                    habitacion.TipoCamas = cbNroCamas.Text;
                    habitacionBLL.AgregarHabitacion(habitacion);
                    //MessageBox.Show("Habitacion agregada correctamente", "Agregar Habitacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    habitacionBLL.ListarHabitacionesEnDataGridView(dgvHabitaciones);
                    validacionBLL.LimpiarCampos(this.Controls);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(txtIdHabitacion.Text != "")
            {
                if (MessageBox.Show("¿Está seguro que desea eliminar la habitacion?", "Eliminar Habitacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabitacionBE habitacion = new HabitacionBE();
                    habitacion.Id = Convert.ToInt32(txtIdHabitacion.Text);
                    habitacionBLL.EliminarHabitacion(habitacion);
                    MessageBox.Show("Habitacion eliminada correctamente", "Eliminar Habitacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    habitacionBLL.ListarHabitacionesEnDataGridView(dgvHabitaciones);
                    validacionBLL.LimpiarCampos(this.Controls);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una habitacion", "Eliminar Habitacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }
        #endregion

        #region DataGridView Habitaciones
        private void dgvHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            validacionBLL.LimpiarCampos(this.Controls);
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvHabitaciones.CurrentRow != null)
                {
                    txtIdHabitacion.Text = dgvHabitaciones.CurrentRow.Cells[0].Value.ToString();
                    //cbNumHabitacion.Text = string numeroHabitacionSimple = numeroCompletoHabitacion.Substring(2);
                    cbPiso.SelectedItem = dgvHabitaciones.CurrentRow.Cells[2].Value.ToString();
                    cbTipoHabitacion.SelectedItem = dgvHabitaciones.CurrentRow.Cells[3].Value.ToString();

                    DGV_DatosEstado();

                    txtPrecioDiario.Text = dgvHabitaciones.CurrentRow.Cells[5].Value.ToString();
                    cbNroCamas.SelectedItem = dgvHabitaciones.CurrentRow.Cells[6].Value.ToString();
                    string numeroCompletoHabitacion = dgvHabitaciones.CurrentRow.Cells[1].Value.ToString();

                    


                    // Obtener el último dígito si es un número de tres dígitos o los dos últimos si es de cuatro dígitos
                    int ultimosDigitos = Convert.ToInt32( numeroCompletoHabitacion.Substring(numeroCompletoHabitacion.Length - 2));

                    // Si los dos últimos dígitos son "00", tomamos solo el tercer dígito
                    if (ultimosDigitos < 10 && numeroCompletoHabitacion.Length >= 3)
                    {
                        string tercerDigito = numeroCompletoHabitacion.Substring(numeroCompletoHabitacion.Length - 3, 1);
                        cbNumHabitacion.Text = tercerDigito;
                    }
                    else
                    {
                        cbNumHabitacion.Text = ultimosDigitos.ToString();
                    }

                    /*
                    cbNumHabitacion.Text = numeroCompletoHabitacion.Substring(2);


                    // Obtener el último dígito si es un número de tres dígitos o los dos últimos si es de cuatro dígitos
                    string ultimosDigitos = numeroCompletoHabitacion.Substring(numeroCompletoHabitacion.Length - 2);

                    // Si los dos últimos dígitos son "00", tomamos solo el tercer dígito
                    if (ultimosDigitos == "00" && numeroCompletoHabitacion.Length >= 3)
                    {
                        string tercerDigito = numeroCompletoHabitacion.Substring(numeroCompletoHabitacion.Length - 3, 1);
                        cbNumHabitacion.Text = tercerDigito; 
                    }
                    else
                    {
                       cbNumHabitacion.Text = ultimosDigitos;
                    }*/
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void DGV_DatosEstado()
        {
            if (dgvHabitaciones.CurrentRow.Cells[4].Value.ToString() == "Ocupado")
            {
                rbOcupado.Checked = true;
            }
            if (dgvHabitaciones.CurrentRow.Cells[4].Value.ToString() == "Disponible")
            {
                rbDisponible.Checked = true;
            }
            if (dgvHabitaciones.CurrentRow.Cells[4].Value.ToString() == "Limpieza")
            {
                rbLimpieza.Checked = true;
            }
        }

        #endregion

        #region Menejo de Precio Diario
        private int PrecioD = 0;
        private int PrecioH = 0;
        private void cbTipoHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoHabitacion.Text == "Basica")
            {
                //this.cbTipoHabitacion.Text = "Basica";
                PrecioH = 100;
                txtPrecioDiario.Text = Convert.ToString(PrecioD + PrecioH);
            }
            if (cbTipoHabitacion.Text == "Medium")
            {
                //this.cbTipoHabitacion.Text = "Medium";
                PrecioH = 200;
                txtPrecioDiario.Text = Convert.ToString(PrecioD + PrecioH);
            }
            if (cbTipoHabitacion.Text == "Premium")
            {
                //this.cbTipoHabitacion.Text = "Premium";
                PrecioH = 300;
                txtPrecioDiario.Text = Convert.ToString(PrecioD + PrecioH);
            }
            if (cbTipoHabitacion.Text == "Suit")
            {
                //this.cbTipoHabitacion.Text = "Suit";
                PrecioH = 400;
                txtPrecioDiario.Text = Convert.ToString(PrecioD + PrecioH);
            }
        }
        private void cbNroCamas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNroCamas.Text == "1-Simple")
            {
                //this.cbNroCamas.Text = "1-Simple";
                PrecioD = 200;
                txtPrecioDiario.Text = Convert.ToString(PrecioD + PrecioH);
            }
            if (cbNroCamas.Text == "2-Simple")
            {
                //this.cbNroCamas.Text = "2-Doble";
                PrecioD = 250;
                txtPrecioDiario.Text = Convert.ToString(PrecioD + PrecioH);
            }
            if (cbNroCamas.Text == "1-Matrimonial")
            {
                //this.cbNroCamas.Text = "1-Matrimonial";
                PrecioD = 300;
                txtPrecioDiario.Text = Convert.ToString(PrecioD + PrecioH);
            }
            if (cbNroCamas.Text == "2-Matrimoniales")
            {
                //this.cbNroCamas.Text = "2-Matrimoniales";
                PrecioD = 500;
                txtPrecioDiario.Text = Convert.ToString(PrecioD + PrecioH);
            }
        }
        #endregion


        private bool ValidarCampos()
        {
            /*if (string.IsNullOrEmpty(this.cbPiso.Text) || string.IsNullOrEmpty(this.cbNumHabitacion.Text)  || string.IsNullOrEmpty(this.txtPrecioDiario.Text) || string.IsNullOrEmpty(this.cbTipoHabitacion.Text) || string.IsNullOrEmpty(this.cbNroCamas.Text))
            {
                MessageBox.Show("Debe completar todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }*/
            //return true;

            if (string.IsNullOrEmpty(this.cbPiso.Text))
            {
                lblError.Text = "Debe completar el piso de la habitacion que quiere agregar.";
                return false;

            }
            if (string.IsNullOrEmpty(this.cbNumHabitacion.Text))
            {
                lblError.Text = "Debe completar el numero de la habitacion  que quiere agregar.";
                return false;
            }
            if (string.IsNullOrEmpty(this.txtPrecioDiario.Text))
            {
                lblError.Text = "Debe completar el precio diario de la habitacion que quiere agregar.";
                return false;
            }
            if (string.IsNullOrEmpty(this.cbTipoHabitacion.Text))
            {
                lblError.Text = "Debe completar el tipo de habitacion que quiere agregar.";
                return false;
            }
            if (string.IsNullOrEmpty(this.cbNroCamas.Text))
            {
                lblError.Text = "Debe completar el tipo de camas de la habitacion que quiere agregar.";
                return false;
            }
            return true;
        }
    }
}
