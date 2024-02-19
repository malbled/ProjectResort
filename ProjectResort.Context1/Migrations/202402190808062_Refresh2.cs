namespace ProjectResort.Context1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refresh2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "Image", c => c.Binary(nullable: true));
            AddColumn("dbo.Staffs", "Image", c => c.Binary(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staffs", "Image");
            DropColumn("dbo.Services", "Image");
        }
    }
}
