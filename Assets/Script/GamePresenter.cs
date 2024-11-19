using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    [SerializeField] private List<PlayerCardList> playerCardLists;
    public PlayerCardList CurrentPlayer;

    public PlayerCardList GetNextPlayer()
    {
        int index = playerCardLists.IndexOf(CurrentPlayer);
        return playerCardLists[(index + 1) % playerCardLists.Count];
    }
    public void NextPlayer()
    {
        CurrentPlayer = GetNextPlayer();
    }
}