namespace VehicleManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTravelStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Travels", "TravelStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Travels", "TravelStatus");
        }
    }
}
