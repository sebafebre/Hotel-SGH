using System;
using System.Collections.Generic;
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
        //ContextoBD = Singleton
        static ContextoBD instance;
        // Constructor is 'protected'

        public static ContextoBD Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (instance == null)
            {
                instance = new ContextoBD();
            }
            return instance;
        }
        #endregion

        protected ContextoBD() : base("BD")
        {
            /*
            if (!Database.Exists("BD"))
                Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());*/
        }

        #region Entidades Seguridad
        public DbSet<GrupoBE> Grupo { get; set; }
        public DbSet<PermisoBE> Permiso { get; set; }
        public DbSet<UsuarioBE> Usuario { get; set; }
        public DbSet<UsuarioGrupoBE> UsuarioGrupo { get; set; }
        public DbSet<GrupoPermisoBE> GrupoPermiso { get; set; }
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
        #endregion

        
        //public DbSet<ComponenteBE> Componente { get; set; }



    }

}
