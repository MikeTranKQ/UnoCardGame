using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayedCardDeck : CardList
{
    public static GamePlayedCardDeck Instance;

    [SerializeField] private GameObject _changeColorsCanvas;

    public void Awake()
    {
        Instance = this;
    }

    public CardData GetLastCardData()
    {
        if (CardDataList.Count == 0)
        {
            return null;
        }

        return CardDataList[CardDataList.Count - 1];
    }

    public CardData GetLastCardDataIndex(int index)
    {
        if (CardDataList.Count == 0)
        {
            return null;
        }

        return CardDataList[index];
    }

    protected override void AddCard(CardData cardData)
    {
        base.AddCard(cardData);
        CardData lastCardData = GetLastCardData();
        if (lastCardData is WildCardData || lastCardData is WildDrawFourCardData)
        {
            _changeColorsCanvas.gameObject.SetActive(true);
        }
    }

    public void Update()
    {
        if (GetLastCardData() != null)
        {
            gameObject.GetComponent<Image>().sprite = GetLastCardData().Image;
        }
    }
}