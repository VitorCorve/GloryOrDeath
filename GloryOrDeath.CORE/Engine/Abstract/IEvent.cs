using GloryOrDeath.CORE.Infrastructure.Abstract;

namespace GloryOrDeath.CORE.Engine.Abstract
{
    public interface IEvent : IUniqualObject
    {
        public Task EvaluateAsync();
    }
}
