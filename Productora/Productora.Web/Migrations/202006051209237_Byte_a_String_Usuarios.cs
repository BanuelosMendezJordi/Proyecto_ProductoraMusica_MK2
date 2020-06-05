namespace Productora.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Byte_a_String_Usuarios : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Artists", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Artists", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            AddColumn("dbo.Albums", "Album_Cover", c => c.String());
            DropColumn("dbo.Albums", "AlbumCover");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "AlbumCover", c => c.Binary());
            DropColumn("dbo.Albums", "Album_Cover");
            RenameIndex(table: "dbo.Artists", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Artists", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
