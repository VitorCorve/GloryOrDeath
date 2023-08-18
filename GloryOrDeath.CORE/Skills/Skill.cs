namespace GloryOrDeath.CORE.Skills
{
    public class Skill
    {
        public const int MinValue = 0;
        public const int MaxValue = 1000;
        public SkillEnumerable Type { get; }
        public int Value { get; set; }

        public string Description { get; set; }
        public Skill(int value, SkillEnumerable type)
        {
            Value = value;
            Type = type;
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
    }
}
