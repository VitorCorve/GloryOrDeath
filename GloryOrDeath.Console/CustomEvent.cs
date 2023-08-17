using GloryOrDeath.CORE.Engine;

namespace GloryOrDeath.Console
{
    internal class CustomEvent : IEvent
    {
        public Guid Guid { get; }
        private readonly string _name;
        public CustomEvent(string eventName)
        {
            Guid = Guid.NewGuid();
            _name = eventName;
        }

        public async Task EvaluateAsync()
        {
            System.Console.WriteLine($"Something happened for {_name} at: " + DateTime.Now);
        }
    }
}
