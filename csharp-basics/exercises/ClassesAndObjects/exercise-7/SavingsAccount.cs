namespace exercise_7
{
    class SavingsAccount
    {
        private double _rate;
        private double _balance;

        public SavingsAccount(double amountOfBalance)
        {
            _balance = amountOfBalance;
        }

        public void SubtractingAmountOfDeposit(double amount)
        {
            _balance -= amount;
        }

        public void AddingAmountOfDeposit(double amount)
        {
            _balance += amount;
        }

        public void AddingAmountOfInterest()
        {
            double interestRate = _rate / 12;
            double interest = _balance * interestRate;
            _balance += interest;
        }

        public double GetBalance()
        {
            return _balance;
        }

        public void SetInterestRate(double rate)
        {
            _rate = rate;
        }
    }
}
