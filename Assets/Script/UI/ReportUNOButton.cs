using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ReportUNOButton : MonoBehaviour
{
    [SerializeField] private Button reportButton;
    private List<EasyMode> aiPlayers;

    private void Start()
    {
        aiPlayers = new List<EasyMode>(FindObjectsOfType<EasyMode>());
        reportButton.onClick.AddListener(ReportUNO);
    }

    private void ReportUNO()
    {
        bool someoneCaught = false;

        foreach (var ai in aiPlayers)
        {
            if (ai.GetPlayerCardList().GetCardCount() == 1 && !ai.HasSaidUNO())
            {
                ai.GetCaughtNotSayingUNO();
                someoneCaught = true;
                Debug.Log($"{ai.gameObject.name} has not said UNO, 2 cards added!");
            }
        }

        if (!someoneCaught)
        {
            Debug.Log("No one gets caught for not saying UNO!");
        }
    }
}