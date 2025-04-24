using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private Canvas _menuCanvas;
    [SerializeField] private Canvas _numberOfPlayerCanvas;
    
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnPlayButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        _menuCanvas.gameObject.SetActive(false);
        _numberOfPlayerCanvas.gameObject.SetActive(true);
    }
}