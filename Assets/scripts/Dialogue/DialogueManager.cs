using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header ("Ink Story")]
    [SerializeField] private TextAsset inkJson;

    private Story story;

    private bool dialogueActive = false;

    private void Awake()
    {
        story = new Story(inkJson.text);
    }

    private void Start()
    {
        GameEventsManager.instance.dialogueEvents.OnEnterDialogue += EnterDialogue;
    }

    private void OnDisable()
    {
        if (GameEventsManager.instance != null)
            GameEventsManager.instance.dialogueEvents.OnEnterDialogue -= EnterDialogue;
    }

    private void Update()
    {
        if (!dialogueActive)
        {
            return;
        }
        if (Input .GetMouseButtonDown(0))
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
        if (story.canContinue)
        {
            string dialogueLine = story.Continue();
            GameEventsManager.instance.dialogueEvents.DisplayDialogue(dialogueLine);
        }
        else
        {
            StartCoroutine(ExitDialogue());
        }
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
