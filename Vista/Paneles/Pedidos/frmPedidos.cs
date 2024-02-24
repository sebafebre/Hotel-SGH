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
using System.Web;
using System.Windows.Forms;

namespace Vista.Paneles
{
    public partial class frmPedidos : Form
    {


        public frmPedidos()
        {
            InitializeComponent();
            ValidacionesBLL.CambiarPanel(typeof(Pedidos.frmAgregarPedidos), this);

        }


        private void btnModificarPedidos_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Pedidos.frmModificarPedidos), this);
        }

        private void btnAgregarProductoStock_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Pedidos.frmProductos), this);
        }

       

        private void btnFrmPedidos_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.AbrirFormulario(typeof(frmPedidos), this);
        }

        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            ValidacionesBLL.CambiarPanel(typeof(Pedidos.frmAgregarPedidos), this);
        }
    }
}
