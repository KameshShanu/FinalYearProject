namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSomecolumnsdataTypeToStringontrackingdevice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrackingDevice", "InputOrOutput", c => c.String());
            AlterColumn("dbo.TrackingDevice", "Mileage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrackingDevice", "Mileage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.TrackingDevice", "InputOrOutput", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
