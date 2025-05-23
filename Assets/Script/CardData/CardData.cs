using UnityEngine;

public abstract class CardData : ScriptableObject
{
    public Sprite Image;
    public CardColor Color;

    public abstract bool CanPlay(CardData lastCardData);

    public virtual void HandleOnPlayDrawCard(PlayerCardList nextPlayerCardList, GameCardDeck gameCardDeck, GamePresenter gamePresenter)
    {
    }

    public virtual void HandleOnPlayControlTurn(PlayerCardList nextPlayerCardList, GamePresenter gamePresenter)
    {
    }
}