using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardPresenter : MonoBehaviour
{
    [SerializeField] private CardData _cardData;
    [SerializeField] private GamePresenter _gamePresenter;
    private GamePlayedCardDeck _gamePlayedCardDeck;
    private PlayerCardList _playerCardList;
    private int _index;

    private void Start()
    {
        _gamePlayedCardDeck = GameObject.Find("PlayedDeck").GetComponent<GamePlayedCardDeck>();
        _gamePresenter = GameObject.Find("GameManager").GetComponent<GamePresenter>();
    }
}