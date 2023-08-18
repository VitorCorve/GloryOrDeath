
using GloryOrDeath.Console.Generators;
using GloryOrDeath.CORE.Engine.World.Continents;
using GloryOrDeath.CORE.Locations.MapMatrix;
using Newtonsoft.Json;
using System.Drawing;

string matrixPath = Path.Combine(Environment.CurrentDirectory, "locationMatrix.json");
string data = File.ReadAllText(matrixPath);
LocationMatrix matrix = JsonConvert.DeserializeObject<LocationMatrix>(data);

while (true)
{
    Console.WriteLine("Enter YCoordinate");
    int yCoordinate = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter XFrom");
    int xFrom = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter XTo");
    int xTo = int.Parse(Console.ReadLine());

    var corrected = CorrectMatrix(matrix, yCoordinate, xFrom, xTo, 1000, ContinentsEnumerable.Ocean);
    DrawMap(corrected, 1000);
    SaveLocationMatrix(corrected);
    Console.Clear();
}

LocationsGenerator locGen = new();

//var continent = locGen.GenerateContinent(GloryOrDeath.CORE.Engine.World.Continents.ContinentsEnumerable.Gloria);
//DrawMap(matrix, 1000);

void FillMapFromEdges(LocationMatrix matrix, int size, ContinentsEnumerable asContinent, bool drawFromLeftToRight)
{
    Bitmap image = new Bitmap(size, size);
    Graphics graphics = Graphics.FromImage(image);

    string edgesData = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "mapEdges.json"));
    List<DotPoint> edges = System.Text.Json.JsonSerializer.Deserialize<List<DotPoint>>(edgesData).Distinct().OrderBy(x => x.Y).ThenBy(x => x.X).ToList();

    for (int y = 0; y < size; y++)
    {
        var yEdge = edges.FirstOrDefault(yEdge => yEdge.Y == y);

        if (yEdge != null)
        {
            for (int x = 0; x < size - 1; x++)
            {
                if (drawFromLeftToRight)
                {
                    if (x <= yEdge.X)
                    {
                        matrix.Map[x, y].Continent = asContinent;
                    }
                }
                else
                {
                    if (x >= yEdge.X)
                    {
                        matrix.Map[x, y].Continent = asContinent;
                    }
                }
            }
        }


        Console.Clear();
        Console.WriteLine($"Filling. Progress: {y / 10}%");
    }
}

LocationMatrix CorrectMatrix(LocationMatrix matrix, int yCoordinate, int xFrom, int xTo, int size, ContinentsEnumerable asContinent)
{
    for (int y = yCoordinate; y < 1000; y++)
    {
        for (int x = 0; x < size - 1; x++)
        {

            if (x >= xFrom && x <= xTo)
            {
                matrix.Map[x, y].Continent = asContinent;
            }

            Console.Clear();
            Console.WriteLine($"Correcting. Progress: {x / 10}%");
        }
        xFrom--;
    }


    return matrix;
}

void DrawMap(LocationMatrix matrix, int size)
{
    Bitmap image = new Bitmap(size, size);
    Graphics graphics = Graphics.FromImage(image);
    Pen pen = new(Color.Gray);

    for (int y = 0; y < size; y++)
    {
        for (int x = 0; x < size - 1; x++)
        {
            ContinentsEnumerable continent = matrix.Map[x, y].Continent;

            switch (continent)
            {
                case ContinentsEnumerable.Ocean:
                    pen.Color = Color.Blue;
                    break;
                case ContinentsEnumerable.Esparda:
                    pen.Color = Color.Bisque;
                    break;
                case ContinentsEnumerable.Gloria:
                    pen.Color = Color.Chartreuse;
                    break;
                default:
                    break;
            }

            Rectangle rectangle = new(x, y, 1, 1);
            graphics.DrawRectangle(pen, rectangle);
        }

        Console.Clear();
        Console.WriteLine($"Drawing. Progress: {y / 10}%");
    }

    string filePath = Path.Combine(Environment.CurrentDirectory, "map.jpg");
    image.Save(filePath);

    graphics.Dispose();
    image.Dispose();
}

void SaveLocationMatrix(LocationMatrix matrix)
{
    string path = Path.Combine(Environment.CurrentDirectory, "locationMatrix.json");
    string data = JsonConvert.SerializeObject(matrix, Formatting.Indented);
    File.WriteAllText(path, data);
}

public class DotPoint
{
    public double X { get; set; } = 0;
    public double Y { get; set; }
}

//Console.ReadLine();