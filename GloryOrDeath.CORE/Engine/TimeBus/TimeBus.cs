using GloryOrDeath.CORE.Constants;
using GloryOrDeath.CORE.Engine.Abstract;
using GloryOrDeath.DotnetExtensions.List;
using GloryOrDeath.Instrumentary.Clock;

namespace GloryOrDeath.CORE.Engine.TimeBus
{
    public class TimeBus : ITimeBus
    {
        private readonly List<IEvent> _events;
        private readonly Clock _timer;

        public TimeBus(IEnumerable<IEvent> events)
        {
            _events = new List<IEvent>(events);
            _timer = new Clock(GlobalVariables.ITERATION_INTERVAL);
            _timer.Elapsed += HandleOnTick; ;
        }

        private async Task HandleOnTick()
        {
            foreach (var item in _events)
            {
                await item.EvaluateAsync();
            }
        }

        public async Task StartAsync()
        {
            await _timer.StartAsync();
        }

        public async Task StopAsync()
        {
            await _timer.StopAsync();
            _timer.Elapsed -= HandleOnTick;
            _timer.Dispose();
        }

        public void Subscribe(IEvent events)
        {
            _events.Add(events);
        }

        public void Unsubscribe(IEvent effect)
        {
            _events.RemoveByCondition(effect, _events.FirstOrDefault(x => x.ID == effect.ID) != null);
        }
    }
}
