using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controladora
{
    public class ClienteBLL
    {
        ClienteDAL _clienteDal = new ClienteDAL();
        public string AgregarCliente(ClienteBE cliente)
        {
            return _clienteDal.AgregarCliente(cliente);
        }


        public string EliminarCliente(ClienteBE cliente)
        {
            return _clienteDal.EliminarCliente(cliente);
        }

        public string ModificarCliente(ClienteBE cliente)
        {
            return _clienteDal.ModificarCliente(cliente);
        }

        
        /*
        //Funcion Obtener un cliente de la base de datos
        public ClienteBE ObtenerCliente(int idCliente)
        {
            return _clienteDal.ObtenerCliente(idCliente);
        }*/

        



        /*
        public List<ClienteBE> ListarClientes()
        {
            return _clienteDal.ListarClientes();
        }*/


        public void ListarClientesActivosEnDataGridView(DataGridView dataGridView)
        {
            _clienteDal.ListarClientesActivosEnDataGridView(dataGridView);
        }

        










    }
}
