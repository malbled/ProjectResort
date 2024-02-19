namespace ProjectResort.Context1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refresh : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "TimeRental", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Services", "ImagePreview");
            DropColumn("dbo.Staffs", "ImagePreview");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "ImagePreview", c => c.Binary(nullable: false));
            AddColumn("dbo.Services", "ImagePreview", c => c.Binary(nullable: false));
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "TimeRental", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
