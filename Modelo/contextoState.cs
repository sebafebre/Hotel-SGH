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

namespace Modelo
{
    
    public class contextoState
    {
        ContextoBD con = new ContextoBD();

        public void FinalizarPedido(List<DetallePedidoBE> listaDetallesPedidos, int nroReserva, string Estado, string tipoFactura, string usuarioActual)
        {
            // Obtener el cliente de la reserva
            ReservaBE reserva = con.Reserva.FirstOrDefault(r => r.NroReserva == nroReserva);
            ClienteBE cliente = reserva.Cliente;

            UsuarioBE usuario = con.Usuario.Include(u => u.Empleado).FirstOrDefault(u => u.Nombre == usuarioActual);

            EmpleadoBE empleado = usuario.Empleado;



            // Obtener la carpeta de facturas
            string ubica = "SGH - UAI";
            string nombreCarpetaExistente = "FacturasHotel";
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
                else if (Estado == "PagoInstantaneo" && reserva.Estado == "Activa")
                {
                    estadoPedido = new EstadoPagoInstantaneo();
                }
                else
                {
                    // Manejar el estado no válido
                    Console.WriteLine("Estado de pedido no válido");
                    return;
                }

                // Procesar el pedido con el estado actual
                estadoPedido.ProcesarPedido(listaDetallesPedidos, nroReserva, tipoFactura, carpetaReserva, empleado);
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
        public override void ProcesarPedido(List<DetallePedidoBE> listaDetallesPedidos, int nroReserva, string tipoFactura, string rutaCarpetaFacturas, EmpleadoBE empleado)
        {
            using(var transaction = con.Database.BeginTransaction())
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
                        detalleNuevo.Pedido = pedido;
                        detalleNuevo.Subtotal = detallePedido.Subtotal;
                        detalleNuevo.Impuestos = detallePedido.Impuestos;
                        detalleNuevo.Total = detallePedido.Total;


                        // Agrega el nuevo detalle de pedido a la base de datos
                        con.DetallePedido.Add(detalleNuevo);
                    }

                    con.SaveChanges(); // Guarda los cambios en la base de datos




                    // Se agregan los detalles de pedido a la base de datos
                    //con.DetallePedido.AddRange(listaDetallesPedidos);



                    // Guardar todos los cambios en la base de datos
                    //con.SaveChanges();

                    // Commit de la transacción si todo ha sido exitoso
                    transaction.Commit();

                    Console.WriteLine("Pedido Realizado");
                    MessageBox.Show("Pedido guardado con exito");
                }
                catch (Exception ex)
                {
                    // Rollback de la transacción en caso de error
                    //transaction.Rollback();
                    Console.WriteLine("Error al finalizar el pedido: " + ex.Message);
                    MessageBox.Show("Error al finalizar el pedido: " + ex.Message);
                    // Manejar el error adecuadamente, posiblemente mostrar un mensaje al usuario
                }

            }

        }
    }

    public class EstadoPagoInstantaneo : State
    {
        ContextoBD con = new ContextoBD();
        public override void ProcesarPedido(List<DetallePedidoBE> listaDetallesPedidos, int nroReserva, string tipoFactura, string rutaCarpetaFacturas, EmpleadoBE empleado)
        {

            using (var transaction = con.Database.BeginTransaction())
            {
                try
                {

                    //SE CREA EL PEDIDO Y LA FACTURA

                    ClienteBE cliente = new ClienteBE();
                    // Recuperamos el usuario por su Id



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
                        Pedido = pedido,
                        Empleado = empleado
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
                    contenidoFactura.AppendLine($"Cliente: {cliente.Persona.Nombre}    {cliente.Persona.Apellido}");
                    contenidoFactura.AppendLine($"Reserva ID: {reserva.NroReserva}");
                    contenidoFactura.AppendLine($"Fecha de la reserva: {reserva.FechaLlegada.Date} hasta {reserva.FechaIda.Date}");
                    contenidoFactura.AppendLine($" \n \n \n \n \n");
                    contenidoFactura.AppendLine("Productos:");

                    foreach (var producto in listaDetallesPedidos)
                    {
                        contenidoFactura.AppendLine($"Producto: {producto.NombreProducto}  cantidad: {producto.CantidadPedida}  precio U: {producto.Producto.PrecioUnitario}   total:  {producto.Total}  ");
                    }

                    contenidoFactura.AppendLine($"Subtotal: {listaDetallesPedidos.Sum(detalle => detalle.Subtotal)}");
                    contenidoFactura.AppendLine($"Impuestos: {listaDetallesPedidos.Sum(detalle => detalle.Impuestos)}");
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
                    PedidoDAL pedidoDAL = new PedidoDAL();
                    pedidoDAL.EnviarCorreoElectronico(cliente.Persona.Mail, "Factura de la reserva", "Adjunto se encuentra la factura de su reserva.", rutaArchivo, "HotelSGH.Diploma@gmail.com");

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
                    EnviarCorreoElectronico(cliente.Persona.Mail, "Factura de la reserva", "Adjunto se encuentra la factura de su reserva.", rutaArchivo, "HotelSGH.Diploma@gmail.com");

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









        }*/















    #region composite

    /*



    public interface Composite
    {
        void Crear(ComponenteBE componente);
        //void Unir(ComponenteBE componente, GrupoBE grupo);
        void Eliminar(ComponenteBE componente);
        void Modificar(ComponenteBE componente);
    }

    public class Grupo : Composite
    {
        ContextoBD con = ContextoBD.Instance();
        public void Crear(ComponenteBE componente)
        {
            try
            {
                if (con.Grupo.Any(p => p.Componente.Nombre == componente.Nombre))
                {
                    MessageBox.Show("Ya existe un grupo con ese nombre.");
                }
                else
                {
                    //GrupoBE grupo = new GrupoBE();
                    GrupoBE grupo = new GrupoBE();
                    grupo.Componente = componente;

                    //guardar en bd
                    con.Componente.Add(componente);
                    con.Grupo.Add(grupo);
                    con.SaveChanges();
                    MessageBox.Show("Grupo creado con exito");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar el grupo. " + ex.Message);
            }

        }
        public void Eliminar(ComponenteBE componente)
        {
            

            GrupoBE grupo = con.Grupo.Include(p => p.Componente).FirstOrDefault(p => p.Componente.Id == componente.Id);
            
            if (grupo != null)
            {
                ComponenteBE compEliminar = con.Componente.FirstOrDefault(p => p.Id == componente.Id);

                List<GrupoComponenteBE> grupoComponentes = con.GrupoComponente.Where(p => p.Componente.Id == componente.Id).ToList();

                List<UsuarioGrupoComponenteBE> usuarioComponentes = con.UsuarioGrupoComponente.Where(p => p.Componente.Id == componente.Id).ToList();

                if (grupoComponentes != null)
                {
                    foreach (var grupoComponente in grupoComponentes)
                    {
                        con.GrupoComponente.Remove(grupoComponente);
                    }

                }
                if (usuarioComponentes != null)
                {
                    foreach (var usuarioComponente in usuarioComponentes)
                    {
                        con.UsuarioGrupoComponente.Remove(usuarioComponente);
                    }
                }
                con.Grupo.Remove(grupo);
                con.Componente.Remove(compEliminar);
                con.SaveChanges();
                MessageBox.Show("Grupo eliminado con exito");
                // Actualizar las propiedades del permiso

            }



        }

        public void Modificar(ComponenteBE componente)
        {
            GrupoBE grupo = con.Grupo.Include(p => p.Componente).FirstOrDefault(p => p.Componente.Id == componente.Id);
            grupo.Componente.Nombre = componente.Nombre;
            con.SaveChanges();
            MessageBox.Show("Grupo modificado con exito");
        }

    }

    public class Permiso : Composite
    {
        ContextoBD con = ContextoBD.Instance();
        public void Crear(ComponenteBE componente)
        {
            


            try
            {
                if (con.Permiso.Any(p => p.Componente.Nombre == componente.Nombre))
                {
                    MessageBox.Show("Ya existe un permiso con ese nombre.");
                }
                else
                {
                    PermisoBE permiso = new PermisoBE();
                    permiso.Componente = componente;

                    con.Componente.Add(componente);
                    con.Permiso.Add(permiso);
                    con.SaveChanges();
                    MessageBox.Show("Permiso creado con exito");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar el grupo. " + ex.Message);
            }

        }

        public void Eliminar(ComponenteBE componente)
        {
            PermisoBE permiso = con.Permiso.Include(p => p.Componente).FirstOrDefault(p => p.Componente.Id == componente.Id);
            //permiso.Componente = componente;
            if (permiso != null)
            {
                ComponenteBE compEliminar = con.Componente.FirstOrDefault(p => p.Id == componente.Id);

                List <GrupoComponenteBE> grupoComponentes = con.GrupoComponente.Where(p => p.Componente.Id == componente.Id).ToList();

                List <UsuarioGrupoComponenteBE> usuarioComponentes = con.UsuarioGrupoComponente.Where(p => p.Componente.Id == componente.Id).ToList();

                if(grupoComponentes != null)
                {
                    foreach(var grupoComponente in grupoComponentes)
                    {
                        con.GrupoComponente.Remove(grupoComponente);
                    }
                    
                }
                if (usuarioComponentes != null)
                {
                    foreach (var usuarioComponente in usuarioComponentes)
                    {
                        con.UsuarioGrupoComponente.Remove(usuarioComponente);
                    }
                }
                con.Componente.Remove(compEliminar);
                con.Permiso.Remove(permiso);
                con.SaveChanges();
                MessageBox.Show("Permiso eliminado con exito");
                // Actualizar las propiedades del permiso

            }

        }

        public void Modificar(ComponenteBE componente)
        {
            // Buscar el PermisoBE existente en la base de datos
            PermisoBE permiso = con.Permiso.Include(p => p.Componente).FirstOrDefault(p => p.Componente.Id == componente.Id);
            

            if (permiso != null)
            {
                // Actualizar las propiedades del permiso
                permiso.Componente.Nombre = componente.Nombre;

                // Guardar los cambios en la base de datos
                con.SaveChanges();
                MessageBox.Show("Permiso modificado con exito");
            }
        }




    }





    */






    #endregion
















}
