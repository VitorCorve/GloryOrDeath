using GloryOrDeath.Console;
using GloryOrDeath.CORE.Engine.TimeBus;

CustomEvent customEvent = new("First event");
CustomEvent customEvent2 = new("Second event");

List<CustomEvent> events = new()
{
    customEvent
};

TimeBus bus = new TimeBus(events);
bus.Subscribe(customEvent2);
await bus.StartAsync();