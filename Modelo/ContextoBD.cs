using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Entidades;
using Entidades.Seguridad;

namespace Modelo
{
    public partial class ContextoBD : DbContext
    {

        #region Singleton 
        /*
        //ContextoBD = Singleton
        static ContextoBD instance;
        // Constructor is 'protected'

        public static ContextoBD Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (instance == null || instance.Database.Connection.State == ConnectionState.Closed )
            {
                instance = new ContextoBD();
            }
            return instance;
        }*/
        /*
        public static ContextoBD instance;
        private static readonly object lockObject = new object();

        public static ContextoBD Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ContextoBD();
                    }
                    return instance;
                }
            }
        }
        */


        #endregion

        public ContextoBD() : base("pruebaComponente2")
        {
            /*
            if (!Database.Exists("BD"))
                Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());*/
        }

        #region Entidades Seguridad
        public DbSet<ComponenteBE> Componente { get; set; }
        public DbSet<GrupoBE> Grupo { get; set; }
        public DbSet<PermisoBE> Permiso { get; set; }
        public DbSet<UsuarioBE> Usuario { get; set; }
        public DbSet<UsuarioGrupoComponenteBE> UsuarioGrupoComponente { get; set; }
        public DbSet<GrupoComponenteBE> GrupoComponente { get; set; }
        #endregion

        #region Entidades

        public DbSet<PersonaBE> Persona { get; set; }


        public DbSet<ClienteBE> Cliente { get; set; }
        public DbSet<EmpleadoBE> Empleado { get; set; }
        public DbSet<ProductoBE> Producto { get; set; }
        public DbSet<DetallePedidoBE> DetallePedido { get; set; }
        public DbSet<PedidoBE> Pedido { get; set; }
        public DbSet<DetalleFacturaBE> DetalleFactura { get; set; }
        public DbSet<FacturaBE> Factura { get; set; }
        public DbSet<HabitacionBE> Habitacion { get; set; }
        public DbSet<ReservaBE> Reserva { get; set; }


        public DbSet<BackupBE> Backup { get; set; }
        #endregion

        



    }

}
