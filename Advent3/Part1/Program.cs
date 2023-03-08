var lines = File.ReadLines("input");

int prioritySum = 0;
foreach (String line in lines)
{
    int compartmentLength = line.Length / 2;

    SortedSet<char> charSet = new SortedSet<char>();
    for (int i = 0; i < compartmentLength; i++)
    {
        charSet.Add(line.ElementAt(i));
    }
    for (int i = compartmentLength; i < line.Length; i++)
    {
        if (charSet.Contains(line.ElementAt(i)))
        {
            prioritySum += GetItemPriority(line.ElementAt(i));
            break;
        }
    }
}

Console.WriteLine("Sum of priorities: " + prioritySum);

int GetItemPriority(char item)
{
    int priority;
    int itemAscii = (int)item;
    if (itemAscii is >= 65 and <= 90)
    {
        //Uppercase letter
        priority = itemAscii - 38;
        return priority;
    } else if (itemAscii is >= 97 and <= 122)
    {
        //Lowercase letter
        priority = itemAscii - 96;
        return priority;
    }
    throw new ArgumentException("Char should be alphabetical");
}