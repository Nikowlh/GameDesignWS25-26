using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header ("Ink Story")]
    [SerializeField] private TextAsset inkJson;

    [SerializeField] private TextMeshProUGUI diaplayNameText;

    [SerializeField] private Image portraitImage;
    [SerializeField] private string portraitsResourcesFolder = "Portraits";

    private Story story;

    private int currentChoiceIndex = -1;

    private bool dialogueActive = false;

    private InkDialogueVariables inkDialogueVariables;

    private const string SPEAKER_TAG = "speaker";

    private const string PORTRAIT_TAG = "portrait";

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
        if (GameEventsManager.instance == null) return;
            
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

            HandleTags(story.currentTags);

            return;   
        }

        if (story.currentChoices.Count == 0)
            StartCoroutine(ExitDialogue());
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogWarning("Ungültiges Tag-Format: " + tag);
                continue;
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    diaplayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    SetPortrait(tagValue);
                    break;
                default:
                    Debug.LogWarning("Unbekanntes Tag: " + tag);
                    break;
            }
        }
    }

    private void SetPortrait(string portraitId)
    {
        if (portraitImage == null) return;
        
        Sprite sprite = Resources.Load<Sprite>($"{portraitsResourcesFolder}/{portraitId}");

        if (sprite == null)
        {
            Debug.LogWarning($"Portrait not found in Resources: {portraitsResourcesFolder}/{portraitId}");
            portraitImage.enabled = false;
            return;
        }
        
        portraitImage.sprite = sprite;
        portraitImage.enabled = true;

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
