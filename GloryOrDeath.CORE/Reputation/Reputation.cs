using GloryOrDeath.CORE.Engine.World.Fractions;

namespace GloryOrDeath.CORE.Reputations
{
    public class Reputation
    {
        private const int MinValue = -100;
        private const int MaxValue = 100;
        public FractionsEnumerable Fraction { get; set; }
        public int Value { get; set; }

        public Reputation(FractionsEnumerable fraction, int value)
        {
            Fraction = fraction;
            Value = value;
        }

        public void Upgrade()
        {
            if (Value < MaxValue)
                Value++;
        }

        public void Downgrade()
        {
            if (Value > MinValue)
                Value--;
        }
    }
}
