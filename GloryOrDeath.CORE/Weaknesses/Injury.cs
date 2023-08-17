using GloryOrDeath.CORE.Weaknesses.Abstract;

namespace GloryOrDeath.CORE.Weaknesses
{
    public class Injury : WeaknessBase
    {
        public InjuresEnumerable Type { get; set; }
        public Injury(int stage) : base(stage)
        {
        }
    }
}
