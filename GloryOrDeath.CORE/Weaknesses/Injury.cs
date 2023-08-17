using GloryOrDeath.CORE.Weaknesses.Abstract;

namespace GloryOrDeath.CORE.Weaknesses
{
    public class Injury : WeaknessBase
    {
        public InjuresEnumerable Type { get; }
        public Injury(int stage, InjuresEnumerable type) : base(stage)
        {
            Type = type;
        }
    }
}
