namespace GloryOrDeath.CORE.Engine.Abstract
{
    public interface ITimeBus
    {
        public void Subscribe(IEvent effect);
        public void Unsubscribe(IEvent effect);

        public Task StartAsync();
        public Task StopAsync();
    }
}
