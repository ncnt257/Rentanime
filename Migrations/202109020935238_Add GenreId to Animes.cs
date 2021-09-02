namespace Rentanime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreIdtoAnimes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Animes", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Animes", new[] { "Genre_Id" });
            RenameColumn(table: "dbo.Animes", name: "Genre_Id", newName: "GenreId");
            AlterColumn("dbo.Animes", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Animes", "GenreId");
            AddForeignKey("dbo.Animes", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animes", "GenreId", "dbo.Genres");
            DropIndex("dbo.Animes", new[] { "GenreId" });
            AlterColumn("dbo.Animes", "GenreId", c => c.Int());
            RenameColumn(table: "dbo.Animes", name: "GenreId", newName: "Genre_Id");
            CreateIndex("dbo.Animes", "Genre_Id");
            AddForeignKey("dbo.Animes", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
