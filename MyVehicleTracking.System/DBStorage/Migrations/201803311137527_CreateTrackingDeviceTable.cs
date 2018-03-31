namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTrackingDeviceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrackingDevice",
                c => new
                    {
                        TrackingDeviceId = c.Int(nullable: false, identity: true),
                        MassageType = c.String(),
                        Imei = c.String(),
                        DeviceDate = c.DateTime(nullable: false),
                        GPSflag = c.String(),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LatitudeHemisphere = c.String(),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LongitudeHemisphere = c.String(),
                        GroundSpeed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Time = c.DateTime(nullable: false),
                        VehicleAngal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InputOrOutput = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MileageIdentify = c.String(),
                        Mileage = c.Decimal(nullable: false, precision: 18, scale: 2),
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
