using UnityEngine;

[CreateAssetMenu(fileName = "CD_", menuName = "Card Data/Number", order = 0)]
public class NumberCardData : CardData
{
    public int Number;

    public override bool CanPlay(CardData lastCardData)
    {
        if (lastCardData is NumberCardData lastNumberCardData)
        {
            return lastNumberCardData.Number == Number || lastNumberCardData.Color == Color;
        }

        if (lastCardData is ReverseCardData lastReverseCardData)
        {
            return lastReverseCardData.Color == Color;
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