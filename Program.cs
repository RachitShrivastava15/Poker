
using System;
using System.Collections.Generic;
using System.Linq;
using Proker;

public class Program
{
    public static void Main(string[] args)
    {
        var evaluator = new PokerHandDeterminization();

        
        var firstHand = new List<Card>
        {
            new Card(Suit.Spades, Rank.Ten),
            new Card(Suit.Spades, Rank.Jack),
            new Card(Suit.Spades, Rank.Queen),
            new Card(Suit.Spades, Rank.King),
            new Card(Suit.Spades, Rank.Ace)
        };

        var secondHand = new List<Card>
        {
            new Card(Suit.Hearts, Rank.Ace),
            new Card(Suit.Clubs, Rank.Ten),
            new Card(Suit.Spades, Rank.Five),
            new Card(Suit.Diamonds, Rank.Eight),
            new Card(Suit.Hearts, Rank.Three)
        };

        var firstHandResult = evaluator.EvaluateHand(firstHand);
        var secondHandResult = evaluator.EvaluateHand(secondHand);

        if(firstHandResult > secondHandResult)
        {
            Console.WriteLine("First Player is the Winner");
        }
        if(firstHandResult == secondHandResult)
        {
            Console.WriteLine("It's an Tie");
        }
        else
        {
            Console.WriteLine("Second Player is Winner");
        }
    }
}