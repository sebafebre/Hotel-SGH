using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controladora
{
    public class ClienteBLL
    {
        ClienteDAL _clienteDal = new ClienteDAL();
        public void AgregarCliente(ClienteBE cliente)
        {
            _clienteDal.AgregarCliente(cliente);
        }


        public string EliminarCliente(ClienteBE cliente)
        {
            return _clienteDal.EliminarCliente(cliente);
        }

        public string ModificarCliente(ClienteBE cliente)
        {
            return _clienteDal.ModificarCliente(cliente);
        }

        
       


        public void ListarClientesActivosEnDataGridView(DataGridView dataGridView)
        {
            _clienteDal.ListarClientesActivosEnDataGridView(dataGridView);
        }



        public int ObtenerIdCliente(ClienteBE cliente)
        {
            return _clienteDal.ObtenerIdCliente(cliente);
        }

        




    }
}
