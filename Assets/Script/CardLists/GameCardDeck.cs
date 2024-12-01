using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameCardDeck : CardList, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private List<PlayerCardList> playerCardLists;
    [SerializeField] private GamePlayedCardDeck gamePlayedCardDeck;
    private GamePresenter _gamePresenter;

    private void Start()
    {
        _gamePresenter = GameObject.Find("GameManager").GetComponent<GamePresenter>();
        CardDataList = ShuffleCards((CardDataList));
        for (int i = 0; i < playerCardLists.Count; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                MoveCard(0, playerCardLists[i]);
            }
        }

        int index = 0;
        while (index < CardDataList.Count && !(CardDataList[index] is NumberCardData))
        {
            index++;
        }

        MoveCard(index, gamePlayedCardDeck);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_gamePresenter.CurrentPlayer == playerCardLists[0])
        {
            MoveCard(0, playerCardLists[0]);
            _gamePresenter.NextPlayer();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
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