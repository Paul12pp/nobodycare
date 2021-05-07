using System;
using System.Collections.Generic;
using System.Linq;
					
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

public class Mastermind
{
    private List<CodePeg> code;
    private HashSet<Movement> movements;
    private HashSet<CodePeg> pegs;

    public Mastermind(List<CodePeg> code)
    {
        this.code = code;
        movements = code.Select((color, order) => new Movement { Order = order, Color = color }).ToHashSet();
        pegs = code.ToHashSet();
    }

    public List<ResultPeg> GetHints(List<CodePeg> guess)
    {
        var whites = new List<ResultPeg>();
        var blacks = new List<ResultPeg>();

        for (int i = 0; i < guess.Count; i++)
        {
            var color = guess[i];
            var movement = new Movement { Order = i, Color = color };
            if (movements.Contains(movement))
            {
                blacks.Add(ResultPeg.Black);
            }
            else if (pegs.Contains(color))
            {
                whites.Add(ResultPeg.White);
            }
        }
        return blacks.Concat(whites).Take(4).ToList();
    }
}

public enum CodePeg
{
    Black,
    Blue,
    Green,
    Red,
    White,
    Yellow,
}

public enum ResultPeg
{
    Black,
    White,
}

public class Movement : IEquatable<Movement>
{
    public int Order { get; set; }
    public CodePeg Color { get; set; }

    public bool Equals(Movement move)
    {
        return move != null && Order == move.Order && Color == move.Color;
    }

    public override bool Equals(Object obj)
    {
        return Equals(obj as Movement);
    }

    public override int GetHashCode()
    {
        return Order.GetHashCode() ^ Color.GetHashCode();
    }
}