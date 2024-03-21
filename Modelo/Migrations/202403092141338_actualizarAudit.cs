namespace Modelo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizarAudit : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.DetallePedidoHistorico", "ProductoId");
            CreateIndex("dbo.DetallePedidoHistorico", "PedidoId");
            CreateIndex("dbo.FacturaHistorico", "EmpleadoId");
            CreateIndex("dbo.PedidoHistorico", "ReservaId");
            CreateIndex("dbo.PedidoHistorico", "FacturaId");
            AddForeignKey("dbo.DetallePedidoHistorico", "PedidoId", "dbo.Pedido", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DetallePedidoHistorico", "ProductoId", "dbo.Producto", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FacturaHistorico", "EmpleadoId", "dbo.Empleado", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PedidoHistorico", "FacturaId", "dbo.Factura", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PedidoHistorico", "ReservaId", "dbo.Reserva", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoHistorico", "ReservaId", "dbo.Reserva");
            DropForeignKey("dbo.PedidoHistorico", "FacturaId", "dbo.Factura");
            DropForeignKey("dbo.FacturaHistorico", "EmpleadoId", "dbo.Empleado");
            DropForeignKey("dbo.DetallePedidoHistorico", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.DetallePedidoHistorico", "PedidoId", "dbo.Pedido");
            DropIndex("dbo.PedidoHistorico", new[] { "FacturaId" });
            DropIndex("dbo.PedidoHistorico", new[] { "ReservaId" });
            DropIndex("dbo.FacturaHistorico", new[] { "EmpleadoId" });
            DropIndex("dbo.DetallePedidoHistorico", new[] { "PedidoId" });
            DropIndex("dbo.DetallePedidoHistorico", new[] { "ProductoId" });
        }
    }
}
