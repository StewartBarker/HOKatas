const int markerLength = 4;

String input = File.ReadAllLines("input")[0];

for (int i = 0; i <= input.Length-markerLength; i++)
{
    if (IsMarker(input.Substring(i, markerLength)))
    {
        Console.WriteLine("Answer: " + (i+markerLength));
        return;
    }
}

bool IsMarker(String range)
{
    return range.Length == range.Distinct().Count();
}