using UnityEngine;

[CreateAssetMenu(fileName = "CD_", menuName = "Card Data/Skip", order = 0)]
public class SkipCardData : CardData
{
    public CardColor Color;

    public override bool canPlay(CardData lastCardData)
    {
        if (lastCardData is NumberCardData lastNumberCardData)
        {
            return lastNumberCardData.Color == Color;
        }
        if (lastCardData is SkipCardData lastSkipCardData)
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