using UnityEngine;

public abstract class CardData : ScriptableObject
{
    public Sprite Image;
    public CardColor Color;
    public abstract bool canPlay(CardData lastCardData);

    public virtual void HandleOnPlayDrawCard(PlayerCardList nextPlayerCardList, GameCardDeck gameCardDeck)
    {
    }
    
    public virtual void HandleOnPlayControlTurn(PlayerCardList nextPlayerCardList, GamePresenter gamePresenter)
    {
    }
}