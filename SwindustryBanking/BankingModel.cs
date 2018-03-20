namespace SwindustryBanking
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;

    public class BankingModel : DbContext
    {
        // Your context has been configured to use a 'BankingModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SwindustryBanking.BankingModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BankingModel' 
        // connection string in the application configuration file.
        public BankingModel()
            : base("name=AzureDatabase")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Account> Accounts { get; set; }
    }

    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        public double Balance { get; set; }
    }
}