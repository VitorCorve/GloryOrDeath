using GloryOrDeath.CORE.Engine.Abstract;

namespace GloryOrDeath.CORE.Engine.World.Date
{
    public class WorldDateBus : IEvent
    {
        public DateTime Date { get; private set; }

        public Guid ID => throw new NotImplementedException();

        public void Initialize(DateTime date)
        {
            Date = date;
        }

        public async Task EvaluateAsync()
        {
            Date = Date.AddMinutes(1);
        }

        public WorldDateBus(DateTime date)
        {
            Date = date;
        }
    }
}
