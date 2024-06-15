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
        StateBLL stateBLL = new StateBLL();

        List<DetallePedidoBE> listaDetallesPedidos = new List<DetallePedidoBE>();


        string usuarioActual = UsuarioBE.usaurioLogueado;


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
                    int idDetalle = Convert.ToInt32(txtIdDetalle.Text);
                    string nomProd = txtNombreProducto.Text;
                    pedidoBLL.EliminarDetallePedido(idDetalle, nomProd);
                    pedidoBLL.ListarDetallesDelPedidoDGV(Convert.ToInt32(txtNroPedido.Text), dgvDetalles);
                    pedidoBLL.ListarPedidosEnDataGridView(dgvPedidos);

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
                            pedidoBLL.ListarPedidosEnDataGridView(dgvPedidos);


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
        
        
        private void txtNroReserva_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtNombreProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantProducto_TextChanged(object sender, EventArgs e)
        {

        }
        

        private void btnModificarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbAPagar.Checked == true || rbPagoInstantaneo.Checked == true)
                {
                    int nroPedido = Convert.ToInt32(txtNroPedido.Text);
                    string estadoSeleccionado = validacionBLL.ObtenerEstadoSeleccionado(flpEstado);
                    int nroReserva = Convert.ToInt32(txtNroReserva.Text);
                    if (estadoSeleccionado == "Pago en el momento" /*&&*/ )
                    {

                        List<DetallePedidoBE> listaDetallesPedidos = pedidoBLL.ObtenerListaDetallesPedidos(nroPedido);


                        frmPago formularioPago = new frmPago();
                        formularioPago.Accion = "PagoDePedido";
                        formularioPago.nroReserva = nroReserva;
                        formularioPago.listaDetallesPedidos = listaDetallesPedidos;
                        formularioPago.Estado = estadoSeleccionado;
                        formularioPago.nroPedido = nroPedido;
                        formularioPago.ShowDialog(); 

                        
                        pedidoBLL.ListarPedidosEnDataGridView(dgvPedidos);

                        validacionBLL.LimpiarCampos(this.Controls);
                        
                    }
                    else
                    {
                        MessageBox.Show("El pedido ya pagado no se puede modificar, solo se puede pagar el pedido que se encuentra con el pago pendiente", "Modificar Estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            if (dgvPedidos.CurrentRow.Cells[3].Value.ToString() == "PagoPendiente")
            {
                rbAPagar.Checked = true;
            }
            if (dgvPedidos.CurrentRow.Cells[3].Value.ToString() == "Pendiente")
            {
                rbAPagar.Checked = true;
            }
            if (dgvPedidos.CurrentRow.Cells[3].Value.ToString() == "Pagado")
            {
                rbPagoInstantaneo.Checked = true;
            }
        }



        private bool usuarioEscribiendo = false;
        private void txtNroHabitacion_KeyPress(object sender, KeyPressEventArgs e)
        {

            usuarioEscribiendo = e.KeyChar != '\b';
        }        
        
        private void txtNroHabitacion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (usuarioEscribiendo)
                {
                    if (!string.IsNullOrEmpty(txtNroHabitacion.Text))
                    {
                        string nroHabitacion = txtNroHabitacion.Text.Trim().ToLower();
                        checkinBLL.BuscarClientePorNumHabitacion(nroHabitacion, dgvPedidos);
                    }
                    


                    // Restablecer usuarioEscribiendo solo cuando el usuario ha terminado de escribir
                    usuarioEscribiendo = false;
                }
                if (string.IsNullOrEmpty(txtNroHabitacion.Text))
                {
                    pedidoBLL.ListarPedidosEnDataGridView(dgvPedidos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }


        private void txtBuscarDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarioEscribiendo = e.KeyChar != '\b';
        }
        

        private void txtBuscarDNI_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvDetalles_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvDetalles.CurrentRow != null)
                {
                    txtIdDetalle.Text = dgvDetalles.CurrentRow.Cells[0].Value.ToString();
                    
                    txtNombreProducto.Text = dgvDetalles.CurrentRow.Cells[2].Value.ToString();
                    txtCantProducto.Text = dgvDetalles.CurrentRow.Cells[3].Value.ToString();
                    lblPrecioProd.Text = dgvDetalles.CurrentRow.Cells[5].Value.ToString();



                    ClienteBE clienteReserva;
                    HabitacionBE habitacionReserva;

                    pedidoBLL.ObtenerDatosClienteYHabitacion(Convert.ToInt16(txtNroReserva.Text), out clienteReserva, out habitacionReserva);

                    txtNroHabitacion.Text = habitacionReserva.NroHabitacion.ToString();
                    txtNombreCliente.Text = clienteReserva.Persona.Nombre + clienteReserva.Persona.Apellido;
                    txtBuscarDNI.Text = clienteReserva.Persona.DNI.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvPedidos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvPedidos.CurrentRow != null)
                {
                    int nroPedido = Convert.ToInt32(dgvPedidos.CurrentRow.Cells[0].Value.ToString());

                    string nroReserva = dgvPedidos.CurrentRow.Cells[1].Value.ToString();
                    txtNroReserva.Text = nroReserva.ToString();


                    string nroHabitacion = dgvPedidos.CurrentRow.Cells[2].Value.ToString();
                    txtNroHabitacion.Text = nroHabitacion.ToString();



                    ClienteBE clienteReserva;
                    HabitacionBE habitacionReserva;

                    pedidoBLL.ObtenerDatosClienteYHabitacion(Convert.ToInt32(nroReserva), out clienteReserva, out habitacionReserva);
                    txtNombreCliente.Text = clienteReserva.Persona.Nombre + clienteReserva.Persona.Apellido;
                    txtBuscarDNI.Text = clienteReserva.Persona.DNI.ToString();
                    txtNroPedido.Text = nroPedido.ToString();




                    DGV_DatosEstadoPedido();

                    pedidoBLL.ListarDetallesDelPedidoDGV(nroPedido, dgvDetalles);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

