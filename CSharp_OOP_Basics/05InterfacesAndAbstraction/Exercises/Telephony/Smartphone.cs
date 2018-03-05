using System;
using System.Collections.Generic;
using System.Linq;

public class Smartphone : ICalling, IBrowsing
{
    public void Browse(List<string> websites)
    {
        foreach (var website in websites)
        {
            try
            {
                if (website.Any(x => char.IsDigit(x)))
                {
                    throw new ArgumentException("Invalid URL!");
                }
                else
                {
                    Console.WriteLine($"Browsing: {website}!");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public void Call(List<string> phones)
    {
        foreach (var phone in phones)
        {
            try
            {
                if (phone.Any(x => !char.IsDigit(x)))
                {
                    throw new ArgumentException("Invalid number!");
                }
                else
                {
                    Console.WriteLine($"Calling... {phone}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}