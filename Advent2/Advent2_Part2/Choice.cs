using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks.Sources;

namespace Advent2_Part2;

public class Choice
{
    const int rockScore = 1;
    const int paperScore = 2;
    const int scissorsScore = 3;
    const int lossScore = 0;
    const int drawScore = 3;
    const int winScore = 6;
    
    public enum Shape
    {
    Rock,
    Paper,
    Scissors
    }

    private static Dictionary<Shape, Shape> beatsDictionary = new Dictionary<Shape, Shape>()
    {
        {
            Shape.Rock, Shape.Scissors
        },
        {
            Shape.Paper, Shape.Rock
        },
        {
            Shape.Scissors, Shape.Paper
        }
    };

    public Shape shape;
    public Choice(String str)
    {
        switch (str)
        {
            case "A":
                shape = Shape.Rock;
                break;
            case "B":
                shape = Shape.Paper;
                break;
            case "C":
                shape = Shape.Scissors;
                break;
            default:
                throw new ArgumentException("value not in {A, B, C}");
        }
    }

    public Choice(Shape shape)
    {
        this.shape = shape;
    }
    
    private bool Beats(Choice opponent)
    {
        return beatsDictionary[this.shape].Equals(opponent.shape);
    }

    public bool Equals(Choice opponent)
    {
        return this.shape.Equals(opponent.shape);
    }

    public int GetShapeValue()
    {
        switch (shape)
        {
            case Shape.Rock:
                return rockScore;
                break;
            case Shape.Paper:
                return paperScore;
                break;
            case Shape.Scissors:
                return scissorsScore;
                break;
            default:
                return 0;
        }
    }

    public int GetRoundScore(Choice opponent)
    {
        if (Beats(opponent))
        {
            return winScore;
        }
        if (Equals(opponent))
        {
            return drawScore;
        }
        return lossScore;
        }

    public static Choice CreateWinner(Choice opponent)
    {
        foreach (Shape shape in beatsDictionary.Keys)
        {
            if (beatsDictionary[shape].Equals(opponent.shape))
            {
                return new Choice(shape);
            }
        }

        return null;
    }

    public static Choice CreateLoser(Choice opponent)
    {
        return new Choice(beatsDictionary[opponent.shape]);
    }
    
}