namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fifth : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Countries");
            AddColumn("dbo.Countries", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Countries", "CountryName", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Countries");
            AlterColumn("dbo.Countries", "CountryName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Countries", "Id");
            AddPrimaryKey("dbo.Countries", "CountryName");
        }
    }
}
