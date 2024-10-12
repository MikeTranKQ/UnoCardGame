using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    private List<CardData> cardList = new List<CardData>();

    public void AddCard(CardData cardData, Vector3 position)
    {
        cardList.Add(cardData);
        GameObject cardInstance = Instantiate(cardPrefab); 
        cardInstance.transform.SetParent(transform);
        cardInstance.transform.localPosition = position;
        cardInstance.transform.localRotation = Quaternion.identity;
        cardInstance.transform.localScale = Vector3.one;

        CardPresenter cardPresenter = cardInstance.GetComponent<CardPresenter>();
        cardPresenter.SetCardData(cardData);
        if (gameObject.CompareTag("Player"))
        {
            cardPresenter.ShowImage();
        }
    }
}