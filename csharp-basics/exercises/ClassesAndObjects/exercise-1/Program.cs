namespace exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product firstProduct = new Product("Logitech mouse", 70.00, 14);
            Product secondProduct = new Product("iPhone 5s", 999.99, 3);
            Product thirdProduct = new Product("Epson EB-U05", 440.46, 1);

            firstProduct.PrintProduct();
            secondProduct.PrintProduct();
            thirdProduct.PrintProduct();

            firstProduct.AmountChange(3);
            thirdProduct.PriceChanged(399.99);

            firstProduct.PrintProduct();
            secondProduct.PrintProduct();
            thirdProduct.PrintProduct();
        }
    }
}
