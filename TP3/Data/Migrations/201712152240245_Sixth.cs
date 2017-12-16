namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sixth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Shift_Id", "dbo.Shifts");
            DropIndex("dbo.Employees", new[] { "Shift_Id" });
            DropPrimaryKey("dbo.Countries");
            AddColumn("dbo.Countries", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Employees", "Shift", c => c.Int(nullable: false));
            AlterColumn("dbo.Countries", "CountryName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Shift_Id", c => c.Int());
            AddPrimaryKey("dbo.Countries", "Id");
            CreateIndex("dbo.Employees", "Shift_Id");
            AddForeignKey("dbo.Employees", "Shift_Id", "dbo.Shifts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Shift_Id", "dbo.Shifts");
            DropIndex("dbo.Employees", new[] { "Shift_Id" });
            DropPrimaryKey("dbo.Countries");
            AlterColumn("dbo.Employees", "Shift_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Countries", "CountryName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Employees", "Shift");
            DropColumn("dbo.Countries", "Id");
            AddPrimaryKey("dbo.Countries", "CountryName");
            CreateIndex("dbo.Employees", "Shift_Id");
            AddForeignKey("dbo.Employees", "Shift_Id", "dbo.Shifts", "Id", cascadeDelete: true);
        }
    }
}
