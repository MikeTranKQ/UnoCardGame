using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardPresenter : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private CardData _cardData;
    [SerializeField] private GamePresenter _gamePresenter;
    private GamePlayedCardDeck _gamePlayedCardDeck;
    private void Start()
    {
        _gamePlayedCardDeck = GameObject.Find("PlayedDeck").GetComponent<GamePlayedCardDeck>();
    }

    public void ShowImage()
    {
        GetComponent<Image>().sprite = _cardData.Image;
    }

    public void SetCardData(CardData cardData)
    {
        _cardData = cardData;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("CardPresenter OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _cardData.play(_gamePlayedCardDeck.GetLastCardData());
    }
}    