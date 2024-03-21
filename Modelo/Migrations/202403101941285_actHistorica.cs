namespace Modelo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actHistorica : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetallePedidoHistorico", "DetallePedidoId", c => c.Int());
            AddColumn("dbo.PedidoHistorico", "PedidoId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PedidoHistorico", "PedidoId");
            DropColumn("dbo.DetallePedidoHistorico", "DetallePedidoId");
        }
    }
}
