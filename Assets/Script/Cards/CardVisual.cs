using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CardVisual : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private CardData _cardData;
    private GamePresenter _gamePresenter;
    private GamePlayedCardDeck _gamePlayedCardDeck;
    private GameCardDeck _gameCardDeck;
    private PlayerCardList _playerCardList;
    private int _index;
    public Transform CardPlaceholderTransform;
    
    private void Start()
    {
        _gamePlayedCardDeck = GamePlayedCardDeck.Instance;
        _gamePresenter = GamePresenter.Instance;
        _gameCardDeck = GameCardDeck.Instance;
    }

    private void Update()
    {
        if (CardPlaceholderTransform != null)
        {
            transform.position = CardPlaceholderTransform.position;
            transform.rotation = CardPlaceholderTransform.rotation;
        }
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
        if (_playerCardList != _gamePresenter.CurrentPlayer)
        {
            return;
        }

        if (_cardData.CanPlay(_gamePlayedCardDeck.GetLastCardData()))
        {
            _cardData.HandleOnPlayControlTurn(_gamePresenter.GetNextPlayer(), _gamePresenter);
            _cardData.HandleOnPlayDrawCard(_gamePresenter.GetNextPlayer(), _gameCardDeck, _gamePresenter);
            _playerCardList.MoveCard(_index, _gamePlayedCardDeck);
            _gamePresenter.CheckGameOver();
            _gamePresenter.NextPlayer();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }
}