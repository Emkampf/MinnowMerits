namespace MMRB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingWalletId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "WalletId", c => c.Int());
            CreateIndex("dbo.Transaction", "WalletId");
            AddForeignKey("dbo.Transaction", "WalletId", "dbo.Wallet", "WalletId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "WalletId", "dbo.Wallet");
            DropIndex("dbo.Transaction", new[] { "WalletId" });
            DropColumn("dbo.Transaction", "WalletId");
        }
    }
}
