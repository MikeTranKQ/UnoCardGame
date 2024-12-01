using UnityEngine;

[CreateAssetMenu(fileName = "CD_", menuName = "Card Data/Wild Draw Four", order = 0)]
public class WildDrawFourCardData : CardData
{
    public override void HandleOnPlayDrawCard(PlayerCardList nextPlayerCardList, GameCardDeck gameCardDeck)
    {
        for (int i = 0; i < 4; i++)
        {
            gameCardDeck.MoveCard(0, nextPlayerCardList);
        }
    }

    public override bool CanPlay(CardData lastCardData)
    {
        return true;
    }
}