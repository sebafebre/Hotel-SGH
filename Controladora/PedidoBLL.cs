using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controladora
{
    public class PedidoBLL
    {
        PedidoDAL pedidoDAL = new PedidoDAL();

        #region Eliminar y Modificar DetallesPedido y Pedido
        

        public void ModificarEstadoPedido(int nroPedido, string estado)
        {
            pedidoDAL.ModificarEstadoPedido(nroPedido, estado);
        }
        public void EliminarPedido(int nroPedido)
        {
            pedidoDAL.EliminarPedido(nroPedido);  
        }



        

        public void EliminarDetallePedido(int idDetalle, string NombreProd)
        {
            pedidoDAL.EliminarDetallePedido(idDetalle, NombreProd);
            
        }

        public void ModificarDetallePedido(int idDetalle, int cantidad, string NombreProd)
        {
            pedidoDAL.ModificarDetallePedido(idDetalle, cantidad, NombreProd);
        }

        #endregion








        public void ObtenerDatosClienteYHabitacion(int nroReservaDGV, out ClienteBE cliente, out HabitacionBE habitacion)
        {
            pedidoDAL.ObtenerDatosClienteYHabitacion(nroReservaDGV, out cliente, out habitacion);
        }

        public void ListarProductosEnDGV(DataGridView dataGridView)
        {
            pedidoDAL.ListarProductosEnDGV(dataGridView);
        }







        public List<DetallePedidoBE> AgregarPedido(List<DetallePedidoBE> listaDetallesPedidos, DataGridView dgvProductos, int idProducto, string NomProduct, int CantPedido)
        {
            return pedidoDAL.AgregarPedido(listaDetallesPedidos, dgvProductos, idProducto, NomProduct, CantPedido);
        }

        /*public void FinalizarPedido(List<DetallePedidoBE> listaDetallesPedidos, int nroReserva)
        {
            pedidoDAL.FinalizarPedido( listaDetallesPedidos , nroReserva);   
        }*/

        public List<DetallePedidoBE> CancelarPedido(List<DetallePedidoBE> listaDetallesPedidos, DataGridView dgvProductos, DataGridView dgvDetalles)
        {
            return pedidoDAL.CancelarPedido(listaDetallesPedidos, dgvProductos, dgvDetalles);
        }
        public void CargarDetallesEnDataGridView(List<DetallePedidoBE> listaDetalles, DataGridView dataGridView)
        {
            pedidoDAL.CargarDetallesEnDataGridView(listaDetalles, dataGridView);
        }





        
        public void ListarPedidosEnDataGridView(DataGridView dataGridView)
        {
            pedidoDAL.ListarPedidosEnDataGridView(dataGridView);
        }

        public void ListarDetallesEnDataGridView(int nroReserva, DataGridView dataGridView)
        {
            pedidoDAL.ListarDetallesEnDataGridView(nroReserva, dataGridView);
        }



        public void ListarDetallesDelPedidoDGV(int nroPedido, DataGridView dataGridView)
        {
            pedidoDAL.ListarDetallesDelPedidoDGV(nroPedido, dataGridView);
        }


        public void BuscarPorNumHabitacion(int NumHab, DataGridView dataGridView)
        {
            pedidoDAL.BuscarPorNumHabitacion(NumHab, dataGridView);
        }

        public void ListarPedidosDeReservaEnDGV(DataGridView dataGridView, int nroReserva)
        {
            pedidoDAL.ListarPedidosDeReservaEnDGV(dataGridView, nroReserva);

        }










        public void GenerarFacturaTXT(int nroReserva, string tipoFactura, string usuarioActual)
        {
            pedidoDAL.GenerarFacturaTXT(nroReserva, tipoFactura, usuarioActual);
        }



        public List<DetallePedidoBE> ObtenerListaDetallesPedidos(int nroPedido)
        {
            return pedidoDAL.ObtenerListaDetallesPedidos(nroPedido);
        }

    }
}
