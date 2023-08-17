using GloryOrDeath.CORE.Infrastructure.Abstract;
using GloryOrDeath.CORE.Needs;
using GloryOrDeath.CORE.Relationships;
using GloryOrDeath.CORE.Reputations;
using GloryOrDeath.CORE.Skills;
using GloryOrDeath.CORE.Weaknesses.Abstract;

namespace GloryOrDeath.CORE.Engine.Characters
{
    public class Character : IUniqualObject
    {
        public IEnumerable<Skill> Skills { get; }
        public CharacterSex Sex { get; }
        public int Age { get; }
        public string Name { get; }
        public bool IsAlive { get; }
        public bool IsVampire { get; }
        public bool IsWerewolf { get; }

        public Guid ID { get; }
        public List<WeaknessBase> Weaknesses { get; }
        public List<Reputation> Reputations { get; }
        public List<Relationship> Relationships { get; }
        public List<Need> Needs { get; set; }
    }
}
