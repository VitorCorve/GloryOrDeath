using GloryOrDeath.Console;
using GloryOrDeath.CORE.Characters;
using GloryOrDeath.CORE.Constants;
using GloryOrDeath.CORE.Creatures.Humans;
using GloryOrDeath.CORE.Engine.Abstract;
using GloryOrDeath.CORE.Engine.NeedsBus;
using GloryOrDeath.CORE.Engine.TimeBus;
using GloryOrDeath.CORE.Engine.World.Date;
using GloryOrDeath.CORE.Needs;
using GloryOrDeath.CORE.Relationships;
using GloryOrDeath.CORE.Reputations;
using GloryOrDeath.CORE.Skills;
using GloryOrDeath.CORE.Weaknesses;


List<IEvent> events = new()
{

};
TimeBus globalBus = new TimeBus(events);

WorldDateBus worldDateBus = new(new DateTime(year: 1412, month: 2, day: 11, hour: 12, minute: 3, 0));
globalBus.Subscribe(worldDateBus);
globalBus.StartAsync();

var totalSkills = SkillsVariables.SKILLS_LIST;
var skills = totalSkills.Select(x => new Skill(0, x));
var weaknesses = new List<Disease>();
var reputatuions = new List<Reputation>();
var relationships = new List<Relationship>();
var needs = new List<Need>()
{
    new Need(NeedsEnumerable.Hunger, 0),
    new Need(NeedsEnumerable.Thirtness, 0),
    new Need(NeedsEnumerable.Exhaustion, 0),
};
var kind = new Human();
Character character = new Character(skills, weaknesses, reputatuions, needs, CharacterSex.Male, 20, "Character", true, Guid.NewGuid(), kind);
NeedsBus needsBus = new NeedsBus();
needsBus.Register(character);
globalBus.Subscribe(needsBus);

Console.ReadLine();
