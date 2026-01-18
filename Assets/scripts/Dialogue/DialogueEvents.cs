using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueEvents
{
    public event Action<string> OnEnterDialogue;

    public void EnterDialogue(string knotName)
    {
        if (OnEnterDialogue != null)
        {
            OnEnterDialogue.Invoke(knotName);
        }
    }
    public event Action OnDialogueStarted;

    public void DialogueStarted()
    {
        if (OnDialogueStarted != null)
        {
            OnDialogueStarted();
        }


    }

    public event Action OnDialogueFinished;

    public void DialogueFinished()
    {
        if (OnDialogueFinished != null)
        {
            OnDialogueFinished();
        }
    }
    public event Action<string> OnDisplayDialogue;

    public void DisplayDialogue(string dialogueLine)
    {
        if (OnDisplayDialogue != null)
        {
            OnDisplayDialogue(dialogueLine);
        }
    }
}
