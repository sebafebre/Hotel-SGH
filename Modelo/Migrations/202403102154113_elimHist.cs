namespace Modelo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class elimHist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetallePedidoHistorico", "PedidoId", "dbo.Pedido");
            DropForeignKey("dbo.DetallePedidoHistorico", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.FacturaHistorico", "EmpleadoId", "dbo.Empleado");
            DropForeignKey("dbo.PedidoHistorico", "FacturaId", "dbo.Factura");
            DropForeignKey("dbo.PedidoHistorico", "ReservaId", "dbo.Reserva");
            DropIndex("dbo.DetallePedidoHistorico", new[] { "ProductoId" });
            DropIndex("dbo.DetallePedidoHistorico", new[] { "PedidoId" });
            DropIndex("dbo.FacturaHistorico", new[] { "EmpleadoId" });
            DropIndex("dbo.PedidoHistorico", new[] { "ReservaId" });
            DropIndex("dbo.PedidoHistorico", new[] { "FacturaId" });
            DropTable("dbo.CambioHistorico");
            DropTable("dbo.FacturaHistorico");
        }
        
        public override void Down()
        {
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
                        EmpleadoId = c.Int(),
                        FechaModificacion = c.DateTime(nullable: false),
                        Operacion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CambioHistorico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaModificacion = c.DateTime(nullable: false),
                        Operacion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.PedidoHistorico", "FacturaId");
            CreateIndex("dbo.PedidoHistorico", "ReservaId");
            CreateIndex("dbo.FacturaHistorico", "EmpleadoId");
            CreateIndex("dbo.DetallePedidoHistorico", "PedidoId");
            CreateIndex("dbo.DetallePedidoHistorico", "ProductoId");
            AddForeignKey("dbo.PedidoHistorico", "ReservaId", "dbo.Reserva", "Id");
            AddForeignKey("dbo.PedidoHistorico", "FacturaId", "dbo.Factura", "Id");
            AddForeignKey("dbo.FacturaHistorico", "EmpleadoId", "dbo.Empleado", "Id");
            AddForeignKey("dbo.DetallePedidoHistorico", "ProductoId", "dbo.Producto", "Id");
            AddForeignKey("dbo.DetallePedidoHistorico", "PedidoId", "dbo.Pedido", "Id");
        }
    }
}
