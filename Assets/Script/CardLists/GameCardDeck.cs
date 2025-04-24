using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameCardDeck : CardList, IPointerUpHandler, IPointerDownHandler
{
    public static GameCardDeck Instance;
    [SerializeField] private GamePlayedCardDeck gamePlayedCardDeck;
    private GamePresenter _gamePresenter;

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _gamePresenter = GamePresenter.Instance;
        CardDataList = ShuffleCards((CardDataList));
        for (int i = 0; i < _gamePresenter.PlayerCardLists.Count; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                MoveCard(0, _gamePresenter.PlayerCardLists[i]);
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
        if (_gamePresenter.CurrentPlayer == _gamePresenter.PlayerCardLists[0])
        {
            MoveCard(0, _gamePresenter.PlayerCardLists[0]);
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