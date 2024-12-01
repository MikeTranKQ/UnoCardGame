using UnityEngine;

[CreateAssetMenu(fileName = "CD_", menuName = "Card Data/Draw Two", order = 0)]
public class DrawTwoCardData : CardData
{
    public override void HandleOnPlayDrawCard(PlayerCardList nextPlayerCardList, GameCardDeck gameCardDeck)
    {
        for (int i = 0; i < 2; i++)
        {
            gameCardDeck.MoveCard(0, nextPlayerCardList);
        }
    }

    public override bool CanPlay(CardData lastCardData)
    {
        if (lastCardData is NumberCardData lastNumberCardData)
        {
            return lastNumberCardData.Color == Color;
        }

        if (lastCardData is DrawTwoCardData)
        {
            return true;
        }

        if (lastCardData is SkipCardData lastSkipCardData)
        {
            return lastSkipCardData.Color == Color;
        }

        if (lastCardData is ReverseCardData lastReverseCardData)
        {
            return lastReverseCardData.Color == Color;
        }

        if (lastCardData is WildCardData lastWildCardData)
        {
            return lastWildCardData.Color == Color;
        }

        if (lastCardData is WildDrawFourCardData lastWildDrawFourCardData)
        {
            return lastWildDrawFourCardData.Color == Color;
        }

        return false;
    }
}