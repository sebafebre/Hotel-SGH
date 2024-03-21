namespace Modelo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Auditoria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CambioHistorico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaModificacion = c.DateTime(nullable: false),
                        Operacion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetallePedidoHistorico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreProducto = c.String(),
                        CantidadPedida = c.Int(nullable: false),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Impuestos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductoId = c.Int(nullable: false),
                        PedidoId = c.Int(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        Operacion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FacturaHistorico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Emisor = c.String(),
                        TipoFactura = c.String(),
                        NroFactura = c.Int(nullable: false),
                        FechaEmision = c.DateTime(nullable: false),
                        Estado = c.String(),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Impuestos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmpleadoId = c.Int(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        Operacion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PedidoHistorico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NroPedido = c.Int(nullable: false),
                        Estado = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Impuestos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReservaId = c.Int(nullable: false),
                        FacturaId = c.Int(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        Operacion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PedidoHistorico");
            DropTable("dbo.FacturaHistorico");
            DropTable("dbo.DetallePedidoHistorico");
            DropTable("dbo.CambioHistorico");
        }
    }
}
