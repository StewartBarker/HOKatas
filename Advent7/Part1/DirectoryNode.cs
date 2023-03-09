namespace Part1;

public class DirectoryNode : FileNode
{
    private readonly List<FileNode?> _children = new List<FileNode?>();
    public DirectoryNode(String name)
    {
        this.Name = name;
    }

    private DirectoryNode(DirectoryNode? parent, String name)
    {
        this.Parent = parent;
        this.Name = name;
    }
    public FileNode? AddChildFile(String childName, int childSize)
    {
        FileNode? child = new FileNode(this, childName, childSize);
        _children.Add(child);
        this.Size += childSize;
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

}