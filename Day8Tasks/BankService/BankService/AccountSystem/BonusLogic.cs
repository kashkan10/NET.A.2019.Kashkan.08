namespace BankService.AccountSystem
{
    class BonusLogic
    {
        /// <summary>
        /// Add bonus logic
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="type"></param>
        /// <returns>Sum to add</returns>
        public static double Add(int sum, CardType type)
        {
            return sum * (int)type / 100;
        }

        /// <summary>
        /// Withdraw bonus logic
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="type"></param>
        /// <returns>Sum to withdraw</returns>
        public static double Withdraw(int sum, CardType type)
        {
            return sum * (int)type / 200;
        }
    }
}
