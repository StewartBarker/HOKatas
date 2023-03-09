using Part1;

string[] lines = File.ReadAllLines("input");



int lineNumber = 1;

// Initialise at root
DirectoryNode? currentDir = new DirectoryNode("/");

foreach (string line in lines)
{
    Console.WriteLine("Parsing line: " + lineNumber);
    ParseLine(line);
    lineNumber++;
}


void ParseLine(string line)
{
    string[] parts = line.Split(" ");
    if (parts[0].Equals("$"))
    {
        if (parts[1].Equals("cd"))
        {
            ChangeDir(parts[2]);
        }
        // Ignore ls command
        return;
    }
    ParseDirContents(parts);
}

void ChangeDir(string dir)
{
    if (dir.Equals(currentDir.Name))
    {
        return;
    }
    if (dir.Equals(".."))
    {
        if (currentDir.Name.Equals("/"))
        {
            Console.WriteLine("ERROR - Cannot access parent of root");
            return;
        }
        currentDir = currentDir.Parent;
        return;
    }

    var newDir = currentDir.GetChild(dir) as DirectoryNode;
    if (newDir == null)
    {
        Console.WriteLine("ERROR - Directory does not exist: " + dir);
        return;
    }
    currentDir = newDir;
}

void ParseDirContents(string[] parts)
{
    if (parts[0].Equals("dir"))
    {
        currentDir.AddChildDir(parts[1]);
    }
    else
    {
        currentDir.AddChildFile(parts[1], int.Parse(parts[0]));
    }
}