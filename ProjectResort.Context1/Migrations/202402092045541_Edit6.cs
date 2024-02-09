namespace ProjectResort.Context1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderEquipments", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderEquipments", "Equipment_Id", "dbo.Equipments");
            DropIndex("dbo.OrderEquipments", new[] { "Order_Id" });
            DropIndex("dbo.OrderEquipments", new[] { "Equipment_Id" });
            DropTable("dbo.Equipments");
            DropTable("dbo.OrderEquipments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderEquipments",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Equipment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Equipment_Id });
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.OrderEquipments", "Equipment_Id");
            CreateIndex("dbo.OrderEquipments", "Order_Id");
            AddForeignKey("dbo.OrderEquipments", "Equipment_Id", "dbo.Equipments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderEquipments", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
