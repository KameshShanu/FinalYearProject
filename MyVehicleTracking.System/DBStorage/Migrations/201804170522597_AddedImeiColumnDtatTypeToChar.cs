namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImeiColumnDtatTypeToChar : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TrackingDevice", "Imei");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrackingDevice", "Imei", c => c.Int(nullable: false));
        }
    }
}
