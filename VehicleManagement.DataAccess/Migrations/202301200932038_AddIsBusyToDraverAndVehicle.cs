namespace VehicleManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsBusyToDraverAndVehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "IsBusy", c => c.Boolean(nullable: false));
            AddColumn("dbo.Vehicles", "IsBusy", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "IsBusy");
            DropColumn("dbo.Drivers", "IsBusy");
        }
    }
}
