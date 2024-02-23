using Controladora;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Paneles.Pedidos
{
    public partial class frmModificarPedidos : Form
    {
        PedidoBLL pedidoBLL = new PedidoBLL();
        CheckInBLL checkinBLL = new CheckInBLL();
        ValidacionesBLL validacionBLL = new ValidacionesBLL();

        List<DetallePedidoBE> listaDetallesPedidos = new List<DetallePedidoBE>();

        public frmModificarPedidos()
        {
            InitializeComponent();

            
            pedidoBLL.CargarDetallesEnDataGridView(listaDetallesPedidos, dgvDetalles);
            pedidoBLL.ListarPedidosEnDataGridView(dgvPedidos);
        }

        

        private void btnEliminarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNroPedido.Text != "")
                {
                    

                    int nroPedido = Convert.ToInt32(txtNroPedido.Text);
                    pedidoBLL.EliminarPedido(nroPedido);
                    pedidoBLL.ListarPedidosEnDataGridView(dgvPedidos);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un pedido para eliminarlo");
                    dgvPedidos.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdDetalle.Text != "" && txtNombreProducto.Text != "" )
                {
                    //int nroReserva = Convert.ToInt32(txtNroReserva.Text);
                    int idDetalle = Convert.ToInt32(txtIdDetalle.Text);
                    string nomProd = txtNombreProducto.Text;
                    pedidoBLL.EliminarDetallePedido(idDetalle, nomProd);
                    pedidoBLL.ListarDetallesDelPedidoDGV(Convert.ToInt32(txtNroPedido.Text), dgvDetalles);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un detalle del producto que quiero eliminar");
                    dgvPedidos.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnModificarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdDetalle.Text != "")
                {
                    if (txtCantProducto.Text != "" )
                    {
                        if(txtNombreProducto.Text != "")
                        {
                            int idDetalle = Convert.ToInt32(txtIdDetalle.Text);
                            string nomProd = txtNombreProducto.Text;
                            int CantPedido = Convert.ToInt32(txtCantProducto.Text);
                            pedidoBLL.ModificarDetallePedido(idDetalle, CantPedido, nomProd);
                            pedidoBLL.ListarDetallesDelPedidoDGV(Convert.ToInt32(txtNroPedido.Text), dgvDetalles);

                        }
                        else
                        {
                            MessageBox.Show("Debe completar el campo del nombre del producto");
                            txtNombreProducto.Focus();
                        }

                        
                        
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar la cantidad del producto");
                        txtCantProducto.Focus();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un detalle");
                    dgvPedidos.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
        
        private void txtBuscarDNI_TextChanged(object sender, EventArgs e)
        {
            /*
            string dni = txtBuscarDNI.Text.Trim().ToLower();
            checkinBLL.BuscarClientePorDNI(dni, dgvPedidos);*/
        }

        private void txtNroReserva_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNroHabitacion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNroHabitacion.Text != "")
                {
                    int nroHabitacion = Convert.ToInt32(txtNroHabitacion.Text.Trim());
                    pedidoBLL.BuscarPorNumHabitacion(nroHabitacion, dgvPedidos);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }

        private void txtNombreProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvPedidos.CurrentRow != null)
                {
                    int nroPedido = Convert.ToInt32(dgvPedidos.CurrentRow.Cells[0].Value.ToString());
                    //row.Cells["Nro de Habitacion"].Value.ToString().

                    string nroReserva = dgvPedidos.CurrentRow.Cells["NroReserva"].Value.ToString();
                    txtNroReserva.Text = nroReserva.ToString();


                    //txtNombreProducto.Text = dgvDetalles.CurrentRow.Cells[2].Value.ToString();
                    //txtCantProducto.Text = dgvDetalles.CurrentRow.Cells[3].Value.ToString();


                    ClienteBE clienteReserva;
                    HabitacionBE habitacionReserva;

                    pedidoBLL.ObtenerDatosClienteYHabitacion(Convert.ToInt32(nroReserva), out clienteReserva, out habitacionReserva);
                    txtNroHabitacion.Text = habitacionReserva.NroHabitacion.ToString();
                    txtNombreCliente.Text = clienteReserva.Persona.Nombre + clienteReserva.Persona.Apellido;
                    txtBuscarDNI.Text = clienteReserva.Persona.DNI;
                    txtNroPedido.Text = nroPedido.ToString();

                    DGV_DatosEstadoPedido();

                    //ListarDetallesDelPedidoDGV(int IdPedido, DataGridView dataGridView)
                    pedidoBLL.ListarDetallesDelPedidoDGV(nroPedido, dgvDetalles);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        /*dataGridView.Columns.Add("NroPedido", "NroPedido");
            dataGridView.Columns.Add("NroReserva", "NroReserva");
            dataGridView.Columns.Add("Estado", "Estado");
            dataGridView.Columns.Add("FechaCreacion", "FechaCreacion");
            dataGridView.Columns.Add("Total", "Total");*/

        private void dgvDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvDetalles.CurrentRow != null)
                {
                    txtIdDetalle.Text = dgvDetalles.CurrentRow.Cells[0].Value.ToString();
                    //txtNroReserva.Text = dgvDetalles.CurrentRow.Cells[0].Value.ToString();
                    //
                    txtNombreProducto.Text = dgvDetalles.CurrentRow.Cells[2].Value.ToString();
                    txtCantProducto.Text = dgvDetalles.CurrentRow.Cells[3].Value.ToString();
                    lblPrecioProd.Text = dgvDetalles.CurrentRow.Cells[4].Value.ToString();
                    

                    
                    ClienteBE clienteReserva;
                    HabitacionBE habitacionReserva;

                    pedidoBLL.ObtenerDatosClienteYHabitacion(Convert.ToInt16(txtNroReserva.Text), out clienteReserva, out habitacionReserva);

                    txtNroHabitacion.Text = habitacionReserva.NroHabitacion.ToString();
                    txtNombreCliente.Text = clienteReserva.Persona.Nombre + clienteReserva.Persona.Apellido;
                    txtBuscarDNI.Text = clienteReserva.Persona.DNI;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnModificarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbAPagar.Checked == true || rbPagoInstantaneo.Checked == true)
                {
                    int nroPedido = Convert.ToInt32(txtNroPedido.Text);
                    string estadoSeleccionado = validacionBLL.ObtenerEstadoSeleccionado(flpEstado);
                    //pedido.Estado = estadoSeleccionado;
                    pedidoBLL.ModificarEstadoPedido(nroPedido, estadoSeleccionado);

                    MessageBox.Show("Habitacion modificada correctamente", "Modificar Habitacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pedidoBLL.ListarPedidosEnDataGridView(dgvPedidos);
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

        public void DGV_DatosEstadoPedido()
        {
            if (dgvPedidos.CurrentRow.Cells[2].Value.ToString() == "PagoPendiente")
            {
                rbAPagar.Checked = true;
            }
            if (dgvPedidos.CurrentRow.Cells[2].Value.ToString() == "Pendiente")
            {
                rbAPagar.Checked = true;
            }
            if (dgvPedidos.CurrentRow.Cells[2].Value.ToString() == "Pagado")
            {
                rbPagoInstantaneo.Checked = true;
            }
        }
    }
}
