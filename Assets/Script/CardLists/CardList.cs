using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    [SerializeField] protected List<CardData> CardDataList;

    public int GetCardCount()
    {
        return CardDataList.Count;
    }

    public CardData GetCardData(int index)
    {
        return CardDataList[index];
    }
    protected virtual void AddCard(CardData cardData)
    {
        CardDataList.Add(cardData);
        UpdateView();
    }

    protected virtual void UpdateView()
    {
    }

    public void MoveCard(int index, CardList targetCardList)
    {
        targetCardList.AddCard(CardDataList[index]);
        CardDataList.RemoveAt(index);
        UpdateView();
    }
}