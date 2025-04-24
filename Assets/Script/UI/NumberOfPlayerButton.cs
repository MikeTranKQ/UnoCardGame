using UnityEngine;
using UnityEngine.UI;

public class NumberOfPlayerButton : MonoBehaviour
{
    [SerializeField] private Canvas _numberOfPlayerCanvas;
    [SerializeField] private Canvas _gameModeCanvas;
    [SerializeField] private int numberOfPlayers;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnPlayButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        _numberOfPlayerCanvas.gameObject.SetActive(false);
        _gameModeCanvas.gameObject.SetActive(true);

        Debug.Log("Number of players selected: " + numberOfPlayers);
    }
}