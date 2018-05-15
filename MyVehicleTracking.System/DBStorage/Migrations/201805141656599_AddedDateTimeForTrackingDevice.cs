namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateTimeForTrackingDevice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NewTrackingDevice", "date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NewTrackingDevice", "date", c => c.DateTime(nullable: false));
        }
    }
}
