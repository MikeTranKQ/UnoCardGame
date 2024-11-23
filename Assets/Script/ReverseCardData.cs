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
        if (lastCardData is SkipCardData)
        {
            return true;
        }
        if (lastCardData is DrawTwoCardData)
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