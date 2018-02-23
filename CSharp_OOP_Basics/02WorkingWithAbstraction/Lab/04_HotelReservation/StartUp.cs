using System;

public class StartUp
{
    public static void Main()
    {
        var inputLine = Console.ReadLine()
            .Split(new char[] {' '}, StringSplitOptions.None);
        var pricePerDay = double.Parse(inputLine[0]);
        var numberOfDays = int.Parse(inputLine[1]);
        var season = inputLine[2];

        var discountType = inputLine.Length == 4 ? inputLine[3] : string.Empty;

        var priceCalculator = new PriceCalculator(pricePerDay, numberOfDays, season);
        var price = priceCalculator.CalculatePrice();

        price = PriceBySeason(season, price);
        price = PriceByDiscount(discountType, price);

        Console.WriteLine($"{price:f2}");
    }

    private static double PriceByDiscount(string discountType, double price)
    {
        if (discountType == "VIP") price -= (price * 20) / 100;
        else if (discountType == "SecondVisit") price -= (price * 10) / 100;

        return price;
    }

    private static double PriceBySeason(string season, double price)
    {
        if (season == "Spring") price *= 2;
        else if (season == "Winter") price *= 3;
        else if (season == "Summer") price *= 4;

        return price;
    }
}
