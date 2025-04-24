using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using System.Collections;

public class GamePresenter : MonoBehaviour
{
    public static GamePresenter Instance;
    [SerializeField] public List<PlayerCardList> PlayerCardLists;
    public PlayerCardList CurrentPlayer;
    private int _direction = 1;
    [SerializeField] private Canvas _gameCanvas;
    [SerializeField] private Canvas _gameOverCanvas;
    [SerializeField] private TextMeshProUGUI _gameOverMessageText;

    private void Awake()
    {
        Instance = this;
    }
    

    public PlayerCardList GetNextPlayer()
    {
        int index = PlayerCardLists.IndexOf(CurrentPlayer);
        index = (index + _direction + PlayerCardLists.Count) % PlayerCardLists.Count;
        return PlayerCardLists[index];
    }

    public void NextPlayer()
    {
        CurrentPlayer = GetNextPlayer();
    }

    public void ReverseNextPlayer()
    {
        _direction *= -1;
    }
    
    public void CheckGameStart()
    {
        
    }
    public void CheckGameOver()
    {
        if (CurrentPlayer.GetCardCount() == 0)
        {
            _gameCanvas.gameObject.SetActive(false);
            _gameOverCanvas.gameObject.SetActive(true);
            _gameOverMessageText.text = "Congratulation! " + CurrentPlayer.gameObject.name + " is the winner!";
        }
    }
}