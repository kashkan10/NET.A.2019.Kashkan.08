using System.Collections.Generic;
using System.IO;
using BankService.AccountSystem;

namespace BankService.Storage
{
    class BinaryStorage : IStorage
    {
        /// <summary>
        /// Path property
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BinaryStorage()
        {
            this.Path = "E:\\accounts.dat";
        }

        /// <summary>
        /// Custom constructor
        /// </summary>
        /// <param name="path"></param>
        public BinaryStorage(string path)
        {
            this.Path = path;
        }

        /// <summary>
        /// Write list to storage
        /// </summary>
        /// <param name="accounts"></param>
        public void Write(List<Account> accounts)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(Path, FileMode.OpenOrCreate)))
            {
                foreach (Account s in accounts)
                {
                    writer.Write(s.Id);
                    writer.Write(s.Name);
                    writer.Write(s.LastName);
                    writer.Write(s.Balance);
                    writer.Write((int)s.Type);
                    writer.Write((int)s.Status);
                }
            }
        }

        /// <summary>
        /// Load list from storage
        /// </summary>
        /// <param name="accounts"></param>
        public void Read(List<Account> accounts)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(Path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    int id = reader.ReadInt32();
                    string name = reader.ReadString();
                    string lastName = reader.ReadString();
                    int balance = reader.ReadInt32();
                    CardType type = (CardType)reader.ReadInt32();
                    Status status = (Status)reader.ReadInt32();

                    accounts.Add(new Account(id, name, lastName, balance, type, status));
                }
            }
        }
    }
}
