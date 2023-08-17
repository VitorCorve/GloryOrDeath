namespace GloryOrDeath.CORE.Needs
{
    public class Need
    {
        private const int MinValue = 0;
        private const int MaxValue = 10;
        public int Value { get; private set; }
        public NeedsEnumerable Type { get; set; }

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
    }
}
