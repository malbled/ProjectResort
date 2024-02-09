namespace ProjectResort.Context1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntryLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateLog = c.DateTimeOffset(nullable: false, precision: 7),
                        StaffKod = c.String(nullable: false),
                        TypeEntry = c.Int(nullable: false),
                        Staff_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Staffs", t => t.Staff_Id)
                .Index(t => t.Staff_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntryLogs", "Staff_Id", "dbo.Staffs");
            DropIndex("dbo.EntryLogs", new[] { "Staff_Id" });
            DropTable("dbo.EntryLogs");
        }
    }
}
