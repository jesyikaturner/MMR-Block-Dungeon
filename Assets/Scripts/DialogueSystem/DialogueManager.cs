using System;
using UnityEngine;

public class DialogueManager: MonoBehaviour
{

    private DialogueList _dialogueList;
    public TextAsset dialogueJson;

    public Dialogue currDialogue;
    public int currentParagraph;

    public void Start()
    {
        _dialogueList = new DialogueList(dialogueJson);
        currDialogue = null;
    }
    /// <summary>
    /// This method gets the nextKey value of the choice object which links to the next dialogue object
    /// if the user were to click on that dialogue option.
    /// </summary>
    /// <param name="currentPage"></param>
    /// <param name="choiceID"></param>
    /// <returns>Returns the key of the connected dialogue object.</returns>
    public string GetKeyOfConnectedDialogue(int currentPage, int choiceID)
    {
        return currDialogue.Paragraphs[currentPage].Choices[choiceID].NextKey;
    }

    public bool SetCurrentDisplayedDialogue(string key)
    {
        currDialogue = _dialogueList.GetDialogueByKey(key);
        return currDialogue != null;
    }

    //public Dialogue GetNextDialogue(string key)
    //{
    //    return _dialogueList.GetDialogueByKey(key);
    //}
}
