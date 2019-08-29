using BankService.Storage;
using System;
using System.Collections.Generic;

namespace BankService.AccountSystem
{
    class AccountService
    {
        /// <summary>
        /// List of accounts
        /// </summary>
        private List<Account> accounts;

        /// <summary>
        /// Default constructor
        /// </summary>
        public AccountService()
        {
            accounts = new List<Account>();
        }

        /// <summary>
        /// Custom constructor
        /// </summary>
        /// <param name="list"></param>
        public AccountService(List<Account> list)
        {
            this.accounts = list;
        }

        /// <summary>
        /// Create new account 
        /// </summary>
        /// <param name="account"></param>
        public void CreateAccount(Account account)
        {
            if (!accounts.Contains(account))
                accounts.Add(account);
            else throw new Exception("Account already exists");
        }

        /// <summary>
        /// Add sum to account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sum"></param>
        public void AddSum(int id, int sum)
        {
            Account account = accounts.Find(acc => acc.Id == id);
            CheckExistOfAcc(account);
            account.AddSum(sum);
        }

        /// <summary>
        /// Withdraw sum from account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sum"></param>
        public void WithdrawSum(int id, int sum)
        {
            Account account = accounts.Find(acc => acc.Id == id);
            CheckExistOfAcc(account);
            account.WithdrawSum(sum);
        }

        /// <summary>
        /// Close account
        /// </summary>
        /// <param name="id"></param>
        public void CloseAcc(int id)
        {
            Account account = accounts.Find(acc => acc.Id == id);
            CheckExistOfAcc(account);
            account.Close();
        }

        /// <summary>
        /// Show list of accounts on the console
        /// </summary>
        public void ShowList()
        {
            foreach (Account account in accounts)
            {
                Console.WriteLine(account.ToString());
            }
        }

        /// <summary>
        /// Write list to storage
        /// </summary>
        /// <param name="storage"></param>
        public void WriteToStorage(IStorage storage)
        {
            storage.Write(accounts);
        }

        /// <summary>
        /// Load List from storage
        /// </summary>
        /// <param name="storage"></param>
        public void LoadFromStorage(IStorage storage)
        {
            storage.Read(accounts);
        }

        /// <summary>
        /// Check for account existence
        /// </summary>
        private void CheckExistOfAcc(Account account)
        {
            if (!accounts.Contains(account))
                throw new Exception("Account not found");
        }
    }
}
