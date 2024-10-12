using System;
using System.Collections.Generic;
using UnityEngine;

public class GameCardDeck : MonoBehaviour
{
    [SerializeField] private List<CardData> cardList;
    [SerializeField] private List<Player> playerList;
    [SerializeField] private GamePlayedCardDeck gamePlayedCardDeck;
    private void Start()
    {
        List<CardData> shuffledCards = ShuffleCards(cardList);
        for (int i = 0; i < playerList.Count; i++)
        {
            Debug.Log($"Dealing cards to player {i + 1}");
            for (int j = 0; j < 7; j++)
            {
                playerList[i].AddCard(shuffledCards[i * 7 + j], new Vector3(j*100, 0, 0));
            }
        }
        gamePlayedCardDeck.AddPlayedCard(shuffledCards[28]);
    }
        
    private List<CardData> ShuffleCards(List<CardData> cards)
    {
        System.Random rng = new System.Random();
        int n = cards.Count;
        while (n > 1)
        {
            int k = rng.Next(n--);
            (cards[n], cards[k]) = (cards[k], cards[n]);
        }
        return cards;
    }
}