namespace Firm
{
    class Commission : Hourly
    {
        private double totalSalesEmpolyeeMade;
        private double commissionRateForEmployee;

        public Commission(string eName, string eAddress, string ePhone, string socSecNumber, double rate, double commissionRate) : base(eName, eAddress, ePhone, socSecNumber, rate)
        {
            totalSalesEmpolyeeMade = 0;
            this.commissionRateForEmployee = commissionRate;
        }

        public void AddSales(double totalSales)
        {
            totalSalesEmpolyeeMade += totalSales;
        }

        public override double Pay()
        {
            double pay = base.Pay();
            double comPay = totalSalesEmpolyeeMade * commissionRateForEmployee;
            totalSalesEmpolyeeMade = 0;
            return pay + comPay;
        }

        public override string ToString()
        {
            string hour = base.ToString();
            return $"{hour}\nTotal Sales: {totalSalesEmpolyeeMade}";
        }
    }
}
