namespace ProjectResort.Context1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "DateEnd", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "DateEnd", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
