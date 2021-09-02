namespace Rentanime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedpropertiestoAnimes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Animes", "ReleasedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Animes", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Animes", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Animes", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Animes", "Genre_Id");
            AddForeignKey("dbo.Animes", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animes", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Animes", new[] { "Genre_Id" });
            DropColumn("dbo.Animes", "Genre_Id");
            DropColumn("dbo.Animes", "NumberInStock");
            DropColumn("dbo.Animes", "DateAdded");
            DropColumn("dbo.Animes", "ReleasedDate");
            DropTable("dbo.Genres");
        }
    }
}
