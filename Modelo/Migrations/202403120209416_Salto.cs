namespace Modelo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Salto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Salto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Salto");
        }
    }
}
