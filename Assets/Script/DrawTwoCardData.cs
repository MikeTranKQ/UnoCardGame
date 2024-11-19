using UnityEngine;

[CreateAssetMenu(fileName = "CD_", menuName = "Card Data/Draw Two", order = 0)]
public class DrawTwoCardData : CardData
{
    public CardColor Color;
    public override void HandleOnPlay(PlayerCardList nextPlayerCardList, GameCardDeck gameCardDeck)
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
        if (lastCardData is SkipCardData)
        {
            return true;
        }
        if (lastCardData is ReverseCardData)
        {
            return true;
        }
        if (lastCardData is WildCardData)
        {
            return true;
        }
        if (lastCardData is WildDrawFourCardData)
        {
            return true;
        }

        return false;
    }
}