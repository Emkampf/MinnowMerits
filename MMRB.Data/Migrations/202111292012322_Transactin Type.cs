namespace MMRB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactinType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "TransactionType", c => c.Int(nullable: false));
            DropColumn("dbo.Transaction", "TypeTransaction");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "TypeTransaction", c => c.Int(nullable: false));
            DropColumn("dbo.Event", "TransactionType");
        }
    }
}
