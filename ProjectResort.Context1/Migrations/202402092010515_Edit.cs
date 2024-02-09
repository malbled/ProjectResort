namespace ProjectResort.Context1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Staffs", "DateLog");
            DropColumn("dbo.Staffs", "TypeEntry");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "TypeEntry", c => c.Int(nullable: false));
            AddColumn("dbo.Staffs", "DateLog", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
