var lines = File.ReadAllLines("input");

int containedCount = 0;

foreach (String line in lines)
{
    string[] elves = line.Split(",");
    int[] range1 = Array.ConvertAll(elves[0].Split("-"), int.Parse);
    int[] range2 = Array.ConvertAll(elves[1].Split("-"), int.Parse);
    if (Contains(range1, range2) || Contains(range2, range1))
    {
        containedCount++;
    }
}

Console.WriteLine("Number of pairs where one range fully encompasses the other: " + containedCount);



bool Contains(int[] inner, int[] outer)
{
    return inner[0] >= outer[0] && inner[1] <= outer[1];
}