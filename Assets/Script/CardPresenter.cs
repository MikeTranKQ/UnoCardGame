using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardPresenter : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private CardData _cardData;
    [SerializeField] private GamePresenter _gamePresenter;
    private GamePlayedCardDeck _gamePlayedCardDeck;
    private PlayerCardList _playerCardList;
    private int _index;

    private void Start()
    {
        _gamePlayedCardDeck = GameObject.Find("PlayedDeck").GetComponent<GamePlayedCardDeck>();
    }

    public void ShowImage()
    {
        GetComponent<Image>().sprite = _cardData.Image;
    }

    public void SetPlayerCardList(PlayerCardList playerCardList)
    {
        _playerCardList = playerCardList;
    }

    public void SetCardData(CardData cardData)
    {
        _cardData = cardData;
    }

    public void SetIndex(int index)
    {
        _index = index;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_cardData.canPlay(_gamePlayedCardDeck.GetLastCardData()))
        {
            _playerCardList.MoveCard(_index, _gamePlayedCardDeck);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }
}