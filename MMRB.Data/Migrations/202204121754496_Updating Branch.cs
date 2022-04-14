namespace MMRB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingBranch : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "WalletId", "dbo.Wallet");
            DropForeignKey("dbo.WriteUp", "WalletId", "dbo.Wallet");
            DropForeignKey("dbo.Wallet", "WriteUp_WriteUpId", "dbo.WriteUp");
            DropIndex("dbo.Transaction", new[] { "WalletId" });
            DropIndex("dbo.Wallet", new[] { "WriteUp_WriteUpId" });
            DropIndex("dbo.WriteUp", new[] { "WalletId" });
            AlterColumn("dbo.Wallet", "BirthDay", c => c.Int(nullable: false));
            DropColumn("dbo.Transaction", "WalletId");
            DropColumn("dbo.Wallet", "WriteUp_WriteUpId");
            DropColumn("dbo.WriteUp", "WalletId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WriteUp", "WalletId", c => c.Int());
            AddColumn("dbo.Wallet", "WriteUp_WriteUpId", c => c.Int());
            AddColumn("dbo.Transaction", "WalletId", c => c.Int());
            AlterColumn("dbo.Wallet", "BirthDay", c => c.DateTime(nullable: false));
            CreateIndex("dbo.WriteUp", "WalletId");
            CreateIndex("dbo.Wallet", "WriteUp_WriteUpId");
            CreateIndex("dbo.Transaction", "WalletId");
            AddForeignKey("dbo.Wallet", "WriteUp_WriteUpId", "dbo.WriteUp", "WriteUpId");
            AddForeignKey("dbo.WriteUp", "WalletId", "dbo.Wallet", "WalletId");
            AddForeignKey("dbo.Transaction", "WalletId", "dbo.Wallet", "WalletId");
        }
    }
}
