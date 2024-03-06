namespace Modelo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearBD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaDeAlta = c.DateTime(nullable: false),
                        Persona_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.Persona_Id)
                .Index(t => t.Persona_Id);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 20),
                        Apellido = c.String(maxLength: 20),
                        DNI = c.String(maxLength: 8),
                        Telefono = c.String(maxLength: 20),
                        Mail = c.String(maxLength: 40),
                        Direccion = c.String(maxLength: 60),
                        FechaNacimiento = c.DateTime(nullable: false, storeType: "date"),
                        EstadoActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Componente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetalleFactura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreProducto = c.String(),
                        CantidadPedida = c.Int(nullable: false),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Impuestos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Factura_Id = c.Int(),
                        Producto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factura", t => t.Factura_Id)
                .ForeignKey("dbo.Producto", t => t.Producto_Id)
                .Index(t => t.Factura_Id)
                .Index(t => t.Producto_Id);
            
            CreateTable(
                "dbo.Factura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Emisor = c.String(),
                        TipoFactura = c.String(),
                        NroFactura = c.Int(nullable: false),
                        FechaEmision = c.DateTime(nullable: false),
                        Estado = c.String(),
                        Empleado_Id = c.Int(),
                        Pedido_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleado", t => t.Empleado_Id)
                .ForeignKey("dbo.Pedido", t => t.Pedido_Id)
                .Index(t => t.Empleado_Id)
                .Index(t => t.Pedido_Id);
            
            CreateTable(
                "dbo.Empleado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Puesto = c.String(),
                        Cargo = c.String(),
                        FechaIngreso = c.DateTime(nullable: false),
                        Persona_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.Persona_Id)
                .Index(t => t.Persona_Id);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NroPedido = c.Int(nullable: false),
                        Estado = c.String(),
                        FechaCreacion = c.DateTime(nullable: false, storeType: "date"),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reserva_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reserva", t => t.Reserva_Id)
                .Index(t => t.Reserva_Id);
            
            CreateTable(
                "dbo.Reserva",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NroReserva = c.Int(nullable: false),
                        FechaLlegada = c.DateTime(nullable: false, storeType: "date"),
                        FechaIda = c.DateTime(nullable: false, storeType: "date"),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Impuestos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.String(),
                        Cliente_Id = c.Int(),
                        Habitacion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id)
                .ForeignKey("dbo.Habitacion", t => t.Habitacion_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Habitacion_Id);
            
            CreateTable(
                "dbo.Habitacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Piso = c.Int(nullable: false),
                        NroHabitacion = c.Int(nullable: false),
                        Estado = c.String(),
                        PrecioDiario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoCamas = c.String(),
                        TipoHabitacion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreProducto = c.String(),
                        CantidadStock = c.Int(nullable: false),
                        PrecioUnitario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetallePedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreProducto = c.String(),
                        CantidadPedida = c.Int(nullable: false),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Impuestos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pedido_Id = c.Int(),
                        Producto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedido", t => t.Pedido_Id)
                .ForeignKey("dbo.Producto", t => t.Producto_Id)
                .Index(t => t.Pedido_Id)
                .Index(t => t.Producto_Id);
            
            CreateTable(
                "dbo.Grupo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Componente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Componente", t => t.Componente_Id)
                .Index(t => t.Componente_Id);
            
            CreateTable(
                "dbo.GrupoComponente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Componente_Id = c.Int(),
                        Grupo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Componente", t => t.Componente_Id)
                .ForeignKey("dbo.Grupo", t => t.Grupo_Id)
                .Index(t => t.Componente_Id)
                .Index(t => t.Grupo_Id);
            
            CreateTable(
                "dbo.Permiso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Componente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Componente", t => t.Componente_Id)
                .Index(t => t.Componente_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Clave = c.String(),
                        Empleado_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleado", t => t.Empleado_Id)
                .Index(t => t.Empleado_Id);
            
            CreateTable(
                "dbo.UsuarioGrupoComponente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Componente_Id = c.Int(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Componente", t => t.Componente_Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Componente_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioGrupoComponente", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioGrupoComponente", "Componente_Id", "dbo.Componente");
            DropForeignKey("dbo.Usuario", "Empleado_Id", "dbo.Empleado");
            DropForeignKey("dbo.Permiso", "Componente_Id", "dbo.Componente");
            DropForeignKey("dbo.GrupoComponente", "Grupo_Id", "dbo.Grupo");
            DropForeignKey("dbo.GrupoComponente", "Componente_Id", "dbo.Componente");
            DropForeignKey("dbo.Grupo", "Componente_Id", "dbo.Componente");
            DropForeignKey("dbo.DetallePedido", "Producto_Id", "dbo.Producto");
            DropForeignKey("dbo.DetallePedido", "Pedido_Id", "dbo.Pedido");
            DropForeignKey("dbo.DetalleFactura", "Producto_Id", "dbo.Producto");
            DropForeignKey("dbo.DetalleFactura", "Factura_Id", "dbo.Factura");
            DropForeignKey("dbo.Factura", "Pedido_Id", "dbo.Pedido");
            DropForeignKey("dbo.Pedido", "Reserva_Id", "dbo.Reserva");
            DropForeignKey("dbo.Reserva", "Habitacion_Id", "dbo.Habitacion");
            DropForeignKey("dbo.Reserva", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.Factura", "Empleado_Id", "dbo.Empleado");
            DropForeignKey("dbo.Empleado", "Persona_Id", "dbo.Persona");
            DropForeignKey("dbo.Cliente", "Persona_Id", "dbo.Persona");
            DropIndex("dbo.UsuarioGrupoComponente", new[] { "Usuario_Id" });
            DropIndex("dbo.UsuarioGrupoComponente", new[] { "Componente_Id" });
            DropIndex("dbo.Usuario", new[] { "Empleado_Id" });
            DropIndex("dbo.Permiso", new[] { "Componente_Id" });
            DropIndex("dbo.GrupoComponente", new[] { "Grupo_Id" });
            DropIndex("dbo.GrupoComponente", new[] { "Componente_Id" });
            DropIndex("dbo.Grupo", new[] { "Componente_Id" });
            DropIndex("dbo.DetallePedido", new[] { "Producto_Id" });
            DropIndex("dbo.DetallePedido", new[] { "Pedido_Id" });
            DropIndex("dbo.Reserva", new[] { "Habitacion_Id" });
            DropIndex("dbo.Reserva", new[] { "Cliente_Id" });
            DropIndex("dbo.Pedido", new[] { "Reserva_Id" });
            DropIndex("dbo.Empleado", new[] { "Persona_Id" });
            DropIndex("dbo.Factura", new[] { "Pedido_Id" });
            DropIndex("dbo.Factura", new[] { "Empleado_Id" });
            DropIndex("dbo.DetalleFactura", new[] { "Producto_Id" });
            DropIndex("dbo.DetalleFactura", new[] { "Factura_Id" });
            DropIndex("dbo.Cliente", new[] { "Persona_Id" });
            DropTable("dbo.UsuarioGrupoComponente");
            DropTable("dbo.Usuario");
            DropTable("dbo.Permiso");
            DropTable("dbo.GrupoComponente");
            DropTable("dbo.Grupo");
            DropTable("dbo.DetallePedido");
            DropTable("dbo.Producto");
            DropTable("dbo.Habitacion");
            DropTable("dbo.Reserva");
            DropTable("dbo.Pedido");
            DropTable("dbo.Empleado");
            DropTable("dbo.Factura");
            DropTable("dbo.DetalleFactura");
            DropTable("dbo.Componente");
            DropTable("dbo.Persona");
            DropTable("dbo.Cliente");
        }
    }
}
