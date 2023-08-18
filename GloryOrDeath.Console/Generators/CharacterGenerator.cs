using GloryOrDeath.CORE.Characters;

namespace GloryOrDeath.Console.Generators
{
    internal class CharacterGenerator
    {
        private readonly string[] _familyNames,
                                  _maleNames,
                                  _femaleNames;

        private readonly Random _random = new();
        public CharacterGenerator(string[] familyNames, string[] maleNames, string[] femaleNames)
        {
            _familyNames = familyNames;
            _maleNames = maleNames;
            _femaleNames = femaleNames;
        }

        public Character Generate()
        {
            return null;
            
        }

        private int GetCreationPowerLevel() => _random.Next(1, 10);


    }
}
