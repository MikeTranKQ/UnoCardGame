using System;
using System.Collections.Generic;
using UnityEngine;

public class GameCardDeck: MonoBehaviour
{ 
    [SerializeField] private List<CardData> cardList;
    [SerializeField] private List<Player> playerList;

    private void Start()
    {
        Debug.Log(playerList[0]);
        Debug.Log(cardList[0]);
        Debug.Log(playerList.Count);
        Debug.Log(cardList.Count);
        playerList[0].AddCard(cardList[0]); 
    }
}