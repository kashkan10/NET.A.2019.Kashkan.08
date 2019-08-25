using System.Collections.Generic;
using BankService.AccountSystem;

namespace BankService.Storage
{
    interface IStorage
    {
        string Path { get; set; }

        void Write(List<Account> accounts);
        void Read(List<Account> accounts);
    }
}
