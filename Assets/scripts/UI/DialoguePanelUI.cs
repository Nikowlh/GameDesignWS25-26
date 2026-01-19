using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;


public class DialoguePanelUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject contentParent;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private DialogueChoiceButton[] choiceButtons;

    private void Awake()
    {
        contentParent.SetActive(false);
        ResetPanel();
    }

    private void Start()
    {
        GameEventsManager.instance.dialogueEvents.OnDialogueStarted += DialogueStarted;
        GameEventsManager.instance.dialogueEvents.OnDialogueFinished += DialogueFinished;
        GameEventsManager.instance.dialogueEvents.OnDisplayDialogue += DisplayDialogue;
    }

    private void OnDisable()
    {
            GameEventsManager.instance.dialogueEvents.OnDialogueStarted -= DialogueStarted;
            GameEventsManager.instance.dialogueEvents.OnDialogueFinished -= DialogueFinished;
            GameEventsManager.instance.dialogueEvents.OnDisplayDialogue -= DisplayDialogue;
    }

    private void DialogueStarted()
    {
        contentParent.SetActive(true);
    }

    private void DialogueFinished()
    {
        contentParent.SetActive(false);
        ResetPanel();
    }

    private void DisplayDialogue(string dialogueLine, List<Choice> dialogueChoices)
    {
        dialogueText.text = dialogueLine;

        if (dialogueChoices.Count > choiceButtons.Length)
        {
            Debug.LogError("Mehr Dialogue Choices("
                + dialogueChoices.Count + ") als vorhandene Buttons("
                + choiceButtons.Length + ").");
        }

        foreach (DialogueChoiceButton ChoiceButton in choiceButtons)
        {
            ChoiceButton.gameObject.SetActive(false);
        }

        int ChoiceButtonIndex = dialogueChoices.Count - 1;
        for (int inkChoiceIndex = 0; inkChoiceIndex < dialogueChoices.Count; inkChoiceIndex++)
        {
            Choice dialougueChoice = dialogueChoices[inkChoiceIndex];
            DialogueChoiceButton ChoiceButton = choiceButtons[ChoiceButtonIndex];
            ChoiceButton.gameObject.SetActive(true);
            ChoiceButton.SetChoiceText(dialougueChoice.text);
            ChoiceButton.SetChoiseIndex(inkChoiceIndex);

            if (inkChoiceIndex == 0)
            {
                ChoiceButton.SelectButton();
                GameEventsManager.instance.dialogueEvents.UpdateChoiceIndex(0);
            }

            ChoiceButtonIndex--;
        }

    }

    private void ResetPanel()
    {
        dialogueText.text = "";
    }
}
