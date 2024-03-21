using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Core.Mapping;
using System.IO;
using System.Data.Entity;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Modelo
{
    public class PedidoDAL
    {
        //ContextoBD con = new ContextoBD();

        //private ContextoBD dbContext;
        //dbContext = ContextoBD.Instancia();

        ContextoBD con = new ContextoBD();

       
        
        //AgregarProductoAPedido --------------------------> BORRAR
        /* public void AgregarProductoAPedido(int idReserva, int idProducto, int cantidad)
        {
            try
            {
                // Buscamos la reserva por su ID
                ReservaBE reserva = con.Reserva.FirstOrDefault(r => r.Id == idReserva);

                if (reserva != null)
                {
                    // Buscamos el producto por su ID
                    ProductoBE producto = con.Producto.FirstOrDefault(p => p.Id == idProducto);

                    if (producto != null)
                    {
                        // Creamos un nuevo pedido
                        PedidoBE pedido = new PedidoBE
                        {
                            Reserva = reserva,
                            Producto = producto,
                            Cantidad = cantidad,
                            Fecha = DateTime.Now
                        };

                        // Agregamos el pedido a la base de datos
                        con.Pedido.Add(pedido);
                        con.SaveChanges();
                    }
                    else
                    {
                        // Si no se encuentra el producto, puedes manejar el caso según tus requerimientos
                        Console.WriteLine("No se encontró el producto con el ID especificado.");
                    }
                }
                else
                {
                    // Si no se encuentra la reserva, puedes manejar el caso según tus requerimientos
                    Console.WriteLine("No se encontró la reserva con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el producto al pedido: " + ex.Message);
            }
        }*/


        #region Eliminar / Modificar Pedidos
        //EL modificar pedido se basa en cambiar el estado del pedido para pagarlo en el momento 
        //Ej: El cliente lo desea parar ahora pero no puede entonces lo paga en elc checkout
        //Eliminar el Pedido es si el cliente se arrepiente de su compra y desea cancelarla


        public void ModificarEstadoPedido(int nroPedido, string opcionPago)   //---> Modifica rel estado del Estado
        {
            try
            {
                // Buscamos el pedido por su ID
                PedidoBE pedido = con.Pedido.FirstOrDefault(p => p.NroPedido == nroPedido);

                if (pedido != null)
                {
                    if(opcionPago == "A Pagar")
                    {
                        pedido.Estado = "PagoPendiente";
                        con.SaveChanges();


                    }
                    if (opcionPago == "Pago en el momento")
                    {
                        //Usar los ultimos metodos para realizar el checkout (crear factur y enviarla)




                        pedido.Estado = "Pagado";
                        con.SaveChanges();

                    }
                    
                }
                else
                {
                    // Si no se encuentra el pedido, puedes manejar el caso según tus requerimientos
                    Console.WriteLine("No se encontró el pedido con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar el pedido: " + ex.Message);
            }




        }




        public void EliminarPedido(int nroPedido)
        {
            using(var transaction = con.Database.BeginTransaction())
            {
                try
                {
                    // Buscamos el pedido por su ID
                    PedidoBE pedido = con.Pedido.FirstOrDefault(p => p.NroPedido == nroPedido);

                    FacturaBE factura = new FacturaBE();
                    if (pedido != null)
                    {
                        factura = pedido.Factura;

                    }

                    if (pedido.Estado == "Pagado" || factura != null)
                    {
                        MessageBox.Show("No se puede eliminar un pedido que ya ha sido pagado ya que tiene una factura asociada");
                    }
                    else
                    {
                        List<DetallePedidoBE> listaDetalles = ObtenerDetallesPedidoDePedido(nroPedido);

                        if (pedido != null)
                        {
                            foreach (var detallePedido in listaDetalles)
                            {
                                ProductoBE producto = con.Producto.FirstOrDefault(p => p.Id == detallePedido.Producto.Id);
                                producto.CantidadStock += detallePedido.CantidadPedida;
                                con.DetallePedido.Remove(detallePedido);
                                
                            }

                            
                            con.SaveChanges();
                            // Eliminamos el pedido de la base de datos
                            con.Pedido.Remove(pedido);
                            con.SaveChanges();
                            

                            transaction.Commit();

                            MessageBox.Show("Pedido eliminado con éxito.");
                        }
                        else
                        {
                            // Si no se encuentra el pedido, puedes manejar el caso según tus requerimientos
                            MessageBox.Show("No se encontró el pedido con el ID especificado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al eliminar el pedido: " + ex.Message);
                }

            }
            
        }

        #endregion

        #region Eliminar y Modificar DetallesPedido

        public void EliminarDetallePedido(int idDetalle, string  NombreProd)
        {
            try
            {
                // Buscamos el detalle de pedido por su ID
                DetallePedidoBE detallePedido = con.DetallePedido.FirstOrDefault(d => d.Id == idDetalle && d.NombreProducto == NombreProd);

                if (detallePedido != null)
                {
                    

                    //Buscar la cantidad y sumarla a la cantidad del stock del producto
                    ProductoBE producto = con.Producto.FirstOrDefault(p => p.Id == detallePedido.Producto.Id);
                    producto.CantidadStock += detallePedido.CantidadPedida;

                    int nroPedido = detallePedido.Pedido.NroPedido;
                    con.DetallePedido.Remove(detallePedido);
                    con.SaveChanges();

                    //Actualizo el total del pedido
                    PedidoBE pedido = con.Pedido.FirstOrDefault(p => p.NroPedido == nroPedido);
                    List<DetallePedidoBE> listaDetalles = ObtenerDetallesPedidoDePedido(nroPedido);
                    pedido.Total = listaDetalles.Sum(d => d.Total);

                    if (pedido.Total == 0 || listaDetalles.Count == 0)
                    {
                        EliminarPedido(pedido.NroPedido);
                        
                    }

                    // Eliminamos el detalle de pedido de la base de datos
                    //con.DetallePedido.Remove(detallePedido);
                    con.SaveChanges();

                    MessageBox.Show("Detalle de pedido eliminado con éxito.");
                }
                else
                {
                    // Si no se encuentra el detalle de pedido, puedes manejar el caso según tus requerimientos
                    Console.WriteLine("No se encontró el detalle de pedido con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el detalle de pedido: " + ex.Message);
            }
        }

        public void ModificarDetallePedido(int idDetalle, int cantidad, string NombreProd)
        {
            try
            {
                // Buscamos el detalle de pedido por su ID
                DetallePedidoBE detallePedido = con.DetallePedido.FirstOrDefault(d => d.Id == idDetalle && d.NombreProducto == NombreProd);

                if (detallePedido != null)
                {
                    int diferenciaDeCant = detallePedido.CantidadPedida - cantidad;
                    detallePedido.Producto.CantidadStock += diferenciaDeCant;
                    // Modificamos la cantidad del detalle de pedido
                    detallePedido.CantidadPedida = cantidad;
                    detallePedido.Subtotal = cantidad * detallePedido.Producto.PrecioUnitario;
                    //detallePedido.Impuestos = (decimal)(cantidad * detallePedido.Producto.PrecioUnitario * 0.21);
                    detallePedido.Impuestos = (decimal)(   (double)detallePedido.Subtotal   * 0.21);
                    //detallePedido.Total = (decimal)(cantidad * detallePedido.Producto.PrecioUnitario * 1.21);
                    detallePedido.Total = (decimal)(detallePedido.Subtotal  +  detallePedido.Impuestos);

                    //Actualizo el total del pedido
                    PedidoBE pedido = con.Pedido.FirstOrDefault(p => p.NroPedido == detallePedido.Pedido.NroPedido);
                    List<DetallePedidoBE> listaDetalles = ObtenerDetallesPedidoDePedido(detallePedido.Pedido.NroPedido);
                    pedido.Total = listaDetalles.Sum(d => d.Total);

                    // Guardamos los cambios en la base de datos
                    con.SaveChanges();

                    MessageBox.Show("Detalle de pedido modificado con éxito.");
                }
                else
                {
                    // Si no se encuentra el detalle de pedido, puedes manejar el caso según tus requerimientos
                    Console.WriteLine("No se encontró el detalle de pedido con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar el detalle de pedido: " + ex.Message);
            }
        }



        #endregion









        public void ObtenerDatosClienteYHabitacion(int nroReservaDGV, out ClienteBE cliente, out HabitacionBE habitacion)
        {
            // Inicializamos las variables de cliente y habitación
            cliente = null;
            habitacion = null;

            try
            {
                // Buscamos la reserva por su ID
                ReservaBE reserva = con.Reserva.FirstOrDefault(r => r.NroReserva == nroReservaDGV);

                if (reserva != null)
                {
                    // Obtenemos los datos del cliente asociado a la reserva
                    cliente = reserva.Cliente;

                    // Obtenemos los datos de la habitación asociada a la reserva
                    habitacion = reserva.Habitacion;
                }
                else
                {
                    // Si no se encuentra la reserva, puedes manejar el caso según tus requerimientos
                    Console.WriteLine("No se encontró la reserva con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los datos del cliente y la habitación: " + ex.Message);
            }
        }


        #region frmPedidos Aregar detalle,finalizar / cancelar pedido
        public void ListarProductosEnDGV(DataGridView dataGridView)
        {
            // Limpiamos las filas existentes en el DataGridView
            dataGridView.Rows.Clear();

            dataGridView.Columns.Clear();
            // Obtener la lista de las Habitaciones
            //List<ReservaBE> listaReservas = ListarReservas();

            // Iteramos sobre la lista de clientes activos y agregamos cada cliente al DataGridView


            dataGridView.Columns.Add("Id Producto", "Id Producto");
            dataGridView.Columns.Add("Producto", "Producto");
            dataGridView.Columns.Add("Cantidad en Stock", "Cantidad en Stock");
            dataGridView.Columns.Add("Precio", "Precio");



            List<ProductoBE> listaProductos = con.Producto.ToList().Where(c => c.CantidadStock != 0).ToList();

            foreach (var producto in listaProductos)
            {
                // Agregamos una fila al DataGridView
                int rowIndex = dataGridView.Rows.Add();

                dataGridView.Rows[rowIndex].Cells[0].Value = producto.Id; // Suponiendo que "Nombre" es la segunda columna agregada
                dataGridView.Rows[rowIndex].Cells[1].Value = producto.NombreProducto;
                dataGridView.Rows[rowIndex].Cells[2].Value = producto.CantidadStock;
                dataGridView.Rows[rowIndex].Cells[3].Value = producto.PrecioUnitario;

            }
        }

        public void ActualizarStockEnDataGridView(DataGridView dataGridView, int idProducto, int cantidadPedida)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == idProducto)
                {
                    int cantidadStockActual = Convert.ToInt32(row.Cells[2].Value);
                    row.Cells[2].Value = cantidadStockActual - cantidadPedida;
                    break; // Salir del bucle una vez actualizada la cantidad de stock
                }
            }
        }

        ///---------------------------------/////BORRARRRR 
        /*
         public void ActualizarStockCancelarEnDataGridView(DataGridView dataGridView, int idProducto, int cantidadPedida)
         {
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == idProducto)
                        {
                            int cantidadStockActual = Convert.ToInt32(row.Cells[2].Value);
                            row.Cells[2].Value = cantidadStockActual + cantidadPedida;
                            break; // Salir del bucle una vez actualizada la cantidad de stock
                        }
                    }
         }*/


        public List<DetallePedidoBE> AgregarPedido(List<DetallePedidoBE> listaDetallesPedidos, DataGridView dgvProductos, int idProducto, string NomProduct, int CantPedido)
        {
            try
            {
                // Copia de seguridad de la cantidad de stock original
                int cantidadStockOriginal = con.Producto.FirstOrDefault(p => p.Id == idProducto).CantidadStock;

                DetallePedidoBE detallePedido = new DetallePedidoBE
                {
                    Producto = con.Producto.FirstOrDefault(p => p.Id == idProducto),
                    NombreProducto = NomProduct,
                    CantidadPedida = CantPedido,
                    Subtotal = CantPedido * con.Producto.FirstOrDefault(p => p.Id == idProducto).PrecioUnitario,
                    Impuestos = (decimal)(CantPedido * con.Producto.FirstOrDefault(p => p.Id == idProducto).PrecioUnitario * 0.21),
                    Total = (decimal)(CantPedido * con.Producto.FirstOrDefault(p => p.Id == idProducto).PrecioUnitario * 1.21)
                };

                // Actualizar el stock del producto
                ProductoBE producto = con.Producto.FirstOrDefault(p => p.Id == idProducto);
                producto.CantidadStock -= CantPedido;

                // Agregar el detalle a la lista
                listaDetallesPedidos.Add(detallePedido);
                Console.WriteLine("Producto agregado al pedido: " + detallePedido.NombreProducto);

                // Actualizar el DataGridView
                ActualizarStockEnDataGridView(dgvProductos, idProducto, CantPedido);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar pedido: " + ex.Message);
            }

            return listaDetallesPedidos;
        }


        public List<DetallePedidoBE> CancelarPedido(List<DetallePedidoBE> listaDetallesPedidos, DataGridView dgvProductos, DataGridView dgvDetalles)
        {
            try
            {
                // Restaurar el stock de los productos en el DataGridView de productos
                foreach (var detallePedido in listaDetallesPedidos)
                {
                    // Recuperar la cantidad original del producto antes de que se agregara al pedido
                    //int cantidadOriginal = detallePedido.CantidadPedida;


                    detallePedido.Producto = con.Producto.FirstOrDefault(p => p.Id == detallePedido.Producto.Id);
                    detallePedido.Producto.CantidadStock += detallePedido.CantidadPedida;

                    // Restaurar el stock del producto en el DataGridView
                    //ActualizarStockCancelarEnDataGridView(dgvProductos, detallePedido.Producto.Id, cantidadOriginal);
                }
                con.SaveChanges();
                ListarProductosEnDGV(dgvProductos);

                // Limpiar la lista de detalles
                listaDetallesPedidos.Clear();

                // Limpiar el DataGridView de detalles
                dgvDetalles.Rows.Clear();
                dgvDetalles.Columns.Clear();


                return listaDetallesPedidos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar el pedido: " + ex.Message);
            }

            return listaDetallesPedidos;
        }



        /*public void FinalizarPedido(List<DetallePedidoBE> listaDetallesPedidos, int nroReserva)   //, DataGridView dgvProductos, int idProducto, string NomProduct, int Cantidad)
        {
            using (var transaction = con.Database.BeginTransaction())
            {
                try
                {
                    //List<DetallePedidoBE> listaDetallesPedidos = AgregarPedido(dgvProductos,  idProducto,  NomProduct,  Cantidad);
                    ClienteBE cliente = new ClienteBE();
                    // Se crea el pedido
                    PedidoBE pedido = new PedidoBE
                    {
                        NroPedido = con.Pedido.Count() + 1,
                        Reserva = con.Reserva.FirstOrDefault(r => r.NroReserva == nroReserva),
                        Estado = "PagoPendiente",
                        FechaCreacion = DateTime.Now,
                        Total = listaDetallesPedidos.Sum(d => d.Total)
                    };

                    // Se agrega el pedido a la base de datos
                    con.Pedido.Add(pedido);

                    // Se agregan los detalles de pedido al pedido
                    foreach (var detallePedido in listaDetallesPedidos)
                    {
                        detallePedido.Pedido = pedido; // Asignar el pedido a cada detalle

                       
                        //ProductoBE producto = con.Producto.FirstOrDefault(p => p.Id == detallePedido.Producto.Id);
                        ///if (producto != null) // Verifica si el producto existe
                        //{
                        //    producto.CantidadStock -= detallePedido.CantidadPedida;
                        //}


                        //AGREGADO
                        //detallePedido.Producto = con.Producto.FirstOrDefault(p => p.Id == detallePedido.Producto.Id);
                        //detallePedido.Producto.CantidadStock -= detallePedido.CantidadPedida;
                    }

                    // Se agregan los detalles de pedido a la base de datos
                    con.DetallePedido.AddRange(listaDetallesPedidos);
                    
                    
                    // Se actualiza el stock de los productos
                    //foreach (var detallePedido in listaDetallesPedidos)
                    //{
                    //    ProductoBE producto = con.Producto.FirstOrDefault(p => p.Id == detallePedido.Producto.Id);
                    //    if (producto != null) // Verifica si el producto existe
                    //    {
                    //        producto.CantidadStock -= detallePedido.CantidadPedida;
                    //    }
                    //}


                    // Guardar todos los cambios en la base de datos
                    con.SaveChanges();

                    // Commit de la transacción si todo ha sido exitoso
                    transaction.Commit();

                    Console.WriteLine("Pedido Realizado ");
                }
                catch (Exception ex)
                {
                    // Rollback de la transacción en caso de error
                    transaction.Rollback();
                    Console.WriteLine("Error al finalizar el pedido: " + ex.Message);
                    // Manejar el error adecuadamente, posiblemente mostrar un mensaje al usuario
                }
            }
        }*/
        
        public void CargarDetallesEnDataGridView(List<DetallePedidoBE> listaDetalles, DataGridView dataGridView)
        {
            // Limpiar las filas existentes en el DataGridView
            dataGridView.Rows.Clear();

            // Agregar las columnas al DataGridView si no están agregadas previamente
            if (dataGridView.Columns.Count == 0)
            {
                dataGridView.Columns.Add("Id Producto", "Id Producto");
                dataGridView.Columns.Add("Producto", "Producto");
                dataGridView.Columns.Add("Cantidad Pedida", "Cantidad Pedida");
            }

            // Iterar sobre la lista de detalles y agregar cada detalle como una fila en el DataGridView
            foreach (var detalle in listaDetalles)
            {
                int rowIndex = dataGridView.Rows.Add();
                dataGridView.Rows[rowIndex].Cells[0].Value = detalle.Producto.Id;
                dataGridView.Rows[rowIndex].Cells[1].Value = detalle.NombreProducto;
                dataGridView.Rows[rowIndex].Cells[2].Value = detalle.CantidadPedida;
            }
        }

        #endregion







        #region Metodos para frmModificarPedido

        //Listar Pedidos en DataGridView
        public void ListarPedidosEnDataGridView(DataGridView dataGridView)
        {
            // Limpiamos las filas existentes en el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // Obtener la lista de las Habitaciones
            List<PedidoBE> listaPedidos = con.Pedido.Include(p => p.Reserva).Include(p => p.Reserva.Habitacion).ToList();

            // Iteramos sobre la lista de clientes activos y agregamos cada cliente al DataGridView
            dataGridView.Columns.Add("NroPedido", "NroPedido");
            dataGridView.Columns.Add("NroReserva", "NroReserva");
            dataGridView.Columns.Add("NroHabitacion", "NroHabitacion");
            dataGridView.Columns.Add("Estado", "Estado");
            dataGridView.Columns.Add("FechaCreacion", "FechaCreacion");
            dataGridView.Columns.Add("Total", "Total");

            foreach (var pedido in listaPedidos)
            {

                ReservaBE reserva = con.Reserva.FirstOrDefault(r => r.Id == pedido.Reserva.Id);

                HabitacionBE habitacion = con.Habitacion.FirstOrDefault(h => h.Id == reserva.Habitacion.Id);



                // Agregamos una fila al DataGridView
                int rowIndex = dataGridView.Rows.Add();

                dataGridView.Rows[rowIndex].Cells[0].Value = pedido.NroPedido; // Suponiendo que "Nombre" es la segunda columna agregada
                dataGridView.Rows[rowIndex].Cells[1].Value = reserva.NroReserva;
                dataGridView.Rows[rowIndex].Cells[2].Value = habitacion.NroHabitacion;
                dataGridView.Rows[rowIndex].Cells[3].Value = pedido.Estado;
                dataGridView.Rows[rowIndex].Cells[4].Value = pedido.FechaCreacion;
                dataGridView.Rows[rowIndex].Cells[5].Value = pedido.Total;
            }
        }
        

        public void ListarPedidosEnDataGridView2(DataGridView dataGridView)
        {
            // Limpiamos las filas existentes en el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // Obtener la lista de las Habitaciones
            List<PedidoBE> listaPedidos = con.Pedido.Include(p => p.Reserva).Include(p => p.Reserva.Habitacion).ToList();



            // Iteramos sobre la lista de clientes activos y agregamos cada cliente al DataGridView
            dataGridView.Columns.Add("NroPedido", "NroPedido");
            dataGridView.Columns.Add("NroReserva", "NroReserva");
            dataGridView.Columns.Add("NroHabitacion", "NroHabitacion");
            dataGridView.Columns.Add("Estado", "Estado");
            dataGridView.Columns.Add("FechaCreacion", "FechaCreacion");
            dataGridView.Columns.Add("Total", "Total");

            foreach (var pedido in listaPedidos)
            {


                // Agregamos una fila al DataGridView
                int rowIndex = dataGridView.Rows.Add();



                dataGridView.Rows[rowIndex].Cells[0].Value = pedido.NroPedido;


                

                // Verificamos si la propiedad Reserva es nula antes de intentar acceder a sus propiedades
                if (pedido.Reserva != null)
                {
                    dataGridView.Rows[rowIndex].Cells[1].Value = pedido.Reserva.NroReserva;

                    // Verificamos si la propiedad Habitacion es nula antes de intentar acceder a sus propiedades
                    if (pedido.Reserva.Habitacion != null)
                    {
                        dataGridView.Rows[rowIndex].Cells[2].Value = pedido.Reserva.Habitacion.NroHabitacion;
                    }
                    else
                    {
                        dataGridView.Rows[rowIndex].Cells[2].Value = pedido.Reserva.Habitacion?.NroHabitacion;
                    }
                }
                else
                {
                    dataGridView.Rows[rowIndex].Cells[1].Value = pedido.Reserva?.NroReserva;
                }

                dataGridView.Rows[rowIndex].Cells[3].Value = pedido.Estado;
                dataGridView.Rows[rowIndex].Cells[4].Value = pedido.FechaCreacion;
                dataGridView.Rows[rowIndex].Cells[5].Value = pedido.Total;
            }
        }





        //Obtener lista de detalles de la reserva seleccionad
        public List<DetallePedidoBE> ObtenerDetallesPedido(int nroReserva)
        {
            List<DetallePedidoBE> listaDetalles = new List<DetallePedidoBE>();

            try
            {
                // Buscamos la reserva por su ID
                ReservaBE reserva = con.Reserva.FirstOrDefault(r => r.NroReserva == nroReserva);

                if (reserva != null)
                {
                    // Obtenemos los detalles de pedido asociados a la reserva
                    listaDetalles = con.DetallePedido.Where(d => d.Pedido.Reserva.NroReserva == nroReserva).ToList();
                }
                else
                {
                    // Si no se encuentra la reserva, puedes manejar el caso según tus requerimientos
                    Console.WriteLine("No se encontró la reserva con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los detalles del pedido: " + ex.Message);
            }

            return listaDetalles;
        }

        //Pone los detalles pedido de toda la reserva seleccioanda
        public void ListarDetallesEnDataGridView(int nroReserva, DataGridView dataGridView)
        {
            List<DetallePedidoBE> listaDetalles = ObtenerDetallesPedido(nroReserva);

            // Limpiar las filas existentes en el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // Agregar las columnas al DataGridView si no están agregadas previamente
            if (dataGridView.Columns.Count == 0)
            {
                dataGridView.Columns.Add("Id Producto", "Id Producto");
                dataGridView.Columns.Add("Producto", "Producto");
                dataGridView.Columns.Add("Cantidad Pedida", "Cantidad Pedida");
            }

            // Iterar sobre la lista de detalles y agregar cada detalle como una fila en el DataGridView
            foreach (var detalle in listaDetalles)
            {
                int rowIndex = dataGridView.Rows.Add();
                dataGridView.Rows[rowIndex].Cells[0].Value = detalle.Producto.Id;
                dataGridView.Rows[rowIndex].Cells[1].Value = detalle.NombreProducto;
                dataGridView.Rows[rowIndex].Cells[2].Value = detalle.CantidadPedida;
            }
        }






        //Pone los detallespedido del pedido seleccionado
        public void ListarDetallesDelPedidoDGV(int nroPedido, DataGridView dataGridView)
        {
            List<DetallePedidoBE> listaDetalles = ObtenerDetallesPedidoDePedido(nroPedido);

            // Limpiar las filas existentes en el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // Agregar las columnas al DataGridView si no están agregadas previamente
            if (dataGridView.Columns.Count == 0)
            {
                dataGridView.Columns.Add("Id Detalle", "Id Detalle");
                dataGridView.Columns.Add("Id Producto", "Id Producto");
                dataGridView.Columns.Add("Producto", "Producto");
                dataGridView.Columns.Add("Cantidad Pedida", "Cantidad Pedida");
                dataGridView.Columns.Add("Precio Unitario", "Precio Unitario");
                dataGridView.Columns.Add("Total", "Total");

            }

            // Iterar sobre la lista de detalles y agregar cada detalle como una fila en el DataGridView
            foreach (var detalle in listaDetalles)
            {
                int rowIndex = dataGridView.Rows.Add();
                dataGridView.Rows[rowIndex].Cells[0].Value = detalle.Id;
                dataGridView.Rows[rowIndex].Cells[1].Value = detalle.Producto.Id;
                dataGridView.Rows[rowIndex].Cells[2].Value = detalle.NombreProducto;
                dataGridView.Rows[rowIndex].Cells[3].Value = detalle.CantidadPedida;
                dataGridView.Rows[rowIndex].Cells[4].Value = detalle.Producto.PrecioUnitario;
                dataGridView.Rows[rowIndex].Cells[5].Value = detalle.Total;
            }
        }

        //Obtener lista de detalles de la reserva seleccionad
        public List<DetallePedidoBE> ObtenerDetallesPedidoDePedido(int nroPedido)
        {
            List<DetallePedidoBE> listaDetalles = new List<DetallePedidoBE>();

            try
            {
                // Buscamos la reserva por su ID
                PedidoBE pedido = con.Pedido.FirstOrDefault(r => r.NroPedido == nroPedido);

                if (pedido != null)
                {
                    // Obtenemos los detalles de pedido asociados a la reserva
                    listaDetalles = con.DetallePedido.Where(d => d.Pedido.NroPedido == nroPedido).ToList();
                }
                else
                {
                    // Si no se encuentra la reserva, puedes manejar el caso según tus requerimientos
                    Console.WriteLine("No se encontró el Pedido con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los detalles del pedido: " + ex.Message);
            }

            return listaDetalles;
        }








        //Buscar por NumHabitacion -> Se pone en el datagridView de Pedido la que corresponda a esa habitacion
        public void BuscarPorNumHabitacion(int NumHab, DataGridView dataGridView)
        {
            // Limpiamos las filas existentes en el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // Obtener la lista de las Habitaciones
            List<PedidoBE> listaPedidos = con.Pedido.ToList().Where(c => c.Reserva.Habitacion.NroHabitacion == NumHab).ToList();

            // Iteramos sobre la lista de clientes activos y agregamos cada cliente al DataGridView
            dataGridView.Columns.Add("NroPedido", "NroPedido");
            dataGridView.Columns.Add("NroReserva", "NroReserva");
            dataGridView.Columns.Add("Estado", "Estado");
            dataGridView.Columns.Add("FechaCreacion", "FechaCreacion");
            dataGridView.Columns.Add("Total", "Total");

            foreach (var pedido in listaPedidos)
            {
                // Agregamos una fila al DataGridView
                int rowIndex = dataGridView.Rows.Add();

                dataGridView.Rows[rowIndex].Cells[0].Value = pedido.NroPedido; // Suponiendo que "Nombre" es la segunda columna agregada
                dataGridView.Rows[rowIndex].Cells[1].Value = pedido.Reserva.NroReserva;
                dataGridView.Rows[rowIndex].Cells[2].Value = pedido.Estado;
                dataGridView.Rows[rowIndex].Cells[3].Value = pedido.FechaCreacion;
                dataGridView.Rows[rowIndex].Cells[4].Value = pedido.Total;
            }
        }





        #endregion


        #region Obtener y Listar Pedidos y Detalles
        public void ListarPedidosDeReservaEnDGV(DataGridView dataGridView, int nroReserva)
        {
            List<PedidoBE> listaPedidos = new List<PedidoBE>();

            try
            {
                // Buscamos la reserva por su ID
                ReservaBE reserva = con.Reserva.FirstOrDefault(r => r.NroReserva == nroReserva);

                if (reserva != null)
                {
                    // Obtenemos los detalles de pedido asociados a la reserva
                    listaPedidos = con.Pedido.Where(d => d.Reserva.NroReserva == nroReserva).ToList();

                    dataGridView.Rows.Clear();
                    dataGridView.Columns.Clear();

                    // Obtener la lista de las Habitaciones
                    ///List<PedidoBE> listaPedidos = con.Pedido.ToList();

                    // Iteramos sobre la lista de clientes activos y agregamos cada cliente al DataGridView
                    dataGridView.Columns.Add("NroPedido", "NroPedido");
                    dataGridView.Columns.Add("NroReserva", "NroReserva");
                    dataGridView.Columns.Add("Estado", "Estado");
                    dataGridView.Columns.Add("FechaCreacion", "FechaCreacion");
                    dataGridView.Columns.Add("Total", "Total");

                    foreach (var pedido in listaPedidos)
                    {
                        // Agregamos una fila al DataGridView
                        int rowIndex = dataGridView.Rows.Add();

                        dataGridView.Rows[rowIndex].Cells[0].Value = pedido.NroPedido; // Suponiendo que "Nombre" es la segunda columna agregada
                        dataGridView.Rows[rowIndex].Cells[1].Value = pedido.Reserva.NroReserva;
                        dataGridView.Rows[rowIndex].Cells[2].Value = pedido.Estado;
                        dataGridView.Rows[rowIndex].Cells[3].Value = pedido.FechaCreacion;
                        dataGridView.Rows[rowIndex].Cells[4].Value = pedido.Total;
                    }


                }
                else
                {
                    // Si no se encuentra la reserva, puedes manejar el caso según tus requerimientos
                    Console.WriteLine("No se encontró la reserva con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los detalles del pedido: " + ex.Message);
            }
        }


        //Obtener lista de detalles de la reserva seleccionad
        public List<PedidoBE> ObtenerPedidosDeLaReserva(int nroReserva)
        {
            List<PedidoBE> listaPedidos = new List<PedidoBE>();

            try
            {
                // Buscamos la reserva por su ID
                ReservaBE reserva = con.Reserva.FirstOrDefault(r => r.NroReserva == nroReserva);

                if (reserva != null)
                {
                    // Obtenemos los detalles de pedido asociados a la reserva
                    listaPedidos = con.Pedido.Where(d => d.Reserva.NroReserva == nroReserva).ToList();
                }
                else
                {
                    // Si no se encuentra la reserva, puedes manejar el caso según tus requerimientos
                    Console.WriteLine("No se encontró la reserva con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los detalles del pedido: " + ex.Message);
            }

            return listaPedidos;
        }



        public List<PedidoBE> ObtenerPedidosPendientesDeReserva(int nroReserva)
        {
            List<PedidoBE> listaPedidos = new List<PedidoBE>();

            try
            {
                // Buscamos la reserva por su ID
                ReservaBE reserva = con.Reserva.FirstOrDefault(r => r.NroReserva == nroReserva);

                if (reserva != null)
                {
                    // Obtenemos los detalles de pedido asociados a la reserva
                    listaPedidos = con.Pedido.Where(d => d.Reserva.NroReserva == nroReserva && d.Estado == "PagoPendiente").ToList();
                }
                else
                {
                    // Si no se encuentra la reserva, puedes manejar el caso según tus requerimientos
                    Console.WriteLine("No se encontró la reserva con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los detalles del pedido: " + ex.Message);
            }

            return listaPedidos;
        }


        public List<DetallePedidoBE> ObtenerDetallesPedidoDeLaReserva(int nroReserva)
        {
            List<DetallePedidoBE> listaDetalles = new List<DetallePedidoBE>();

            try
            {
                // Buscamos la reserva por su ID
                ReservaBE reserva = con.Reserva.FirstOrDefault(r => r.NroReserva == nroReserva);

                if (reserva != null)
                {
                    // Obtenemos los detalles de pedido asociados a la reserva
                    listaDetalles = con.DetallePedido.Where(d => d.Pedido.Reserva.NroReserva == nroReserva ).ToList();
                }
                else
                {
                    // Si no se encuentra la reserva, puedes manejar el caso según tus requerimientos
                    Console.WriteLine("No se encontró la reserva con el ID especificado.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los detalles del pedido: " + ex.Message);
            }

            return listaDetalles;
        }

        public List<DetallePedidoBE> ObtenerDetallesPendientesDeLaReserva(int nroReserva)
        {
            List<DetallePedidoBE> listaDetalles = new List<DetallePedidoBE>();

            try
            {
                // Buscamos la reserva por su ID
                ReservaBE reserva = con.Reserva.FirstOrDefault(r => r.NroReserva == nroReserva);

                if (reserva != null)
                {
                    // Obtenemos los detalles de pedido asociados a la reserva
                    listaDetalles = con.DetallePedido.Where(d => d.Pedido.Reserva.NroReserva == nroReserva && d.Pedido.Estado == "PagoPendiente").ToList();
                }
                else
                {
                    // Si no se encuentra la reserva, puedes manejar el caso según tus requerimientos
                    Console.WriteLine("No se encontró la reserva con el ID especificado.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los detalles del pedido: " + ex.Message);
            }

            return listaDetalles;
        }
        #endregion


        #region Realizar Facturas y enviar --> CheckOut



        public void GenerarFacturaTXT(int nroReserva, string tipoFactura, string usuarioActual)
        {
            try
            {
                GenerarFactura_DetalleFactura(nroReserva, tipoFactura, usuarioActual);
                using (var transaction = con.Database.BeginTransaction())
                {
                    try
                    {
                        List<PedidoBE> listaPedidos = ObtenerPedidosPendientesDeReserva(nroReserva);
                        List<DetallePedidoBE> listaDetalles = new List<DetallePedidoBE>();
                        ReservaBE reserva = con.Reserva.FirstOrDefault(r => r.NroReserva == nroReserva);
                        reserva.Estado = "Finalizada";
                        reserva.Habitacion.Estado = "Limpieza";
                        foreach (var pedido in listaPedidos)
                        {
                            listaDetalles = ObtenerDetallesPendientesDeLaReserva(nroReserva);
                            pedido.Estado = "Pagado";
                            con.SaveChanges();
                        }

                        
                        ClienteBE cliente = reserva.Cliente;

                        StringBuilder contenidoFactura = new StringBuilder();
                        contenidoFactura.AppendLine("DETALLE DE LA FACTURA");
                        contenidoFactura.AppendLine($"Cliente: {cliente.Persona.Nombre} {cliente.Persona.Apellido}");
                        contenidoFactura.AppendLine($"Reserva ID: {reserva.NroReserva}");
                        contenidoFactura.AppendLine($"Fecha de la reserva: {reserva.FechaLlegada} hasta {reserva.FechaIda}");
                        contenidoFactura.AppendLine($"Total de la estadia: {reserva.Total}");
                        contenidoFactura.AppendLine("Productos:");

                        foreach (var producto in listaDetalles)
                        {
                            contenidoFactura.AppendLine($"Producto: {producto.NombreProducto}  cantidad {producto.CantidadPedida} precio: {producto.Producto.PrecioUnitario} total {producto.Total}  ");
                        }

                        contenidoFactura.AppendLine($"Subtotal: {reserva.Subtotal}");
                        contenidoFactura.AppendLine($"Impuestos: {reserva.Impuestos}");
                        contenidoFactura.AppendLine($"Total de la factura: {reserva.Total}");
                        string ubica = "SGH - UAI - Final/ArchivosHotel";
                        string nombreCarpetaExistente = "Facturas";
                        string rutaCarpetaExistente = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), ubica, nombreCarpetaExistente);
                        string carpetaReserva = Path.Combine(rutaCarpetaExistente, nroReserva.ToString());

                        if (!Directory.Exists(carpetaReserva))
                        {
                            Directory.CreateDirectory(carpetaReserva);
                        }

                        int nroFactura = con.Factura.Count();
                        string nombreArchivo = $"factura_{nroFactura}.txt";
                        string rutaArchivo = Path.Combine(carpetaReserva, nombreArchivo);

                        File.WriteAllText(rutaArchivo, contenidoFactura.ToString());

                        // Enviar correo electrónico con el archivo adjunto
                        EnviarCorreoElectronico(cliente.Persona.Mail, "Factura de la reserva", "Adjunto se encuentra la factura de su reserva.", rutaArchivo, "  *MAIL*  "); //> Completar con el mail el cual envia el correo electronico

                        transaction.Commit();
                        Console.WriteLine("Factura generada y correo electrónico enviado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error al enviar la factura: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar la factura: " + ex.Message);
            }
        }

        private void GenerarFactura_DetalleFactura(int nroReserva, string tipoFactura, string usuarioActual)
        {
            using (var transaction = con.Database.BeginTransaction())
            {
                try
                {
                    // Obtenemos los pedidos pendientes de la reserva
                    List<PedidoBE> listaPedidos = ObtenerPedidosPendientesDeReserva(nroReserva);

                    // Recuperamos el usuario por su Id
                    UsuarioBE usuario = con.Usuario.Include(u => u.Empleado).FirstOrDefault(u => u.Nombre == usuarioActual);

                    if (usuario == null)
                    {
                        Console.WriteLine("No se encontró ningún usuario con el Id especificado.");
                        return; // Salir del método si no se encuentra el usuario
                    }

                    FacturaBE factura = new FacturaBE
                    {
                        Emisor = "Hotel SGH",
                        NroFactura = con.Factura.Count() + 1, // Método para obtener el próximo número de factura de manera segura
                        TipoFactura = tipoFactura,
                        FechaEmision = DateTime.Now,
                        Estado = "Pagado",
                        Empleado = usuario.Empleado,
                        Subtotal = listaPedidos.Sum(p => p.Subtotal),
                        Impuestos = (decimal)(listaPedidos.Sum(p => p.Impuestos)),
                        Total = (decimal)(listaPedidos.Sum(p => p.Total))

                    };
                    con.Factura.Add(factura);

                    foreach (var pedido in listaPedidos)
                    {
                        pedido.Factura = factura;

                        // Obtenemos los detalles del pedido de la reserva
                        List<DetallePedidoBE> listaDetalles = ObtenerDetallesPedidoDeLaReserva(nroReserva);



                        foreach (var detalle in listaDetalles)
                        {
                            // Creamos un nuevo detalle de factura
                            DetalleFacturaBE detalleFactura = new DetalleFacturaBE
                            {
                                Factura = factura,
                                Producto = detalle.Producto,
                                NombreProducto = detalle.NombreProducto,
                                CantidadPedida = detalle.CantidadPedida,
                                Subtotal = detalle.Subtotal,
                                Impuestos = detalle.Impuestos,
                                Total = detalle.Total
                            };

                            // Agregamos el detalle de factura al contexto
                            con.DetalleFactura.Add(detalleFactura);
                        }
                    }

                    // Guardamos los cambios una vez que hemos creado todas las facturas y detalles de factura
                    con.SaveChanges();

                    // Confirmamos la transacción
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // En caso de error, realizamos un rollback de la transacción
                    transaction.Rollback();
                    Console.WriteLine("Error al generar la factura: " + ex.ToString());
                }
            }
        }

        

        public void EnviarCorreoElectronico(string destinatario, string asunto, string cuerpo, string adjunto, string mail)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(mail);
                correo.To.Add(destinatario);
                correo.Subject = asunto;
                correo.Body = cuerpo;

                // Adjuntar el archivo
                Attachment adjuntoCorreo = new Attachment(adjunto);
                correo.Attachments.Add(adjuntoCorreo);

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.office365.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false; // No usar las credenciales predeterminadas
                smtp.Credentials = new NetworkCredential("  mail     ", " contraseña  ");  //---> completar el mail y contraseña el cual va a enviar el mail
                smtp.EnableSsl = true;

                smtp.Send(correo);

                // Liberar recursos
                adjuntoCorreo.Dispose();
                correo.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo electrónico: " + ex.Message);
            }
        }











        #endregion






        public List<DetallePedidoBE> ObtenerListaDetallesPedidos(int nroPedido)
        { 
            List<DetallePedidoBE> listaDetalles = new List<DetallePedidoBE>();

            PedidoBE pedido = con.Pedido.FirstOrDefault(p => p.NroPedido == nroPedido);

            if (pedido != null)
            {
                listaDetalles = con.DetallePedido.Where(d => d.Pedido.Id == pedido.Id && d.Pedido.Estado == "PagoPendiente").ToList();
            }

            return listaDetalles;
        }





    }
}





