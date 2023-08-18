namespace GloryOrDeath.CORE.Needs
{
    public class Need
    {
        private const int MinValue = 0;
        private const int MaxValue = 10;
        public int Value { get; set; }
        public NeedsEnumerable Type { get; set; }
        public Need(NeedsEnumerable type, int value)
        {
            Type = type;
            Value = value;
        }

        public void StageUp()
        {
            if (Value < MaxValue)
                Value++;
        }

        public void StageDown()
        {
            if (Value > MinValue)
                Value--;
        }

        public void Reset() => Value = 0;
    }
}
