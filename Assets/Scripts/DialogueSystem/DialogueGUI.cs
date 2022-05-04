using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueGUI : MonoBehaviour
{
    private TextMesh _paragraph;
    private TextMesh _name;
    private Image _displayedImage;

    public void Start()
    {
        _paragraph = GameObject.Find("Paragraph").GetComponent<TextMesh>();
        _name = GameObject.Find("Name").GetComponent<TextMesh>();
        _displayedImage = GameObject.Find("Image").GetComponent<Image>();

        if (!_displayedImage.sprite) 
            _displayedImage.gameObject.SetActive(false);
    }

    public void StartDialogue()
    {

    }

    public void StopDialogue()
    {
        // Reset Dialogue Object
        gameObject.SetActive(false);
    }
}
