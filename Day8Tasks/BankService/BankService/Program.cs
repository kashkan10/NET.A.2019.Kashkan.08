using System;
using BankService.AccountSystem;
using BankService.Storage;

namespace BankService
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountService service = new AccountService();

            service.CreateAccount(new Account(1, "Nick", "Sop", 2007, CardType.Base));
            service.AddSum(1, 45);
            service.CreateAccount(new Account(2, "Eek", "Koaer", 1999, CardType.Gold));
            service.WithdrawSum(2, 258);
            service.ShowList();
            service.CloseAcc(1);
            service.WriteToStorage(new BinaryStorage());
            Console.WriteLine();

            AccountService service1 = new AccountService();
            service1.LoadFromStorage(new BinaryStorage());
            service1.ShowList();

            Console.Read();
        }
    }
}
