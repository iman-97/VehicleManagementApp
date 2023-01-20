namespace VehicleManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompleteTravel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompleteTravels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TravelId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CompleteTravels");
        }
    }
}
