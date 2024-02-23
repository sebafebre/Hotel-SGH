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
            if (IdProductoSelec == 0)
            {
                MessageBox.Show("Debe seleccionar un producto");
                dgvProductos.Focus();
                return false;
            }
            if (txtCantProducto.Text == "")
            {
                MessageBox.Show("Debe ingresar una cantidad");
                txtCantProducto.Focus();
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

                    if (CantProductoSelec > Convert.ToInt32(txtCantProducto.Text))
                    {

                        // Agregar el producto al pedido
                        //pedidoBLL.AgregarProductoAPedido(IdReservaDGV, IdProducto, NombreProducto, CantidadProducto, PrecioProducto);
                        //pedidoBLL.AgregarPedido( IdProductoSelec, txtNombreProducto.Text, Convert.ToInt32(txtCantProducto.Text));

                        listaDetallesPedidos = pedidoBLL.AgregarPedido(listaDetallesPedidos, dgvProductos, IdProductoSelec, txtNombreProducto.Text, Convert.ToInt32(txtCantProducto.Text));

                        // Actualizar el total del pedido
                        //pedidoBLL.ActualizarTotalPedido(IdReservaDGV, Convert.ToInt32(lblTotal.Text) + (CantidadProducto * PrecioProducto));

                        // Actualizar el DataGridView de productos
                        //pedidoBLL.ListarProductosEnDGV(dgvProductos);
                        pedidoBLL.CargarDetallesEnDataGridView(listaDetallesPedidos, dgvDetalles);

                        lblTotalPedido.Text = listaDetallesPedidos.Sum(d => d.Total).ToString();
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
                        pedidoBLL.FinalizarPedido(listaDetallesPedidos, nroReservaDGV);
                        MessageBox.Show("Se guardo el pedido con exito.");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvReservas.CurrentRow != null)
                {
                    nroReservaDGV = Convert.ToInt32(dgvReservas.CurrentRow.Cells[0].Value.ToString());
                    txtNroReserva.Text = dgvReservas.CurrentRow.Cells[1].Value.ToString();
                    lblTotal.Text = dgvReservas.CurrentRow.Cells[4].Value.ToString();
                    int NumHab = Convert.ToInt32(dgvReservas.CurrentRow.Cells[5].Value.ToString());




                    ClienteBE clienteReserva;
                    HabitacionBE habitacionReserva;

                    pedidoBLL.ObtenerDatosClienteYHabitacion(nroReservaDGV, out clienteReserva, out habitacionReserva);

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

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
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

                    //lblTotal.Text = (Convert.ToInt32(txtCantProducto.Text) * PrecioProductoSelec).ToString();

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

        private void txtCantProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtCantProducto.Text != "")
            {
                lblTotal.Text = (Convert.ToInt32(txtCantProducto.Text) * PrecioProductoSelec).ToString();
            }
        }

        private void txtNroHabitacion_TextChanged(object sender, EventArgs e)
        {
            string nroHabitacion = txtNroHabitacion.Text.Trim().ToLower();
            checkinBLL.BuscarClientePorNumHabitacion(nroHabitacion, dgvReservas);

        }

        private void txtBuscarDNI_TextChanged(object sender, EventArgs e)
        {
            string dni = txtBuscarDNI.Text.Trim().ToLower();
            checkinBLL.BuscarClientePorDNI(dni, dgvReservas);
        }
    }
}
