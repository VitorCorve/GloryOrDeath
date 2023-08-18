using GloryOrDeath.CORE.Characters;
using GloryOrDeath.CORE.Engine.Abstract;
using GloryOrDeath.DotnetExtensions.List;

namespace GloryOrDeath.CORE.Engine.NeedsBus
{
    public class NeedsBus : IEvent
    {
        private List<Character> _characters = new();

        public Guid ID { get; } = Guid.NewGuid();
        private const int HungerTicksConstant = 400;
        private const int ThirtnessTicksConstant = 300;
        private const int ExhaustionTicksConstant = 300;

        private int _hungerTicks;
        private int _thirtnessTicks;
        private int _exhaustionTicks;

        public async Task EvaluateAsync()
        {
            _hungerTicks++;
            _thirtnessTicks++;
            _exhaustionTicks++;

            if (_hungerTicks >= HungerTicksConstant)
            {
                _hungerTicks = 0;
                EvaluateHunger();
            }
            if (_thirtnessTicks >= ThirtnessTicksConstant)
            {
                _thirtnessTicks = 0;
                EvaluateThirtness();
            }
            if (_exhaustionTicks >= ExhaustionTicksConstant)
            {
                _exhaustionTicks = 0;
                EvaluateExhaustion();
            }
        }

        private void EvaluateHunger()
        {
            foreach (var character in _characters)
            {
                if (character.Kind.Type == Creatures.HumanoidCreatureEnumerable.Human || character.Kind.Type == Creatures.HumanoidCreatureEnumerable.Werewolf)
                {
                    character.Needs?.FirstOrDefault(x => x.Type == Needs.NeedsEnumerable.Hunger)?.StageUp();
                }
            }
        }

        private void EvaluateThirtness()
        {
            foreach (var character in _characters)
            {
                character.Needs?.FirstOrDefault(x => x.Type == Needs.NeedsEnumerable.Thirtness)?.StageUp();
            }
        }

        private void EvaluateExhaustion()
        {
            foreach (var character in _characters)
            {
                if (character.Kind.Type == Creatures.HumanoidCreatureEnumerable.Human || character.Kind.Type == Creatures.HumanoidCreatureEnumerable.Werewolf)
                {
                    character.Needs?.FirstOrDefault(x => x.Type == Needs.NeedsEnumerable.Exhaustion)?.StageUp();
                }
            }
        }

        public void Register(Character character)
        {
            _characters.AddByCondition(character, !_characters.Contains(character));
        }
    }
}
