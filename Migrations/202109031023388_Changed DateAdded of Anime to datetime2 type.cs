namespace Rentanime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDateAddedofAnimetodatetime2type : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animes", "ReleasedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animes", "ReleasedDate", c => c.DateTime(nullable: false));
        }
    }
}
