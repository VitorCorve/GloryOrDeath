using GloryOrDeath.CORE.Weaknesses.Abstract;

namespace GloryOrDeath.CORE.Weaknesses
{
    public class Disease : WeaknessBase
    {
        public DiseaseEnumerable Type { get; }
        public Disease(int stage, DiseaseEnumerable type) : base(stage)
        {
            Type = type;
        }
    }
}
