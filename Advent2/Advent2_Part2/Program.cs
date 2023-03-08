using System.Xml.Serialization;
using Advent2_Part2;

int totalScore = 0;

var lines = File.ReadLines("input");
foreach (String line in lines)
{
    String[] parts = line.Split(" ");
    Choice opponentChoice = new Choice(parts[0]);
    // Choose player choice based on Y = draw, X = lose, Z = win

    Choice myChoice;

    switch (parts[1])
    {
        // Draw
        case "Y":
            myChoice = new Choice(opponentChoice.shape);
            break;
        // Lose
        case "X":
            myChoice = Choice.CreateLoser(opponentChoice);
            break;
        // Win
        case "Z":
            myChoice = Choice.CreateWinner(opponentChoice);
            break;
        default:
            myChoice = new Choice(opponentChoice.shape);
            break;
    }



    int roundScore = 0;
    // Score for selected shape
    roundScore += myChoice.GetShapeValue();
    // Score for Win/Loss/Draw
    roundScore += myChoice.GetRoundScore(opponentChoice);
    //
    totalScore += roundScore;
}

Console.WriteLine("Your total score is: " + totalScore);