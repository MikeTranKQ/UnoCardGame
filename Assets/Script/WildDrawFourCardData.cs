using UnityEngine;

[CreateAssetMenu(fileName = "CD_", menuName = "Card Data/Wild Draw Four", order = 0)]
public class WildDrawFourCardData : CardData
{
    public override void HandleOnPlayDrawCard(PlayerCardList nextPlayerCardList, GameCardDeck gameCardDeck)
    {
        gameCardDeck.MoveCard(0, nextPlayerCardList);
        gameCardDeck.MoveCard(0, nextPlayerCardList);
        gameCardDeck.MoveCard(0, nextPlayerCardList);
        gameCardDeck.MoveCard(0, nextPlayerCardList);
    }
    
    public override bool canPlay(CardData lastCardData)
    {
        return true;
    }
}