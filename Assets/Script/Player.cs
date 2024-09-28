using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<CardData> cardList = new List<CardData>();

    public void AddCard(CardData cardData)
    {
        cardList.Add(cardData);
    }
}