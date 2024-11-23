using UnityEngine;
using UnityEngine.UI;

public class ChangeColorsUI : MonoBehaviour
{
    [SerializeField] private Button[] _colorOptionsButtonsList;

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            int index = i;
            _colorOptionsButtonsList[i].onClick.AddListener(
                () =>
                {
                    if (index == 0)
                    {
                        Debug.Log("Red");
                    }

                    if (index == 1)
                    {
                        Debug.Log("Green");
                    }

                    if (index == 2)
                    {
                        Debug.Log("Blue");
                    }

                    if (index == 3)
                    {
                        Debug.Log("Yellow");
                    }
                }
            );    
        }
    }
}
                  