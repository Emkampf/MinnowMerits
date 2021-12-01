namespace MMRB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WriteUpWork : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wallet", "WriteUp_WriteUpId", c => c.Int());
            AddColumn("dbo.WriteUp", "WalletId", c => c.Int());
            CreateIndex("dbo.Wallet", "WriteUp_WriteUpId");
            CreateIndex("dbo.WriteUp", "WalletId");
            AddForeignKey("dbo.WriteUp", "WalletId", "dbo.Wallet", "WalletId");
            AddForeignKey("dbo.Wallet", "WriteUp_WriteUpId", "dbo.WriteUp", "WriteUpId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wallet", "WriteUp_WriteUpId", "dbo.WriteUp");
            DropForeignKey("dbo.WriteUp", "WalletId", "dbo.Wallet");
            DropIndex("dbo.WriteUp", new[] { "WalletId" });
            DropIndex("dbo.Wallet", new[] { "WriteUp_WriteUpId" });
            DropColumn("dbo.WriteUp", "WalletId");
            DropColumn("dbo.Wallet", "WriteUp_WriteUpId");
        }
    }
}
