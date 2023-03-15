using System;

namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[5];
            products[0] = new Product { Name = "Snicker", Price = new Money { Euros = 2, Cents = 20 }, Available = 5 }; 
            products[1] = new Product { Name = "Chips Doritos", Price = new Money { Euros = 1, Cents = 70 }, Available = 2 };
            products[2] = new Product { Name = "Coffee", Price = new Money { Euros = 0, Cents = 80 }, Available = 9 };
            products[3] = new Product { Name = "Tea", Price = new Money { Euros = 0, Cents = 60 }, Available = 3 };
            products[4] = new Product { Name = "Chocolate", Price = new Money { Euros = 1, Cents = 40 }, Available = 7 };

            IVendingMachine newVending = new VendingMachine("Codelex", products);

            newVending.InsertCoin(new Money { Euros = 1, Cents = 20 });
            newVending.InsertCoin(new Money { Euros = 0, Cents = 10 });
            newVending.InsertCoin(new Money { Euros = 2, Cents = 50 });
            newVending.InsertCoin(new Money { Euros = 1, Cents = 50 });
            newVending.InsertCoin(new Money { Euros = 1, Cents = 20 });

            Console.WriteLine("Choose a product: ");
            
            for(int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"{i}: ({products[i].Name}), Euro - {products[i].Price.Euros}, {products[i].Price.Cents}");
            }

            int numberChoose;

            while(true)
            {
                Console.WriteLine("Enter Product number: ");

                if(int.TryParse(Console.ReadLine(), out numberChoose) && numberChoose >= 0 && numberChoose < products.Length)
                {
                    break;
                }

                Console.WriteLine("Invalid product number.");
            }

            Console.WriteLine($"Buying {products[numberChoose].Name}...");
            bool buy = newVending.Buy(numberChoose);

            if (buy)
            {
                Console.WriteLine($"{products[numberChoose].Name} successfully purchased.");
            }
            else
            {
                Console.WriteLine("The product is sold or there is not enough money.");
            }

            Money returnMoney = newVending.ReturnMoney();
            Console.WriteLine($"Returning {returnMoney.Euros} euros and {returnMoney.Cents} cents.");
        }
    }
}
