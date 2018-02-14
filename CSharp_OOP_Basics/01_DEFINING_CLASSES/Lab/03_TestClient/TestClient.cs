using System;
using System.Collections.Generic;

public class TestClient
{
    public static void Main()
    {
        var accounts = new Dictionary<int, BankAccount>();

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var cmdArgs = command.Split();
            var cmdType = cmdArgs[0];

            switch (cmdType)
            {
                case "Create":
                    Create(cmdArgs, accounts);
                    break;

                case "Deposit":
                    Deposit(cmdArgs, accounts);
                    break;

                case "Withdraw":
                    Withdraw(cmdArgs, accounts);
                    break;

                case "Print":
                    Print(cmdArgs, accounts);
                    break;
            }
        }
    }

    public static void Print(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);

        Console.WriteLine(!accounts.ContainsKey(id)
            ? "Account does not exist"
            : $"Account ID{id}, balance {accounts[id].Balance:f2}");
    }

    public static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            if (accounts[id].Balance < decimal.Parse(cmdArgs[2]))
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                accounts[id].Balance -= decimal.Parse(cmdArgs[2]);
            }
        }
    }

    public static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);

        if (!accounts.ContainsKey(id)) Console.WriteLine("Account does not exist");
        else accounts[id].Balance += decimal.Parse(cmdArgs[2]);
    }

    public static void Create(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);

        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var acc = new BankAccount { Id = id };
            accounts.Add(id, acc);
        }
    }
}