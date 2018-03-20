namespace SwindustryBanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountBalance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Balance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "Balance");
        }
    }
}
