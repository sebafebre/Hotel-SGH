using Controladora;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Paneles.Pedidos
{
    public partial class frmProductos : Form
    {

        ProductoBLL productoBLL = new ProductoBLL();


        public frmProductos()
        {
            InitializeComponent();
            productoBLL.ListarProductosEnDGV(dgvProductos);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text != "" && txtPrecioUnitario.Text != "" && txtCantidadStock.Text != "")
                {
                    ProductoBE producto = new ProductoBE();
                    producto.NombreProducto = txtNombre.Text;
                    producto.PrecioUnitario = Convert.ToInt32(txtPrecioUnitario.Text);
                    producto.CantidadStock = Convert.ToInt32(txtCantidadStock.Text);
                    productoBLL.AgregarProducto(producto);
                    MessageBox.Show("Producto agregado correctamente", "Agregar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    productoBLL.ListarProductosEnDGV(dgvProductos);
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos", "Agregar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el producto", "Agregar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "" && txtNombre.Text != "" && txtPrecioUnitario.Text != "" && txtCantidadStock.Text != "")
                {
                    ProductoBE producto = new ProductoBE();
                    producto.Id = Convert.ToInt32(txtID.Text);
                    producto.NombreProducto = txtNombre.Text;
                    producto.PrecioUnitario = Convert.ToInt32(txtPrecioUnitario.Text);
                    producto.CantidadStock = Convert.ToInt32(txtCantidadStock.Text);
                    productoBLL.ModificarProducto(producto);
                    productoBLL.ListarProductosEnDGV(dgvProductos);
                    MessageBox.Show("Producto modificado correctamente", "Modificar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos", "Modificar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el producto", "Modificar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "")
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar el producto?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        productoBLL.EliminarProducto(Convert.ToInt32(txtID.Text));
                        productoBLL.ListarProductosEnDGV(dgvProductos);
                        MessageBox.Show("Producto eliminado correctamente", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un producto", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dgvProductos.Rows[e.RowIndex];
                    txtID.Text = row.Cells["Id Producto"].Value.ToString();
                    txtNombre.Text = row.Cells["Producto"].Value.ToString();
                    txtPrecioUnitario.Text = row.Cells["Precio"].Value.ToString();
                    txtCantidadStock.Text = row.Cells["Cantidad en Stock"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }   


        }



    }
}