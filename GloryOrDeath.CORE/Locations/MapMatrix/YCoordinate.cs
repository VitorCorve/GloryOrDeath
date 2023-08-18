namespace GloryOrDeath.CORE.Locations.MapMatrix
{
    public struct YCoordinate
    {
        public int Value { get; set; }

        public static implicit operator YCoordinate(int value)
        {
            return new YCoordinate { Value = value };
        }
    }
}
