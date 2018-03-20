using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using SwindustryBanking;

namespace BankingDBHandler
{
    public class BankingHandler
    {
        HttpClient client;

        public BankingHandler(string baseAddress)
        {

            client = new HttpClient() { BaseAddress = new Uri(baseAddress) };
        }
                
        
        public async Task<Account> ReadAccountAsync(int accountID)
        {
            Account account = null;
            HttpResponseMessage response = await client.GetAsync($"api/accounts/{accountID}");
            if (response.IsSuccessStatusCode)
            {
                account = await response.Content.ReadAsAsync<Account>();
            }
            return account;
        }

        public async Task UpdateAccountAsync(Account account)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/accounts/{account.AccountID}", account);
            response.EnsureSuccessStatusCode();
        }

        public async Task<Account> CreateAccountAsync(double balance)
        {
            Account account = new Account { Balance = balance };

            HttpResponseMessage response = await client.PostAsJsonAsync($"api/accounts", account);
            if (response.IsSuccessStatusCode)
            {
                account = await response.Content.ReadAsAsync<Account>();
            }
            return account;
        }

        public async Task<Account> DeleteAccountAsync(int accountID)
        {
            Account account = null;
            HttpResponseMessage response = await client.DeleteAsync($"api/accounts/{accountID}");
            if (response.IsSuccessStatusCode)
            {
                account = await response.Content.ReadAsAsync<Account>();
            }
            return account;
        }
    }
}
