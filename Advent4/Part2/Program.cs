var lines = File.ReadAllLines("input");

int overlapsCount = 0;

foreach (String line in lines)
{
    string[] elves = line.Split(",");
    int[] range1 = Array.ConvertAll(elves[0].Split("-"), int.Parse);
    int[] range2 = Array.ConvertAll(elves[1].Split("-"), int.Parse);
    if (Overlaps(range1, range2))
    {
        overlapsCount++;
    }
}

Console.WriteLine("Number of pairs where the two ranges overlap: " + overlapsCount);


bool Overlaps(int[] range1, int[] range2)
{
    // Cannot overlap if one range ends before other's start or starts after other's end
    if (range1[1] < range2[0] || range1[0] > range2[1])
    {
        return false;
    }
    return true;
}