using GloryOrDeath.CORE.Skills;
using System.Collections.ObjectModel;

namespace GloryOrDeath.CORE.Constants
{
    internal class SkillsVariables
    {
        public readonly static ReadOnlyCollection<SkillEnumerable> SKILLS_LIST = new(new List<SkillEnumerable>
        {
            SkillEnumerable.Alchemy,
            SkillEnumerable.Ambush,
            SkillEnumerable.Archery,
            SkillEnumerable.Attention,
            SkillEnumerable.Axes,
            SkillEnumerable.Building,
            SkillEnumerable.Business,
            SkillEnumerable.FirstAid,
            SkillEnumerable.Initiative,
            SkillEnumerable.Leadership,
            SkillEnumerable.MagicOfDarksouls,
            SkillEnumerable.MagicOfFire,
            SkillEnumerable.MagicOfFrost,
            SkillEnumerable.MagicOfIllusion,
            SkillEnumerable.MagicOfRestoration,
            SkillEnumerable.MagicOfStorm,
            SkillEnumerable.MagicOfWitchcraft,
            SkillEnumerable.MagicResistance,
            SkillEnumerable.Marine,
            SkillEnumerable.Parry,
            SkillEnumerable.RealEstate,
            SkillEnumerable.Riding,
            SkillEnumerable.Seduction,
            SkillEnumerable.Smithing,
            SkillEnumerable.Speech,
            SkillEnumerable.Stealth,
            SkillEnumerable.Swords,
            SkillEnumerable.Tracking,
            SkillEnumerable.Unarmed,
            SkillEnumerable.Warcraft,
    }
}
