using GloryOrDeath.CORE.Characters;
using GloryOrDeath.CORE.Constants;
using GloryOrDeath.CORE.Creatures.Humans;
using GloryOrDeath.CORE.Creatures.Vampires;
using GloryOrDeath.CORE.Creatures.Werewolves;
using GloryOrDeath.CORE.Engine.Abstract;
using GloryOrDeath.CORE.Engine.NeedsBus;
using GloryOrDeath.CORE.Engine.TimeBus;
using GloryOrDeath.CORE.Engine.World.Date;
using GloryOrDeath.CORE.Needs;
using GloryOrDeath.CORE.Relationships;
using GloryOrDeath.CORE.Reputations;
using GloryOrDeath.CORE.Skills;
using GloryOrDeath.CORE.Weaknesses;
using GloryOrDeath.DEBUG_UI.Services;
using GloryOrDeath.WPF.CORE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GloryOrDeath.DEBUG_UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private DateTime _worldDateTime;

        private WorldDateBus _dateBus = new(new DateTime(year: 1412, month: 2, day: 11, hour: 12, minute: 3, 0));

        private ObservableCollection<Character> _characters = new ObservableCollection<Character>();

        private Character _selectedCharacter;

        public DateTime WorldDateTime
        {
            get => _worldDateTime;
            set => Set(ref _worldDateTime, value);
        }

        public ObservableCollection<Character> Characters
        {
            get => _characters;
            set => Set(ref _characters, value);
        }

        public Character SelectedCharacter
        {
            get => _selectedCharacter;
            set => Set(ref _selectedCharacter, value);
        }

        public Dictionary<string, int> Relations
        {
            get
            {

                Dictionary<string, int> relations = new();
                if (SelectedCharacter != null)
                {
                    foreach (var relation in SelectedCharacter.Relationships)
                    {
                        var relatedCharacter = Characters.FirstOrDefault(x => x.ID == relation.To);
                        if (relatedCharacter != null)
                        {
                            relations.Add(relatedCharacter.Name, relation.Stage);
                        }
                    }
                }
                return relations;
            }
        }

        public MainWindowViewModel()
        {
            List<IEvent> events = new()
            {

            };
            TimeBus globalBus = new TimeBus(events);
            Random rand = new();

            StateObserver stateObserver = new(this);
            globalBus.Subscribe(_dateBus);
            globalBus.Subscribe(stateObserver);
            globalBus.StartAsync();

            Guid marcusGuid = Guid.NewGuid();
            Guid ciennaGuid = Guid.NewGuid();
            Guid raquelGuid = Guid.NewGuid();

            var totalSkills = SkillsVariables.SKILLS_LIST;
            var marcusSkills = totalSkills.Select(x => new Skill(rand.Next(0, 1000), x));
            var ciennaSkills = totalSkills.Select(x => new Skill(rand.Next(0, 1000), x));
            var raquelSkills = totalSkills.Select(x => new Skill(rand.Next(0, 1000), x));
            var weaknesses = new List<Disease>();

            var marcusReputation = new List<Reputation>()
            {
                new Reputation(CORE.Engine.World.Fractions.FractionsEnumerable.Indrath, 1),
                new Reputation(CORE.Engine.World.Fractions.FractionsEnumerable.Empire, 3),
            };

            var ciennaReputation = new List<Reputation>()
            {
                new Reputation(CORE.Engine.World.Fractions.FractionsEnumerable.Indrath, 3),
                new Reputation(CORE.Engine.World.Fractions.FractionsEnumerable.Empire, 7),
            };

            var raquelReputation = new List<Reputation>()
            {
                new Reputation(CORE.Engine.World.Fractions.FractionsEnumerable.Indrath, 7),
                new Reputation(CORE.Engine.World.Fractions.FractionsEnumerable.Empire, 8),
            };

            var marcusRelationships = new List<Relationship>()
            {
                new Relationship(marcusGuid, ciennaGuid, 2)
            };
            var ciennaRelationships = new List<Relationship>()
            {
                new Relationship(ciennaGuid, marcusGuid, 2)
            };
            var raquelRelationships = new List<Relationship>()
            {
                new Relationship(raquelGuid, ciennaGuid, -2)
            };
            var marcusNeeds = new List<Need>()
            {
                new Need(NeedsEnumerable.Hunger, 1),
                new Need(NeedsEnumerable.Thirtness, 1),
                new Need(NeedsEnumerable.Exhaustion, 1),
            };
            var ciennaNeeds = new List<Need>()
            {
                new Need(NeedsEnumerable.Hunger, 3),
                new Need(NeedsEnumerable.Thirtness, 2),
                new Need(NeedsEnumerable.Exhaustion, 1),
            };
            var raquelNeeds = new List<Need>()
            {
                new Need(NeedsEnumerable.Hunger, 2),
                new Need(NeedsEnumerable.Thirtness, 3),
                new Need(NeedsEnumerable.Exhaustion, 1),
            };
            Character marcus = new(marcusSkills, weaknesses, marcusReputation, marcusRelationships, marcusNeeds, CharacterSex.Male, 27, "Marcus", true, marcusGuid, new Human());
            Character cienna = new(ciennaSkills, weaknesses, ciennaReputation, ciennaRelationships, ciennaNeeds, CharacterSex.Female, 27, "Cienna", true, ciennaGuid, new Vampire());
            Character raquel = new(raquelSkills, weaknesses, raquelReputation, raquelRelationships, raquelNeeds, CharacterSex.Female, 27, "Raquel", true, raquelGuid, new Werewolf());

            Characters.Add(marcus);
            Characters.Add(cienna);
            Characters.Add(raquel);

            NeedsBus needsBus = new();

            needsBus.Register(marcus);
            needsBus.Register(cienna);
            needsBus.Register(raquel);

            globalBus.Subscribe(needsBus);


        }

        public async Task UpdateAsync()
        {
            WorldDateTime = _dateBus.Date;
            var selectedCharacter = SelectedCharacter;
            SelectedCharacter = null;
            SelectedCharacter = selectedCharacter;
        }
    }
}
