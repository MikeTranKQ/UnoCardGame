using UnityEngine;

[CreateAssetMenu(fileName = "CD_", menuName = "Card Data/Wild", order = 0)]
public class WildCardData : CardData
{
    public override bool canPlay(CardData lastCardData)
    {
        return true;
    }
}