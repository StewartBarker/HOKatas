var lines = File.ReadLines("input");

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

int maxValue = elves.Max();
Console.WriteLine(maxValue);

