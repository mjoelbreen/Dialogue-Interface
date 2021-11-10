using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueFlow : MonoBehaviour
{
    public Sentence[] dialogueSequence;
    private Sentence currentSentence;
    private Speaker currentSpeaker;
    public GameObject dialogueBox;
    private Button boxButton;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public GameObject dialogueChoices;
    private int currentIndex;
    private float typingSpeed = 0.01f;
    public GameObject nextArrow;







    // Start is called before the first frame update
    void Start()
    {
        boxButton = dialogueBox.GetComponent<Button>();
        currentSentence = dialogueSequence[0];
        currentSpeaker = currentSentence.speaker;
        currentIndex = 1;
        nameText.GetComponent<TextMeshProUGUI>().text = currentSpeaker.speakerName;
        StartCoroutine(Type());
        Debug.Log($"Current Index: {currentIndex}");
        Debug.Log($"CurrentLength: {dialogueSequence.Length}");
    }

    // Update is called once per frame
    void Update()
    {
        currentSentence = dialogueSequence[currentIndex];
        currentSpeaker = currentSentence.speaker;
    }

    IEnumerator Type()
    {
        nextArrow.SetActive(false);
        foreach (char letter in currentSentence.sentence.ToCharArray())
        {
            boxButton.interactable = false;
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        nextArrow.SetActive(true);
        boxButton.interactable = true;
        yield break;

    }

    public void NextSentence()
    {
        Debug.Log("button clicked");
        if (currentIndex < dialogueSequence.Length - 1)
        {
            dialogueText.text = "";

            nameText.GetComponent<TextMeshProUGUI>().text = currentSpeaker.speakerName;
            
            StartCoroutine(Type());
            currentIndex++;

            Debug.Log($"Current Index: {currentIndex}");
            Debug.Log($"CurrentLength: {dialogueSequence.Length}");
        }
        else if (currentIndex == dialogueSequence.Length - 1)
        {
           
            NextSequence();
        }
    }

    public void NextSequence()
    {
        dialogueBox.SetActive(false);
        dialogueChoices.SetActive(true);
        Debug.Log("End of Sequence");
    }
}
