namespace ProjectResort.Context1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KOD = c.Int(nullable: false),
                        FIO = c.String(nullable: false),
                        Passport = c.String(nullable: false),
                        DateBirth = c.DateTimeOffset(nullable: false, precision: 7),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KOD = c.String(nullable: false),
                        DateAdd = c.DateTimeOffset(nullable: false, precision: 7),
                        ClientKod = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        DateEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        TimeRental = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        KOD = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImagePreview = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Post = c.Int(nullable: false),
                        FIO = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        DateLog = c.DateTimeOffset(nullable: false, precision: 7),
                        TypeEntry = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderEquipments",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Equipment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Equipment_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Equipment_Id);
            
            CreateTable(
                "dbo.ServiceOrders",
                c => new
                    {
                        Service_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_Id, t.Order_Id })
                .ForeignKey("dbo.Services", t => t.Service_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Service_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ServiceOrders", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.OrderEquipments", "Equipment_Id", "dbo.Equipments");
            DropForeignKey("dbo.OrderEquipments", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Clients");
            DropIndex("dbo.ServiceOrders", new[] { "Order_Id" });
            DropIndex("dbo.ServiceOrders", new[] { "Service_Id" });
            DropIndex("dbo.OrderEquipments", new[] { "Equipment_Id" });
            DropIndex("dbo.OrderEquipments", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            DropTable("dbo.ServiceOrders");
            DropTable("dbo.OrderEquipments");
            DropTable("dbo.Staffs");
            DropTable("dbo.Services");
            DropTable("dbo.Orders");
            DropTable("dbo.Equipments");
            DropTable("dbo.Clients");
        }
    }
}
