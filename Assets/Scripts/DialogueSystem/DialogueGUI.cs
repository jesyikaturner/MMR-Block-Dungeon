using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueGUI : MonoBehaviour
{
    public TextMeshProUGUI _paragraph;
    private TextMeshProUGUI _name;
    private Image _displayedImage;

    private DialogueManager _dm;

    public void Start()
    {
        _paragraph = GameObject.Find("Paragraph").GetComponent<TextMeshProUGUI>();
        _name = GameObject.Find("Name").GetComponent<TextMeshProUGUI>();
        _displayedImage = GameObject.Find("Image").GetComponent<Image>();
        _dm = GetComponent<DialogueManager>();

        if (!_displayedImage.sprite) 
            _displayedImage.gameObject.SetActive(false);

        //_dm.SetCurrentDisplayedDialogue("shop_welcome");

        //_paragraph.text = _dm.currDialogue.Paragraphs[0].Text;
        //_name.text = _dm.currDialogue.Name;
        //Debug.Log(_dm.GetKeyOfConnectedDialogue(2, 1));
    }

    public void StartDialogue(string key)
    {

    }

    public void StopDialogue()
    {
        // Reset Dialogue Object
        gameObject.SetActive(false);
    }
}
