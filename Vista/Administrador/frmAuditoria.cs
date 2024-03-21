using Controladora;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Administrador
{
    public partial class frmAuditoria : Form
    {
        PedidoBLL pedidoBLL = new PedidoBLL();
        AuditoriaBLL auditoriaBLL = new AuditoriaBLL();
        int idFactura;
        string tipoID = "";
        public frmAuditoria()
        {
            InitializeComponent();
            auditoriaBLL.ListarFacturasEnDGV(dgvFacturas);
            
        }
        
        

        


        

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            tipoID ="Factura";
            auditoriaBLL.ListarFacturasEnDGV(dgvFacturas);
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            tipoID = "Pedido";
            auditoriaBLL.ListarPedidosEnDGV(dgvFacturas);

        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            tipoID = "Detalle";
            auditoriaBLL.ListarDetallesEnDGV(dgvFacturas);
        }


        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tipoID == "Factura" || tipoID == "")
            {
                try
                {
                    //Poner los datos del cliente seleccionado en los campos correspondientes
                    if (dgvFacturas.CurrentRow != null)
                    {
                        idFactura = Convert.ToInt32(dgvFacturas.CurrentRow.Cells[0].Value);

                        if (idFactura != 0)
                        {

                            auditoriaBLL.MostrarPedidosDeFactura(idFactura, dgvPedidos);
                            auditoriaBLL.MostrarDetallesHistDeFactura(idFactura, dgvDetallesPedido);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (tipoID == "Pedido")
            {
                try
                {
                    //Poner los datos del cliente seleccionado en los campos correspondientes
                    if (dgvFacturas.CurrentRow != null)
                    {
                        int pedidoId = Convert.ToInt32(dgvFacturas.CurrentRow.Cells[0].Value);

                        if (pedidoId != 0)
                        {
                            auditoriaBLL.MostrarPedidosHistDePedido(pedidoId, dgvPedidos);
                            auditoriaBLL.MostrarDetallesHistDePedido(pedidoId, dgvDetallesPedido);

                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (tipoID == "Detalle")
            {
                try
                {
                    //Poner los datos del cliente seleccionado en los campos correspondientes
                    if (dgvFacturas.CurrentRow != null)
                    {
                        int DetalleId = Convert.ToInt32(dgvFacturas.CurrentRow.Cells[0].Value);

                        if (DetalleId != 0)
                        {
                            auditoriaBLL.MostrarDetallesHistDeDetalle(DetalleId, dgvDetallesPedido);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Poner los datos del cliente seleccionado en los campos correspondientes
                if (dgvPedidos.CurrentRow != null)
                {
                    int pedidoId = Convert.ToInt32(dgvPedidos.CurrentRow.Cells[0].Value);

                    if (pedidoId != 0)
                    {
                        auditoriaBLL.MostrarDetallesHistDePedido(pedidoId, dgvDetallesPedido);

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        

        private void btnReportePedidos_Click_1(object sender, EventArgs e)
        {
            auditoriaBLL.ExportarDataGridView(dgvPedidos, "Pedidos");
        }

        private void btnReporteDetalles_Click_1(object sender, EventArgs e)
        {
            auditoriaBLL.ExportarDataGridView(dgvDetallesPedido, "DetallesPedido");
        }
    }
}
