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

namespace Vista.Paneles.Pedidos
{
    public partial class frmAgregarPedidos : Form
    {
        CheckInBLL checkinBLL = new CheckInBLL();

        PedidoBLL pedidoBLL = new PedidoBLL();

        StateBLL stateBLL = new StateBLL();

        ReservaBLL reservaBLL = new ReservaBLL();

        string usuarioActual = UsuarioBE.usaurioLogueado;

        int nroReservaDGV = 0;

        int IdProductoSelec = 0;
        int CantProductoSelec = 0;
        int PrecioProductoSelec = 0;


        List<DetallePedidoBE> listaDetallesPedidos = new List<DetallePedidoBE>();

        public frmAgregarPedidos()
        {
            InitializeComponent();
            checkinBLL.ListarReservasActivasEnDataGridView(dgvReservas);
            pedidoBLL.ListarProductosEnDGV(dgvProductos);
        }

        private bool ValidarCampos()
        {
            if (txtNroReserva.Text == "")
            {
                MessageBox.Show("Debe seleccionar una reserva");
                dgvReservas.Focus();
                return false;

            }
            else if (IdProductoSelec == 0)
            {
                MessageBox.Show("Debe seleccionar un producto");
                dgvProductos.Focus();
                return false;
            }
            else if (txtCantProducto.Text == "")
            {
                MessageBox.Show("Debe ingresar una cantidad");
                txtCantProducto.Focus();
                return false;
            }
            else
            {
                return true;
            }
            //return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {

                    if (CantProductoSelec > Convert.ToInt32(txtCantProducto.Text))
                    {


                        listaDetallesPedidos = pedidoBLL.AgregarPedido(listaDetallesPedidos, dgvProductos, IdProductoSelec, txtNombreProducto.Text, Convert.ToInt32(txtCantProducto.Text));

                        
                        pedidoBLL.CargarDetallesEnDataGridView(listaDetallesPedidos, dgvDetalles);

                        lblTotalPedido.Text = listaDetallesPedidos.Sum(d => d.Total).ToString();

                        txtCantProducto.Text = "";
                        txtNombreProducto.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("No hay suficiente stock del producto seleccionado.");
                    }

                }
                else
                {
                    MessageBox.Show("Debe seleccionar una reserva y un producto");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnFinalizarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (nroReservaDGV != 0)
                {
                    if (listaDetallesPedidos.Count > 0)
                    {
                        if(rbAPagar.Checked == false && rbPagoInstantaneo.Checked == false)
                        {
                            MessageBox.Show("Debe seleccionar cuando lo quiere abonar");
                        }
                        else
                        {
                            if (rbAPagar.Checked == true)
                            {
                                string Estado = "PagoPendiente";
                                stateBLL.FinalizarPedido(listaDetallesPedidos, nroReservaDGV, Estado, "A", usuarioActual, 0);

                            }
                            if (rbPagoInstantaneo.Checked == true)
                            {
                                string Estado = "Pago en el momento";



                                frmPago formularioPago = new frmPago();
                                formularioPago.Accion = "PagoDePedido";
                                formularioPago.nroReserva = nroReservaDGV;
                                formularioPago.listaDetallesPedidos = listaDetallesPedidos;
                                formularioPago.Estado = Estado;
                                formularioPago.nroPedido = 0;
                                formularioPago.ShowDialog(); // Abre el formulario de búsqueda de cliente como un cuadro de diálogo



                                /*
                                string Estado = "Pago en el momento";
                                stateBLL.FinalizarPedido(listaDetallesPedidos, nroReservaDGV, Estado, "A", usuarioActual, 0);
                                */

                            }


                            dgvDetalles.Rows.Clear();
                            txtCantProducto.Text = "";
                            txtNombreProducto.Text = "";
                            listaDetallesPedidos.Clear();

                        }
 
                    }
                    else
                    {
                        MessageBox.Show("Primero debes agregar productos al pedido.");
                    }
                }
                else
                {
                    MessageBox.Show("Primero debes seleccionar una reserva.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                listaDetallesPedidos = pedidoBLL.CancelarPedido(listaDetallesPedidos, dgvProductos, dgvDetalles);

                txtCantProducto.Text = "";
                txtNombreProducto.Text = "";
                lblTotalPedido.Text = "0";
                listaDetallesPedidos.Clear();
                dgvDetalles.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void txtCantProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtCantProducto.Text != "")
            {
                lblTotal.Text = (Convert.ToInt32(txtCantProducto.Text) * PrecioProductoSelec).ToString();
            }
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
                        checkinBLL.BuscarClientePorNumHabitacion(nroHabitacion, dgvReservas);
                    }



                    // Restablecer usuarioEscribiendo solo cuando el usuario ha terminado de escribir
                    usuarioEscribiendo = false;
                }
                if (string.IsNullOrEmpty(txtNroHabitacion.Text))
                {
                    reservaBLL.ListarReservasActivasEnDataGridView(dgvReservas);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void txtBuscarDNI_TextChanged(object sender, EventArgs e)
        {
            

            try
            {
                if (usuarioEscribiendo)
                {
                    if (!string.IsNullOrEmpty(txtBuscarDNI.Text))
                    {
                        string dni = txtBuscarDNI.Text.Trim().ToLower();
                        checkinBLL.BuscarClientePorDNI(dni, dgvReservas);
                    }

                    // Restablecer usuarioEscribiendo solo cuando el usuario ha terminado de escribir
                    usuarioEscribiendo = false;
                }
                if (string.IsNullOrEmpty(txtBuscarDNI.Text))
                {
                    reservaBLL.ListarReservasActivasEnDataGridView(dgvReservas);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }



        }

        private void txtNroHabitacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarioEscribiendo = e.KeyChar != '\b';
        }

        private void txtNroHabitacion_KeyDown(object sender, KeyEventArgs e)
        {
            string nroHabitacion = txtNroHabitacion.Text.Trim().ToLower();
            checkinBLL.BuscarClientePorNumHabitacion(nroHabitacion, dgvReservas);

        }

        private void dgvReservas_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvReservas.CurrentRow != null)
                {
                    nroReservaDGV = Convert.ToInt32(dgvReservas.CurrentRow.Cells[0].Value.ToString());
                    txtNroReserva.Text = nroReservaDGV.ToString();
                    lblTotal.Text = dgvReservas.CurrentRow.Cells[8].Value.ToString();
                    int NumHab = Convert.ToInt32(dgvReservas.CurrentRow.Cells[5].Value.ToString());


                    ClienteBE clienteReserva;
                    HabitacionBE habitacionReserva;

                    pedidoBLL.ObtenerDatosClienteYHabitacion(nroReservaDGV, out clienteReserva, out habitacionReserva);

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

        private void dgvProductos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvProductos.CurrentRow != null)
                {
                    IdProductoSelec = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    txtNombreProducto.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                    CantProductoSelec = Convert.ToInt32(dgvProductos.CurrentRow.Cells[2].Value.ToString());
                    PrecioProductoSelec = Convert.ToInt32(dgvProductos.CurrentRow.Cells[3].Value.ToString());


                    if (txtCantProducto.Text != "")
                    {
                        lblTotal.Text = (Convert.ToInt32(txtCantProducto.Text) * PrecioProductoSelec).ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private bool usuarioEscribiendo = false;
        private void txtBuscarDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarioEscribiendo = e.KeyChar != '\b';
        }
    }
}
