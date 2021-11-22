namespace MMRB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventSevie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wallet", "ChildId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wallet", "ChildId");
        }
    }
}
