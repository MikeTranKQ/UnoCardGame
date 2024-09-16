using UnityEngine;

public abstract class CardData : ScriptableObject
{
    public Sprite Image;
    public abstract bool canPlay(CardData lastCardData);
    public abstract void play(CardData lastCardData);
    
}