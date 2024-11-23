using UnityEngine;

[CreateAssetMenu(fileName = "CD_", menuName = "Card Data/Draw Two", order = 0)]
public class DrawTwoCardData : CardData
{
    public override void HandleOnPlayDrawCard(PlayerCardList nextPlayerCardList, GameCardDeck gameCardDeck)
    {
        gameCardDeck.MoveCard(0, nextPlayerCardList);
        gameCardDeck.MoveCard(0, nextPlayerCardList);
    }
    public override bool canPlay(CardData lastCardData)
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
        return false;
    }
}