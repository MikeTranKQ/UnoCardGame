using System;

public enum CardColor
{
    Red,
    Green,
    Blue,
    Yellow,
    None
}

public enum CardValue
{
    Zero,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Skip,
    Reverse,
    DrawTwo,
    Wild,
    WildDrawFour
}

public class Card
{
    public CardColor Color { get; private set; }
    public CardValue Value { get; private set; }

    public Card(CardColor color, CardValue value)
    {
        Color = color;
        Value = value;
    }
}