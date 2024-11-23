using UnityEngine;
using UnityEngine.UI;

public class ChangeColorsUI : MonoBehaviour
{
    [SerializeField] private Button[] _colorOptionsButtonsList;
    [SerializeField] private GameObject _changeColorsCanvas;
    [SerializeField] private GamePlayedCardDeck _gamePlayedCardDeck;
    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            int index = i;
            _colorOptionsButtonsList[i].onClick.AddListener(
                () =>
                {
                    CardColor selectedColor = (CardColor)index;
                    _gamePlayedCardDeck.GetLastCardData().Color = selectedColor;
                    _changeColorsCanvas.gameObject.SetActive(false);
                }
            );    
        }
    }
}
                  