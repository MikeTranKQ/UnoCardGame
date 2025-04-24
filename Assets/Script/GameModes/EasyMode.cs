using System.Collections;
using UnityEngine;

public class EasyMode : MonoBehaviour
{
    private PlayerCardList _playerCardList;
    private bool _isPlayingTurn = false;
    [SerializeField] private GameCardDeck _gameCardDeck;
    private GamePresenter _gamePresenter;
    private bool _hasSaidUNO = false;
    private bool _isWaitingToSayUNO = false; 
    [SerializeField] private GameObject _changeColorsCanvas;
    private void Awake()
    {
        _playerCardList = GetComponent<PlayerCardList>();
    }

    private void Start()
    {
        _gamePresenter = GamePresenter.Instance;
    }

    private void Update()
    {
        if (_isPlayingTurn || _playerCardList != GamePresenter.Instance.CurrentPlayer)
        {
            return;
        }
        
        StartCoroutine(PlayTurnWithDelay());
    }
    
    private IEnumerator PlayTurnWithDelay()
{
    _isPlayingTurn = true;
    bool hasPlayed = false;

    for (int i = 0; i < _playerCardList.GetCardCount(); i++)
    {
        CardData cardData = _playerCardList.GetCardData(i);
        if (cardData.CanPlay(GamePlayedCardDeck.Instance.GetLastCardData()))
        {
            yield return new WaitForSeconds(3.0f);

            cardData.HandleOnPlayControlTurn(GamePresenter.Instance.GetNextPlayer(), GamePresenter.Instance);
            cardData.HandleOnPlayDrawCard(GamePresenter.Instance.GetNextPlayer(), GameCardDeck.Instance, GamePresenter.Instance);
            _playerCardList.MoveCard(i, GamePlayedCardDeck.Instance);
            _gamePresenter.CheckGameOver();
            
            if (cardData is WildCardData)
            {
                CardColor randomColor = (CardColor)UnityEngine.Random.Range(0, 4);
                GamePlayedCardDeck.Instance.GetLastCardData().Color = randomColor;
                _changeColorsCanvas.gameObject.SetActive(false);
                Debug.Log($"{gameObject.name} has chosen the color {randomColor}");
            }
            
            if (cardData is WildDrawFourCardData)
            {
                CardColor randomColor = (CardColor)UnityEngine.Random.Range(0, 4);
                GamePlayedCardDeck.Instance.GetLastCardData().Color = randomColor;
                _changeColorsCanvas.gameObject.SetActive(false);
                Debug.Log($"{gameObject.name} has chosen the color {randomColor}");
            }

            GamePresenter.Instance.NextPlayer();
            hasPlayed = true;

            if (_playerCardList.GetCardCount() == 1)
            {
                StartCoroutine(AutoSayUNO());
            }
            break;
        }
    }

    if (!hasPlayed)
    {
        yield return new WaitForSeconds(2.0f);
        if (_gameCardDeck.GetCardCount() > 0)
        {
            _gameCardDeck.MoveCard(0, _playerCardList);
            CardData drawnCard = _playerCardList.GetCardData(_playerCardList.GetCardCount() - 1);

            if (drawnCard.CanPlay(GamePlayedCardDeck.Instance.GetLastCardData()))
            {
                yield return new WaitForSeconds(2.0f);
                drawnCard.HandleOnPlayControlTurn(GamePresenter.Instance.GetNextPlayer(), GamePresenter.Instance);
                drawnCard.HandleOnPlayDrawCard(GamePresenter.Instance.GetNextPlayer(), GameCardDeck.Instance, GamePresenter.Instance);
                _playerCardList.MoveCard(_playerCardList.GetCardCount() - 1, GamePlayedCardDeck.Instance);
            }
        }

        GamePresenter.Instance.NextPlayer();
    }

    _isPlayingTurn = false;
}


    private IEnumerator AutoSayUNO()
    {
        _isWaitingToSayUNO = true;
        yield return new WaitForSeconds(3.0f);
        
        if (_isWaitingToSayUNO)
        {
            _hasSaidUNO = true;
            Debug.Log($"{gameObject.name} has said UNO");
        }

        _isWaitingToSayUNO = false;
    }

    public bool HasSaidUNO()
    {
        return _hasSaidUNO;
    }

    public PlayerCardList GetPlayerCardList()
    {
        return _playerCardList;
    }

    public void GetCaughtNotSayingUNO()
    {
        if (!_hasSaidUNO) 
        {
            _gameCardDeck.MoveCard(0, _playerCardList);
            _gameCardDeck.MoveCard(0, _playerCardList);
        }
        
        _isWaitingToSayUNO = false; 
    }
}