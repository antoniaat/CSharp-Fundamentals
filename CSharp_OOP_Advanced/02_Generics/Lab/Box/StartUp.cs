/*============================================================================
    File:		Lab.sln

    Summary:	This document defines the exercises for "C# OOP Advanced" course at Software University. 
                You can check the solution here: https://judge.softuni.bg/Contests/Practice/Index/706

                THIS SCRIPT IS PART OF LECTURE: 
                Generics - Lab

    Date:		29.03.2018

    .NET Version: 2.1.4
------------------------------------------------------------------------------*/

using System;

public class StartUp
{
    public static void Main()
    {
        Box<int> box = new Box<int>();
        box.Add(1);
        box.Add(2);
        box.Add(3);
        Console.WriteLine(box.Remove());
        box.Add(4);
        box.Add(5);
        Console.WriteLine(box.Remove());
    }
}