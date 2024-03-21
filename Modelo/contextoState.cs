using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using Entidades.Seguridad;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace Modelo
{

    public class contextoState
    {
        ContextoBD con = new ContextoBD();

        public void FinalizarPedido(List<DetallePedidoBE> listaDetallesPedidos, int nroReserva, string Estado, string tipoFactura, string usuarioActual, int nroPedido)
        {
            // Obtener el cliente de la reserva
            ReservaBE reserva = con.Reserva.FirstOrDefault(r => r.NroReserva == nroReserva);
            ClienteBE cliente = reserva.Cliente;

            UsuarioBE usuario = con.Usuario.Include(u => u.Empleado).FirstOrDefault(u => u.Nombre == usuarioActual);

            EmpleadoBE empleado = usuario.Empleado;



            // Obtener la carpeta de facturas
            string ubica = "SGH - UAI - Final/ArchivosHotel";
            string nombreCarpetaExistente = "Facturas";
            string rutaCarpetaExistente = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), ubica, nombreCarpetaExistente);
            string carpetaReserva = Path.Combine(rutaCarpetaExistente, nroReserva.ToString());

            try
            {
                // Determinar el estado actual del pedido y asignar el estado correspondiente
                State estadoPedido;
                if (Estado == "PagoPendiente" && reserva.Estado == "Activa")
                {
                    estadoPedido = new EstadoAPagar();
                }
                else if (Estado == "Pago en el momento" && reserva.Estado == "Activa")
                {
                    estadoPedido = new EstadoPagoInstantaneo(con);
                }
                else
                {
                    // Manejar el estado no válido
                    Console.WriteLine("Estado de pedido no válido");
                    return;
                }

                // Procesar el pedido con el estado actual
                estadoPedido.ProcesarPedido(listaDetallesPedidos, nroReserva, tipoFactura, carpetaReserva, empleado, nroPedido);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al procesar el pedido: " + ex.Message);
            }
        }

    }

    public class EstadoAPagar : State
    {
        ContextoBD con = new ContextoBD();
        public override void ProcesarPedido(List<DetallePedidoBE> listaDetallesPedidos, int nroReserva, string tipoFactura, string rutaCarpetaFacturas, EmpleadoBE empleado, int nroPedido)
        {
            using (var transaction = con.Database.BeginTransaction())
            {
                try
                {
                    ClienteBE cliente = new ClienteBE();
                    // Se crea el pedido
                    PedidoBE pedido = new PedidoBE
                    {
                        NroPedido = con.Pedido.Count() + 1,
                        Reserva = con.Reserva.FirstOrDefault(r => r.NroReserva == nroReserva),
                        Estado = "PagoPendiente",
                        FechaCreacion = DateTime.Now,
                        Subtotal = listaDetallesPedidos.Sum(d => d.Subtotal),
                        Impuestos = listaDetallesPedidos.Sum(d => d.Impuestos),
                        Total = listaDetallesPedidos.Sum(d => d.Total)
                    };

                    // Se agrega el pedido a la base de datos
                    con.Pedido.Add(pedido);

                    // Se agregan los detalles de pedido al pedido
                    foreach (var detallePedido in listaDetallesPedidos)
                    {
                        // Asegúrate de que el producto está cargado desde la base de datos
                        var productoEnBD = con.Producto.FirstOrDefault(p => p.Id == detallePedido.Producto.Id);

                        if (productoEnBD != null)
                        {
                            // Asigna el producto cargado desde la base de datos al detalle de pedido
                            detallePedido.Producto = productoEnBD;
                            productoEnBD.CantidadStock -= detallePedido.CantidadPedida; // Restar la cantidad pedida al stock del producto
                        }

                        // Ahora crea un nuevo detalle de pedido y asígnale el producto adecuado
                        DetallePedidoBE detalleNuevo = new DetallePedidoBE();
                        detalleNuevo.Producto = detallePedido.Producto;
                        detalleNuevo.NombreProducto = detallePedido.Producto.NombreProducto;
                        detalleNuevo.CantidadPedida = detallePedido.CantidadPedida;
                        //Creado por Sebastian Febre
                        // https://github.com/sebafebre
                        detalleNuevo.Pedido = pedido;
                        detalleNuevo.Subtotal = detallePedido.Subtotal;
                        detalleNuevo.Impuestos = detallePedido.Impuestos;
                        detalleNuevo.Total = detallePedido.Total;


                        // Agrega el nuevo detalle de pedido a la base de datos
                        con.DetallePedido.Add(detalleNuevo);
                    }


                    con.Pedido.Add(pedido);
                    con.SaveChanges();



                    // Commit de la transacción si todo ha sido exitoso
                    transaction.Commit();

                    Console.WriteLine("Pedido Realizado");
                    MessageBox.Show("Pedido guardado con exito");
                }
                catch (Exception ex)
                {
                    // Rollback de la transacción en caso de error
                    transaction.Rollback();
                    Console.WriteLine("Error al finalizar el pedido: " + ex.Message);

                    if (ex.InnerException != null)
                    {
                        Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                    }

                    MessageBox.Show("Error al finalizar el pedido: " + ex.Message);
                    // Manejar el error adecuadamente, posiblemente mostrar un mensaje al usuario
                }


            }

        }
    }

    public class EstadoPagoInstantaneo : State
    {
        private ContextoBD _con;
        public EstadoPagoInstantaneo(ContextoBD con)
        {
            _con = con;
        }
        public override void ProcesarPedido(List<DetallePedidoBE> listaDetallesPedidos, int nroReserva, string tipoFactura, string rutaCarpetaFacturas, EmpleadoBE empleado, int nroPedido)
        {

            using (var transaction = _con.Database.BeginTransaction())
            {
                try
                {

                    ClienteBE cliente = new ClienteBE();
                    PedidoBE pedido = new PedidoBE();


                    if (nroPedido != 0)
                    {
                        pedido = _con.Pedido.FirstOrDefault(p => p.NroPedido == nroPedido);

                        FacturaBE factura = new FacturaBE
                        {
                            Emisor = "Hotel SGH",
                            NroFactura = _con.Factura.Count() + 1, // Método para obtener el próximo número de factura de manera segura
                            TipoFactura = tipoFactura,
                            FechaEmision = DateTime.Now,
                            Estado = "Pagado",
                            //Pedido = pedido,
                            Empleado = empleado,
                            Subtotal = pedido.Subtotal,
                            Impuestos = pedido.Impuestos,
                            Total = pedido.Total

                        };

                        _con.Factura.Add(factura);

                        pedido.Estado = "Pagado";
                        pedido.Factura = factura;

                        _con.SaveChanges();

                        // Commit de la transacción si todo ha sido exitoso
                        transaction.Commit();

                        Console.WriteLine("Pedido y Factura Realizado ");
                    }
                    if (nroPedido == 0)
                    {
                        

                       
                        // Recuperamos el usuario por su Id

                        FacturaBE factura = new FacturaBE
                        {
                            Emisor = "Hotel SGH",
                            NroFactura = _con.Factura.Count() + 1, // Método para obtener el próximo número de factura de manera segura
                            TipoFactura = tipoFactura,
                            FechaEmision = DateTime.Now,
                            Estado = "Pagado",
                            //Pedido = pedido,
                            Empleado = empleado
                        };


                        // Se crea el pedido
                        pedido = new PedidoBE
                        {
                            NroPedido = _con.Pedido.Count() + 1,
                            Reserva = _con.Reserva.FirstOrDefault(r => r.NroReserva == nroReserva),
                            Estado = "Pagado",
                            FechaCreacion = DateTime.Now,
                            Subtotal = listaDetallesPedidos.Sum(d => d.Subtotal),
                            Impuestos = listaDetallesPedidos.Sum(d => d.Impuestos),
                            Total = listaDetallesPedidos.Sum(d => d.Total),
                            Factura = factura
                        };


                        factura.Subtotal = pedido.Subtotal;
                        factura.Impuestos = pedido.Impuestos;
                        factura.Total = pedido.Total;


                        // Se agrega el pedido Y factura a la base de datos
                        _con.Pedido.Add(pedido);
                        _con.Factura.Add(factura);



                        // Se agregan los detalles de pedido al pedido
                        foreach (var detallePedido in listaDetallesPedidos)
                        {
                            detallePedido.Pedido = pedido; // Asignar el pedido a cada detalle


                            // Creamos un nuevo detalle de factura
                            DetalleFacturaBE detalleFactura = new DetalleFacturaBE
                            {
                                Factura = factura,
                                Producto = detallePedido.Producto,
                                NombreProducto = detallePedido.NombreProducto,
                                CantidadPedida = detallePedido.CantidadPedida,
                                Subtotal = detallePedido.Subtotal,
                                Impuestos = detallePedido.Impuestos,
                                Total = detallePedido.Total
                            };

                            _con.DetalleFactura.Add(detalleFactura);

                        }


                        // Se agregan los detalles de pedido a la base de datos
                        _con.DetallePedido.AddRange(listaDetallesPedidos);

                        // Guardar todos los cambios en la base de datos
                        _con.SaveChanges();

                        // Commit de la transacción si todo ha sido exitoso
                        transaction.Commit();

                        Console.WriteLine("Pedido y Factura Realizado ");
                    }
                    
                    ReservaBE reserva = _con.Reserva.FirstOrDefault(r => r.NroReserva == nroReserva);
                    cliente = reserva.Cliente;


                    //https://github.com/sebafebre

                    StringBuilder contenidoFactura = new StringBuilder();
                    contenidoFactura.AppendLine("DETALLE DE LA FACTURA");
                    contenidoFactura.AppendLine($"Fecha de la emision de la Factura:  {DateTime.Now}   ");
                    contenidoFactura.AppendLine($"Cliente: {cliente.Persona.Nombre}    {cliente.Persona.Apellido}");
                    contenidoFactura.AppendLine($"Reserva ID: {reserva.NroReserva}");
                    contenidoFactura.AppendLine($"Fecha de la reserva: {reserva.FechaLlegada.Date} hasta {reserva.FechaIda.Date}");
                    contenidoFactura.AppendLine($" \n \n \n ");
                    contenidoFactura.AppendLine("Productos:");

                    foreach (var producto in listaDetallesPedidos)
                    {
                        contenidoFactura.AppendLine($"Producto: {producto.NombreProducto}  cantidad: {producto.CantidadPedida}  precio U: {producto.Producto.PrecioUnitario}   total:  {producto.Total}  ");
                    }

                    contenidoFactura.AppendLine($"Subtotal: {listaDetallesPedidos.Sum(detalle => detalle.Subtotal)}");
                    contenidoFactura.AppendLine($"Impuestos: {listaDetallesPedidos.Sum(detalle => detalle.Impuestos)}");
                    contenidoFactura.AppendLine($"Total de la factura: {pedido.Total}");
                    string ubica = "SGH - UAI - Final/ArchivosHotel";
                    string nombreCarpetaExistente = "Facturas";
                    string rutaCarpetaExistente = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), ubica, nombreCarpetaExistente);
                    string carpetaReserva = Path.Combine(rutaCarpetaExistente, nroReserva.ToString());

                    if (!Directory.Exists(carpetaReserva))
                    {
                        Directory.CreateDirectory(carpetaReserva);
                    }

                    int nroFactura = _con.Factura.Count();
                    string nombreArchivo = $"factura_{nroFactura}.txt";
                    string rutaArchivo = Path.Combine(carpetaReserva, nombreArchivo);

                    File.WriteAllText(rutaArchivo, contenidoFactura.ToString());

                    // Enviar correo electrónico con el archivo adjunto
                    PedidoDAL pedidoDAL = new PedidoDAL();
                    pedidoDAL.EnviarCorreoElectronico(cliente.Persona.Mail, "Factura de la reserva", "Adjunto se encuentra la factura de su reserva.", rutaArchivo, "   *MAIL*   ");     //----> Colocar el mail el cual envia el correo electronico       

                    //transaction.Commit();
                    Console.WriteLine("Factura generada y correo electrónico enviado correctamente.");
                    MessageBox.Show("Factura generada y correo electrónico enviado correctamente.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error al generar y enviar la factura : " + ex.Message);
                    MessageBox.Show("Error al generar y enviar la factura : " + ex.Message);

                }

            }


        }
    }

}







//Metodo sin patron State

/*public void PedidoTerminado(List<DetallePedidoBE> listaDetallesPedidos, int nroReserva, string Estado, string tipoFactura, int idUsuario)
{


    if (Estado == "A Pagar")
    {
        //FinalizarPedido(listaDetallesPedidos, nroReserva);
        using (var transaction = con.Database.BeginTransaction())
        {
            try
            {
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

                }

                // Se agregan los detalles de pedido a la base de datos
                con.DetallePedido.AddRange(listaDetallesPedidos);

    //https://github.com/sebafebre

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

    }

    if (Estado == "PagoPendiente")
    {

        #region CrearPedido
        using (var transaction = con.Database.BeginTransaction())
        {
            try
            {

                //SE CREA EL PEDIDO Y LA FACTURA

                ClienteBE cliente = new ClienteBE();
                // Recuperamos el usuario por su Id

                UsuarioBE usuario = con.Usuario.FirstOrDefault(u => u.Id == idUsuario);

                if (usuario == null)
                {
                    Console.WriteLine("No se encontró ningún usuario con el Id especificado.");
                    return; // Salir del método si no se encuentra el usuario
                }

                // Se crea el pedido
                PedidoBE pedido = new PedidoBE
                {
                    NroPedido = con.Pedido.Count() + 1,
                    Reserva = con.Reserva.FirstOrDefault(r => r.NroReserva == nroReserva),
                    Estado = "Pagado",
                    FechaCreacion = DateTime.Now,
                    Total = listaDetallesPedidos.Sum(d => d.Total)
                };


                FacturaBE factura = new FacturaBE
                {
                    Emisor = "Hotel SGH",
                    NroFactura = con.Factura.Count() + 1, // Método para obtener el próximo número de factura de manera segura
                    TipoFactura = tipoFactura,
                    FechaEmision = DateTime.Now,
                    Estado = "Pagado",
                    Pedido = pedido
                };


                // Se agrega el pedido Y factura a la base de datos
                con.Pedido.Add(pedido);
                con.Factura.Add(factura);



                // Se agregan los detalles de pedido al pedido
                foreach (var detallePedido in listaDetallesPedidos)
                {
                    detallePedido.Pedido = pedido; // Asignar el pedido a cada detalle


                    // Creamos un nuevo detalle de factura
                    DetalleFacturaBE detalleFactura = new DetalleFacturaBE
                    {
                        Factura = factura,
                        Producto = detallePedido.Producto,
                        NombreProducto = detallePedido.NombreProducto,
                        CantidadPedida = detallePedido.CantidadPedida,
                        Subtotal = detallePedido.Subtotal,
                        Impuestos = detallePedido.Impuestos,
                        Total = detallePedido.Total
                    };

                    con.DetalleFactura.Add(detalleFactura);

                }


                // Se agregan los detalles de pedido a la base de datos
                con.DetallePedido.AddRange(listaDetallesPedidos);

                // Guardar todos los cambios en la base de datos
                con.SaveChanges();

                // Commit de la transacción si todo ha sido exitoso
                transaction.Commit();

                Console.WriteLine("Pedido y Factura Realizado ");


                //List<DetallePedidoBE> listaDetalles = new List<DetallePedidoBE>();



                ReservaBE reserva = con.Reserva.FirstOrDefault(r => r.NroReserva == nroReserva);

                cliente = reserva.Cliente;

                StringBuilder contenidoFactura = new StringBuilder();
                contenidoFactura.AppendLine("DETALLE DE LA FACTURA");
                contenidoFactura.AppendLine($"Fecha de la emision de la Factura:  {DateTime.Now}   ");
                contenidoFactura.AppendLine($"Cliente: {cliente.Persona.Nombre} {cliente.Persona.Apellido}");
                contenidoFactura.AppendLine($"Reserva ID: {reserva.NroReserva}");
                contenidoFactura.AppendLine($"Fecha de la reserva: {reserva.FechaLlegada} hasta {reserva.FechaIda}");
                contenidoFactura.AppendLine($" \n \n \n \n \n");
                contenidoFactura.AppendLine("Productos:");

                foreach (var producto in listaDetallesPedidos)
                {
                    contenidoFactura.AppendLine($"Producto: {producto.NombreProducto}  cantidad {producto.CantidadPedida} precio: {producto.Producto.PrecioUnitario} total {producto.Total}  ");
                }

                contenidoFactura.AppendLine($"Subtotal: {reserva.Subtotal}");
                contenidoFactura.AppendLine($"Impuestos: {reserva.Impuestos}");
                contenidoFactura.AppendLine($"Total de la factura: {pedido.Total}");
                string ubica = "SGH - UAI";
                string nombreCarpetaExistente = "FacturasHotel";
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
                EnviarCorreoElectronico(cliente.Persona.Mail, "Factura de la reserva", "Adjunto se encuentra la factura de su reserva.", rutaArchivo, "   *MAIL*   ");

                //transaction.Commit();
                Console.WriteLine("Factura generada y correo electrónico enviado correctamente.");
                MessageBox.Show("Factura generada y correo electrónico enviado correctamente.");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("Error al generar y enviar la factura : " + ex.Message);

            }
        }
        #endregion


//https://github.com/sebafebre






    }*/


































































































//Creado por Sebastian Febre
// https://github.com/sebafebre