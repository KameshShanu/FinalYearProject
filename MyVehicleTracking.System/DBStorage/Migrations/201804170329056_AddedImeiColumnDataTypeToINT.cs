namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImeiColumnDataTypeToINT : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrackingDevice", "Imei", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrackingDevice", "Imei", c => c.String());
        }
    }
}
