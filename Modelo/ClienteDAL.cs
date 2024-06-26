﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Modelo
{
    public class ClienteDAL
    {
        ContextoBD con = new ContextoBD();


        #region Agregar Modificar ELiminar Clientes
        //Funcion para guardar un cliente en la base de datos
        public void AgregarCliente(ClienteBE cliente)
        {
            try
            {
                ClienteBE clienteExistente = con.Cliente.FirstOrDefault(c => c.Persona.DNI == cliente.Persona.DNI);

                if (clienteExistente != null)
                {
                    MessageBox.Show("Ya existe un cliente con el DNI ingresado");
                }
                else
                {
                    con.Cliente.Add(cliente);
                    con.SaveChanges();
                    MessageBox.Show("Cliente agregado correctamente");

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar el cliente. " + ex.Message);
            }
        }

        
        //Funcion para eliminar un cliente de la base de datos
        public string EliminarCliente(ClienteBE cliente)
        {
            try
            {
                // Obtener el cliente que se va a "eliminar"
                ClienteBE clienteEliminar = con.Cliente.FirstOrDefault(c => c.Id == cliente.Id);
                if (clienteEliminar != null)
                {
                    // Obtener el ID de la persona asociada
                    int IDpersonaEliminar = clienteEliminar.Persona.Id;

                    // Marcar el estado de activo del cliente como falso
                    clienteEliminar.Persona.EstadoActivo = false;

                    // Guardar los cambios en el cliente
                    con.SaveChanges();

                    // Buscar y "eliminar" la persona asociada
                    PersonaBE personaEliminar = con.Persona.FirstOrDefault(p => p.Id == IDpersonaEliminar);
                    if (personaEliminar != null)
                    {
                        // Marcar el estado de activo de la persona como falso
                        personaEliminar.EstadoActivo = false;

                        // Guardar los cambios en la persona
                        con.SaveChanges();
                    }

                    return "Cliente y persona asociada están con Estado = 'False'";
                }
                else
                {
                    return "No se encontró el cliente a 'eliminar'";
                }
            }
            catch (Exception ex)
            {
                return "No se pudo 'eliminar' el cliente y la persona asociada. " + ex.Message;
            }
        }



        //Funcion para modificar un cliente de la base de datos
        public string ModificarCliente(ClienteBE cliente)
        {
            //Obtener cliente con la funcion ObtenerCliente
            ClienteBE clienteModificar = con.Cliente.Find(cliente.Id);

            //Ahora modificar el cliente
            clienteModificar.Persona.Nombre = cliente.Persona.Nombre;
            clienteModificar.Persona.Apellido = cliente.Persona.Apellido;
            clienteModificar.Persona.DNI = cliente.Persona.DNI;
            clienteModificar.Persona.Direccion = cliente.Persona.Direccion;
            clienteModificar.Persona.Telefono = cliente.Persona.Telefono;
            clienteModificar.Persona.Mail = cliente.Persona.Mail;
            clienteModificar.Persona.FechaNacimiento = cliente.Persona.FechaNacimiento;
            clienteModificar.FechaDeAlta = cliente.FechaDeAlta;
            try
            {
                con.SaveChanges();
                return "Cliente modificado correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo modificar el cliente. " + ex.Message;
            }
        }
        #endregion




         #region Metodos para el DataGridView

        
        


        //Listar los clientes para ponerlos en el data grid view y los datos de las Persona correspondiente a ese cliente
        public void ListarClientesActivosEnDataGridView(DataGridView dataGridView)
        {
            // Limpiamos las filas y columnas existentes en el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // Agregamos las columnas una vez fuera del bucle
            dataGridView.Columns.Add("IdCliente", "ID Cliente");
            dataGridView.Columns.Add("Nombre", "Nombre");
            dataGridView.Columns.Add("Apellido", "Apellido");
            dataGridView.Columns.Add("DNI", "DNI");
            dataGridView.Columns.Add("Direccion", "Direccion");
            dataGridView.Columns.Add("Telefono", "Telefono");
            dataGridView.Columns.Add("Mail", "Mail");
            dataGridView.Columns.Add("Fecha de Nacimiento", "Fecha de Nacimiento");
            dataGridView.Columns.Add("Fecha de Alta", "Fecha de Alta");

            // Obtener la lista de clientes cuya persona asociada tiene EstadoActivo = true
            List<ClienteBE> listaClientesActivos = con.Cliente.ToList().Where(c => c.Persona.EstadoActivo).ToList();

            // Iteramos sobre la lista de clientes activos y agregamos cada cliente al DataGridView
            foreach (var cliente in listaClientesActivos)
            {
                // Agregamos una fila al DataGridView
                int rowIndex = dataGridView.Rows.Add();

                dataGridView.Rows[rowIndex].Cells[0].Value = cliente.Id; // Suponiendo que "IdCliente" es la primera columna agregada
                dataGridView.Rows[rowIndex].Cells[1].Value = cliente.Persona.Nombre; // Suponiendo que "Nombre" es la segunda columna agregada
                dataGridView.Rows[rowIndex].Cells[2].Value = cliente.Persona.Apellido; // y así sucesivamente
                dataGridView.Rows[rowIndex].Cells[3].Value = cliente.Persona.DNI;
                dataGridView.Rows[rowIndex].Cells[4].Value = cliente.Persona.Direccion;
                dataGridView.Rows[rowIndex].Cells[5].Value = cliente.Persona.Telefono;
                dataGridView.Rows[rowIndex].Cells[6].Value = cliente.Persona.Mail;
                dataGridView.Rows[rowIndex].Cells[7].Value = cliente.Persona.FechaNacimiento;
                dataGridView.Rows[rowIndex].Cells[8].Value = cliente.FechaDeAlta;
            }
        }

        
        #endregion

        





        public int ObtenerIdCliente(ClienteBE cliente)
        {
            ClienteBE clienteExistente = con.Cliente.FirstOrDefault(c => c.Persona.DNI == cliente.Persona.DNI);
            if (clienteExistente != null)
            {
                return clienteExistente.Id;
            }
            else
            {
                return -1;
            }
        }

    }
}

