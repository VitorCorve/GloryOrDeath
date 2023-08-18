using GloryOrDeath.CORE.Engine.World.Cities;
using GloryOrDeath.CORE.Engine.World.Continents;
using GloryOrDeath.CORE.Infrastructure.Abstract;
using GloryOrDeath.CORE.Locations.Properties;

namespace GloryOrDeath.CORE.Locations
{
    public class Location : IUniqualObject
    {
        public ContinentsEnumerable Continent { get; set; }
        public CitiesEnumerable? City { get; set; }
        public LocationTypesEnumerable? Type { get; set; }
        public LocationStatusEnumerable Status { get; set; }
        public string Name { get; set; }
        public List<Location> Contains { get; set; }
        public Location? PartOf { get; set; }
        public Guid ID { get; set; }
    }
}
