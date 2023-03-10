namespace Part1;

public class DirectoryNode : FileNode
{
    private readonly List<FileNode?> _children;
    public DirectoryNode(String name)
    {
        this.Name = name;
        _children = new List<FileNode>();
    }

    private DirectoryNode(DirectoryNode? parent, String name)
    {
        this.Parent = parent;
        this.Name = name;
        _children = new List<FileNode>();
    }
    public FileNode? AddChildFile(String childName, int childSize)
    {
        FileNode? child = new FileNode(this, childName, childSize);
        _children.Add(child);
        return child;
    }
    public DirectoryNode? AddChildDir(String childName)
    {
        DirectoryNode? child = new DirectoryNode(this, childName);
        _children.Add(child);
        return child;
    }

    public FileNode? GetChild(string name)
    {
        foreach (var child in _children)
        {
            if (child != null && child.Name.Equals(name))
            {
                return child;
            }
        }

        return null;
    }

    public override int GetSize()
    {
        if (this.Size > 0)
        {
            //If size already set, do not recalculate
            return this.Size;
        }
        int size = 0;
        foreach (FileNode child in _children)
        {
            size += child.GetSize();
        }
        this.Size = size;
        return this.Size;
    }

    public List<DirectoryNode> GetDirsBelowSize(int size, List<DirectoryNode> dirs)
    {
        if (GetSize() <= size && this.GetType() == typeof(DirectoryNode))
        {
            dirs.Add(this);
        }

        foreach (var child in _children)
        {
            if (child.GetType() == typeof(DirectoryNode))
            {
                DirectoryNode childDir = (DirectoryNode)child;
                childDir.GetDirsBelowSize(size, dirs);
            }
        }
        return dirs;
    }

    public List<FileNode> ToFlatList()
    {
        Console.WriteLine("Creating flat list for directory " + this.Name);
        List <FileNode> list= new List<FileNode>(_children);
        
        foreach (var child in _children)
        {
            if (child.GetType() == typeof(DirectoryNode))
            {
                DirectoryNode childDir = (DirectoryNode)child;
                list.AddRange(childDir.ToFlatList());
            }
        }
        return list;
    }

}