using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class StateBLL
    {
        StateDAL stateDAL = new StateDAL();

        public void FinalizarPedido(List<DetallePedidoBE> listaDetallesPedidos, int nroReserva, string Estado, string tipoFactura, string usuarioActual)
        {
            stateDAL.FinalizarPedido(listaDetallesPedidos, nroReserva, Estado, tipoFactura, usuarioActual);
            

        }
    }
}
