namespace Productora.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "FirstName", c => c.String());
            AddColumn("dbo.Artists", "LastName", c => c.String());
            DropColumn("dbo.Artists", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artists", "Email", c => c.String(nullable: false, maxLength: 45));
            DropColumn("dbo.Artists", "LastName");
            DropColumn("dbo.Artists", "FirstName");
        }
    }
}
