using System;
using System.IO;
using NUnit.Framework;
using UnityEngine;

public class TestDialogueList
{

    private DialogueList _list;

    [SetUp]
    public void TestDialogueListSetup()
    {
        // TODO: Create a test dialogue dictionary
        string dialoguePath = File.ReadAllText(Application.dataPath + "/Scripts/Data/DialogueDictionary.json");
        TextAsset dialogueJSON = new TextAsset(dialoguePath);
        _list = new DialogueList(dialogueJSON);
    }
}
