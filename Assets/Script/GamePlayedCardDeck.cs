using System;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayedCardDeck : MonoBehaviour 
{
    [SerializeField] private List<CardData> playedCardList;

    public CardData GetLastCardData()
    {
        return playedCardList[playedCardList.Count - 1];
    }
    public void AddPlayedCard(CardData playedCardData)
    {
        playedCardList.Add(playedCardData);
    }
}
