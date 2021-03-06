namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveHomeAddressColumnFromDriverTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Driver", "HomeAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Driver", "HomeAddress", c => c.String());
        }
    }
}
