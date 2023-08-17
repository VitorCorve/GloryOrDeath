using GloryOrDeath.CORE.Creatures;
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
        public IEnumerable<WeaknessBase> Weaknesses { get; }
        public IEnumerable<Reputation> Reputations { get; }
        public IEnumerable<Relationship> Relationships { get; }
        public IEnumerable<Need> Needs { get; set; }
        public CharacterSex Sex { get; }
        public int Age { get; }
        public string Name { get; }
        public bool IsAlive { get; }
        public bool IsVampire { get; }
        public bool IsWerewolf { get; }
        public Guid ID { get; }
        public ICharacterKind Kind { get; }


        public Character
            (
                IEnumerable<Skill> skills,
                IEnumerable<WeaknessBase> weaknesses,
                IEnumerable<Reputation> reputations,
                IEnumerable<Relationship> relationships,
                IEnumerable<Need> needs,
                CharacterSex sex,
                int age,
                string name,
                bool isAlive,
                bool isVampire,
                bool isWerewolf,
                Guid id,
                ICharacterKind kind

            )
        {
            Skills = skills;
            Sex = sex;
            Age = age;
            Name = name;
            IsAlive = isAlive;
            IsVampire = isVampire;
            IsWerewolf = isWerewolf;
            ID = id;
            Weaknesses = weaknesses;
            Reputations = reputations;
            Relationships = relationships;
            Needs = needs;
            Kind = kind;
        }
    }
}
