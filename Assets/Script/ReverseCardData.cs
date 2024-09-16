using UnityEngine;

[CreateAssetMenu(fileName = "CD_", menuName = "Card Data/Reverse", order = 0)]
public class ReverseCardData : CardData
{
    public CardColor Color;
    public override bool canPlay(CardData lastCardData)
    {
        if (lastCardData is NumberCardData lastNumberCardData)
        {
            return lastNumberCardData.Color == Color;
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
    public override void play(CardData lastCardData)
    {
        if (canPlay(lastCardData))
        {
            Debug.Log("play!");
        }
    }
}