using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCardList : CardList
{
    [SerializeField] private GameObject cardPlaceholderPrefab;
    [SerializeField] private GameObject cardVisualPrefab;
    [SerializeField] private Transform _cardPlaceholdersContainerTransform;
    [SerializeField] private Transform _cardViualsContainerTransform;

    protected override void UpdateView()
    {
        foreach (Transform child in _cardPlaceholdersContainerTransform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in _cardViualsContainerTransform)
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
        GameObject cardPlaceholderInstance = Instantiate(cardPlaceholderPrefab, _cardPlaceholdersContainerTransform);
        cardPlaceholderInstance.transform.SetParent(_cardPlaceholdersContainerTransform);
        cardPlaceholderInstance.transform.localPosition = position;
        cardPlaceholderInstance.transform.localRotation = Quaternion.identity;
        cardPlaceholderInstance.transform.localScale = Vector3.one;

        CardPresenter cardPlaceHolderPresenter = cardPlaceholderInstance.GetComponent<CardPresenter>();
        cardPlaceHolderPresenter.SetCardData(cardData);
        cardPlaceHolderPresenter.SetPlayerCardList(this);
        cardPlaceHolderPresenter.SetIndex(index);

        GameObject cardVisualInstance = Instantiate(cardVisualPrefab, _cardViualsContainerTransform);
        cardVisualInstance.transform.SetParent(_cardViualsContainerTransform);
        cardVisualInstance.transform.localPosition = position;
        cardVisualInstance.transform.localRotation = Quaternion.identity;
        cardVisualInstance.transform.localScale = Vector3.one;

        cardVisualInstance.GetComponent<Image>().sprite = cardData.Image;
        
    }
}