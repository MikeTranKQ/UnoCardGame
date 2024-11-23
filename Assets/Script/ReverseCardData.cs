using UnityEngine;

[CreateAssetMenu(fileName = "CD_", menuName = "Card Data/Reverse", order = 0)]
public class ReverseCardData : CardData
{

    public override void HandleOnPlayControlTurn(PlayerCardList nextPlayerCardList, GamePresenter gamePresenter)
    {
        gamePresenter.ReverseNextPlayer();
    }
    
    public override bool canPlay(CardData lastCardData)
    {
        if (lastCardData is NumberCardData lastNumberCardData)
        {
            return lastNumberCardData.Color == Color;
        }
        if (lastCardData is ReverseCardData)
        {
            return true;
        }
        if (lastCardData is SkipCardData lastSkipCardData)
        {
            return lastSkipCardData.Color == Color;
        }
        if (lastCardData is DrawTwoCardData lastDrawTwoCardData)
        {
            return lastDrawTwoCardData.Color == Color;
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