namespace GloryOrDeath.DotnetExtensions.Enums
{
    public static class EnumExtensions
    {
        public static string ToNormalizedString(this Enum value)
        {
            return value.ToString().Replace("_", " ");
        }
    }
}
