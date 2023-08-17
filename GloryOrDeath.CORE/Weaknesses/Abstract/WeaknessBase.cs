namespace GloryOrDeath.CORE.Weaknesses.Abstract
{
    public abstract class WeaknessBase
    {
        public const int MinStage = 0;
        public const int MaxStage = 10;
        public int Stage { get; set; }

        public void StageUp()
        {
            if (Stage < MaxStage)
                Stage++;
        }

        public void StageDown()
        {
            if (Stage > MinStage)
                Stage--;
        }

        public WeaknessBase(int stage)
        {
            Stage = stage;
        }
    }
}
