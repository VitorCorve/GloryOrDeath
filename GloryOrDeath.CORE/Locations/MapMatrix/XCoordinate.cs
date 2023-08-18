namespace GloryOrDeath.CORE.Locations.MapMatrix
{
    public struct XCoordinate
    {
        public int Value { get; set; }

        public static implicit operator XCoordinate(int value)
        {
            return new XCoordinate { Value = value };
        }
    }
}
