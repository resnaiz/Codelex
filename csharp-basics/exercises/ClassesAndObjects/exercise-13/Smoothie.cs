using System;

namespace exercise_13
{
    internal class Smoothie
    {
        public string[] Ingredients { get; set; }

        public Smoothie(string[] ingredients)
        {
            Ingredients = ingredients;
        }

        public double GetCost()
        {
            double totalCost = 0.0;

            foreach (string ingredient in Ingredients)
            {
                switch (ingredient)
                {
                    case "Strawberries":
                        totalCost += 1.5;
                        break;
                    case "Banana":
                        totalCost += 0.5;
                        break;
                    case "Mango":
                        totalCost += 2.5;
                        break;
                    case "Blueberries":
                        totalCost += 1.0;
                        break;
                    case "Raspberries":
                        totalCost += 1.0;
                        break;
                    case "Apple":
                        totalCost += 1.75;
                        break;
                    case "Pineapple":
                        totalCost += 3.5;
                        break;
                }
            }

            return totalCost;
        }

        public string GetPrice() 
        {
            double anotherCost = GetCost();
            double price = anotherCost + (anotherCost * 1.5);
            return string.Format("£{0:0.00}", price);
        }

        public string GetName()
        {
            string name;

            if (Ingredients.Length == 0)
            {
                name = "No ingredients in the smoothie.";
            }
            else if (Ingredients.Length == 1)
            {
                name = $"{Ingredients[0]} Smoothie";
            }
            else
            {
                Array.Sort(Ingredients);

                for (int i = 0; i < Ingredients.Length; i++)
                {
                    if (Ingredients[i].EndsWith("berries"))
                    {
                        Ingredients[i] = Ingredients[i].Replace("berries", "berry");
                    }
                }

                name = $"{string.Join(" ", Ingredients)} Fusion";
            }

            return name;
        }
    }
}
