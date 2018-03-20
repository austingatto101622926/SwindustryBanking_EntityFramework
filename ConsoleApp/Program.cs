using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BankingDBHandler;
using SwindustryBanking;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            TestHandler();
            Console.ReadLine();
        }

        public static async void TestHandler()
        {
            //CRUD Using the BankingHandler Class:
            //BankingHandler BankHandle = new BankingHandler("http://localhost:64560/");
            BankingHandler BankHandle = new BankingHandler("http://swindustrybankingapi.azurewebsites.net/");

            //CREATE
            //Creates new account with a balance of 500 and adds it to the database
            Account newAccount = await BankHandle.CreateAccountAsync(500);
            Console.WriteLine("CREATE");
            Console.WriteLine($"AccountID:{newAccount.AccountID}");
            Console.WriteLine($"Balance:{newAccount.Balance}");
            Console.WriteLine();

            //READ
            //Reads the account just created from the database
            Account readAccount = await BankHandle.ReadAccountAsync(newAccount.AccountID);
            Console.WriteLine("READ");
            Console.WriteLine($"AccountID:{readAccount.AccountID}");
            Console.WriteLine($"Balance:{readAccount.Balance}");
            Console.WriteLine();

            //UPDATE
            //Replaces the account in the database with the same id as the account given
            Account replacementAccount = new Account() { AccountID = readAccount.AccountID, Balance = 600 };
            await BankHandle.UpdateAccountAsync(replacementAccount);

            Account replacedAccount = await BankHandle.ReadAccountAsync(replacementAccount.AccountID);
            Console.WriteLine("UPDATE");
            Console.WriteLine($"AccountID:{replacedAccount.AccountID}");
            Console.WriteLine($"Balance:{replacedAccount.Balance}");
            Console.WriteLine();

            //DELETE
            //Deletes the account at the id given
            //Account deletedAccount = await BankHandle.DeleteAccountAsync(replacedAccount.AccountID);
            //Console.WriteLine("DELETE");
            //Console.WriteLine($"Deleted AccountID:{deletedAccount.AccountID}");
            //Console.WriteLine($"Deleted Balance:{deletedAccount.Balance}");
        }
    }
}