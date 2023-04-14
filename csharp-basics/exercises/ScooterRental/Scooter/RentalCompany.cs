using Scooter.Interfaces;

namespace Scooter;

public class RentalCompany : IRentalCompany
{
    public string Name { get; }
    private ScooterService _scooterService;
    private Dictionary<DateTime, decimal> _rentals;

    public RentalCompany(string name, ScooterService scooterService)
    {
        Name = name;
        _scooterService = scooterService;
        _rentals = new Dictionary<DateTime, decimal>();
    }
    
    public void StartRent(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new InvalidIdException();
        }

        var scooter = _scooterService.GetScooterById(id);

        if (scooter.IsRented)
        {
            throw new ScooterIsRentedException();
        }

        scooter.IsRented = true;
        scooter.startRentTime = DateTime.Now;
    }

    public decimal EndRent(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new InvalidIdException();
        }

        var scooter = _scooterService.GetScooterById(id);

        if (!scooter.IsRented)
        {
            throw new ScooterIsNotRentedException();
        }

        scooter.IsRented = false;
        scooter.endRentTime = DateTime.Now;

        var price = CalculateRentPrice(scooter);
        _rentals.Add(scooter.endRentTime, price);
        return price;
    }

    public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
    {
        decimal totalIncome = 0m;

        if (year == null)
        {
            totalIncome = _rentals.Values.Sum();
        }
        else 
        {
            foreach (var key in _rentals.Keys)
            {
                if (key.Year == year.Value && _rentals.TryGetValue(key, out var value))
                {
                    totalIncome += value;
                }
            }
        }

        if (includeNotCompletedRentals)
        {
            var scooters = _scooterService.GetScooters();
            var rentedScooters = scooters.Where(x => x.IsRented);

            foreach (var scooter in rentedScooters)
            {
                var minutesRented = Math.Round((decimal)(DateTime.Now - scooter.startRentTime).TotalMinutes);
                var incomeFromScooter = minutesRented * (decimal)scooter.PricePerMinute;
                totalIncome += incomeFromScooter;
            }
        }

        return totalIncome;
    }

    public static decimal CalculateRentPrice(Scooter scooter)
    {
        if (scooter == null)
        {
            throw new InvalidScooterException();
        }
        else if (scooter.startRentTime == DateTime.MinValue || scooter.endRentTime == DateTime.MinValue)
        {
            return 0;
        }

        var totalAmount = 0m;

        var duration = (scooter.endRentTime - scooter.startRentTime).TotalMinutes;

        if (duration < 1)
        {
            totalAmount = scooter.PricePerMinute;
        }
        else if (scooter.endRentTime.Day == scooter.startRentTime.Day)
        {
            var price = (decimal)duration * scooter.PricePerMinute;

            if (price >= 20)
            {
                totalAmount += 20;
            }
            else
            {
                totalAmount += price;
            }
        }
        else
        {
            var date = scooter.startRentTime;

            while (date <= scooter.endRentTime)
            {
                if (date.Day == scooter.endRentTime.Day)
                {
                    duration = (scooter.endRentTime - date).TotalMinutes;
                    var price2 = (decimal)duration * scooter.PricePerMinute;

                    if (price2 >= 20)
                    {
                        totalAmount = 20;
                    }
                    else if(price2 < 20)
                    {
                        totalAmount += price2;
                    }

                    break;
                }
                else
                {
                    duration = (date.Date.AddDays(1) - date).TotalMinutes;
                    var price3 = (decimal)duration * scooter.PricePerMinute;

                    if (price3 >= 20)
                    {
                        totalAmount += 20 - totalAmount;
                    }
                    else
                    {
                        totalAmount += price3;
                    }

                    date = date.Date.AddDays(1);
                }
            }
        }

        return Math.Round(totalAmount, 6);
    }
}