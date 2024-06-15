using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controladora
{
    public class ProductoBLL
    {
        ProductoDAL productoDAL = new ProductoDAL();

        public void AgregarProducto(ProductoBE producto)
        {
            productoDAL.AgregarProducto(producto);
        }

        public void ModificarProducto(ProductoBE producto)
        {
            productoDAL.ModificarProducto(producto);
        }

        public void EliminarProducto(int id)
        {
            productoDAL.EliminarProducto(id);
        }

        

        public void ListarProductosEnDGV(DataGridView dataGridView)
        {
            productoDAL.ListarProductosEnDGV(dataGridView);
        }
    }
}
