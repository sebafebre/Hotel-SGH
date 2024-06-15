//Creado por Sebastian Febre
// https://github.com/sebafebre
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using Entidades;
using Entidades.Auditoria;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Modelo
{
    public class AuditoriaDAL
    {
        private readonly ContextoBD _con;

        public AuditoriaDAL(ContextoBD dbContext)
        {
            _con = dbContext;
        }


        #region Obtener cambios históricos 

        

        #region cambios de Factura
        private List<PedidoHistoricoBE> obtenerPedidosHistDeFactura (int idFactura)
        {
            List<PedidoHistoricoBE> pedidosHistoricos = _con.PedidoHistorico.Where(p => p.FacturaId == idFactura).ToList();
            return pedidosHistoricos;
        }

        private List<DetallePedidoHistoricoBE> obtenerDetallesHistDeFactura(int idFactura)
        {
            List<DetallePedidoHistoricoBE> detallesHistoricos = new List<DetallePedidoHistoricoBE>();

            // Obtén todos los pedidos asociados a la factura
            List<PedidoBE> pedidos = _con.Pedido.Where(p => p.Factura.Id == idFactura).ToList();

            foreach (var pedido in pedidos)
            {
                // Obtén los detalles históricos del pedido actual y agrégales a la lista
                List<DetallePedidoHistoricoBE> detallesPedido = _con.DetallePedidoHistorico
                    .Where(d => d.PedidoId == pedido.Id)
                    .ToList();

                detallesHistoricos.AddRange(detallesPedido);
            }

            return detallesHistoricos;
        }




        public void MostrarPedidosDeFactura(int idFactura, DataGridView DGV)
        {
            List<PedidoHistoricoBE> pedidosHistoricos = obtenerPedidosHistDeFactura(idFactura);

            DGV.Rows.Clear();
            DGV.Columns.Clear();

            DGV.Columns.Add("Id Pedido", "ID Pedido");
            //DGV.Columns.Add("NroPedido", "NroPedido");
            DGV.Columns.Add("Estado", "Estado");
            DGV.Columns.Add("FechaCreacion", "FechaCreacion");
            //DGV.Columns.Add("Subtotal", "Subtotal");
            //DGV.Columns.Add("Impuestos", "Impuestos");
            DGV.Columns.Add("Total", "Total");
            //DGV.Columns.Add("ReservaId", "ReservaId");
            DGV.Columns.Add("FacturaId", "FacturaId");
            DGV.Columns.Add("FechaModificacion", "FechaModificacion");
            DGV.Columns.Add("Operacion", "Operacion");

            Dictionary<int, PedidoHistoricoBE> ultimosPedidos = new Dictionary<int, PedidoHistoricoBE>();

            foreach (var pedido in pedidosHistoricos)
            {
                int rowIndex = DGV.Rows.Add();
                DGV.Rows[rowIndex].Cells[0].Value = pedido.PedidoId;
                //DGV.Rows[rowIndex].Cells[1].Value = pedido.NroPedido;
                DGV.Rows[rowIndex].Cells[1].Value = pedido.Estado;
                DGV.Rows[rowIndex].Cells[2].Value = pedido.FechaCreacion;
                //DGV.Rows[rowIndex].Cells[4].Value = pedido.Subtotal;
                //DGV.Rows[rowIndex].Cells[5].Value = pedido.Impuestos;
                DGV.Rows[rowIndex].Cells[3].Value = pedido.Total;
                //DGV.Rows[rowIndex].Cells[7].Value = pedido.ReservaId;
                DGV.Rows[rowIndex].Cells[4].Value = pedido.FacturaId;
                DGV.Rows[rowIndex].Cells[5].Value = pedido.FechaModificacion;
                //DGV.Rows[rowIndex].Cells[10].Value = pedido.Operacion;

                if (pedido.Operacion == "Crear")
                {
                    DGV.Rows[rowIndex].Cells[6].Value = pedido.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (pedido.Operacion == "Modificar")
                {
                    DGV.Rows[rowIndex].Cells[6].Value = pedido.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Orange;
                }
                else if (pedido.Operacion == "Eliminar")
                {
                    DGV.Rows[rowIndex].Cells[6].Value = pedido.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
                if (pedido.FechaModificacion == pedidosHistoricos.Where(d => d.PedidoId == pedido.PedidoId).Max(d => d.FechaModificacion) && (pedido.Operacion == "Crear" || pedido.Operacion == "Modificar"))
                {
                    DGV.Rows[rowIndex].Cells[6].Value = pedido.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Green;
                }
                if (!ultimosPedidos.ContainsKey((int)pedido.PedidoId))
                {
                    ultimosPedidos.Add((int)pedido.PedidoId, pedido);
                }
            }
        }



        public void MostrarDetallesHistDeFactura(int idFactura, DataGridView DGV)
        {
            List<DetallePedidoHistoricoBE> detallesHistoricos = obtenerDetallesHistDeFactura(idFactura);

            DGV.Rows.Clear();
            DGV.Columns.Clear();

            DGV.Columns.Add("Id Detalle", "ID Detalle");
            DGV.Columns.Add("Cantidad", "Cantidad");
            DGV.Columns.Add("Precio", "Precio");
            DGV.Columns.Add("Nombre Producto", "Nombre Producto");
            DGV.Columns.Add("Id Pedido", "ID Pedido");
            DGV.Columns.Add("FechaModificacion", "FechaModificacion");
            DGV.Columns.Add("Operacion", "Operacion");

            Dictionary<int, DetallePedidoHistoricoBE> ultimosDetalles = new Dictionary<int, DetallePedidoHistoricoBE>();

            foreach (var detalle in detallesHistoricos)
            {
                ProductoBE producto = _con.Producto.FirstOrDefault(p => p.Id == detalle.ProductoId);
                PedidoBE pedido = _con.Pedido.FirstOrDefault(p => p.Id == detalle.PedidoId);

                int rowIndex = DGV.Rows.Add();
                DGV.Rows[rowIndex].Cells[0].Value = detalle.DetallePedidoId;
                DGV.Rows[rowIndex].Cells[1].Value = detalle.CantidadPedida;
                DGV.Rows[rowIndex].Cells[2].Value = producto?.PrecioUnitario;
                DGV.Rows[rowIndex].Cells[3].Value = detalle.NombreProducto;
                DGV.Rows[rowIndex].Cells[4].Value = pedido.Id;
                DGV.Rows[rowIndex].Cells[5].Value = detalle.FechaModificacion;
                //DGV.Rows[rowIndex].Cells[6].Value = detalle.Operacion;

                if (detalle.Operacion == "Crear")
                {
                    DGV.Rows[rowIndex].Cells[6].Value = detalle.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (detalle.Operacion == "Modificar")
                {
                    DGV.Rows[rowIndex].Cells[6].Value = detalle.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Orange;
                }
                else if (detalle.Operacion == "Eliminar")
                {
                    DGV.Rows[rowIndex].Cells[6].Value = detalle.Operacion;

                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
                if (detalle.FechaModificacion == detallesHistoricos.Where(d => d.DetallePedidoId == detalle.DetallePedidoId).Max(d => d.FechaModificacion) && (detalle.Operacion == "Crear" || detalle.Operacion == "Modificar"))
                {
                    DGV.Rows[rowIndex].Cells[6].Value = detalle.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Green;
                    
                }
                if (!ultimosDetalles.ContainsKey((int)detalle.DetallePedidoId))
                {
                    ultimosDetalles.Add((int)detalle.DetallePedidoId, detalle);
                }
            }
        }

        #endregion

        #region cambios de Pedido
        private List<PedidoHistoricoBE> obtenerPedidosHistDePedido(int idPedido)
        {
            List<PedidoHistoricoBE> pedidosHistoricos = _con.PedidoHistorico.Where(p => p.PedidoId == idPedido).ToList();
            return pedidosHistoricos;
        }


        private List<DetallePedidoHistoricoBE> obtenerDetallesHistDePedido(int idPedido)
        {
            PedidoBE pedido = _con.Pedido.FirstOrDefault(p => p.Id == idPedido);

            List<DetallePedidoHistoricoBE> detallesHistoricos = _con.DetallePedidoHistorico.Where(p => p.PedidoId == idPedido).ToList();
            return detallesHistoricos;
        }

        public void MostrarPedidosHistDePedido(int idPedido, DataGridView DGV)
        {
            List<PedidoHistoricoBE> pedidosHistoricos = obtenerPedidosHistDePedido(idPedido);

            DGV.Rows.Clear();
            DGV.Columns.Clear();

            DGV.Columns.Add("Id Pedido", "ID Pedido");
            //DGV.Columns.Add("NroPedido", "NroPedido");
            DGV.Columns.Add("Estado", "Estado");
            DGV.Columns.Add("FechaCreacion", "FechaCreacion");
            //DGV.Columns.Add("Subtotal", "Subtotal");
            //DGV.Columns.Add("Impuestos", "Impuestos");
            DGV.Columns.Add("Total", "Total");
            //DGV.Columns.Add("ReservaId", "ReservaId");
            DGV.Columns.Add("FacturaId", "FacturaId");
            DGV.Columns.Add("FechaModificacion", "FechaModificacion");
            DGV.Columns.Add("Operacion", "Operacion");

            Dictionary<int, PedidoHistoricoBE> ultimosPedidos = new Dictionary<int, PedidoHistoricoBE>();

            foreach (var pedido in pedidosHistoricos)
            {
                int rowIndex = DGV.Rows.Add();
                DGV.Rows[rowIndex].Cells[0].Value = pedido.PedidoId;
               // DGV.Rows[rowIndex].Cells[1].Value = pedido.NroPedido;
                DGV.Rows[rowIndex].Cells[1].Value = pedido.Estado;
                DGV.Rows[rowIndex].Cells[2].Value = pedido.FechaCreacion;
                //DGV.Rows[rowIndex].Cells[4].Value = pedido.Subtotal;
                //DGV.Rows[rowIndex].Cells[5].Value = pedido.Impuestos;
                DGV.Rows[rowIndex].Cells[3].Value = pedido.Total;
                //DGV.Rows[rowIndex].Cells[7].Value = pedido.ReservaId;
                DGV.Rows[rowIndex].Cells[4].Value = pedido.FacturaId;
                DGV.Rows[rowIndex].Cells[5].Value = pedido.FechaModificacion;
                //DGV.Rows[rowIndex].Cells[10].Value = pedido.Operacion;


                if (pedido.Operacion == "Crear")
                {
                    //DGV.Rows[rowIndex].Cells[6].Style.BackColor = Color.Yellow; // Crear en amarillo
                    DGV.Rows[rowIndex].Cells[6].Value = pedido.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (pedido.Operacion == "Modificar")
                {
                    //DGV.Rows[rowIndex].Cells[6].Style.BackColor = Color.Orange; // Modificar en naranja
                    DGV.Rows[rowIndex].Cells[6].Value = pedido.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Orange;
                }
                else if (pedido.Operacion == "Eliminar")
                {
                    //DGV.Rows[rowIndex].Cells[6].Style.BackColor = Color.Red; // Eliminar en rojo
                    DGV.Rows[rowIndex].Cells[6].Value = pedido.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
                if (pedido.FechaModificacion == pedidosHistoricos.Where(d => d.PedidoId == pedido.PedidoId).Max(d => d.FechaModificacion) && (pedido.Operacion == "Crear" || pedido.Operacion == "Modificar"))
                {
                    //DGV.Rows[rowIndex].Cells[6].Style.BackColor = Color.Green; // Ultimo detalle creado es verde
                    DGV.Rows[rowIndex].Cells[6].Value = pedido.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Green;
                }
                if (!ultimosPedidos.ContainsKey((int)pedido.PedidoId))
                {
                    ultimosPedidos.Add((int)pedido.PedidoId, pedido);
                }
            }
        }


        public void MostrarDetallesHistDePedido(int idPedido, DataGridView DGV)
        {
            List<DetallePedidoHistoricoBE> detallesHistoricos = obtenerDetallesHistDePedido(idPedido);

            DGV.Rows.Clear();
            DGV.Columns.Clear();

            DGV.Columns.Add("Id Detalle", "ID Detalle");
            DGV.Columns.Add("Cantidad", "Cantidad");
            DGV.Columns.Add("Precio", "Precio");
            DGV.Columns.Add("Nombre Producto", "Nombre Producto");
            DGV.Columns.Add("Id Pedido", "ID Pedido");
            DGV.Columns.Add("FechaModificacion", "FechaModificacion");
            DGV.Columns.Add("Operacion", "Operacion");

            Dictionary<int, DetallePedidoHistoricoBE> ultimosDetalles = new Dictionary<int, DetallePedidoHistoricoBE>();

            foreach (var detalleHis in detallesHistoricos)
            {
                ProductoBE producto = _con.Producto.FirstOrDefault(p => p.Id == detalleHis.ProductoId);
                PedidoBE pedido = _con.Pedido.FirstOrDefault(p => p.Id == detalleHis.PedidoId);

                int rowIndex = DGV.Rows.Add();
                DGV.Rows[rowIndex].Cells[0].Value = detalleHis.DetallePedidoId;
                DGV.Rows[rowIndex].Cells[1].Value = detalleHis.CantidadPedida;
                DGV.Rows[rowIndex].Cells[2].Value = producto?.PrecioUnitario;
                DGV.Rows[rowIndex].Cells[3].Value = detalleHis.NombreProducto;
                DGV.Rows[rowIndex].Cells[4].Value = pedido.Id;
                DGV.Rows[rowIndex].Cells[5].Value = detalleHis.FechaModificacion;
                if (detalleHis.Operacion == "Crear")
                {
                    //DGV.Rows[rowIndex].Cells[6].Style.BackColor = Color.Yellow; // Crear en amarillo
                    DGV.Rows[rowIndex].Cells[6].Value = detalleHis.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (detalleHis.Operacion == "Modificar")
                {
                    //DGV.Rows[rowIndex].Cells[6].Style.BackColor = Color.Orange; // Modificar en naranja
                    DGV.Rows[rowIndex].Cells[6].Value = detalleHis.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Orange;
                }
                else if (detalleHis.Operacion == "Eliminar")
                {
                    //DGV.Rows[rowIndex].Cells[6].Style.BackColor = Color.Red; // Eliminar en rojo
                    DGV.Rows[rowIndex].Cells[6].Value = detalleHis.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
                if (detalleHis.FechaModificacion == detallesHistoricos.Where(d => d.DetallePedidoId == detalleHis.DetallePedidoId).Max(d => d.FechaModificacion) && (detalleHis.Operacion == "Crear" || detalleHis.Operacion == "Modificar"))
                {
                    //DGV.Rows[rowIndex].Cells[6].Style.BackColor = Color.Green; // Ultimo detalle creado es verde
                    DGV.Rows[rowIndex].Cells[6].Value = detalleHis.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Green;
                }

                if (!ultimosDetalles.ContainsKey((int)detalleHis.DetallePedidoId))
                {
                    ultimosDetalles.Add((int)detalleHis.DetallePedidoId, detalleHis);
                }
                
            }
        }




        #endregion

        #region cambios de DetallePedido

        private List<DetallePedidoHistoricoBE> obtenerDetallesHistDeDetalle(int idDetalle)
        {
            List<DetallePedidoHistoricoBE> detallesHistoricos = _con.DetallePedidoHistorico.Where(p => p.DetallePedidoId == idDetalle).ToList();
            return detallesHistoricos;
        }

        public void MostrarDetallesHistDeDetalle(int idDetalle, DataGridView DGV)
        {
            List<DetallePedidoHistoricoBE> detallesHistoricos = obtenerDetallesHistDeDetalle(idDetalle);

            DGV.Rows.Clear();
            DGV.Columns.Clear();

            DGV.Columns.Add("Id Detalle", "ID Detalle");
            DGV.Columns.Add("Cantidad", "Cantidad");
            DGV.Columns.Add("Precio", "Precio");
            DGV.Columns.Add("Nombre Producto", "Nombre Producto");
            DGV.Columns.Add("Id Pedido", "ID Pedido");
            DGV.Columns.Add("FechaModificacion", "FechaModificacion");
            DGV.Columns.Add("Operacion", "Operacion");

            Dictionary<int, DetallePedidoHistoricoBE> ultimosDetalles = new Dictionary<int, DetallePedidoHistoricoBE>();

            foreach (var detalle in detallesHistoricos)
            {
                ProductoBE producto = _con.Producto.FirstOrDefault(p => p.Id == detalle.ProductoId);
                PedidoBE pedido = _con.Pedido.FirstOrDefault(p => p.Id == detalle.PedidoId);

                int rowIndex = DGV.Rows.Add();
                DGV.Rows[rowIndex].Cells[0].Value = detalle.DetallePedidoId;
                DGV.Rows[rowIndex].Cells[1].Value = detalle.CantidadPedida;
                DGV.Rows[rowIndex].Cells[2].Value = producto?.PrecioUnitario;
                DGV.Rows[rowIndex].Cells[3].Value = detalle.NombreProducto;
                DGV.Rows[rowIndex].Cells[4].Value = pedido.Id;
                DGV.Rows[rowIndex].Cells[5].Value = detalle.FechaModificacion;
                //DGV.Rows[rowIndex].Cells[6].Value = detalle.Operacion;

                if (detalle.Operacion == "Crear")
                {
                    //DGV.Rows[rowIndex].Cells[6].Style.BackColor = Color.Yellow; // Crear en amarillo
                    DGV.Rows[rowIndex].Cells[6].Value = detalle.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (detalle.Operacion == "Modificar")
                {
                    //DGV.Rows[rowIndex].Cells[6].Style.BackColor = Color.Orange; // Modificar en naranja
                    DGV.Rows[rowIndex].Cells[6].Value = detalle.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Orange;
                }
                else if (detalle.Operacion == "Eliminar")
                {
                    //DGV.Rows[rowIndex].Cells[6].Style.BackColor = Color.Red; // Eliminar en rojo
                    DGV.Rows[rowIndex].Cells[6].Value = detalle.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
                if (detalle.FechaModificacion == detallesHistoricos.Where(d => d.DetallePedidoId == detalle.DetallePedidoId).Max(d => d.FechaModificacion) && (detalle.Operacion == "Crear" || detalle.Operacion == "Modificar"))
                {
                    //DGV.Rows[rowIndex].Cells[6].Style.BackColor = Color.Green; // Ultimo detalle creado es verde
                    DGV.Rows[rowIndex].Cells[6].Value = detalle.Operacion;
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Green;
                }
                if (!ultimosDetalles.ContainsKey((int)detalle.DetallePedidoId))
                {
                    ultimosDetalles.Add((int)detalle.DetallePedidoId, detalle);
                }

            }
        }


        #endregion




        /// 
        ///
        #endregion




        





        //Exportar Grilla
        public void ExportarDataGridView(DataGridView dataGridView, string nombreArchivo)
        {
            try
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Datos");

                // Encabezados
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dataGridView.Columns[i].HeaderText;
                }

                // Datos
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }

                string ubicacionProyecto = "SGH - UAI - Final/ArchivosHotel";
                string carpetaExcels = "Excels";
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string excelDirectory = Path.Combine(desktopPath, ubicacionProyecto, carpetaExcels);
                Directory.CreateDirectory(excelDirectory);
                string excelFileName = $"{nombreArchivo}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                string excelFilePath = Path.Combine(excelDirectory, excelFileName);

                // Guardar el archivo Excel en disco
                workbook.SaveAs(excelFilePath);

                MessageBox.Show($"Archivo Excel guardado en {excelFilePath}", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch
            {
                MessageBox.Show("Error al exportar a Excel", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        





        #region Listar en DataGridView (Facturas/Pedidos/Detalles)
        //
        //

        //Listar facturas en DataGridView
        public void ListarFacturasEnDGV(DataGridView dataGridView)
        {
            // Limpiamos las filas y columnas existentes en el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            // Obtenemos las facturas de la base de datos
            var facturas = _con.Factura.ToList();

      
            // Agregamos las columnas una vez fuera del bucle

            dataGridView.Columns.Add("Id Factura", "ID Factura");
            dataGridView.Columns.Add("Fecha Emision", "Fecha Emision ");
            dataGridView.Columns.Add("Total", "Total");
            //dataGridView.Columns.Add("Estado", "Estado");
            dataGridView.Columns.Add("DNI", "DNI");
            //dataGridView.Columns.Add("Cliente", "Cliente");
            dataGridView.Columns.Add("NroHabitacion", "NroHabitacion");
            //dataGridView.Columns.Add("Empleado", "Empleado");


            // Agregamos las facturas al DataGridView
            foreach (var factura in facturas)
            {
                PedidoBE pedido = _con.Pedido
                    .Include(p => p.Reserva)
                    .Include(p => p.Reserva.Cliente)
                    .Include(p => p.Reserva.Cliente.Persona)
                    .Include(p => p.Reserva.Habitacion)
                    .FirstOrDefault(p => p.Factura.Id == factura.Id);

                if (pedido != null)
                {
                    PersonaBE personaCliente = _con.Persona.FirstOrDefault(p => p.Id == pedido.Reserva.Cliente.Persona.Id);
                    HabitacionBE habitacion = _con.Habitacion.FirstOrDefault(h => h.Id == pedido.Reserva.Habitacion.Id);

                    int rowIndex = dataGridView.Rows.Add();
                    dataGridView.Rows[rowIndex].Cells[0].Value = factura.Id;
                    dataGridView.Rows[rowIndex].Cells[1].Value = factura.FechaEmision;
                    dataGridView.Rows[rowIndex].Cells[2].Value = factura.Total;
                    dataGridView.Rows[rowIndex].Cells[3].Value = personaCliente?.DNI; 
                    dataGridView.Rows[rowIndex].Cells[4].Value = habitacion?.NroHabitacion; 
                }
            }

        }


        //Listar pedidos en DataGridView
        public void ListarPedidosEnDGV(DataGridView dataGridView)
        {
            // Limpiamos las filas y columnas existentes en el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            // Obtenemos los pedidos de la base de datos
            var pedidos = _con.Pedido.ToList();

            // Agregamos las columnas una vez fuera del bucle

            dataGridView.Columns.Add("Id Pedido", "ID Pedido");
            dataGridView.Columns.Add("Fecha", "Fecha");
            dataGridView.Columns.Add("Estado", "Estado");
            dataGridView.Columns.Add("NroReserva", "NroReserva");
            dataGridView.Columns.Add("Cliente", "Cliente");
            dataGridView.Columns.Add("NroHabitacion", "NroHabitacion");
            //dataGridView.Columns.Add("Empleado", "Empleado");

            foreach(var pedido in pedidos)
            {
                ReservaBE reserva = _con.Reserva
                    .Include(r => r.Cliente)
                    .Include(r => r.Cliente.Persona)
                    .Include(r => r.Habitacion)
                    .FirstOrDefault(r => r.Id == pedido.Reserva.Id);

                if (reserva != null)
                {
                    PersonaBE personaCliente = _con.Persona.FirstOrDefault(p => p.Id == reserva.Cliente.Persona.Id);
                    HabitacionBE habitacion = _con.Habitacion.FirstOrDefault(h => h.Id == reserva.Habitacion.Id);

                    int rowIndex = dataGridView.Rows.Add();
                    dataGridView.Rows[rowIndex].Cells[0].Value = pedido.Id; // -->  ver con q remplezar
                    dataGridView.Rows[rowIndex].Cells[1].Value = pedido.FechaCreacion;
                    dataGridView.Rows[rowIndex].Cells[2].Value = pedido.Estado;
                    dataGridView.Rows[rowIndex].Cells[3].Value = reserva.Id; //-->Eliminar o  ver con q remplezar
                    dataGridView.Rows[rowIndex].Cells[4].Value = personaCliente?.DNI;
                    dataGridView.Rows[rowIndex].Cells[5].Value = habitacion?.NroHabitacion; 
                }

            }


        }

        //Listar Detalles de Pedido en DataGridView

        public void ListarDetallesEnDGV(DataGridView dataGridView)
        {
            // Limpiamos las filas y columnas existentes en el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            // Obtenemos los detalles de pedido de la base de datos
            var detallesPedido = _con.DetallePedido.ToList();

            // Agregamos las columnas una vez fuera del bucle

            dataGridView.Columns.Add("Id Detalle", "ID Detalle");
            dataGridView.Columns.Add("Cantidad", "Cantidad");
            dataGridView.Columns.Add("Precio", "Precio");
            dataGridView.Columns.Add("Nombre Producto", "Nombre Producto");
            dataGridView.Columns.Add("Id Pedido", "ID Pedido");

            foreach (var detalle in detallesPedido)
            {
                int rowIndex = dataGridView.Rows.Add();
                dataGridView.Rows[rowIndex].Cells[0].Value = detalle.Id;
                dataGridView.Rows[rowIndex].Cells[3].Value = detalle?.NombreProducto;
                dataGridView.Rows[rowIndex].Cells[1].Value = detalle.CantidadPedida;
                dataGridView.Rows[rowIndex].Cells[2].Value = detalle?.Producto?.PrecioUnitario;
                dataGridView.Rows[rowIndex].Cells[4].Value = detalle.Pedido.Id;
            }
        }



        //
        //
        #endregion

    }

}

