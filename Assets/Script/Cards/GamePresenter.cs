using System;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    public static GamePresenter Instance;
    
    [SerializeField] private List<PlayerCardList> playerCardLists;
    public PlayerCardList CurrentPlayer;

    private int direction = 1;

    private void Awake()
    {
        Instance = this;
    }

    public PlayerCardList GetNextPlayer()
    {
        int index = playerCardLists.IndexOf(CurrentPlayer);
        index = (index + direction + playerCardLists.Count) % playerCardLists.Count;
        return playerCardLists[index];
    }

    public void NextPlayer()
    {
        CurrentPlayer = GetNextPlayer();
    }

    public void ReverseNextPlayer()
    {
        direction *= -1;
    }
}