using UnityEngine;

public class PlayableColorDisplay : MonoBehaviour
{
    [SerializeField] private GameObject redColorObject;
    [SerializeField] private GameObject greenColorObject;
    [SerializeField] private GameObject blueColorObject;
    [SerializeField] private GameObject yellowColorObject;

    public void Update()
    {
        if (GamePlayedCardDeck.Instance == null)
        {
            return;
        }

        CardData lastCard = GamePlayedCardDeck.Instance.GetLastCardData();
        if (lastCard == null)
        {
            return;
        }

        UpdateColorDisplay(lastCard.Color);
    }

    private void UpdateColorDisplay(CardColor cardColor)
    {
        redColorObject.SetActive(false);
        greenColorObject.SetActive(false);
        blueColorObject.SetActive(false);
        yellowColorObject.SetActive(false);
        
        switch (cardColor)
        {
            case CardColor.Red:
                redColorObject.SetActive(true);
                break;
            case CardColor.Green:
                greenColorObject.SetActive(true);
                break;
            case CardColor.Blue:
                blueColorObject.SetActive(true);
                break;
            case CardColor.Yellow:
                yellowColorObject.SetActive(true);
                break;
        }
    }
}