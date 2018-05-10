namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewTrackingDeviceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewTrackingDevice",
                c => new
                    {
                        TrackingDeviceId = c.Int(nullable: false, identity: true),
                        device_Id = c.String(),
                        massage_type = c.String(),
                        imei = c.String(),
                        date = c.DateTime(nullable: false),
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
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TrackingDeviceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewTrackingDevice");
        }
    }
}
