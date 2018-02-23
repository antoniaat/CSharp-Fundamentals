internal class PriceCalculator
{
    private double pricePerDay;
    private int days;
    private string season;
    private double discount;

    public PriceCalculator(double pricePerDay, int days, string season, double discount)
    {
        this.PricePerDay = pricePerDay;
        this.Days = days;
        this.Season = season;
        this.Discount = discount;
    }

    public PriceCalculator(double pricePerDay, int days, string season)
    {
        this.PricePerDay = pricePerDay;
        this.Days = days;
        this.Season = season;
    }

    public double PricePerDay { get; set; }
    public int Days { get; set; }
    public string Season { get; set; }
    public double Discount { get; set; }

    public double CalculatePrice()
    {
        var price = PricePerDay * Days;
        return price;
    }
}
