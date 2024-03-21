using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class State
    {
        public abstract  void ProcesarPedido(List<DetallePedidoBE> listaDetallesPedidos, int nroReserva, string tipoFactura, string rutaCarpetaFacturas, EmpleadoBE empleado, int nroPedido);
    }
    
    



}
