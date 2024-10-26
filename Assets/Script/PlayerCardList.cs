using System.Collections.Generic;
using UnityEngine;

public class PlayerCardList : CardList
{
    [SerializeField] private GameObject cardPrefab;

    protected override void UpdateView()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < CardDataList.Count; i++)
        {
            ShowCardGameObject(CardDataList[i], i, new Vector3(i * 100, 0, 0));
        }
    }

    public void ShowCardGameObject(CardData cardData, int index, Vector3 position)
    {
        GameObject cardInstance = Instantiate(cardPrefab, transform); 
        cardInstance.transform.SetParent(transform);
        cardInstance.transform.localPosition = position;
        cardInstance.transform.localRotation = Quaternion.identity;
        cardInstance.transform.localScale = Vector3.one;

        CardPresenter cardPresenter = cardInstance.GetComponent<CardPresenter>();
        cardPresenter.SetCardData(cardData);
        cardPresenter.SetPlayerCardList(this);
        cardPresenter.SetIndex(index);
        if (gameObject)
        {
            cardPresenter.ShowImage();
        }
    }
}