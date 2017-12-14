namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fourth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Shifts", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shifts", "Name", c => c.String(nullable: false));
        }
    }
}
