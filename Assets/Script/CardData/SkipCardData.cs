using UnityEngine;

[CreateAssetMenu(fileName = "CD_", menuName = "Card Data/Skip", order = 0)]
public class SkipCardData : CardData
{
    public override void HandleOnPlayControlTurn(PlayerCardList nextPlayerCardList, GamePresenter gamePresenter)
    {
        gamePresenter.NextPlayer();
    }

    public override bool CanPlay(CardData lastCardData)
    {
        if (lastCardData is NumberCardData lastNumberCardData)
        {
            return lastNumberCardData.Color == Color;
        }

        if (lastCardData is SkipCardData)
        {
            return true;
        }

        if (lastCardData is DrawTwoCardData lastDrawTwoCardData)
        {
            return lastDrawTwoCardData.Color == Color;
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