﻿using System;
using System.Collections.Generic;
using NobodyCare;

public class Program
{
    public static void Main(string[] args)
    {
        var mastermind = new Mastermind(new List<CodePeg> { CodePeg.Black, CodePeg.Blue, CodePeg.Yellow, CodePeg.Blue });
        var hints = mastermind.GetHints(new List<CodePeg> { CodePeg.Black, CodePeg.Blue, CodePeg.Green, CodePeg.Yellow });
        foreach (var hint in hints)
        {
            Console.WriteLine(hint);
        }
    }
}
