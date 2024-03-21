namespace Modelo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizarFKs : DbMigration
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
            AlterColumn("dbo.DetallePedidoHistorico", "ProductoId", c => c.Int());
            AlterColumn("dbo.DetallePedidoHistorico", "PedidoId", c => c.Int());
            AlterColumn("dbo.FacturaHistorico", "EmpleadoId", c => c.Int());
            AlterColumn("dbo.PedidoHistorico", "ReservaId", c => c.Int());
            AlterColumn("dbo.PedidoHistorico", "FacturaId", c => c.Int());
            CreateIndex("dbo.DetallePedidoHistorico", "ProductoId");
            CreateIndex("dbo.DetallePedidoHistorico", "PedidoId");
            CreateIndex("dbo.FacturaHistorico", "EmpleadoId");
            CreateIndex("dbo.PedidoHistorico", "ReservaId");
            CreateIndex("dbo.PedidoHistorico", "FacturaId");
            AddForeignKey("dbo.DetallePedidoHistorico", "PedidoId", "dbo.Pedido", "Id");
            AddForeignKey("dbo.DetallePedidoHistorico", "ProductoId", "dbo.Producto", "Id");
            AddForeignKey("dbo.FacturaHistorico", "EmpleadoId", "dbo.Empleado", "Id");
            AddForeignKey("dbo.PedidoHistorico", "FacturaId", "dbo.Factura", "Id");
            AddForeignKey("dbo.PedidoHistorico", "ReservaId", "dbo.Reserva", "Id");
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
            AlterColumn("dbo.PedidoHistorico", "FacturaId", c => c.Int(nullable: false));
            AlterColumn("dbo.PedidoHistorico", "ReservaId", c => c.Int(nullable: false));
            AlterColumn("dbo.FacturaHistorico", "EmpleadoId", c => c.Int(nullable: false));
            AlterColumn("dbo.DetallePedidoHistorico", "PedidoId", c => c.Int(nullable: false));
            AlterColumn("dbo.DetallePedidoHistorico", "ProductoId", c => c.Int(nullable: false));
            CreateIndex("dbo.PedidoHistorico", "FacturaId");
            CreateIndex("dbo.PedidoHistorico", "ReservaId");
            CreateIndex("dbo.FacturaHistorico", "EmpleadoId");
            CreateIndex("dbo.DetallePedidoHistorico", "PedidoId");
            CreateIndex("dbo.DetallePedidoHistorico", "ProductoId");
            AddForeignKey("dbo.PedidoHistorico", "ReservaId", "dbo.Reserva", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PedidoHistorico", "FacturaId", "dbo.Factura", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FacturaHistorico", "EmpleadoId", "dbo.Empleado", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DetallePedidoHistorico", "ProductoId", "dbo.Producto", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DetallePedidoHistorico", "PedidoId", "dbo.Pedido", "Id", cascadeDelete: true);
        }
    }
}
