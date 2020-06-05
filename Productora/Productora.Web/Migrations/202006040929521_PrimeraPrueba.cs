namespace Productora.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeraPrueba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlbumName = c.String(),
                        AlbumDescription = c.String(maxLength: 250),
                        AlbumRelease = c.DateTime(nullable: false),
                        AlbumCover = c.Binary(),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StageName = c.String(maxLength: 25),
                        Email = c.String(nullable: false, maxLength: 45),
                        artimg = c.Binary(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SongTitle = c.String(nullable: false),
                        SongLength = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReleaseYear = c.Int(nullable: false),
                        SongGenre = c.String(maxLength: 30),
                        AlbumId = c.Int(nullable: false),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.AlbumId)
                .Index(t => t.Artist_Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.Songs", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Managers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Artists", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Songs", new[] { "Artist_Id" });
            DropIndex("dbo.Songs", new[] { "AlbumId" });
            DropIndex("dbo.Managers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Artists", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Songs");
            DropTable("dbo.Managers");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
