using System.Xml.Serialization;
using Advent2;

int totalScore = 0;

var lines = File.ReadLines("input");
foreach (String line in lines)
{
    String[] parts = line.Split(" ");
    Choice opponentChoice = new Choice(parts[0]);
    Choice myChoice = new Choice(parts[1]);
    int roundScore = 0;
    // Score for selected shape
    roundScore += myChoice.GetShapeValue();
    // Score for Win/Loss/Draw
    roundScore += myChoice.GetRoundScore(opponentChoice);
    //
    totalScore += roundScore;
}

Console.WriteLine("Your total score is: " + totalScore);