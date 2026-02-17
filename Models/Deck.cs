using System;
using System.Collections.Generic;

public class Deck
{
    private List<Card> cards = new List<Card>();
    private Random rand = new Random();

    public Deck()
    {
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        foreach (var suit in suits)
        {
            for (int i = 0; i < ranks.Length; i++)
            {
                int value = i + 2;

                if (ranks[i] == "J" || ranks[i] == "Q" || ranks[i] == "K")
                    value = 10;

                if (ranks[i] == "A")
                    value = 11;

                cards.Add(new Card(suit, ranks[i], value));
            }
        }
    }

    public Card Draw()
    {
        int index = rand.Next(cards.Count);
        Card card = cards[index];
        cards.RemoveAt(index);
        return card;
    }
}
