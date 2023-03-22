namespace BankAccount
{
    internal class BankAccount
    {
        private string _name;
        private double _balance;

        public BankAccount(string name, double balance)
        {
            _name = name;
            _balance = balance;
        }

        public string ShowUserNameAndBalance()
        {
            string newBalance;

            if (_balance < 0)
            {
                newBalance = string.Format("-${0:F2}", -_balance);
            }
            else
            {
                newBalance = string.Format("${0:F2}", _balance);
            }
            return _name + ", " + newBalance;
        }
    }
}