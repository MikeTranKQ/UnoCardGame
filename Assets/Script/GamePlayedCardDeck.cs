using System;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayedCardDeck : CardList
{
    public CardData GetLastCardData()
    {
        return CardDataList[CardDataList.Count - 1];
    }
}