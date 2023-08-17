using GloryOrDeath.CORE.Fractions;

namespace GloryOrDeath.CORE.Reputations
{
    public class Reputation
    {
        private const int MinValue = -100;
        private const int MaxValue = 100;
        public FractionEnumerable Fraction { get; set; }
        public int Value { get; set; }
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
