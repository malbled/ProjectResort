namespace ProjectResort.Context1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EntryLogs", "Staff_Id", "dbo.Staffs");
            DropIndex("dbo.EntryLogs", new[] { "Staff_Id" });
            AddColumn("dbo.Staffs", "ImagePreview", c => c.Binary(nullable: false));
            DropColumn("dbo.EntryLogs", "Staff_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EntryLogs", "Staff_Id", c => c.Int());
            DropColumn("dbo.Staffs", "ImagePreview");
            CreateIndex("dbo.EntryLogs", "Staff_Id");
            AddForeignKey("dbo.EntryLogs", "Staff_Id", "dbo.Staffs", "Id");
        }
    }
}
