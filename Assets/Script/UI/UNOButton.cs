using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UNOButton : MonoBehaviour
{
    [SerializeField] private Button _UNOButton;
    [SerializeField] private CardList _playerCardList;
    [SerializeField] private CardList _gameCardDeck;
    private bool _hasSaidUNO = false;
    private bool _isWaitingToSayUNO = false;

    public bool HasSaidUNO => _hasSaidUNO;

    private void Start()
    {
        _UNOButton.onClick.AddListener(OnUNOButtonClicked);
    }

    private void OnUNOButtonClicked()
    {
        _hasSaidUNO = true;
        _isWaitingToSayUNO = false; 
        Debug.Log("Player1 has said UNO!");
    }

    public void CheckForUNO()
    {
        if (_playerCardList.GetCardCount() == 1)
        {
            StartUNOCountdown();
        }
    }

    private void StartUNOCountdown()
    {
        _hasSaidUNO = false;
        _isWaitingToSayUNO = true;
        StartCoroutine(UNOCountdown());
    }

    private IEnumerator UNOCountdown()
    {
        yield return new WaitForSeconds(3f);

        if (!_hasSaidUNO && _isWaitingToSayUNO)
        {
            Debug.Log("Player1 has not said UNO, 2 cards added");
            _gameCardDeck.MoveCard(0, _playerCardList);
            _gameCardDeck.MoveCard(0, _playerCardList);
        }

        _isWaitingToSayUNO = false;
    }
}