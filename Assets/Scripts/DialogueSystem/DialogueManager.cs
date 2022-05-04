using System;
using UnityEngine;

public class DialogueManager: MonoBehaviour
{

    private DialogueList _dialogueList;
    public TextAsset dialogueJson;

    public void Start()
    {
        _dialogueList = new DialogueList(dialogueJson);
    }

    public string GetNextKey(int currentPage, int choiceID)
    {
        return "";
    }

    public Dialogue GetNextDialogue(string key)
    {
        return null;
    }
}
