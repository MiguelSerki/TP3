namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthPointTwo : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Countries");
            AddColumn("dbo.Shifts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Countries", "CountryName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Countries", "CountryName");
            DropColumn("dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Countries", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Countries");
            AlterColumn("dbo.Countries", "CountryName", c => c.String(nullable: false));
            DropColumn("dbo.Shifts", "Name");
            AddPrimaryKey("dbo.Countries", "Id");
        }
    }
}
