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

namespace Vista.Paneles
{
    public partial class frmPago : Form
    {
        PedidoBLL pedidoBLL = new PedidoBLL();
        StateBLL stateBLL = new StateBLL();

        public string usuarioActual = UsuarioBE.usaurioLogueado;
        public string Accion { get; set; }
        public int nroReserva { get; set; }


        public List<DetallePedidoBE> listaDetallesPedidos = new List<DetallePedidoBE>();
        public string Estado { get; set; }
        public int nroPedido { get; set; }




        public frmPago()
        {
            InitializeComponent();
        }
        
        public bool validarCampos()
        {
            if (cbTipoFactura.Text == "")
            {
                MessageBox.Show("Debe seleccionar un tipo de factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if ( txtNroTarjeta.Text == "")
            {
                MessageBox.Show("Debe ingresar un número de tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtPIN.Text == "")
            {
                MessageBox.Show("Debe ingresar un PIN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }

        }


        public void realizarAccion()
        {
            try
            {
                if((cbPagoEfetivo.Checked == true && cbTipoFactura.Text != "") || validarCampos() == true)
                {
                    
                    if (Accion == "CheckOut")
                    {
                        pedidoBLL.GenerarFacturaTXT(nroReserva, cbTipoFactura.Text, usuarioActual);
                    }
                    if (Accion == "PagoDePedido")
                    {
                        stateBLL.FinalizarPedido(listaDetallesPedidos, nroReserva, Estado, cbTipoFactura.Text, usuarioActual, nroPedido);
                    }

                    nroPedido = -1;
                    listaDetallesPedidos.Clear();
                    nroReserva = -1;
                    Estado = "";

                    this.Close();
                }
                
            }
            catch
            {
                MessageBox.Show("Error al realizar la acción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            realizarAccion();
        }
    }
}
