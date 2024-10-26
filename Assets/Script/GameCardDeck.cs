using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCardDeck :  CardList
{
    [SerializeField] private List<PlayerCardList> playerCardLists;
    [SerializeField] private GamePlayedCardDeck gamePlayedCardDeck;
    private void Start()
    {
        CardDataList = ShuffleCards((CardDataList));
        for (int i = 0; i < playerCardLists.Count; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                MoveCard(0, playerCardLists[i]);
            }
        }
        MoveCard(0, gamePlayedCardDeck);
    }

    public void Update()
    {
        if (CardDataList.Count == 0)
        {
            gameObject.GetComponent<Image>().enabled = false;
        }
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