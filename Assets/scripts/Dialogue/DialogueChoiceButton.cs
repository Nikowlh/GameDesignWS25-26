using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class DialogueChoiceButton : MonoBehaviour
{
    [Header("Components")]

    [SerializeField] private Button button;

    [SerializeField] private TextMeshProUGUI choiceText;    

    public int choiceIndex = -1;

    public void SetChoiceText(string ChoiseTextString)
    {
        choiceText.text = ChoiseTextString;
    }

    public void SetChoiseIndex(int choiceIndex)
    {
        this.choiceIndex = choiceIndex;
    }

    public void SelectButton()
    {
        button.Select();
    }

    public void OnClick()
    {
        if (choiceIndex == -1)
        {
            Debug.LogError("Ungültiger Choice Index: " + choiceIndex);
            return;
        }
        GameEventsManager.instance.dialogueEvents.UpdateChoiceIndex(choiceIndex);

        if (GameEventsManager.instance == null)
        {
            Debug.LogError("GameEventsManager.instance is NULL");
            return;
        }
    }
}
