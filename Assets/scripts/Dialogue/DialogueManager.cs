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

    private InkDialogueVariables inkDialogueVariables;

    private void Awake()
    {
        story = new Story(inkJson.text);
        inkDialogueVariables = new InkDialogueVariables(story);
    }

    private void Start()
    {
        GameEventsManager.instance.dialogueEvents.onEnterDialogue += EnterDialogue;
        GameEventsManager.instance.dialogueEvents.onUpdateChoiceIndex += UpdateChoiceIndex;
        GameEventsManager.instance.dialogueEvents.onUpdateInkDialogueVariable += UpdateInkDialogueVariable;
        GameEventsManager.instance.gameState.OnStateChanged += OnGameStateChanged;
    }

    private void OnDisable()
    {
        if (GameEventsManager.instance != null) return;
            
        GameEventsManager.instance.dialogueEvents.onEnterDialogue -= EnterDialogue;
        GameEventsManager.instance.dialogueEvents.onUpdateChoiceIndex -= UpdateChoiceIndex;
        GameEventsManager.instance.dialogueEvents.onUpdateInkDialogueVariable -= UpdateInkDialogueVariable;
        GameEventsManager.instance.gameState.OnStateChanged -= OnGameStateChanged;


    }
    private void OnGameStateChanged(string key, string value)
    {
        inkDialogueVariables.UpdateVariableState(
            key,
            new Ink.Runtime.StringValue(value)
        );
    }

    private void UpdateInkDialogueVariable(string name, Ink.Runtime.Object value)
    {
        inkDialogueVariables.UpdateVariableState(name, value);
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
        Debug.Log("EnterDialogue knotName = '" + knotName + "'");

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

        inkDialogueVariables.SyncVariablesAndStartListening(story);

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
        inkDialogueVariables.StopListening(story);
        story.ResetState();
        Debug.Log("Dialogue ended.");
    }
}
