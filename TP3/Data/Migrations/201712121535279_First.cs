namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CountryName);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false),
                        HireDate = c.DateTime(),
                        Shift_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Shifts", t => t.Shift_Id, cascadeDelete: true)
                .Index(t => t.Shift_Id);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.Int(nullable: false),
                        Finish = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Shift_Id", "dbo.Shifts");
            DropIndex("dbo.Employees", new[] { "Shift_Id" });
            DropTable("dbo.Shifts");
            DropTable("dbo.Employees");
            DropTable("dbo.Countries");
        }
    }
}
