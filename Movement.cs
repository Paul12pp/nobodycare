using System;

namespace Mastermind
{
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
}
