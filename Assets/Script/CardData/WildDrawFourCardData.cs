using UnityEngine;

[CreateAssetMenu(fileName = "CD_", menuName = "Card Data/Wild Draw Four", order = 0)]
public class WildDrawFourCardData : CardData
{
    public override void HandleOnPlayDrawCard(PlayerCardList nextPlayerCardList, GameCardDeck gameCardDeck, GamePresenter gamePresenter)
    {
        for (int i = 0; i < 4; i++)
        {
            gameCardDeck.MoveCard(0, nextPlayerCardList);
        }
        gamePresenter.NextPlayer();
    }

    public override bool CanPlay(CardData lastCardData)
    {
        return true;
    }
}