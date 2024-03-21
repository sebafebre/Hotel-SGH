using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controladora
{
    public class AuditoriaBLL
    {
        AuditoriaDAL auditoriaDAL = new AuditoriaDAL(new ContextoBD());

        


        public void ListarFacturasEnDGV(DataGridView dataGridView)
        {
            auditoriaDAL.ListarFacturasEnDGV(dataGridView);

        }

        public void ListarPedidosEnDGV(DataGridView dataGridView)
        {
            auditoriaDAL.ListarPedidosEnDGV(dataGridView);

        }

        public void ListarDetallesEnDGV(DataGridView dataGridView)
        {
            auditoriaDAL.ListarDetallesEnDGV(dataGridView);

        }



        public  void ExportarDataGridView(DataGridView dataGridView, string nombreArchivo)
        {
            auditoriaDAL.ExportarDataGridView(dataGridView, nombreArchivo);
        }



        #region Mostrar Historial de Cambios

            public void MostrarPedidosHistDePedido(int idPedido, DataGridView DGV)
        {
            auditoriaDAL.MostrarPedidosHistDePedido(idPedido, DGV);
        }

        public void MostrarDetallesHistDePedido(int idPedido, DataGridView DGV)
        {
            auditoriaDAL.MostrarDetallesHistDePedido(idPedido, DGV);
        }

        public void MostrarDetallesHistDeDetalle(int idDetalle, DataGridView DGV)
        {
            auditoriaDAL.MostrarDetallesHistDeDetalle(idDetalle, DGV);
        }

        public void MostrarPedidosDeFactura(int idFactura, DataGridView DGV)
        {
            auditoriaDAL.MostrarPedidosDeFactura(idFactura, DGV);
        }

        public void MostrarDetallesHistDeFactura(int idFactura, DataGridView DGV)
        {
            auditoriaDAL.MostrarDetallesHistDeFactura(idFactura, DGV);
        }

        




        #endregion
















    }
}
