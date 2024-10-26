using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayedCardDeck : CardList
{
    public CardData GetLastCardData()
    {
        return CardDataList[CardDataList.Count - 1];
    }

    public void Update()
    {
        gameObject.GetComponent<Image>().sprite = GetLastCardData().Image;
    }
}