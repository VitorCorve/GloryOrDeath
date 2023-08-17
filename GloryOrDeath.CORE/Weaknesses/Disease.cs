using GloryOrDeath.CORE.Weaknesses.Abstract;

namespace GloryOrDeath.CORE.Weaknesses
{
    public class Disease : WeaknessBase
    {
        public DiseaseEnumerable Type { get; set; }
        public Disease(int stage) : base(stage)
        {
        }
    }
}
