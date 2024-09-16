using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardPresenter : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private CardData _cardData;
    [SerializeField] private GamePresenter _gamePresenter;

    private void Start()
    {
        GetComponent<Image>().sprite = _cardData.Image;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("CardPresenter OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _cardData.play(_gamePresenter.LastCardData);
    }
}    