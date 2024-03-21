using DocumentFormat.OpenXml.Wordprocessing;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo
{
    public class ProductoDAL
    {
        //ContextoBD con = new ContextoBD();
        ContextoBD con = new ContextoBD();
        public void AgregarProducto(ProductoBE producto)
        {
            try
            {
                // Buscar si existe un producto con el mismo nombre en la base de datos
                ProductoBE productoExistente = con.Producto.FirstOrDefault(p => p.NombreProducto == producto.NombreProducto);

                if (productoExistente != null)
                {
                    if(productoExistente.PrecioUnitario == producto.PrecioUnitario)
                    {
                        productoExistente.CantidadStock += producto.CantidadStock;
                    }
                    if(productoExistente.PrecioUnitario != producto.PrecioUnitario)
                    {
                        //mensajebox con 2 botones "Remplazar precio" "agregar producto"
                        //si elige remplazar precio, se remplaza el precio y se suma la cantidad
                        //si elige agregar producto, se agrega el producto con el precio nuevo
                        DialogResult dialogResult = MessageBox.Show("El producto ya existe, \n ¿Desea reemplazar el precio" + productoExistente.PrecioUnitario.ToString() + "al precio" + producto.PrecioUnitario.ToString() + " y sumar la cantidad? \n Si no quiere se creara el mismo producto con el precio diferente", "Producto Existente", MessageBoxButtons.YesNo );
                        if (dialogResult == DialogResult.Yes)
                        {
                            productoExistente.PrecioUnitario = producto.PrecioUnitario;
                            productoExistente.CantidadStock += producto.CantidadStock;
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            con.Producto.Add(producto);
                        }
                    }
                    //// Sumar la cantidad del producto existente con la cantidad del nuevo producto
                    //productoExistente.CantidadStock += producto.CantidadStock;
                }
                else
                {
                    // Si no existe, agregar el nuevo producto a la base de datos
                    con.Producto.Add(producto);
                }

                // Guardar los cambios en la base de datos
                con.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar el producto. " + ex.Message);
            }
        }


        public void ModificarProducto(ProductoBE producto)
        {
            try
            {
                ProductoBE productoAModificar = con.Producto.Find(producto.Id);
                productoAModificar.NombreProducto = producto.NombreProducto;
                productoAModificar.PrecioUnitario = producto.PrecioUnitario;
                productoAModificar.CantidadStock = producto.CantidadStock;
                con.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el producto. " + ex.Message);
            }
        }

        public void EliminarProducto(int id)
        {
            try
            {
                ProductoBE productoAEliminar = con.Producto.Find(id);
                
                DetallePedidoBE detallePedido = con.DetallePedido.FirstOrDefault(dp => dp.Producto.Id == id);
                if(detallePedido != null)
                {
                    MessageBox.Show("No se puede eliminar el producto porque está asociado al detalle de un pedido");
                }
                else
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar el producto?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        con.Producto.Remove(productoAEliminar);
                        con.SaveChanges();
                        MessageBox.Show("Producto eliminado correctamente", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el producto. " + ex.Message);
            }
        }

        /*
        public List<ProductoBE> ListarProductos()
        {
            return con.Producto.ToList();
        }
        */

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
    }
}
