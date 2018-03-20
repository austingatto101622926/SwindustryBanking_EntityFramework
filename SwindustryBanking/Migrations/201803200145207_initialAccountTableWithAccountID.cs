namespace SwindustryBanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialAccountTableWithAccountID : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AccountID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accounts");
        }
    }
}
