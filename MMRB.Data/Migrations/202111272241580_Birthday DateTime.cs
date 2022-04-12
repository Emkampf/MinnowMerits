namespace MMRB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthdayDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Wallet", "BirthDay", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Wallet", "BirthDay", c => c.Int(nullable: false));
        }
    }
}
