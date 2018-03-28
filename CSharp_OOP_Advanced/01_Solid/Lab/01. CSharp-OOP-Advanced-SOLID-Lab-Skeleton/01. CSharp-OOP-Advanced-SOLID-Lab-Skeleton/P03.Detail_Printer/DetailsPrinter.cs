using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private readonly IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void PrintEmployees()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}