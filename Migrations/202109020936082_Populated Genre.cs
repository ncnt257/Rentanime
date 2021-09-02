namespace Rentanime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatedGenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres(Name) values('Comedy')");
            Sql("insert into Genres(Name) values('Dark')");
            Sql("insert into Genres(Name) values('Fantasy')");
            Sql("insert into Genres(Name) values('Slice of life')");
            Sql("insert into Genres(Name) values('Romantic')");   
        }
        
        public override void Down()
        {
        }
    }
}
