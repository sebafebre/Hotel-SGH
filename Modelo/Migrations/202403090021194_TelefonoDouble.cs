namespace Modelo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TelefonoDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Persona", "Telefono", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Persona", "Telefono", c => c.Int(nullable: false));
        }
    }
}
