using System.Text;

var lines = File.ReadLines("input");

int prioritySum = 0;

for (int i = 0; i < lines.Count(); i += 3)
{
    StringBuilder sb = new StringBuilder();
    for (int j = i; j < i + 3; j++)
    {
        // Remove duplicates in line, join lines together
        sb.Append(new string(lines.ElementAt(j).Distinct().ToArray()));
    }
    String joined = sb.ToString();
    Dictionary<char, int> charCount = new Dictionary<char, int>();

    foreach (char ch in joined)
    {
        if (charCount.ContainsKey(ch))
        {
            charCount[ch]++;
        }
        else
        {
            charCount[ch] = 1;
        }
    }

    char maxKey = char.MinValue;
    int maxValue = 0;
    foreach (KeyValuePair<char, int> entry in charCount)
    {
        if (entry.Value > maxValue)
        {
            maxValue = entry.Value;
            maxKey = entry.Key;
        }
    }

    //Console.WriteLine("Max key = " + maxKey);
    prioritySum += GetItemPriority(maxKey);
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