namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDeviceIdToTrackingDeviceTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrackingDevice", "DeviceId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrackingDevice", "DeviceId");
        }
    }
}
