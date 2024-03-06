namespace Modelo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablaBackup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BackUp",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RutaArchivo = c.String(),
                        FechaDeDatos = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BackUp");
        }
    }
}
