namespace MMRB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedwriteuptowallet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wallet", "WriteUpId", c => c.Int());
            CreateIndex("dbo.Wallet", "WriteUpId");
            AddForeignKey("dbo.Wallet", "WriteUpId", "dbo.WriteUp", "WriteUpId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wallet", "WriteUpId", "dbo.WriteUp");
            DropIndex("dbo.Wallet", new[] { "WriteUpId" });
            DropColumn("dbo.Wallet", "WriteUpId");
        }
    }
}
