using UnityEngine;
using UnityEngine.UI;

public class GameModeCanvas : MonoBehaviour
{
    [SerializeField] private Canvas _gameModeCanvas;
    [SerializeField] private Canvas _gameCanvas;
    
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnPlayButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        _gameModeCanvas.gameObject.SetActive(false);
        _gameCanvas.gameObject.SetActive(true);
    }
}