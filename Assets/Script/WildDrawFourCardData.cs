using UnityEngine;

[CreateAssetMenu(fileName = "CD_", menuName = "Card Data/Wild Draw Four", order = 0)]
public class WildDrawFourCardData : CardData
{
    public override bool canPlay(CardData lastCardData)
    {
        return true;
    }
    public override void play(CardData lastCardData)
    {
        if (canPlay(lastCardData))
        {
            Debug.Log("play!");
        }
    }
}