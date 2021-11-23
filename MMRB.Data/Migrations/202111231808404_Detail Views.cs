namespace MMRB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetailViews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "TypeTransaction", c => c.Int(nullable: false));
            AddColumn("dbo.Wallet", "BirthDay", c => c.Int(nullable: false));
            DropColumn("dbo.Wallet", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wallet", "BirthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Wallet", "BirthDay");
            DropColumn("dbo.Transaction", "TypeTransaction");
        }
    }
}
