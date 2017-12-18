namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class otramigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkingDays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Day = c.DateTime(nullable: false),
                        Entry = c.DateTime(nullable: false),
                        Exit = c.DateTime(nullable: false),
                        Hours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Employee_EmployeeID = c.Int(nullable: false),
                        WorkingMonth_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.WorkingMonths", t => t.WorkingMonth_ID)
                .Index(t => t.Employee_EmployeeID)
                .Index(t => t.WorkingMonth_ID);
            
            CreateTable(
                "dbo.WorkingMonths",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Month = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkingDays", "WorkingMonth_ID", "dbo.WorkingMonths");
            DropForeignKey("dbo.WorkingDays", "Employee_EmployeeID", "dbo.Employees");
            DropIndex("dbo.WorkingDays", new[] { "WorkingMonth_ID" });
            DropIndex("dbo.WorkingDays", new[] { "Employee_EmployeeID" });
            DropTable("dbo.WorkingMonths");
            DropTable("dbo.WorkingDays");
        }
    }
}
