namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewTrackingDeviceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrackingDevice",
                c => new
                    {
                        TrackingDeviceId = c.Int(nullable: false, identity: true),
                        device_Id = c.String(),
                        massage_type = c.String(),
                        imei = c.String(),
                        date = c.DateTime(),
                        GPS_flag = c.String(),
                        Latitude = c.Double(nullable: false),
                        Latitude_hemisphere = c.String(),
                        Longitude = c.Double(nullable: false),
                        Longitude_hemisphere = c.String(),
                        Ground_speed = c.Double(nullable: false),
                        Vehicle_angal = c.Double(nullable: false),
                        input_output = c.String(),
                        mileage_identify = c.String(),
                        mileage = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Vehicle_VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.TrackingDeviceId)
                .ForeignKey("dbo.Vehicle", t => t.Vehicle_VehicleId)
                .Index(t => t.Vehicle_VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrackingDevice", "Vehicle_VehicleId", "dbo.Vehicle");
            DropIndex("dbo.TrackingDevice", new[] { "Vehicle_VehicleId" });
            DropTable("dbo.TrackingDevice");
        }
    }
}
