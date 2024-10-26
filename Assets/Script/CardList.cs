using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    [SerializeField] protected List<CardData> CardDataList;

    public int GetCardCount()
    {
        return CardDataList.Count;
    }

    private void AddCard(CardData cardData)
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