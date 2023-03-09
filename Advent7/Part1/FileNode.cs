namespace Part1;

public class FileNode
{
    public string Name { get; set; }
    public int Size{ get; set; }
    public DirectoryNode? Parent{ get; set; }
    
    public FileNode(DirectoryNode? parent, string name, int size)
    {
        this.Parent = parent;
        this.Name = name;
        this.Size = size;
    }

    public FileNode()
    {
        
    }
    
}