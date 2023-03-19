using System;

namespace exercise_1
{
    internal class Product
    {
        private double _price;
        private int _amount;
        private string _name; 

        public Product(string name, double priceAtStart, int amountAtStart)
        {
            _price = priceAtStart;
            _amount = amountAtStart;
            _name = name;
        }

        public void PrintProduct()
        {
            string printedText = string.Format("{0}, price {1}, amount {2}", _name, _price, _amount);
            Console.WriteLine(printedText);
        }

        public void AmountChange(int newAmount)
        {
            _amount = newAmount;
        }

        public void PriceChanged(double newPrice)
        {
            _price = newPrice;
        }
    }
}
