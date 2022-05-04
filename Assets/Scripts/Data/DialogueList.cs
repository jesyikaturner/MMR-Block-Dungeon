using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueList
{

    private Dictionary<string, Dialogue> _dialogueList;

    public DialogueList(TextAsset json)
    {
        _dialogueList = new Dictionary<string, Dialogue>();
        JSONConversations conversations = JsonUtility.FromJson<JSONConversations>(json.text);

        List<Dialogue.Choice> choiceList = new();
        List<Dialogue.Paragraph> paragraphList = new();

        foreach(JSONDialogue dialogue in conversations.conversations)
        {
            foreach(JSONParagraph paragraph in dialogue.paragraphs)
            {
                foreach (JSONChoice choice in paragraph.choices)
                {
                    choiceList.Add(new Dialogue.Choice(choice.id, choice.text, choice.nextKey));
                }
                paragraphList.Add(new Dialogue.Paragraph(paragraph.id, paragraph.text, choiceList.ToArray()));
                choiceList.Clear();
            }
            _dialogueList.Add(dialogue.key, new Dialogue(dialogue.key, dialogue.name, paragraphList.ToArray()));
            paragraphList.Clear();
        }
    }

    public Dialogue GetDialogueByKey(string key)
    {
        foreach (KeyValuePair<string, Dialogue> d in _dialogueList)
        {
            if (d.Value.Key == key)
                return _dialogueList[d.Key];
        }
        return null;
    }

    [Serializable]
    public class JSONConversations
    {
        public JSONDialogue[] conversations;
    }

    [Serializable]
    public class JSONDialogue
    {
        public string key;
        public string name;
        public JSONParagraph[] paragraphs;
    }

    [Serializable]
    public class JSONParagraph
    {
        public int id;
        public string text;
        public JSONChoice[] choices;
    }

    [Serializable]
    public class JSONChoice
    {
        public int id;
        public string text;
        public string nextKey;
    }
}

public class Dialogue
{

    public string Key { get; private set; }
    public string Name { get; private set; }
    public Paragraph[] Paragraphs { get; private set; }
    public int CurrentParagraphID { get; private set; }

    public Dialogue(string key, string name, Paragraph[] paragraphs)
    {
        Key = key;
        Name = name;
        Paragraphs = paragraphs;
        CurrentParagraphID = 0;
    }

    public bool GoToNextParagraph()
    {
        if (CurrentParagraphID > Paragraphs.Length)
            return false;

        CurrentParagraphID++;
        return true;
    }

    public void ResetCurrentParagraph()
    {
        CurrentParagraphID = 0;
    }

    public string Print()
    {
        string paragraphPrintString = "";
        foreach(Paragraph paragraph in Paragraphs)
        {
            paragraphPrintString += string.Format("\t{0}\n", paragraph.Print());
        }
        return string.Format("Key: {0}, Name: {1}, Current Paragraph ID: {2}, Paragraphs:\n{3}", Key, Name, CurrentParagraphID, paragraphPrintString);
    }

    public class Paragraph
    {
        public int ID { get; private set; }
        public string Text { get; private set; }
        public Choice[] Choices { get; private set; }

        public Paragraph(int id, string text, Choice[] choices)
        {
            ID = id;
            Text = text;
            Choices = choices;
        }

        public string Print()
        {
            string choicePrintString = "";
            foreach (Choice choice in Choices)
            {
                choicePrintString += string.Format("\t\t{0}\n", choice.Print());
            }

            return string.Format("ID: {0}, Text: {1}, Choices:\n{2}", ID, Text, choicePrintString);
        }
    }

    public class Choice
    {
        public int ID { get; private set; }
        public string Text { get; private set; }
        public string NextKey { get; private set; }

        public Choice(int id, string text, string nextKey)
        {
            ID = id;
            Text = text;
            NextKey = nextKey;
        }

        public string Print()
        {
            return string.Format("ID: {0}, Text: {1}, NextKey: {2}.", ID, Text, NextKey);
        }
    }
}
