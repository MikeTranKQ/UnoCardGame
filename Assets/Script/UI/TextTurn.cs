using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTurn : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> playerTexts; 
    private GamePresenter _gamePresenter;

    private void Start()
    {
        _gamePresenter = GamePresenter.Instance;
        UpdateTurnText();
    }

    private void Update()
    {
        UpdateTurnText();
    }

    private void UpdateTurnText()
    {
        for (int i = 0; i < playerTexts.Count; i++)
        {
            playerTexts[i].gameObject.SetActive(_gamePresenter.PlayerCardLists[i] == _gamePresenter.CurrentPlayer);
        }
    }
}