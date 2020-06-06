namespace Productora.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagenString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "artimg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "artimg");
        }
    }
}
