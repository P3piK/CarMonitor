namespace CarMonitor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consumptions",
                c => new
                    {
                        ConsumptionID = c.Int(nullable: false, identity: true),
                        FuelType = c.Int(nullable: false),
                        Distance = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        TankLevel = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ChangeDate = c.DateTime(),
                        Profile_ProfileID = c.Int(),
                    })
                .PrimaryKey(t => t.ConsumptionID)
                .ForeignKey("dbo.Profiles", t => t.Profile_ProfileID)
                .Index(t => t.Profile_ProfileID);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FuelType = c.Int(nullable: false),
                        TankCapacity = c.Int(nullable: false),
                        Description = c.String(),
                        ChangeDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProfileID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consumptions", "Profile_ProfileID", "dbo.Profiles");
            DropIndex("dbo.Consumptions", new[] { "Profile_ProfileID" });
            DropTable("dbo.Profiles");
            DropTable("dbo.Consumptions");
        }
    }
}
