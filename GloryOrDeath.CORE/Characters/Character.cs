using GloryOrDeath.CORE.Creatures;
using GloryOrDeath.CORE.Infrastructure.Abstract;
using GloryOrDeath.CORE.Locations;
using GloryOrDeath.CORE.Locations.Properties;
using GloryOrDeath.CORE.Needs;
using GloryOrDeath.CORE.Relationships;
using GloryOrDeath.CORE.Reputations;
using GloryOrDeath.CORE.Skills;
using GloryOrDeath.CORE.Weaknesses.Abstract;

namespace GloryOrDeath.CORE.Characters
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
        public DateTime Born { get; }
        public string Name { get; }
        public bool IsAlive { get; }
        public Guid ID { get; }
        public ICharacterKind Kind { get; }
        public Character? Mother { get; private set; }
        public Character? Father { get; private set; }
        public Location? Location { get; private set; }

        public Character
            (
                IEnumerable<Skill> skills,
                IEnumerable<WeaknessBase> weaknesses,
                IEnumerable<Reputation> reputations,
                IEnumerable<Relationship> relationships,
                IEnumerable<Need> needs,
                CharacterSex sex,
                DateTime born,
                string name,
                bool isAlive,
                Guid id,
                ICharacterKind kind

            )
        {
            Skills = skills;
            Sex = sex;
            Born = born;
            Name = name;
            IsAlive = isAlive;
            ID = id;
            Weaknesses = weaknesses;
            Reputations = reputations;
            Relationships = relationships;
            Needs = needs;
            Kind = kind;
        }

        public void SetMother(Character mother)
        {
            Mother = mother;
        }


        public void SetFather(Character father)
        {
            Father = father;
        }
    }
}
