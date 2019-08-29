using System;

namespace BankService.AccountSystem
{
    class Account
    {
        private int id;
        private int balance;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="balance"></param>
        /// <param name="cardType"></param>
        public Account(int id, string name, string lastName, int balance, CardType cardType)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Balance = balance;
            Type = cardType;
            Bonus += BonusLogic.Add(balance, cardType);
            Status = Status.Active;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="balance"></param>
        /// <param name="cardType"></param>
        /// <param name="status"></param>
        public Account(int id, string name, string lastName, int balance, CardType cardType, Status status)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Balance = balance;
            Type = cardType;
            Status = status;
            Bonus += BonusLogic.Add(balance, cardType);
        }

        /// <summary>
        /// Id property
        /// </summary>
        public int Id
        {
            get
            {
                return id;
            }
            private set
            {
                if (value < 0)
                    throw new Exception("Id cannot be negative");
                id = value;
            }
        }

        /// <summary>
        /// Name property
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// LastName property
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Balance property
        /// </summary>
        public int Balance
        {
            get
            {
                return balance;
            }
            private set
            {
                if (value < 0)
                    throw new Exception("Balance cannot be negative");
                balance = value;
            }
        }

        /// <summary>
        /// Bonus property
        /// </summary>
        public double Bonus { get; private set; }

        /// <summary>
        /// Status property
        /// </summary>
        public Status Status { get; private set; }

        /// <summary>
        /// Type property
        /// </summary>
        public CardType Type { get; private set; }

        /// <summary>
        /// IsActive property
        /// </summary>
        bool IsActive { get { if (Status == Status.Active) return true; else return false; } }

        /// <summary>
        /// Add sum to account
        /// </summary>
        /// <param name="sum"></param>
        public void AddSum(int sum)
        {
            if (sum < 0)
                throw new ArgumentException("Sum cannot be negative");

            if (IsActive)
            {
                Balance += sum;
                BonusLogic.Add(sum, Type);
            }
            else throw new Exception("Account closed");
        }

        /// <summary>
        /// Withdraw sum from account
        /// </summary>
        /// <param name="sum"></param>
        public void WithdrawSum(int sum)
        {
            if (sum < 0)
                throw new ArgumentException("Sum cannot be negative");

            if (IsActive)
            {
                if (Balance >= sum)
                {
                    Balance -= sum;
                    Bonus = BonusLogic.Withdraw(sum, Type) < Bonus ? Bonus - BonusLogic.Withdraw(sum, Type) : 0;
                }
                else throw new Exception("Account closed");
            }
        }

        /// <summary>
        /// Close account
        /// </summary>
        public void Close()
        {
            Status = Status.Closed;
        }

        /// <summary>
        /// Override of Equals(object obj) method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Equality result</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Account account = obj as Account;
            if (account == null)
                return false;

            return this.Id == account.Id;
        }

        /// <summary>
        /// Override of GetHashCode() method
        /// </summary>
        /// <returns>Hash code of object</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode() + Name.GetHashCode() + LastName.GetHashCode();
        }

        /// <summary>
        /// Override of ToString() method
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return string.Format($"{Name} {LastName} - {Balance}, {Type}({Status})");
        }
    }
}
