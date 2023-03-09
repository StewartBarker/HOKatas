using System.Collections;
using System.ComponentModel;
using System.Threading.Channels;

// Indexes of relevant fields within instruction
const int countInstruction = 1;
const int fromInstruction = 3;
const int toInstruction = 5;

String[] lines = File.ReadAllLines("input");
String[][] splitInput = SplitInput(lines);
String[] starting = splitInput[0];
String[] instructions = splitInput[1];

Stack<char>[] stacks = InitStacks(starting);
foreach (String instruction in instructions)
{
    String[] parts = instruction.Split(" ");
    int count = int.Parse(parts[countInstruction]);
    int from = int.Parse(parts[fromInstruction])-1;
    int to = int.Parse(parts[toInstruction])-1;
    Move(count, stacks[from], stacks[to]);
}

String answer = "";
foreach (Stack<char> stack in stacks)
{
    answer += stack.Peek();
}

Console.WriteLine("Top of each stack, in order: " + answer);
DrawStacks(stacks);


// Splits input between starting conditions and instructions
String[][] SplitInput(String[] lines)
{
    int boundaryIndex= 0;
    for (int i = 0; i < lines.Length; i++)
    {
        // Split by a blank line
        if (String.IsNullOrWhiteSpace(lines[i]))
        {
            boundaryIndex = i;
        }
    }

    String[] starting = lines[..boundaryIndex];
    String[] instructions = lines[(boundaryIndex + 1)..];

    String[][] output = new String[2][];
    output[0] = starting;
    output[1] = instructions;
    return output;
}

Stack<char>[] InitStacks(String[] starting)
{
    // Get label of furthest-right column to determine number of stacks
    int colCount = int.Parse(starting[^1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());

    Stack<char>[] stacks = new Stack<char>[colCount];
    for (int i = 0; i < colCount; i++)
    {
        stacks[i] = new Stack<char>();
    }
    
    for (int i = starting.Length-2; i >= 0; i--)
    {
        for (int j = 0; j < colCount; j++)
        {
            char c = starting[i][(4*j + 1)];
            if (c == ' ')
            {
                continue;
            }
            stacks[j].Push(c);
        }
    }
    
    return stacks;
}

void Move(int count, Stack<char> from, Stack<char> to)
{
    Stack<char> craneStack = new Stack<char>();
    for (int i = 0; i < count; i++)
    {
        craneStack.Push(from.Pop());
    }
    for (int i = 0; i < count; i++)
    {
        to.Push(craneStack.Pop());
    }
}

void DrawStacks(Stack<char>[] stacks)
{
    Console.WriteLine();
    // Get largest stack
    int maxStackSize = 0;
    foreach (Stack<char> stack in stacks)
    {
        if (stack.Count > maxStackSize)
        {
            maxStackSize = stack.Count;
        }
    }
    // Iterate from top of largest stack down, skipping stacks not equal to that size
    for (int i = maxStackSize - 1; i >= 0; i--)
    {
        foreach (Stack<char> stack in stacks)
        {
            if (stack.Count-1 == i)
            {
                Console.Write(stack.Pop());
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
    //Draw stack labels at bottom
    for (int i = 1; i <= stacks.Length; i++)
    {
        Console.Write(i);
    }


}