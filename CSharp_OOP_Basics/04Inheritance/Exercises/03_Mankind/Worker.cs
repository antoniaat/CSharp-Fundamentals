using System;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal SalaryPerHour()
    {
        return (this.WeekSalary / 5) / this.WorkHoursPerDay;
    }

    public decimal WeekSalary
    {
        get => this.weekSalary;
        set
        {
            if (value < 10)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {value:f2}");
            }
            this.weekSalary = value;
        }
    }

    public decimal WorkHoursPerDay
    {
        get => this.workHoursPerDay;
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {value:f2}");
            }
            this.workHoursPerDay = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {base.FirstName}\n" +
               $"Last Name: {base.LastName}\n" +
               $"Week Salary: {this.WeekSalary:f2}\n" +
               $"Hours per day: {this.WorkHoursPerDay:f2}\n" +
               $"Salary per hour: {SalaryPerHour():f2}\n";
    }
}