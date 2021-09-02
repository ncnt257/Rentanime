namespace Rentanime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedBirthdaypropertyofCustomerstoBirthdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime());
            DropColumn("dbo.Customers", "Birthday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Birthday", c => c.DateTime());
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}
