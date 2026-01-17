using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialoguePanelUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject contentParent;
    [SerializeField] private TextMeshProUGUI dialogueText;

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

    private void DisplayDialogue(string dialogueLine)
    {
        dialogueText.text = dialogueLine;

    }

    private void ResetPanel()
    {
        dialogueText.text = "";
    }
}
