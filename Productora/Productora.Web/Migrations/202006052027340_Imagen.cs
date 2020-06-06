namespace Productora.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Imagen : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Artists", "artimg");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artists", "artimg", c => c.Binary());
        }
    }
}
