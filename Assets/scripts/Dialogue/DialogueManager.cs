using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header ("Ink Story")]
    [SerializeField] private TextAsset inkJson;

    private Story story;

    private int currentChoiceIndex = -1;

    private bool dialogueActive = false;

    private void Awake()
    {
        story = new Story(inkJson.text);
    }

    private void Start()
    {
        GameEventsManager.instance.dialogueEvents.OnEnterDialogue += EnterDialogue;
        GameEventsManager.instance.dialogueEvents.onUpdateChoiceIndex += UpdateChoiceIndex;
    }

    private void OnDisable()
    {
        if (GameEventsManager.instance != null)
            GameEventsManager.instance.dialogueEvents.OnEnterDialogue -= EnterDialogue;
            GameEventsManager.instance.dialogueEvents.onUpdateChoiceIndex -= UpdateChoiceIndex;
    }

    private void UpdateChoiceIndex(int choiceIndex)
    {
        this.currentChoiceIndex = choiceIndex;
        ContinueOrExitStory();
    }

    private void Update()
    {
        if (!dialogueActive)
        {
            return;
        }
        if (story.currentChoices.Count == 0 && Input.GetMouseButtonDown(0))
        {
            ContinueOrExitStory();
        }
    }

    private void EnterDialogue(string knotName)
    {
        if (dialogueActive)
        {
            return;
        }

        dialogueActive = true;

        GameEventsManager.instance.dialogueEvents.DialogueStarted();

        if (!knotName.Equals(""))
        {
            story.ChoosePathString(knotName);
        }
        else
        {
            Debug.LogWarning("Knot name is empty!");
        }

        ContinueOrExitStory();
    }

    private void ContinueOrExitStory()
    {
        if (story.currentChoices.Count > 0 && currentChoiceIndex != -1)
        {
            story.ChooseChoiceIndex(currentChoiceIndex);
            currentChoiceIndex = -1;
        }

        while (story.canContinue)
        {
            string line = story.Continue();

            if (string.IsNullOrWhiteSpace(line))
                continue; // leere Zeilen überspringen

            GameEventsManager.instance.dialogueEvents.DisplayDialogue(line, story.currentChoices);
            return;
        }

        if (story.currentChoices.Count == 0)
            StartCoroutine(ExitDialogue());
    }

    private IEnumerator ExitDialogue()
    {
        yield return null;
        dialogueActive = false;
        GameEventsManager.instance.dialogueEvents.DialogueFinished();
        story.ResetState();
        Debug.Log("Dialogue ended.");
    }
}
