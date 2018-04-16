namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDeviceIdColumnToTrackingDeviceTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrackingDevice", "DeviceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrackingDevice", "DeviceId");
        }
    }
}
