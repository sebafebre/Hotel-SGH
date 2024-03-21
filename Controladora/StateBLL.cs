using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Controladora.StateBLL;

namespace Controladora
{
    public class StateBLL
    {
        contextoState stateDAL = new contextoState();

        public void FinalizarPedido(List<DetallePedidoBE> listaDetallesPedidos, int nroReserva, string Estado, string tipoFactura, string usuarioActual, int nroPedido)
        {
            stateDAL.FinalizarPedido(listaDetallesPedidos, nroReserva, Estado, tipoFactura, usuarioActual, nroPedido);


        }


       

    }
}
