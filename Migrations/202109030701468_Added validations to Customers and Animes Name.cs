namespace Rentanime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedvalidationstoCustomersandAnimesName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animes", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String());
            AlterColumn("dbo.Animes", "Name", c => c.String());
        }
    }
}
