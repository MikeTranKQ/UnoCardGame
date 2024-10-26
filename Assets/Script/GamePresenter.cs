using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    [SerializeField] private List<PlayerCardList> playerCardLists;
    public PlayerCardList CurrentPlayer;

    public void NextPlayer()
    {
        int index = playerCardLists.IndexOf(CurrentPlayer);
        CurrentPlayer = playerCardLists[(index + 1) % playerCardLists.Count];
    }
}