using System.Collections.Generic;

public class Hand
{
    public List<Card> Cards { get; set; } = new List<Card>();

    public void AddCard(Card card)
    {
        Cards.Add(card);
    }

    public int GetScore()
    {
        int total = 0;
        int aceCount = 0;

        foreach (var card in Cards)
        {
            total += card.Value;
            if (card.Rank == "A")
                aceCount++;
        }

        // Adjust Aces from 11 to 1 if bust
        while (total > 21 && aceCount > 0)
        {
            total -= 10;
            aceCount--;
        }

        return total;
    }
}
