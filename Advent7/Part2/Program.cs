using Part1;

const int diskSize = 70_000_000;
const int spaceRequired = 30_000_000;

// Initialise at root
DirectoryNode root = new DirectoryNode("/");
DirectoryNode currentDir = root;

string[] lines = File.ReadAllLines("input");
InitTree(lines);
Console.WriteLine("Total disk size: " + diskSize);
Console.WriteLine("Root directory size: " + root.GetSize());
int unusedSpace = diskSize - root.GetSize();
Console.WriteLine("Unused space: " + unusedSpace);

int savingNeeded = spaceRequired - unusedSpace;
Console.WriteLine("Saving needed = " + savingNeeded);


List<FileNode> list = root.ToFlatList();
Console.WriteLine("List size: " + list.Count);
List<DirectoryNode> sortedDirList = list.OfType<DirectoryNode>().OrderBy(e => e.Size).ToList();
Console.WriteLine("DirList size: " + sortedDirList.Count);

for (int i = 0; i < sortedDirList.Count; i++)
{
    int dirSize = sortedDirList[i].Size;
    if (dirSize >= savingNeeded)
    {
        Console.WriteLine("Size of dir to remove: " + dirSize);
        break;
    }
}

void InitTree(string[] lines)
{
    int lineNumber = 1;
    foreach (string line in lines)
    {
        Console.WriteLine("Parsing line: " + lineNumber);
        ParseLine(line);
        lineNumber++;
    }
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
    if (dir.Equals("/"))
    {
        currentDir = root;
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

    FileNode newDir = currentDir.GetChild(dir);
    if (newDir == null)
    {
        Console.WriteLine("ERROR - Directory does not exist: " + dir + ", under parent " + currentDir.Name);
        return;
    }
    if (newDir.GetType() != typeof(DirectoryNode))
    {
        Console.WriteLine("ERROR - Is file, not directory: " + dir);
        return;
    }
    
    currentDir = (DirectoryNode)newDir;
}

void ParseDirContents(string[] parts)
{
    if (currentDir.GetChild(parts[1]) != null)
    {
        //Do not add file/directory if already present
        return;
    }

    if (parts[0].Equals("dir"))
    {
        currentDir.AddChildDir(parts[1]);
    }
    else
    {
        currentDir.AddChildFile(parts[1], int.Parse(parts[0]));
        
    }
}