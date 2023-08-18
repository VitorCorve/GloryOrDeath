using GloryOrDeath.CORE.Engine.World.Continents;
using GloryOrDeath.CORE.Locations;
using GloryOrDeath.CORE.Locations.MapMatrix;
using System.Drawing;

namespace GloryOrDeath.Console.Generators
{
    public class LocationsGenerator
    {
        public Location GenerateContinent(ContinentsEnumerable continent)
        {
            Location location = new()
            {
                Continent = continent,
                ID = Guid.NewGuid(),
            };
            return location;
        }

        public LocationMatrix GenerateMap(int size)
        {
            LocationMatrix matrix = new()
            {
                Map = new CoordinateInfo[size, size]
            };


            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    matrix.Map[x, y] = new CoordinateInfo { X = x, Y = y };
                }
            }

            return matrix;
        }
    }
}
