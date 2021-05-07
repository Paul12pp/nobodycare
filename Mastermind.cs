using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NobodyCare
{

    public class Mastermind
    {
        private readonly List<CodePeg> code;
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

}
