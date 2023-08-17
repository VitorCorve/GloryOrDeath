using GloryOrDeath.CORE.Engine.Abstract;

namespace GloryOrDeath.Console
{
    internal class CustomEvent : IEvent
    {
        public Guid ID { get; }
        private readonly string _name;
        public CustomEvent(string eventName)
        {
            ID = Guid.NewGuid();
            _name = eventName;
        }

        public async Task EvaluateAsync()
        {
            System.Console.WriteLine($"Something happened for {_name} at: " + DateTime.Now);
        }
    }
}
