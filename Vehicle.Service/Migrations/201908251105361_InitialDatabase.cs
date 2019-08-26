namespace Vehicle.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleMakes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Abrv = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Abrv = c.String(nullable: false, maxLength: 100),
                        VehicleMakeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleMakes", t => t.VehicleMakeId)
                .Index(t => t.VehicleMakeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleModels", "VehicleMakeId", "dbo.VehicleMakes");
            DropIndex("dbo.VehicleModels", new[] { "VehicleMakeId" });
            DropTable("dbo.VehicleModels");
            DropTable("dbo.VehicleMakes");
        }
    }
}
