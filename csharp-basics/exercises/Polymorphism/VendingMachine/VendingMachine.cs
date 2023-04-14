using System;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace VendingMachine
{
    public class VendingMachine : IVendingMachine
    {
        private string _manufacturerName;
        private Product[] _products;
        private Money _moneyAmount;
        private bool _hasProducts;

        public VendingMachine(string manufacturerName, Product[] products)
        {
            _manufacturerName = manufacturerName;
            _products = products;
        }

        public string Manufacturer
        {
            get { return _manufacturerName; }
        }

        bool IVendingMachine.HasProducts => Products.Any(p => p.Available > 0);

        public Money Amount
        {
            get { return _moneyAmount; }
        }

        public Product[] Products
        {
            get { return _products; }
            set { _products = value; }
        }    

        public Money InsertCoin(Money amount)
        {
            int cents = _moneyAmount.Cents + amount.Cents;
            int euros = _moneyAmount.Euros + amount.Euros + cents / 100;
            cents %= 100;
            _moneyAmount.Euros = euros;
            _moneyAmount.Cents = cents;
            return _moneyAmount;
        }

        public Money ReturnMoney()
        {
            Money returnMoney = _moneyAmount;
            _moneyAmount = new Money();
            return new Money { Euros = returnMoney.Euros, Cents = returnMoney.Cents };
        }

        public bool ValidatePrice(Money price)
        {
            if(price.Euros < 0 || price.Cents < 0 || price.Cents >= 100)
            {
                throw new InvalidPriceException();
            }
            
            return true; 
        }

        public bool AddProduct(string productName, Money price, int productsCount)
        {
            if (string.IsNullOrWhiteSpace(productName) || productsCount <= 0 || !ValidatePrice(price))
            {
                throw new InvalidInputException();
            }
            
            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i].Available == 0)
                {
                    _products[i] = new Product { Name = productName, Price = price, Available = productsCount };
                    return true;
                }
            }

            throw new ProductOutOfStockException();
        }

        public bool UpdateProduct(int oneProduct, string productName, Money? price, int amount)
        {
            if(oneProduct >= 0 && oneProduct < _products.Length) 
            {
                if(productName != null)
                {
                    _products[oneProduct].Name = productName;
                }

                if(price != null && ValidatePrice(price.Value))
                {
                    _products[oneProduct].Price = price.Value;
                }

                if(amount >= 0)
                {
                    _products[oneProduct].Available = amount;
                }

                return true;
            }
            else
            {
                throw new InvalidInputException();
            }
        }

        public bool IsValidCoin(Money oneCoin)
        {
            if (oneCoin.Euros == 0 && oneCoin.Cents == 0)
            {
                throw new InvalidCoinException();
            }

            if (Math.Sign(oneCoin.Euros | oneCoin.Cents) == -1)
            {
                throw new InvalidCoinException();
            }
            
            switch(oneCoin.Cents)
            {
                case 50:
                case 20:
                case 10:
                case 0:
                    break;
                default:
                    throw new InvalidCoinException();            
            }

            switch(oneCoin.Euros)
            {
                case 2:
                case 1:
                case 0:
                    break;
                default:
                    throw new InvalidCoinException();            
            }

            return true;
        }

        public bool Buy(int productToBuy)
        {
            if(productToBuy < 0 || productToBuy >= _products.Length)
            {
                throw new InvalidIdException();
            }

            Product product = _products[productToBuy];

            if(product.Available <= 0)
            {
                throw new ProductOutOfStockException();
            }

            if (Amount.Euros < product.Price.Euros || (Amount.Euros == product.Price.Euros && Amount.Cents < product.Price.Cents))
            {
                throw new NotEnoughMoneyException();
            }

            int totalPriceInCents = product.Price.Euros * 100 + product.Price.Cents;
            int currentMoneyAmountInCents = _moneyAmount.Euros * 100 + _moneyAmount.Cents;
            int changeInCents = currentMoneyAmountInCents - totalPriceInCents;

            int changeEuro = changeInCents / 100;
            int changeCents = changeInCents % 100;

            _moneyAmount.Euros = changeEuro;
            _moneyAmount.Cents = changeCents;
            product.Available--;
            
            return true;
        }
    }
}