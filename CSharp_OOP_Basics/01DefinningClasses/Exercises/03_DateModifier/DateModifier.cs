using System;

internal class DateModifier
{
    private string firstDate;
    private string secondDate;

    public string FirstDate
    {
        get { return this.firstDate; }
        set { this.firstDate = value; }
    }

    public string SecondDate
    {
        get { return this.secondDate; }
        set { this.secondDate = value; }
    }

    public TimeSpan DifferenceBetweenTwoDates(string firstDate, string secondDate)
    {
        var firstDateTime = DateTime.Parse(firstDate.Replace(' ', '/'));
        var secondDateTime = DateTime.Parse(secondDate.Replace(' ', '/'));

        var difference = firstDateTime - secondDateTime;

        return difference;
    }
}