var lines = File.ReadLines("example");

List<int> elves= new List<int>();

int val = 0;
foreach (string line in lines)
{
    if (string.IsNullOrEmpty(line))
    {
        elves.Add(val);
        val = 0;
        continue;
    }
    val += int.Parse(line);
}

// Catch final elf not ending in a line break
if (val != 0)
{
    elves.Add(val);
}

// Sum top three values
int topThreeSum = 0;
elves.Sort();
for (int i = elves.Count-3; i < elves.Count ; i++)
{
    topThreeSum += elves[i];
}
Console.WriteLine(topThreeSum);