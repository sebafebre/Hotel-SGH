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

        public void FinalizarPedido(List<DetallePedidoBE> listaDetallesPedidos, int nroReserva, string Estado, string tipoFactura, string usuarioActual)
        {
            stateDAL.FinalizarPedido(listaDetallesPedidos, nroReserva, Estado, tipoFactura, usuarioActual);


        }


        #region Composite
        /*

        private Composite grupo;
        private Composite permiso;


        
        public StateBLL()
        {
            grupo = new Grupo();
            permiso = new Permiso();
        }

        public void CrearGrupo(ComponenteBE componente)
        {
            grupo.Crear(componente);
        }

        public void EliminarGrupo(ComponenteBE componente)
        {
            grupo.Eliminar(componente);
        }

        public void ModificarGrupo(ComponenteBE componente)
        {
            grupo.Modificar(componente);
        }

        public void CrearPermiso(ComponenteBE componente)
        {
            permiso.Crear(componente);
        }

        public void EliminarPermiso(ComponenteBE componente)
        {
            permiso.Eliminar(componente);
        }

        public void ModificarPermiso(ComponenteBE componente)
        {
            permiso.Modificar(componente);
        }


        */

        #endregion

    }
}
