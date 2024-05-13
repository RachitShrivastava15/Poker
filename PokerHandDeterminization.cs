using System;
namespace Proker
{
    public class PokerHandDeterminization
    {
        public enum HandRank
        {
            HighCard = 1,
            OnePair = 2,
            TwoPair = 3,
            ThreeOfAKind = 4,
            Straight = 5,
            Flush = 6,
            FullHouse = 7,
            FourOfAKind = 8,
            StraightFlush = 9,
            RoyalFlush = 10

        }

        public int EvaluateHand(List<Card> hand)
        {
            if (IsRoyalFlush(hand)) return (int) HandRank.RoyalFlush;
            if (IsStraightFlush(hand)) return (int) HandRank.StraightFlush;
            if (IsFourOfAKind(hand)) return (int) HandRank.FourOfAKind;
            if (IsFullHouse(hand)) return (int) HandRank.FullHouse;
            if (IsFlush(hand)) return (int) HandRank.Flush;
            if (IsStraight(hand)) return (int) HandRank.Straight;
            if (IsThreeOfAKind(hand)) return (int) HandRank.ThreeOfAKind;
            if (IsTwoPair(hand)) return (int) HandRank.TwoPair;
            if (IsOnePair(hand)) return (int) HandRank.OnePair;
            return (int) HandRank.HighCard;
        }

        private bool IsRoyalFlush(List<Card> hand)
        {
            return IsStraightFlush(hand) && hand.All(card => card.Rank >= Rank.Ten);
        }

        private bool IsStraightFlush(List<Card> hand)
        {
            return IsFlush(hand) && IsStraight(hand);
        }

        private bool IsFourOfAKind(List<Card> hand)
        {
            var rankGroups = hand.GroupBy(card => card.Rank);
            return rankGroups.Any(group => group.Count() == 4);
        }

        private bool IsFullHouse(List<Card> hand)
        {
            var rankGroups = hand.GroupBy(card => card.Rank);
            return rankGroups.Any(group => group.Count() == 3) && rankGroups.Any(group => group.Count() == 2);
        }

        private bool IsFlush(List<Card> hand)
        {
            return hand.GroupBy(card => card.Suit).Count() == 1;
        }

        private bool IsStraight(List<Card> hand)
        {
            var sortedRanks = hand.Select(card => (int)card.Rank).OrderBy(rank => rank).ToList();
            if (sortedRanks.Last() == (int)Rank.Ace && sortedRanks.First() == (int)Rank.Two)
            {
                // Handle A-2-3-4-5 as a valid straight (wheel)
                sortedRanks.Remove(sortedRanks.Last());
                sortedRanks.Insert(0, 1);
            }
            for (int i = 1; i < sortedRanks.Count; i++)
            {
                if (sortedRanks[i] != sortedRanks[i - 1] + 1)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsThreeOfAKind(List<Card> hand)
        {
            var rankGroups = hand.GroupBy(card => card.Rank);
            return rankGroups.Any(group => group.Count() == 3);
        }

        private bool IsTwoPair(List<Card> hand)
        {
            var rankGroups = hand.GroupBy(card => card.Rank);
            return rankGroups.Count(group => group.Count() == 2) == 2;
        }

        private bool IsOnePair(List<Card> hand)
        {
            var rankGroups = hand.GroupBy(card => card.Rank);
            return rankGroups.Any(group => group.Count() == 2);
        }
    }

    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Rank
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public class Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }
        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}