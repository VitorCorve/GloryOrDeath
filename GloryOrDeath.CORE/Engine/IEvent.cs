using GloryOrDeath.CORE.Infrastructure;

namespace GloryOrDeath.CORE.Engine
{
    public interface IEvent : IUniqualObject
    {
        public Task EvaluateAsync();
    }
}
